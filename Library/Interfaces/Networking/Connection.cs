using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IConnection
	{
		String Username { get; set; }
		UInt32 Version { get; set; }

		Boolean IsConnected { get; set; }
		UInt32 ConnectionNumber { get; }

		bool Connect(Socket TCPSocket, IPacketProcessor PacketProcessor);
		bool Disconnect(string Reason);

		bool Send(IPacket packet);
		Task<bool> SendAsync(IPacket packet);
		bool SendMessage(string message);
		Task<bool> SendMessageAsync(string message);
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
