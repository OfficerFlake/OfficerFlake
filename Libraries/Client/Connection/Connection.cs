using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
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

	    #region ConnectionNumber
	    private static int ConnectionIDIncrementer = 0;
	    public int ConnectionNumber
	    {
		    get;
		    private set;
	    }
	    #endregion
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

		#region DataFlow
		#region Connect
		public void Connect()
	    {
			ConnectionNumber = ConnectionIDIncrementer++;
		    AddToServerList();
		}
		#endregion
		#region Sockets
		#region TCP/IP
		private static Socket BlankTCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		private Socket TCPSocket = BlankTCPSocket;
		public bool SetTCPSocket(Socket incomingSocket)
		{
			if (TCPSocket == BlankTCPSocket)
			{
				TCPSocket = incomingSocket;
				//TCPStartToRecieveNewPacket();
				TCPGetPacket();
				return true;
			}
			return false;
		}
		#region Recieve
		private UInt32 TCPGetPacketHeader()
		{
			byte[] sizeBuffer = new byte[4];
			goto Receive;

			//Get Data.
			Receive:
			try
			{
				TCPSocket.Receive(sizeBuffer, 4, SocketFlags.None);
				goto Convert;
			}
			catch (ArgumentNullException)
			{
				//buffer is null.
			}
			catch (ArgumentOutOfRangeException)
			{
				//size exceeds buffer.
			}
			catch (SocketException)
			{
				//WinSock Error.
			}
			catch (ObjectDisposedException)
			{
				//Socket Closed.
			}
			catch (System.Security.SecurityException)
			{
				//Caller in Stack doesn't have permissions.
			}
			return 0;

			//Convert Data.
			Convert:
			try
			{
				return BitConverter.ToUInt32(sizeBuffer, 0);
			}
			catch (ArgumentNullException)
			{
				//sizeBuffer is Null.
			}
			catch (ArgumentOutOfRangeException)
			{
				//StartIndex outside bounds of array.
			}
			catch (ArgumentException)
			{
				//StartIndex != 0
			}
			return 0;
		}
		private byte[] TCPGetPacketBody(UInt32 size)
		{
			byte[] bodyBuffer = new byte[size];

			//Get Data.
			try
			{
				TCPSocket.Receive(bodyBuffer, (int)size, SocketFlags.None);
			}
			catch (ArgumentNullException)
			{
				//buffer is null.
			}
			catch (ArgumentOutOfRangeException)
			{
				//size exceeds buffer.
			}
			catch (SocketException)
			{
				//WinSock Error.
			}
			catch (ObjectDisposedException)
			{
				//Socket Closed.
			}
			catch (System.Security.SecurityException)
			{
				//Caller in Stack doesn't have permissions.
			}
			return bodyBuffer;
		}
		private async Task<GenericPacket> TCPGetPacketAsync()
		{
			#region Init
			GenericPacket output = Packet.NoPacket;

			UInt32 size;
			byte[] body;
			#endregion
			#region GetData
			Header:
			try
			{
				size = await Task.Run(() => TCPGetPacketHeader());
				goto Body;
			}
			catch (ArgumentNullException)
			{
				//thisPacket is Null.
			}
			return output;

			Body:
			try
			{
				body = await Task.Run(() => TCPGetPacketBody(size));
				goto PrepareType;
			}
			catch (ArgumentNullException)
			{
				//thisPacket is Null.
			}
			return output;
			#endregion
			#region Type
			PrepareType:
			byte[] typeBuffer;
			try
			{
				typeBuffer = body.Take(4).ToArray();
				goto ConvertType;
			}
			catch (ArgumentNullException)
			{
				//body is null.
			}
			return output;

			ConvertType:
			UInt32 type;
			try
			{
				type = BitConverter.ToUInt32(typeBuffer, 0);
				goto PrepareData;
			}
			catch (ArgumentNullException)
			{
				//typebuffer is null.
			}
			catch (ArgumentOutOfRangeException)
			{
				//start index not 0.
			}
			catch (ArgumentException)
			{
				//start index would not fit insidde array.
			}
			return output;
			#endregion
			#region Data
			PrepareData:
			byte[] data;
			try
			{
				data = body.Skip(4).ToArray();
				goto Combine;
			}
			catch (ArgumentNullException)
			{
				//body is null.
			}
			return output;
			#endregion
			#region BuildPacket
			Combine:
			try
			{
				output.ResizeData((int)size);
				output.Type = (int)type;
				output.Data = data;
				return output;
			}
			catch (ArgumentNullException)
			{
				//output is null.
				output = Packet.NoPacket;
				return output;
			}
			#endregion
		}
		private async Task TCPGetPacket()
		{
			GenericPacket receivedPacket = Packet.NoPacket;
			receivedPacket = await TCPGetPacketAsync();
			if (receivedPacket.Serialise().SequenceEqual(Packet.NoPacket.Serialise()))
			{
				//Disconnect! Got Nothing!
				Disconnect();

				return;
			}
			ProcessPacket(receivedPacket);
			TCPGetPacket();
		}
		#endregion
		#region Send
		private bool TCPSend(GenericPacket thisPacket)
		{
			try
			{
				TCPSocket.Send(thisPacket.Serialise());
				return true;
			}
			catch (ArgumentNullException)
			{
				//Packet is Null.
			}
			catch (SocketException)
			{
				//WinSock in Error state.
			}
			catch (ObjectDisposedException)
			{
				//Socket closed/disposed.
			}
			return false;
		}
		private async Task<bool> TCPSendAsync(GenericPacket thisPacket)
		{
			try
			{
				return await Task.Run(() => TCPSend(thisPacket));
			}
			catch (ArgumentNullException)
			{
				//thisPacket is Null.
			}
			return false;
		}
		public async Task<bool> SendMessage(string Input)
		{
			Type_32_ChatMessage thisChatMessage = new Type_32_ChatMessage(Input);
			return await TCPSendAsync(thisChatMessage);
		}
		public async Task<bool> Send(GenericPacket Input)
		{
			return await TCPSendAsync(Input);
		}
		#endregion
		#endregion
		#region UDP
		private bool _isUDPEnabled = false;
	    public bool IsUDPCapable => _isUDPEnabled;
		public void SetUDPEnabled() => _isUDPEnabled = true;
		#endregion
		#endregion
		#region Processing
		#region Pass In A Packet
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
		#endregion
		#region Wait For A Packet
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
				PacketWaiters.RemoveAll(x => x == this);
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
		private static List<PacketWaiter> PacketWaiters = new List<PacketWaiter>();
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

		#region Set Up Packet Processor
		public delegate void DelegatePacketProcessor(Connection thisConnection, GenericPacket thisPacket);
	    private static void DummyPacketProcessor(Connection thisConnection, GenericPacket thisPacket)
	    {
		    throw new NotImplementedException();
	    }
	    private static DelegatePacketProcessor PacketProcessor = DummyPacketProcessor;
	    public static bool SetPacketProcessor(DelegatePacketProcessor thisPacketProcessor)
	    {
		    PacketProcessor = thisPacketProcessor;
		    return true;
	    }
		#endregion
		#region Process Packet
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
		#endregion
		#endregion
		#region Disconnect
		public bool Disconnect()
	    {
		    RemoveFromServerList();
		    if (TCPSocket.Connected)
		    {
			    try
			    {
				    TCPSocket.Disconnect(false);
			    }
			    catch
			    {
			    }
		    }
		    try
		    {
			    TCPSocket.Dispose();
		    }
		    catch
		    {
		    }
		    return true;
	    }
		#endregion
		#endregion

		#region Connections List
		private static List<Connection> _connections = new List<Connection>();
	    public static List<Connection> GetConnections => _connections;

	    private void AddToServerList()
	    {
			_connections.Add(this);
		}
	    private void RemoveFromServerList()
	    {
			_connections.RemoveAll(x => x == this);
		}
		#endregion

		public Connection()
	    {
		    Connect();
		}
	    ~Connection()
	    {
			//This is currently being called!
	    }
	}
}
