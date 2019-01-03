using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_22_Damage(IConnection thisConnection, IPacket_22_Damage packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
