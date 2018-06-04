using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_15_KillServer : GenericPacket, IPacket_15_KillServer
	{
		public Type_15_KillServer() : base(15)
		{
		}
	}
}
