using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_02_Logoff : GenericPacket, IPacket_02_Logoff
	{
		public Type_02_Logoff() : base(02)
		{
		}
	}
}
