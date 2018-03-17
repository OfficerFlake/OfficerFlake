using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class Server
		{
			private static bool Process_Type_08_JoinRequest(IConnection thisConnection, IPacket_08_JoinRequest smokeColorPacket)
			{
				//Don't need to do anything...
				return true;
			}
		}
	}
}
