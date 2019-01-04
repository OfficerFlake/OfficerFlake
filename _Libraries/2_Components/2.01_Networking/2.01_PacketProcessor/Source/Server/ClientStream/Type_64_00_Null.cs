using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_64_00_Null(IConnection thisConnection, IPacket_64_00_Null packet)
			{
				//Don't need to do anything.
				return true;
			}
		}
	}
}
