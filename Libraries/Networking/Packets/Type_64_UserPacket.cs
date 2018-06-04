using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_64_UserPacket : GenericPacket, IPacket_64_UserPacket
	{
		public Type_64_UserPacket() : base(64)
		{
		}
	}
}
