using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_13_RemoveAircraft(IConnection thisConnection, IPacket_13_RemoveAircraft packet)
			{
				lock (Extensions.YSFlight.World.Vehicles)
				{
					Extensions.YSFlight.World.Vehicles.RemoveAll(x => x.ID == packet.ID);
				}
				Logger.Debug.AddSummaryMessage("Removed Vehicle(A) by Proxy: " + packet.ID);
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
