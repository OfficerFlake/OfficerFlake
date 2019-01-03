using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_36_WeaponsLoadout(IConnection thisConnection, IPacket_36_WeaponsLoadout packet)
			{
				Logger.Debug.AddDetailMessage("Haven't implented weapons loading yet, so ignored a packet of type 36...");
				return false;
				throw new NotImplementedException();
			}
		}
	}
}
