using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_64_01_OYSVersion(IConnection thisConnection, IPacket_64_01_OYSVersion packet)
			{
				if (packet.OYSVersion == SettingsLibrary.Settings.Options.OYSNetcodeVersion)
				{
					thisConnection.ConnectionType = ConnectionType.OpenYS;
					thisConnection.SendToClientStream(packet); //Acknowledge the handshake and tell the client "Hey, I support that version of OYS too!"
				}
				return true;
			}
		}
	}
}
