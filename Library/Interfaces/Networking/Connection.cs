using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IConnection
	{
		IUser User { get; set; }
		UInt32 Version { get; set; }

		UInt32 ConnectionNumber { get; }
		ConnectionType ConnectionType { get; set; }
		Boolean IsConnected { get; set; }

		LoginStatus LoginState { get; set; }
		Boolean IsLoggingIn { get; }
		Boolean IsLoggedIn { get; }

		FlightStatus FlightStatus { get; set; }
		Boolean IsFlying { get; }
		UInt32 VehicleID { get; set; }

		Boolean JoinRequestPending { get; set; }

		bool Connect(Socket TCPSocket, Boolean isProxyMode);
		bool Disconnect(string Reason);

		void GivePacket(IPacket thisPacket);
		List<IPacket> Last5Packets { get; }

		bool Send(IPacket packet);
		Task<bool> SendAsync(IPacket packet);
		bool SendMessage(string message);
		Task<bool> SendMessageAsync(string message);


		IPacketWaiter CreatePacketWaiter(int type);
		bool GetResponseOrResend(IPacketWaiter waiter, IPacket resendPacket);
	}

	public interface IPacketWaiter
	{
		IPacket RecievedPacket { get; set; }
		UInt32 RequireType { get; }

		Boolean IsReceived { get; }
		Boolean WaitUntilReceived(int timeout);

		bool StartListening();

		void Require(int position, Byte[] data);
		void Require(int position, Byte data);
		void Require(int position, SByte data);
		void Require(int position, Int16 data);
		void Require(int position, Int32 data);
		void Require(int position, Int64 data);
		void Require(int position, UInt16 data);
		void Require(int position, UInt32 data);
		void Require(int position, UInt64 data);
		void Require(int position, Single data);
		void Require(int position, Double data);
		void Require(int position, String data);

		void Desire(int position, Byte[] data);
		void Desire(int position, Byte data);
		void Desire(int position, SByte data);
		void Desire(int position, Int16 data);
		void Desire(int position, Int32 data);
		void Desire(int position, Int64 data);
		void Desire(int position, UInt16 data);
		void Desire(int position, UInt32 data);
		void Desire(int position, UInt64 data);
		void Desire(int position, Single data);
		void Desire(int position, Double data);
		void Desire(int position, String data);

	}

	public interface IPacketWaiterSegmentDescriptor
	{
		int Start { get; set; }
		int End { get; set; }
		byte[] DataExpected { get; set; }
	}

	public enum ConnectionType
	{
		YSFlight,
		OpenYS
	}
	public enum LoginStatus
	{
		Disconnected,
		LoggingIn,
		LoggedIn,
	}
	public enum FlightStatus
	{
		Idle,
		Flying,
	}
}
