using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_25_RequestToBeSideWindowOfServer : GenericPacket, IPacket_25_RequestToBeSideWindowOfServer
	{
		public Type_25_RequestToBeSideWindowOfServer() : base(25)
		{
		}
	}
}
