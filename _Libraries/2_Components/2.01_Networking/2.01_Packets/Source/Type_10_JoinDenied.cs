using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_10_JoinDenied : GenericPacket, IPacket_10_JoinRequestDenied
	{
		public Type_10_JoinDenied() : base(10)
		{
		}
	}
}
