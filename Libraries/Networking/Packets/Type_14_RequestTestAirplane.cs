using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_14_RequestTestAirplane : GenericPacket, IPacket_14_RequestTestAirplane
	{
		public Type_14_RequestTestAirplane() : base(14)
		{
		}
	}
}
