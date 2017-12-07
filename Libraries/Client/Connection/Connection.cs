using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Com.OfficerFlake.Libraries.Networking.Packets;

using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.Networking
{
    public class Connection
    {
		#region Properties
	    public string Username = "<NULL>";
	    public Int32 Version = -1;

		#region ConnectionType
		public enum ConnectionType
	    {
		    YSFlightClient,
			OpenYSClient
	    }
	    private ConnectionType _connectionType = ConnectionType.YSFlightClient;
	    public void SetConnectionType(ConnectionType ConectionType)
	    {
		    _connectionType = ConectionType;
	    }
		#endregion
		#region LoginStatus
	    public enum LoginStatus
	    {
			Disconnected,
		    LoggingIn,
			LoggedIn,
	    }
		private LoginStatus _loginState = LoginStatus.Disconnected;
	    public void SetLoggingIn() => _loginState = LoginStatus.LoggingIn;
	    public void SetLoggedIn() => _loginState = LoginStatus.LoggedIn;
	    public bool IsLoggingIn => _loginState == LoginStatus.LoggingIn;
	    public bool IsLoggedIn => _loginState == LoginStatus.LoggedIn;
		#endregion
		#region FlightStatus
	    public enum FlightStatus
	    {
		    Idle,
			Flying
	    }
	    private FlightStatus _flightStatus = FlightStatus.Idle;
		public bool IsFlying => _flightStatus == FlightStatus.Flying;
	    public void SetIsFlightIdle() => _flightStatus = FlightStatus.Idle;
	    public void SetIsFlying() => _flightStatus = FlightStatus.Flying;
		#endregion
		#endregion
		#region ConnectionNumber
		private static int ConnectionIDIncrementer = 0;
	    public int ConnectionNumber
	    {
		    get;
	    }
		#endregion
		#region UDP
		private bool _isUDPEnabled = false;
	    public bool IsUDPCapable => _isUDPEnabled;
		public void SetUDPEnabled() => _isUDPEnabled = true;
		#endregion

		#region PacketProcessor
		public delegate void DelegatePacketProcessor(Connection thisConnection, GenericPacket thisPacket);
	    private static void DummyPacketProcessor(Connection thisConnection, GenericPacket thisPacket)
	    {
		    throw new NotImplementedException();
	    }
	    #endregion

	    public static DelegatePacketProcessor PacketProcessor
	    {
		    get;
		    private set;
	    }
	    public static bool SetPacketProcessor(DelegatePacketProcessor thisPacketProcessor)
	    {
		    PacketProcessor = thisPacketProcessor;
		    return true;
	    }

		#region Connections List
		private static List<Connection> _connections = new List<Connection>();
	    public static List<Connection> GetConnections => _connections;
		#endregion

		public Connection()
	    {
		    ConnectionNumber = ConnectionIDIncrementer++;
			_connections.Add(this);
		}
	    ~Connection()
	    {
		    _connections.RemoveAll(x => x == this);
	    }

		#region Sockets
		#region TCP/IP
		private static Socket BlankTCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	    private Socket TCPSocket = BlankTCPSocket;
	    public bool SetTCPSocket(Socket incomingSocket)
	    {
		    if (TCPSocket == BlankTCPSocket)
		    {
			    TCPSocket = incomingSocket;
				TCPStartToRecieveNewPacket();
			    return true;
		    }
		    return false;
	    }
		
		#region Reciever
		private class TCPSocketReadObject
	    {
		    // Size
		    public byte[] sizebuffer = new byte[4];
		    public int size = 0;

		    // Data
		    public byte[] databuffer = null;

		    // Operating...
		    public int bytesreceivedsofar = 0;
	    }
	    private void TCPStartToRecieveNewPacket()
	    {
		    TCPReceiveHeader();
	    }
		private void TCPReceiveHeader()
		{
			lock (TCPSocket)
			{
				try
				{
					//Debug.WriteLine("Test Async");
					// Create the state object.
					TCPSocketReadObject state = new TCPSocketReadObject();

					// Begin receiving the data from the remote device.
					//Debug.WriteLine("Start Receiving");
					TCPSocket.BeginReceive(state.sizebuffer, 0, 4, 0,
						new AsyncCallback(TCPReceiveHeaderCallback), state);
				}
				catch (SocketException)
				{
					//Client.Disconnect("Remote client forcibly closed the connection.");
					return;
				}
				catch (Exception)
				{
					//Debug.WriteLine(e.ToString());
					//Client.Disconnect("Failed to receive packet header.");
					return;
				}
			}
		}
		private void TCPReceiveHeaderCallback(IAsyncResult ar)
		{
			lock (TCPSocket)
			{
				try
				{
					// Retrieve the state object and the client socket 
					// from the asynchronous state object.
					TCPSocketReadObject state = (TCPSocketReadObject)ar.AsyncState;
					// Read data from the remote device.
					int bytesRead = TCPSocket.EndReceive(ar);
					if (bytesRead == 0)
					{
						//End Of Stream
						//Debug.WriteLine("End of DataStrem");
						//Client.Disconnect("Recv'd 0 data when trying to receive packet header.");
					}
					state.bytesreceivedsofar += bytesRead;
					if (state.bytesreceivedsofar < 4)
					{
						// need more data, so store the data received so far.
						//state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
						//  Get the rest of the data.
						//client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
						//new AsyncCallback(ReceiveHeaderCallback), state);
						TCPSocket.BeginReceive(state.sizebuffer, state.bytesreceivedsofar, 4 - state.bytesreceivedsofar, SocketFlags.None,
						new AsyncCallback(TCPReceiveHeaderCallback), state);
						return;
					}
					else
					{
						// All bytes have been received.
						TCPReceivePayload(state);
					}
				}
				catch (SocketException)
				{
					//Client.Disconnect("Remote client forcibly closed the connection.");
					return;
				}
				catch (Exception)
				{
					//Debug.WriteLine(e.ToString());
					//Client.Disconnect("Generic Error when trying to receive packet header.");
					return;
				}
			}
		}
		private void TCPReceivePayload(TCPSocketReadObject state)
		{
			lock (TCPSocket)
			{
				try
				{
					// Get Size...
					state.size = (int)(BitConverter.ToUInt32(state.sizebuffer, 0));
					state.bytesreceivedsofar = 0;
					state.databuffer = new byte[state.size];

					// Begin receiving the data from the remote device.
					TCPSocket.BeginReceive(state.databuffer, state.bytesreceivedsofar, state.size - state.bytesreceivedsofar, SocketFlags.None,
						new AsyncCallback(TCPReceivePayloadCallback), state);
				}
				catch (SocketException)
				{
					//Client.Disconnect("Remote client forcibly closed the connection.");
					return;
				}
				catch (Exception)
				{
					//Debug.WriteLine(e.ToString());
					//Client.Disconnect("Failed to receive packet body.");
					return;
				}
			}
		}
		private void TCPReceivePayloadCallback(IAsyncResult ar)
		{
			GenericPacket NewPacket = null;
			lock (TCPSocket)
			{
				try
				{
					// Retrieve the state object and the client socket 
					// from the asynchronous state object.
					TCPSocketReadObject state = (TCPSocketReadObject)ar.AsyncState;
					// Read data from the remote device.
					int bytesRead = TCPSocket.EndReceive(ar);
					if (bytesRead == 0)
					{
						//End Of Stream
						//Debug.WriteLine("End of DataStream");
						//Client.Disconnect("Recv'd 0 data when trying to receive packet body.");
					}
					state.bytesreceivedsofar += bytesRead;
					if (state.bytesreceivedsofar < state.size)
					{
						TCPSocket.BeginReceive(state.databuffer, state.bytesreceivedsofar, state.size - state.bytesreceivedsofar, SocketFlags.None,
							new AsyncCallback(TCPReceivePayloadCallback), state);
						return;
					}
					else
					{
						//Debug.WriteLine(state.sizebuffer.ToDebugHexString() + state.databuffer.ToDebugHexString());
						//Debug.TestPoint();

						// All bytes have been received.
						if (state.databuffer.Length > 4)
						{
							byte[] typedata = new byte[4];
							Array.Copy(state.databuffer, 0, typedata, 0, 4);
							int type = BitConverter.ToInt32(typedata, 0);

							byte[] data = new byte[state.databuffer.Length - 4];
							Array.Copy(state.databuffer, 4, data, 0, state.databuffer.Length - 4);

							NewPacket = new GenericPacket(type, data);

							if (NewPacket == null)
							{
								Disconnect();
								return;
							}
							ProcessPacket(NewPacket);
							TCPStartToRecieveNewPacket();
						}
						//Debug.WriteLine("End Receiving");
					}
				}
				catch (SocketException)
				{
					//Client.Disconnect("Remote client forcibly closed the connection.");
					return;
				}
				catch (Exception)
				{
					//Console.WriteLine(e.ToString());
					//Client.Disconnect("Generic Error when trying to receive packet body.");
					return;
				}
			}
		}
		#endregion
		#endregion
		#endregion

		#region Packet Processing
	    public void GivePacket(GenericPacket thisPacket) => GivePacketToConnection(this, thisPacket);
	    private static void GivePacketToConnection(Connection thisConncetion, GenericPacket thisPacket)
	    {
		    if (thisPacket == null)
		    {
			    return;
		    }

			//Action Packet.
			thisConncetion.ProcessPacket(thisPacket);
	    }

	    private void ProcessPacket(GenericPacket thisPacket)
	    {
		    if (thisPacket == null)
		    {
			    return;
		    }

		    for (int i = 0; i < PacketWaiters.Count; i++)
		    {
			    PacketWaiter thisWaiter = PacketWaiters[i];
				thisWaiter.CheckIfReceived(thisPacket);
		    }

		    PacketProcessor.BeginInvoke(this, thisPacket, null, null);
	    }

		private static List<PacketWaiter> PacketWaiters = new List<PacketWaiter>();
	    public class PacketWaiter
	    {
		    public PacketWaiter(Int32 type)
		    {
			    Type = type;
		    }

		    public Int32 Type { get; private set; }
		    public class PacketSegmentDescriptor
		    {
			    public int Start = 0;
			    public int End = 0;
			    public byte[] DataExpected = new byte[0];

			    public PacketSegmentDescriptor(int start, byte[] dataExpected)
			    {
				    Start = start;
				    End = Start + dataExpected.Length;
				    DataExpected = dataExpected;
			    }
			}

			public GenericPacket RecievedPacket = null;

			#region Require
			private List<PacketSegmentDescriptor> Required = new List<PacketSegmentDescriptor>();
			public void Require(int start, byte[] description)
		    {
				PacketSegmentDescriptor thisDescriptor = new PacketSegmentDescriptor(start, description);
				Required.Add(thisDescriptor);
			}
		    public void Require(int start, byte description)
		    {
			    Require(start, new byte[] { description });
		    }
		    public void Require(int start, SByte description)
		    {
			    Require(start, new byte[] { (byte)description });
		    }
			public void Require(int start, Int16 description)
		    {
			    Require(start, BitConverter.GetBytes(description));
		    }
		    public void Require(int start, Int32 description)
		    {
			    Require(start, BitConverter.GetBytes(description));
		    }
		    public void Require(int start, UInt16 description)
		    {
			    Require(start, BitConverter.GetBytes(description));
		    }
		    public void Require(int start, UInt32 description)
		    {
			    Require(start, BitConverter.GetBytes(description));
		    }
		    public void Require(int start, Single description)
		    {
			    Require(start, BitConverter.GetBytes(description));
		    }
		    public void Require(int start, string description)
		    {
			    byte[] bytes = description.ToByteArray();
				Require(start, bytes);
		    }
			#endregion
			#region Desire
			private List<PacketSegmentDescriptor> Desired = new List<PacketSegmentDescriptor>();
			public void Desire(int start, byte[] description)
		    {
			    PacketSegmentDescriptor thisDescriptor = new PacketSegmentDescriptor(start, description);
			    Desired.Add(thisDescriptor);
		    }
		    public void Desire(int start, byte description)
		    {
			    Desire(start, new byte[] { description });
		    }
		    public void Desire(int start, SByte description)
		    {
			    Desire(start, new byte[] { (byte)description });
		    }
		    public void Desire(int start, Int16 description)
		    {
			    Desire(start, BitConverter.GetBytes(description));
		    }
		    public void Desire(int start, Int32 description)
		    {
			    Desire(start, BitConverter.GetBytes(description));
		    }
		    public void Desire(int start, UInt16 description)
		    {
			    Desire(start, BitConverter.GetBytes(description));
		    }
		    public void Desire(int start, UInt32 description)
		    {
			    Desire(start, BitConverter.GetBytes(description));
		    }
		    public void Desire(int start, Single description)
		    {
			    Desire(start, BitConverter.GetBytes(description));
		    }
		    public void Desire(int start, string description)
		    {
			    byte[] bytes = description.ToByteArray();
			    Desire(start, bytes);
		    }
			#endregion
			#region Receiving
			private ManualResetEvent Received = new ManualResetEvent(false);
		    public bool StartListening()
		    {
			    if (RecievedPacket != null) return false;
			    if (!PacketWaiters.Contains(this)) PacketWaiters.Add(this);
			    return true;
		    }
			private void MarkReceived()
		    {
			    Received.Set();
			    PacketWaiters.RemoveAll(x=>x == this);
			}
		    internal void CheckIfReceived(GenericPacket thisPacket)
		    {
			    bool GetDesired = (false | Desired.Count <= 0);
			    foreach (var desiredPacketSegment in Desired)
			    {
				    if (thisPacket.Data.Length < desiredPacketSegment.End)
				    {
					    continue;
				    }
				    byte[] desiredBytes = desiredPacketSegment.DataExpected;
				    byte[] thisPacketBytes = thisPacket.Data.Skip(desiredPacketSegment.Start)
					    .Take(desiredPacketSegment.End - desiredPacketSegment.Start).ToArray();
				    if (desiredBytes.SequenceEqual(thisPacketBytes))
				    {
					    GetDesired = true;
					    break;
				    }
			    }

			    bool GetAllRequired = true;
			    foreach (var requiredPacketSegment in Required)
			    {
				    if (thisPacket.Data.Length < requiredPacketSegment.End)
				    {
					    GetAllRequired = false;
					    continue;
				    }
				    byte[] requiredBytes = requiredPacketSegment.DataExpected;
				    byte[] thisPacketBytes = thisPacket.Data.Skip(requiredPacketSegment.Start)
					    .Take(requiredPacketSegment.End - requiredPacketSegment.Start).ToArray();
				    if (requiredBytes.SequenceEqual(thisPacketBytes))
				    {
					    GetAllRequired &= true;
					    continue;
				    }
				    else
				    {
					    GetAllRequired = false;
				    }
			    }

			    if (GetDesired & GetAllRequired)
			    {
				    RecievedPacket = thisPacket;
					MarkReceived();
			    }
		    }
			#endregion

			public bool WaitUntilRecived(int microseconds)
		    {
			    if (Received.WaitOne(0)) return true;
			    StartListening();
				return Received.WaitOne(microseconds);
		    }
		}

	    public bool GetResponseOrResend(PacketWaiter response, GenericPacket resend)
	    {
		    int resends = 0;
		    while (!response.WaitUntilRecived(3000))
		    {
			    if (resends >= 3) return false;

				Send(resend);
			    resends++;
		    }
		    return true;
	    }
		#endregion
		#region Send
		private bool BeginSend(GenericPacket input)
	    {
		    if (TCPSocket == BlankTCPSocket)
		    {
			    return false;
		    }
		    if (!TCPSocket.Connected)
		    {
			    return false;
		    }

		    byte[] buffer = input.Serialise();

		    SocketAsyncEventArgs e = new SocketAsyncEventArgs();
		    e.SetBuffer(buffer, 0, buffer.Length);
		    e.Completed += new EventHandler<SocketAsyncEventArgs>(SendCallback);

		    bool completedAsync = false;

		    try
		    {
			    completedAsync = TCPSocket.SendAsync(e);
		    }
		    catch (SocketException se)
		    {
			    Console.WriteLine("Socket Exception: " + se.ErrorCode + " Message: " + se.Message);
			    return false;
		    }

		    if (!completedAsync)
		    {
			    // The call completed synchronously so invoke the callback ourselves
			    SendCallback(this, e);
		    }
		    return true;
	    }
	    private void SendCallback(object sender, SocketAsyncEventArgs e)
	    {
		    if (e.SocketError == SocketError.Success)
		    {
			    // You may need to specify some type of state and 
			    // pass it into the BeginSend method so you don't start
			    // sending from scratch
		    }
		    else
		    {
			    return;
		    }
	    }

		public bool SendMessage(string Input)
	    {
			Type_32_ChatMessage thisChatMessage = new Type_32_ChatMessage(Input);
			return BeginSend(thisChatMessage);
	    }
	    public bool Send(GenericPacket Input)
	    {
		    return BeginSend(Input);
	    }
		#endregion

		#region Disconnect
	    public bool Disconnect()
	    {
		    if (TCPSocket.Connected)
		    {
			    try
			    {
				    TCPSocket.Disconnect(false);
				    return true;
			    }
			    catch
			    {
				    return false;
			    }
		    }
		    return false;
	    }
		#endregion
	}
}
