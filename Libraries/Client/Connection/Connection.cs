using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
    public class Connection : IConnection
    {
		#region Properties
	    public IUser User { get; set; } = ObjectFactory.CreateUser(ObjectFactory.CreateRichTextString("<Unknown User>"));
	    public UInt32 Version { get; set; } = 0;

	    #region ConnectionNumber
	    private static uint ConnectionIDIncrementer = 0;
	    public UInt32 ConnectionNumber
	    {
		    get;
		    private set;
	    }
	    #endregion
		#region ConnectionType
	    public ConnectionType ConnectionType { get; set; }= ConnectionType.YSFlight;
	    public bool IsConnected { get; set; } = false;
		#endregion

		#region LoginStatus
		public LoginStatus LoginState { get; set; } = LoginStatus.Disconnected;
	    public bool IsLoggingIn => LoginState == LoginStatus.LoggingIn;
	    public bool IsLoggedIn => LoginState == LoginStatus.LoggedIn;
		#endregion
		#region FlightStatus
	    public FlightStatus FlightStatus { get; set; } = FlightStatus.Idle;
		public bool IsFlying => FlightStatus == FlightStatus.Flying;
		#endregion
		#endregion

		#region DataFlow
		#region Connect
		public bool Connect(Socket incomingSocket)
	    {
			ConnectionNumber = ConnectionIDIncrementer++;
		    SetTCPSocket(incomingSocket).ConfigureAwait(false);
			AddToServerList();
		    return true;
	    }
		#endregion

		#region Sockets
		#region TCP/IP
		private static Socket BlankTCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		private Socket TCPSocket = BlankTCPSocket;
		private async Task<bool> SetTCPSocket(Socket incomingSocket)
		{
			if (TCPSocket == BlankTCPSocket)
			{
				TCPSocket = incomingSocket;
				//TCPStartToRecieveNewPacket();
				await TCPGetPacket();
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
		private async Task<IPacket> TCPGetPacketAsync()
		{
			#region Init
			IPacket output = null;

			UInt32 size;
			byte[] body;
			#endregion
			#region GetData
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
				output.Type = type;
				output.Data = data;
				return output;
			}
			catch (ArgumentNullException)
			{
				//output is null.
				output = null;
				return output;
			}
			#endregion
		}
		private async Task TCPGetPacket()
		{
			IPacket receivedPacket = null;
			receivedPacket = await TCPGetPacketAsync();
			if (receivedPacket == null)
			{
				//Disconnect! Got Nothing!
				Disconnect("End of datastream.");

				return;
			}
			ProcessPacket(receivedPacket);
			await TCPGetPacket();
		}
		#endregion
		#region Send
		private bool TCPSend(IPacket thisPacket)
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
	    public bool Send(IPacket Input)
	    {
		    return TCPSend(Input);
	    }
		public bool SendMessage(string Input)
	    {
		    IPacket_32_ServerMessage thisChatMessage = ObjectFactory.CreatePacket32ServerMessage(Input);
		    return TCPSend(thisChatMessage);
	    }
		public async Task<bool> SendAsync(IPacket thisPacket)
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
	    public async Task<bool> SendMessageAsync(string Message)
	    {
			try
		    {
			    return await Task.Run(() => SendMessage(Message));
		    }
		    catch (ArgumentNullException)
		    {
			    //thisPacket is Null.
		    }
		    return false;
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
		public void GivePacket(IPacket thisPacket) => GivePacketToConnection(this, thisPacket);
	    private static void GivePacketToConnection(Connection thisConncetion, IPacket thisPacket)
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
		public class PacketWaiter : IPacketWaiter
		{
			public PacketWaiter(UInt32 type)
			{
				RequireType = type;
			}

			public UInt32 RequireType { get; }
			public class PacketWaiterSegmentDescriptor : IPacketWaiterSegmentDescriptor
			{
				public int Start { get; set; } = 0;
				public int End { get; set; } = 0;
				public byte[] DataExpected { get; set; } = new byte[0];

				public PacketWaiterSegmentDescriptor(int start, byte[] dataExpected)
				{
					Start = start;
					End = Start + dataExpected.Length;
					DataExpected = dataExpected;
				}
			}

			public IPacket RecievedPacket { get; set; } = null;

			#region Require
			private List<PacketWaiterSegmentDescriptor> Required = new List<PacketWaiterSegmentDescriptor>();
			public void Require(int start, byte[] description)
			{
				PacketWaiterSegmentDescriptor thisDescriptor = new PacketWaiterSegmentDescriptor(start, description);
				Required.Add(thisDescriptor);
			}
			public void Require(int start, Byte description)
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
			public void Require(int start, Int64 description)
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
			public void Require(int start, UInt64 description)
			{
				Require(start, BitConverter.GetBytes(description));
			}
			public void Require(int start, Single description)
			{
				Require(start, BitConverter.GetBytes(description));
			}
			public void Require(int start, Double description)
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
			private List<PacketWaiterSegmentDescriptor> Desired = new List<PacketWaiterSegmentDescriptor>();
			public void Desire(int start, byte[] description)
			{
				PacketWaiterSegmentDescriptor thisDescriptor = new PacketWaiterSegmentDescriptor(start, description);
				Desired.Add(thisDescriptor);
			}
			public void Desire(int start, Byte description)
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
			public void Desire(int start, Int64 description)
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
			public void Desire(int start, UInt64 description)
			{
				Desire(start, BitConverter.GetBytes(description));
			}
			public void Desire(int start, Single description)
			{
				Desire(start, BitConverter.GetBytes(description));
			}
			public void Desire(int start, Double description)
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
			private ManualResetEvent Received { get; set; }= new ManualResetEvent(false);
			public bool IsReceived => Received.WaitOne(0);
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
			internal void CheckIfReceived(IPacket thisPacket)
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

			public bool WaitUntilReceived(int microseconds)
			{
				if (Received.WaitOne(0)) return true;
				StartListening();
				return Received.WaitOne(microseconds);
			}
		}
		private static List<PacketWaiter> PacketWaiters = new List<PacketWaiter>();

	    public IPacketWaiter CreatePacketWaiter(int type)
	    {
		    return new PacketWaiter((uint)type);
	    }
		public bool GetResponseOrResend(IPacketWaiter response, IPacket resend)
		{
			int resends = 0;
			while (!response.WaitUntilReceived(3000))
			{
				if (resends >= 3) return false;

				Send(resend);
				resends++;
			}
			return true;
		}
		#endregion

		#region Set Up Packet Processor
		public delegate bool DelegatePacketProcessor(Connection thisConnection, IPacket thisPacket);
	    private static bool DummyPacketProcessor(Connection thisConnection, IPacket thisPacket)
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
		private void ProcessPacket(IPacket thisPacket)
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
		public bool Disconnect(string reason)
	    {
		    RemoveFromServerList();
		    Connections.AllConnections.Except(new []{this}).ToList().SendMessageAsync(this.User.UserName.ToUnformattedSystemString() + " left the server.").ConfigureAwait(false);
		    SendMessageAsync("Disconnected from the server.").ConfigureAwait(false);
		    SendMessageAsync("Disconnection reason: " + reason).ConfigureAwait(false);
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
		private void AddToServerList()
	    {
			Connections.AllConnections.Add(this);
		}
	    private void RemoveFromServerList()
	    {
		    Connections.AllConnections.RemoveAll(x => x == this);
		}
		#endregion

		public Connection(Socket incomingSocket)
	    {
		    Connect(incomingSocket);
		}
	    ~Connection()
	    {
			//This is currently being called!
	    }
	}
}
