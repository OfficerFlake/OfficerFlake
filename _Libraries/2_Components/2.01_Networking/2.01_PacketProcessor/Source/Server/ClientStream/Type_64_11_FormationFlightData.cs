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
				if (packet.ID != thisConnection.Vehicle.ID) return true;
				//Debug.AddDetailMessage("Formation Data Packet from Client: " + thisConnection.ConnectionNumber + ", ID: " + packet.ID + ", Target: " + packet.FormationTargetID + ", Timestamp" + packet.Timestamp.TotalSeconds().RawValue);
				thisConnection.Vehicle.Update(FlightData);
				FlightData.PosX = thisConnection.Vehicle.Position.X;
				FlightData.PosY = thisConnection.Vehicle.Position.Y;
				FlightData.PosZ = thisConnection.Vehicle.Position.Z;
				foreach (IConnection otherConnection in Connections.LoggedIn.Exclude(thisConnection))
				{
					otherConnection.SendToClientStreamAsync(FlightData);
				}
				return true;
			}
		}
	}
}
