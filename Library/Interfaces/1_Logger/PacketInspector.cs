using System;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IPacketInspector
	{
		/// <summary>
		/// Updates the packet data in the Packet Inspector
		/// </summary>
		/// <param name="packet">Packet to pull data from.</param>
		void UpdatePacket(IPacket packet);

		IConnection Client { get; }
		Int32 Type { get; }
		DataDirection DataDirection { get; }
	}

	public enum DataDirection
	{
		ServerToClient,
		ClientToServer
	}
}
