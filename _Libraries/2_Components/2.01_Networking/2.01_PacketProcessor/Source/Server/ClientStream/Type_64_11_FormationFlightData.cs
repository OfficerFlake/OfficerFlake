using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_64_11_FormationFlightData(IConnection thisConnection, IPacket_64_11_FormationFlightData packet)
			{
				IPacket_11_FlightData FlightData = packet.ConvertTo_IPacket_11_FlightData();
				foreach (IConnection otherConnection in Connections.LoggedIn.Exclude(thisConnection))
				{
					otherConnection.SendToClientStreamAsync(FlightData);
				}
				Debug.AddDetailMessage("Formation Data Packet from Client: " + thisConnection.ConnectionNumber + ", ID: " + packet.ID + ", Target: " + packet.FormationTargetID);
				return true;
			}
		}
	}
}
