using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Loggers
{
    internal class DefaultPacketInspector : IPacketInspector
    {
		public IConnection Client => null;
		public Int32 Type => 0;
	    public DataDirection DataDirection => DataDirection.ServerToClient;

		public void UpdatePacket(IPacket packet)
	    {
			//Don't do anything, not needed.
	    }
    }
	public static class PacketInspector
	{
		private static IPacketInspector _packetInspector = new DefaultPacketInspector();

		public static void LinkPacketInspector(IPacketInspector packetInspector)
		{
			if (packetInspector != null) _packetInspector = packetInspector;
		}

		public static IConnection Client => _packetInspector.Client;
		public static Int32 Type => _packetInspector.Type;
		public static DataDirection DataDirection => _packetInspector.DataDirection;
		public static void UpdatePacket(IPacket packet) => _packetInspector.UpdatePacket(packet);
	}
}
