using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_17_Heartbeat : GenericPacket, IPacket_17_HeartBeat
	{
		public Type_17_Heartbeat() : base(17)
		{
		}
	}
}
