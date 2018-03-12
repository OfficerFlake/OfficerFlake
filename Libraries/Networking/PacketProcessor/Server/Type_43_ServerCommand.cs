using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class Server
		{
			private static bool Process_Type_43_ServerCommand(IConnection thisConnection, IPacket_43_ServerCommand serverCommandPacket)
			{
				//Don't need to do anything...
				return true;
			}
		}
	}
}
