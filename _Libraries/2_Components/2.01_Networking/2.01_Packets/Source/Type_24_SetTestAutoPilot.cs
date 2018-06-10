using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_24_SetTestAutoPilot : GenericPacket, IPacket_24_SetTestAutoPilot
	{
		public Type_24_SetTestAutoPilot() : base(24)
		{
		}
	}
}
