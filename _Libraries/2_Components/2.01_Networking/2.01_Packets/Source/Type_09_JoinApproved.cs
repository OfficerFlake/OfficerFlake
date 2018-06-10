using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_09_JoinApproved : GenericPacket, IPacket_09_JoinRequestApproved
	{
		public Type_09_JoinApproved() : base(9)
		{
		}
	}
}
