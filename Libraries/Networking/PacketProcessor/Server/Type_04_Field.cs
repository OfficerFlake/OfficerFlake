using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class Server
		{
			private static bool Process_Type_04_Field(IConnection thisConnection, IPacket_04_Field fieldPacket)
			{
				//Don't need to do anything...
				return true;
			}
		}
	}
}
