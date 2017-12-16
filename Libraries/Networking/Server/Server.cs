using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Com.OfficerFlake.Libraries.Networking.Packets;
using static Com.OfficerFlake.Libraries.Networking.Connection;

namespace Com.OfficerFlake.Libraries.Networking
{
    public static class Server
    {
		#region Start/Stop
		public static bool Start()
	    {
		    //UDPReciever = new UdpClient(UDPEndPoint);
		    try
		    {
			    UDPStartRecieve();
			    _listener.Start();
			    TCPBeginAccept();
			    return true;
			}
		    catch
		    {
			    ShutDown();
			    return false;
		    }
	    }

	    private static bool ShuttingDown = false;
	    public static bool ShutDown()
	    {
		    if (ShuttingDown) return false;
		    try
		    {
			    UDPReciever.Close();
			    _listener.Stop();
			    ShuttingDown = true;
			}
		    catch
		    {
				//???
		    }
		    return ShuttingDown;
	    }
		#endregion

		#region UDP Input
		private static IPEndPoint UDPEndPoint = new IPEndPoint(IPAddress.Any, 7916);
		private static UdpClient UDPReciever = new UdpClient(UDPEndPoint);

	    private static bool UDPStartRecieve()
	    {
		    try
		    {
			    UDPReciever.BeginReceive(UDPEndRecieve, null);
			    return true;
		    }
		    catch
		    {
			    return false;
		    }
	    }
	    private static void UDPEndRecieve(IAsyncResult res)
	    {
		    if (!ShuttingDown)
		    {
				//TODO : Graceful Close...
			    byte[] received = UDPReciever.EndReceive(res, ref UDPEndPoint);

			    if (received.Length >= 12)
			    {
				    int ConnectionID = BitConverter.ToInt32(received, 0);
					int Type = BitConverter.ToInt32(received, 8);
					GenericPacket thisPacket = new GenericPacket(Type, received.Skip(12).ToArray());

				    foreach (Connection thisConnection in AllConnections.Where(x => x.ConnectionNumber == ConnectionID))
				    {
					    thisConnection.GivePacket(thisPacket);
				    }
			    }

			    UDPStartRecieve();
			}
	    }
		#endregion
		#region TCP/IP
		private static TcpListener _listener = new TcpListener(IPAddress.Any, 7915);
	    private static void TCPBeginAccept()
	    {
		    _listener.BeginAcceptSocket(TCPEndAccept, _listener);
	    }
	    private static void TCPEndAccept(IAsyncResult ar)
	    {
		    TcpListener listener = (TcpListener)ar.AsyncState;

			try
		    {
			    Socket newSocket = listener.EndAcceptSocket(ar);
			    Connection newConnection = new Connection();
			    newConnection.SetTCPSocket(newSocket);
			    TCPBeginAccept();
			}
		    catch (ObjectDisposedException)
		    {
			    return;
		    }


	    }
		#endregion

		//List<Connection> Clients

		//Callback for TCPListener to Method to get a new Connection
		//Callback for UDPListener to get a new packet and assign to correct connection.

		//PacketProcess in Seperate Class.
	}
}
