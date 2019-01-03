using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_18_LockOn(IConnection thisConnection, IPacket_18_LockOn packet)
			{
				Connections.LoggedIn.Exclude(thisConnection).SendAsync(packet).ConfigureAwait(false);
				return true;
			}
		}
	}
}
