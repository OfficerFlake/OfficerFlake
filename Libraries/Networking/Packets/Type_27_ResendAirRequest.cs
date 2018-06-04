using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_27_ResendAirRequest : GenericPacket, IPacket_27_ResendAirRequest
	{
		public Type_27_ResendAirRequest() : base(27)
		{
		}
	}
}
