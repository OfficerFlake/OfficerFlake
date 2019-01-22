using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_32_ChatMessage(IConnection thisConnection, IPacket_32_ChatMessage packet)
			{
                //TODO: [5] Logic Structure for Proxy linking to Client Window
                //Interface: UpdateClientFormationHost(Number, Username, FlightID) //Username and FlightID may be null to set back to blanks.
                //Interface: UpdateClientFormationPosition (Number, Target, X, Y, Z) //Target can be null for absolute, X Y Z may be null to return to blanks.
			    //Connection sends a formation packet, update the interface
                //UI: UpdateClientFormationHost - Change the values and colors.
                //UI: UpdateClientFormationPosition - Change the values and colors.
                //UI: Maximise/Minise - Change the grid orders, and then limit the window size.
                //TODO: [3] Executable for Formation Client
                //Create UI window
                //Link main proxy UI to Formations Window
                return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
