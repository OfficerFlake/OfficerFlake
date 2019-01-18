using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.Networking
{
	public class Connection : IConnection
	{
		#region Properties

		public IUser User { get; set; } = ObjectFactory.CreateUser(ObjectFactory.CreateRichTextString("<Unknown User>"));
		public UInt32 Version { get; set; } = 0;
		public double Ping { get; set; } = 300;

		#region ConnectionNumber

		private static uint ConnectionIDIncrementer = 0;
		public UInt32 ConnectionNumber { get; private set; }

		#endregion

		#region ConnectionType

		public ConnectionType ConnectionType { get; set; } = ConnectionType.YSFlight;
		public bool IsConnected { get; set; } = false;
		public bool IsProxyMode { get; private set; } = false;

		#endregion

		#region LoginStatus

		public LoginStatus LoginState { get; set; } = LoginStatus.Disconnected;
		public bool IsLoggingIn => LoginState == LoginStatus.LoggingIn;
		public bool IsLoggedIn => LoginState == LoginStatus.LoggedIn;

		#endregion

		#region LoginTime

		public ITimeSpan LoginTime { get; private set; }

		#endregion

		#region FlightStatus

		public FlightStatus FlightStatus { get; set; } = FlightStatus.Idle;
		public bool IsFlying => FlightStatus == FlightStatus.Flying;
		public IWorldVehicle Vehicle { get; set; } = Extensions.YSFlight.World.NoVehicle;
		public bool JoinRequestPending { get; set; } = false;

		#endregion

		public List<IPacket> Last5Packets { get; } = new List<IPacket>();

		#endregion

		#region DataFlow

		#region Connect

		public bool Connect(Socket incomingSocket, bool isProxyMode = false)
		{
			ConnectionNumber = ConnectionIDIncrementer++;
			IsProxyMode = isProxyMode;
			if (isProxyMode) _ = CreateHostSocket();
			AddToServerList();
			LoginTime = ObjectFactory.ServerUpTime;

			_ = SetTCPSocketClientStream(incomingSocket);
			return true;
		}

		#endregion

		#region Sockets

		#region TCP/IP

		#region Socket Setup

		private static Socket BlankTCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		#region Client

		private Socket TCPSocketClientStream = BlankTCPSocket;

		private async Task<bool> SetTCPSocketClientStream(Socket incomingSocket)
		{
			if (TCPSocketClientStream == BlankTCPSocket)
			{
				TCPSocketClientStream = incomingSocket;
				//TCPStartToRecieveNewPacket();
				TCPGetPacket(TCPSocketClientStream);
				return true;
			}
			return false;
		}

		#endregion

		#region Host

		private Socket TCPSocketHostStream = BlankTCPSocket;

		private async Task<bool> SetTCPSocketHostStream(Socket incomingSocket)
		{
			if (TCPSocketHostStream == BlankTCPSocket)
			{
				TCPSocketHostStream = incomingSocket;
				//TCPStartToRecieveNewPacket();
				await TCPGetPacket(TCPSocketHostStream);
				return true;
			}
			return false;
		}

		private async Task<bool> CreateHostSocket()
		{
			if (TCPSocketHostStream == BlankTCPSocket)
			{
				TCPSocketHostStream = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				try
				{
					TCPSocketHostStream.Connect(SettingsLibrary.Settings.Server.ProxyServer.DestinationAddress.IpAddress,
						(int) SettingsLibrary.Settings.Server.ProxyServer.DestinationPort);
				}
				catch (Exception e)
				{
					Debug.AddErrorMessage(e, "Error connecting HostAddress");
				}
				_ = TCPGetPacket(TCPSocketHostStream);
				return true;
			}
			return false;
		}

		#endregion

		#endregion

		#region Recieve

		private UInt32 TCPGetPacketHeader(Socket _TCPSocket)
		{
			byte[] sizeBuffer = new byte[4];
			goto Receive;

			//Get Data.
			Receive:
			try
			{
				_TCPSocket.Receive(sizeBuffer, 4, SocketFlags.None);
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

		private byte[] TCPGetPacketBody(UInt32 size, Socket _TCPSocket)
		{
			byte[] bodyBuffer = new byte[size];

			//Get Data.
			try
			{
				_TCPSocket.Receive(bodyBuffer, (int) size, SocketFlags.None);
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

		private async Task<IPacket> TCPGetPacketAsync(Socket _TCPSocket)
		{
			#region Init

			IPacket output = null;

			UInt32 size;
			byte[] body;

			#endregion

			#region GetData

			try
			{
				size = await Task.Run(() => TCPGetPacketHeader(_TCPSocket));
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
				body = await Task.Run(() => TCPGetPacketBody(size, _TCPSocket));
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
				//start index would not fit inside array.
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
				output = ObjectFactory.CreateGenericPacket();
				output.ResizeData((int) size);
				output.Type = type;
				output.Data = data;
				if (Logger.PacketInspector.Client == null | Logger.PacketInspector.Client == this)
				{
					if (Logger.PacketInspector.DataDirection == DataDirection.ClientToServer)
					{
						if (Logger.PacketInspector.Type == output.Type) Logger.PacketInspector.UpdatePacket(output);
					}
				}
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

		private async Task TCPGetPacket(Socket _TCPSocket)
		{
			IPacket receivedPacket = null;
			receivedPacket = await TCPGetPacketAsync(_TCPSocket);
			if (receivedPacket == null)
			{
				//Disconnect! Got Nothing!
				this.Disconnect("End of datastream.");

				return;
			}
			if (receivedPacket.Type == 01)
			{
				IPacket_01_Login loginPacket = ObjectFactory.CreatePacket01Login();
				loginPacket.Data = receivedPacket.Data;
				User.UserName = (loginPacket.Username ?? ("nameless_" + DateTime.Now.InStandardForm().hhmmss)).AsRichTextString();
			}
			if (_TCPSocket == TCPSocketClientStream)
			{
				_ = ProcessPacketClientStream(receivedPacket);
			}
			else
			{
				_ = ProcessPacketHostStream(receivedPacket);
			}
			_ = TCPGetPacket(_TCPSocket);
		}

		#endregion

		#region Send

		#region Any Socket

		private bool TCPSend(IPacket thisPacket, Socket _TCPSocket)
		{
			try
			{
				_TCPSocket.Send(thisPacket.Serialise());
				if (Logger.PacketInspector.Client == null | Logger.PacketInspector.Client == this)
				{
					if (Logger.PacketInspector.DataDirection == DataDirection.ServerToClient)
					{
						if (Logger.PacketInspector.Type == thisPacket.Type) Logger.PacketInspector.UpdatePacket(thisPacket);
					}
				}
				return true;
			}
			catch (ArgumentNullException e)
			{
				//Packet is Null.
				Debug.AddErrorMessage(e, "Trying to send a Null packet.");
			}
			catch (SocketException e)
			{
				//WinSock in Error state.
				Debug.AddErrorMessage(e, "WinSock is in an error state.");
			}
			catch (ObjectDisposedException e)
			{
				//Socket closed/disposed.
				Debug.AddErrorMessage(e, "Socket has been disposed.");
			}
			catch (Exception e)
			{
				Debug.AddErrorMessage(e, "Exception in TCPSend.");
			}
			return false;
		}

		public bool Send(IPacket Input, Socket _TCPSocket)
		{
			return TCPSend(Input, _TCPSocket);
		}

		public bool SendMessage(string Input, Socket _TCPSocket)
		{
			IPacket_32_ServerMessage thisChatMessage = ObjectFactory.CreatePacket32ServerMessage(Input);
			return TCPSend(thisChatMessage, _TCPSocket);
		}

		public bool SendMessage(IPacket_32_ChatMessage Input, Socket _TCPSocket)
		{
			return TCPSend(Input, _TCPSocket);
		}

		public async Task<bool> SendAsync(IPacket thisPacket, Socket _TCPSocket)
		{
			try
			{
				return await Task.Run(() => TCPSend(thisPacket, _TCPSocket));
			}
			catch (ArgumentNullException)
			{
				//thisPacket is Null.
			}
			return false;
		}

		public async Task<bool> SendMessageAsync(string Message, Socket _TCPSocket)
		{
			try
			{
				return await Task.Run(() => SendMessage(Message, _TCPSocket));
			}
			catch (ArgumentNullException)
			{
				//thisPacket is Null.
			}
			return false;
		}

		#endregion

		#region ToClientStream

		public bool SendToClientStream(IPacket Input)
		{
			return Send(Input, TCPSocketClientStream);
		}

		public bool SendToClientStream(string message)
		{
			return SendMessage(message, TCPSocketClientStream);
		}

		public async Task<bool> SendToClientStreamAsync(IPacket Input)
		{
			return await SendAsync(Input, TCPSocketClientStream);
		}

		public async Task<bool> SendToClientStreamAsync(string message)
		{
			return await SendMessageAsync(message, TCPSocketClientStream);
		}

		#endregion

		#region ToHostStream

		public bool SendToHostStream(IPacket Input)
		{
			return Send(Input, TCPSocketHostStream);
		}

		public bool SendToHostStream(string message)
		{
			return SendMessage(message, TCPSocketHostStream);
		}

		public async Task<bool> SendToHostStreamAsync(IPacket Input)
		{
			return await SendAsync(Input, TCPSocketHostStream);
		}

		public async Task<bool> SendToHostStreamAsync(string message)
		{
			return await SendMessageAsync(message, TCPSocketHostStream);
		}

		#endregion

		#endregion

		#region Ping Tester

		public void StartPingTester()
		{
			_ = Task.Run(PingTest);
		}
		private async Task<bool> PingTest()
		{
			const int PingInterval = 3000;
			const double PingMaxDelta = 0.40;
			const int PingMargin = 20;

			if (Ping < 1) Ping = 1;
			
			if (IsLoggedIn)
			{
				DateTime PingStartTime = DateTime.Now;

				#region Send PrepareSimulation(16)

				//Build Prepare Simulation (16)
				IPacket_16_PrepareSimulation PrepareSimulation = ObjectFactory.CreatePacket16PrepareSimulation();

				IPacketWaiter packetWaiter_AcknowledgePrepareSimulation = CreatePacketWaiter(6);
				packetWaiter_AcknowledgePrepareSimulation.Require(0, 7);
				packetWaiter_AcknowledgePrepareSimulation.StartListening();

				//Send Prepare Simulation (16)
				SendToClientStream(PrepareSimulation);
				LoginState = LoginStatus.LoggedIn;

				#endregion

				#region Get PrepareSimulation(06:07)

				if (!GetResponseOrResend(packetWaiter_AcknowledgePrepareSimulation, PrepareSimulation))
				{
					if (!IsConnected)
					{
						return false;
					}
					else
					{
						await Task.Delay(PingInterval);
						Debug.AddDetailMessage("Ping Check for Connection " + ConnectionNumber + " Failed. Trying Again...");
						_ = Task.Run(PingTest);
						return false;
					}
				}

				#endregion

				DateTime PingEndTime = DateTime.Now;
				double PingAdjustmentRatio = ((((PingEndTime - PingStartTime).TotalMilliseconds/2)-Ping) / Ping);
				if (PingAdjustmentRatio > PingMaxDelta) PingAdjustmentRatio = PingMaxDelta;
				if (PingAdjustmentRatio < -PingMaxDelta) PingAdjustmentRatio = -PingMaxDelta;
				PingAdjustmentRatio = Math.Abs(PingAdjustmentRatio);

				double OldPing = Ping;
				double NewPing = (PingEndTime - PingStartTime).TotalMilliseconds / 2;

				if (Math.Abs((NewPing - OldPing) / OldPing) > 5d && Math.Abs(OldPing - NewPing) > PingMargin)
				{
					//SendToClientStream("Ping Overrun " + Math.Round(NewPing, 3) + "ms");
				}
				else
				{
					Ping = (OldPing) * (PingAdjustmentRatio) +
					       (NewPing) * (1 - PingAdjustmentRatio);
					if (Ping < 1) Ping = 1;
					//SendToClientStream("Your Ping is " + Math.Round(Ping, 3) + "ms");
				}
				
			}

			await Task.Delay(PingInterval);
			_ = Task.Run(PingTest);
			return true;
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
		    thisConncetion.ProcessPacketClientStream(thisPacket);
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

				SendToClientStreamAsync(resend);
				resends++;
			}
			return true;
		}
		#endregion
		#region Set Up Packet Processor
		#region Dummy Processor
		public delegate Task<bool> DelegatePacketProcessor(Connection thisConnection, IPacket thisPacket);
	    private static Task<bool> DummyPacketProcessor(Connection thisConnection, IPacket thisPacket)
	    {
		    throw new NotImplementedException();
	    }
		#endregion
		#region ClientStream
		private static DelegatePacketProcessor PacketProcessorClientStream = DummyPacketProcessor;
	    public static bool SetPacketProcessorClientStream(DelegatePacketProcessor thisPacketProcessor)
	    {
		    PacketProcessorClientStream = thisPacketProcessor;
		    return true;
	    }
		#endregion
		#region HostStream
		private static DelegatePacketProcessor PacketProcessorHostStream = DummyPacketProcessor;
		public static bool SetPacketProcessorHostStream(DelegatePacketProcessor thisPacketProcessor)
	    {
		    PacketProcessorHostStream = thisPacketProcessor;
		    return true;
	    }
		#endregion
		#endregion
		#region Process Packet
		private async Task ProcessPacketClientStream(IPacket thisPacket)
		{
			if (thisPacket == null)
			{
				return;
			}

			for (int i = 0; i < PacketWaiters.Count; i++)
			{
				PacketWaiter thisWaiter = PacketWaiters[i];
				if (thisPacket.Type == thisWaiter.RequireType)
				{
					thisWaiter.CheckIfReceived(thisPacket);
				}
			}

			try
			{
				await Task.Run(() => PacketProcessorClientStream(this, thisPacket));
			}
			catch (NotImplementedException e)
			{
				Debug.AddErrorMessage(e, "Packet Processing for type " + thisPacket.Type + " is not yet implemented.");
				//this.SendMessageAsync("Sorry, that feature or packet is not implemented yet! Please try something else...");
			}
			catch (Exception e)
			{
				Debug.AddErrorMessage(e, "Packet Processing for type " + thisPacket.Type + " encountered an error.");
				_ = this.SendToClientStreamAsync("There was an error processing on of your packets. You haven't been disconnected, but you might have problems on the server from here!");
			}
		}
	    private async Task ProcessPacketHostStream(IPacket thisPacket)
	    {
		    if (thisPacket == null)
		    {
			    return;
		    }

		    try
		    {
			    await Task.Run(() => PacketProcessorHostStream(this, thisPacket));
		    }
		    catch (NotImplementedException e)
		    {
			    Debug.AddErrorMessage(e, "Packet Processing for type " + thisPacket.Type + " is not yet implemented.");
			    //this.SendMessageAsync("Sorry, that feature or packet is not implemented yet! Please try something else...");
		    }
		    catch (Exception e)
		    {
			    Debug.AddErrorMessage(e, "Packet Processing for type " + thisPacket.Type + " encountered an error.");
			    _ = this.SendToHostStreamAsync("There was an error processing on of your packets. You haven't been disconnected, but you might have problems on the server from here!");
		    }
	    }
		#endregion
		#endregion

		#region Disconnect
		public bool Disconnect(string reason)
	    {
		    RemoveFromServerList();
		    LoginState = LoginStatus.Disconnected;
			Logger.Console.AddInformationMessage("&c" + User.UserName.ToUnformattedSystemString() + " left the server.");
		    foreach (IConnection otherConnection in Connections.AllConnections.Exclude(this))
		    {
			    if (Vehicle != null & Vehicle != YSFlight.World.NoVehicle)
			    {
				    if (Vehicle is IWorldAircraft)
				    {
						IPacket_13_RemoveAircraft RemoveAircraft = ObjectFactory.CreatePacket13RemoveAircraft();
					    RemoveAircraft.ID = Vehicle.ID;
					    otherConnection.SendToClientStreamAsync(RemoveAircraft);
					}
				    if (Vehicle is IWorldGround)
				    {
						IPacket_19_RemoveGround RemoveGround = ObjectFactory.CreatePacket19RemoveGround();
					    RemoveGround.ID = Vehicle.ID;
					    otherConnection.SendToClientStreamAsync(RemoveGround);
					}
			    }
			    _ = otherConnection.SendToClientStreamAsync(this.User.UserName.ToUnformattedSystemString() + " left the server.");
		    }
		    if (Vehicle != null & Vehicle != YSFlight.World.NoVehicle)
		    {
				Vehicle.DestroyVehicle();
			    Vehicle = YSFlight.World.NoVehicle;
			    FlightStatus = FlightStatus.Idle;
		    }
		    _ = SendToClientStreamAsync("Disconnected from the server.");
		    _ = SendToClientStreamAsync("Disconnection reason: " + reason);
			if (TCPSocketClientStream.Connected)
		    {
			    try
			    {
				    TCPSocketClientStream.Disconnect(false);
			    }
			    catch
			    {
			    }
		    }
		    if (IsProxyMode & TCPSocketHostStream.Connected)
		    {
			    try
			    {
				    TCPSocketHostStream.Disconnect(false);
			    }
			    catch
			    {
			    }
		    }
			try
		    {
			    TCPSocketClientStream.Dispose();
			    TCPSocketHostStream.Dispose();
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

	    public Connection(Socket incomingSocket, bool isProxyMode = false)
	    {

			Connect(incomingSocket, isProxyMode);
		}
	    ~Connection()
	    {
			//This is currently being called!
	    }
	}
}
