using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.Networking
{
    public class OpenYSServer : IServer
    {
		#region Start/Stop
		public bool Start(bool isProxyMode = false)
		{
			_TCPPort = SettingsLibrary.Settings.Server.ListeningPorts.TCP;
			_UDPPort = SettingsLibrary.Settings.Server.ListeningPorts.UDP;
			IsProxyMode = isProxyMode;
			TCPListener = new TcpListener(IPAddress.Any, (Int32)_TCPPort);
			UDPEndPoint = new IPEndPoint(IPAddress.Any, (Int32)_UDPPort);

			try
		    {
				TCPListener.Start();
			    UDPReciever = new UdpClient(UDPEndPoint);

				Task.Run(() => TCPAcceptNewConnection());
			    Task.Run(() => UDPRecieve());
				return true;
			}
		    catch
		    {
			    Stop();
			    return false;
		    }
	    }
	    public bool Stop()
	    {
		    if (IsShuttingDown) return false;
		    try
		    {
			    UDPReciever.Close();
			    TCPListener.Stop();
			    IsShuttingDown = true;
		    }
		    catch
		    {
			    //???
		    }
		    return IsShuttingDown;
	    }

	    private IDateTime _StartTime { get; set; } = DateTime.Now.ToDateTime();

	    public ITimeSpan UpTime
	    {
		    get => (DateTime.Now - _StartTime.ToSystemDateTime()).ToTimeSpan();
	    }

	    public bool IsShuttingDown { get; private set; }
		public bool IsProxyMode { get; private set; }
		#endregion

	    #region TCP/IP
	    private uint _TCPPort = 7915;
	    private static TcpListener TCPListener = new TcpListener(IPAddress.Any, 7915);

	    private bool TCPAcceptNewConnection()
	    {
	        if (IsShuttingDown)
	        {
	            Debug.AddDetailMessage("TCPAcceptNewConnection cancelled as IsShuttingDown");
                return false;
	        }

	        Socket newSocket;
            try
		    {
		        Debug.AddDetailMessage("Waiting for a new client to connect...");
                newSocket = TCPListener.AcceptSocket();
		        Debug.AddDetailMessage("A new client just connected! Ready to start the connection phase.");
            }
		    catch (SocketException e)
		    {
		        Debug.AddErrorMessage(e, "SocketException in TCPAcceptNewConnection");
                return false;
		    }
		    catch (InvalidOperationException e)
		    {
		        Debug.AddErrorMessage(e, "InvalidOperationException in TCPAcceptNewConnection");
                return false;
		    }

	        Debug.AddDetailMessage("New client is being created.");
	        IConnection newConnection = ObjectFactory.CreateConnection();
	        Debug.AddDetailMessage("New client has been created.");

	        Debug.AddDetailMessage("New client is starting an async call to connect.");
            _ = Task.Run(() => newConnection.Connect(newSocket, IsProxyMode));
	        Debug.AddDetailMessage("New client has started it's async call to connect.");

            try
	        {
	            Task.Run(() => TCPAcceptNewConnection());
	        }
	        catch (ArgumentNullException e)
	        {
	            Debug.AddErrorMessage(e, "ArgumentNullException in TCPAcceptNewConnection when trying to restart the task.");
	            return false;
            }
	        return true;
	    }
	    #endregion
		#region UDP
		private uint _UDPPort = 7916;
		private IPEndPoint UDPEndPoint = new IPEndPoint(IPAddress.Any, 7916);
		private UdpClient UDPReciever { get; set; }

	    private void UDPRecieve()
	    {
		    if (!IsShuttingDown)
		    {
				#region Recieve
				byte[] received;
				try
			    {
				    received = UDPReciever.Receive(ref UDPEndPoint);
			    }
			    catch (ObjectDisposedException)
			    {
					//Socket Closed.
				    return;
			    }
			    catch (SocketException)
			    {
					//Error.
				    return;
			    }
			    if (received == null) return;
				#endregion
				#region Send To Connection
				if (received.Length >= 12)
			    {
				    int connectionID = BitConverter.ToInt32(received, 0);
					uint type = BitConverter.ToUInt32(received, 8);
				    IPacket thisPacket = ObjectFactory.CreateGenericPacket();
				    thisPacket.Type = type;
					thisPacket.Data = received.Skip(12).ToArray();

				    foreach (IConnection thisConnection in Connections.AllConnections.Where(x => x.ConnectionNumber == connectionID))
				    {
					    thisConnection.GivePacket(thisPacket);
				    }
			    }
				#endregion
				Task.Run(() => UDPRecieve());
			}
	    }
		#endregion
	}

	public static class Server
	{
		private static readonly IServer server = new OpenYSServer();

		public static bool Start(bool IsProxyMode = false) => server.Start(IsProxyMode);
		public static bool Stop() => server.Stop();
		public static bool IsShuttingDown => server.IsShuttingDown;
		public static ITimeSpan UpTime => server.UpTime;
	}
}
