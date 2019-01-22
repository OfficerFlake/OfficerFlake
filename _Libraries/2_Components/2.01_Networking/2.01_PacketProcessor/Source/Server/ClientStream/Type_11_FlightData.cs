﻿using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_11_FlightData(IConnection thisConnection, IPacket_11_FlightData packet)
			{
				if (packet.ID != thisConnection.Vehicle.ID) return true;
				//Debug.AddDetailMessage("Flight Data packet received from Client: " + thisConnection.ConnectionNumber + ", ID: " + packet.ID + ", Timestamp" + packet.Timestamp.TotalSeconds().RawValue);
				thisConnection.Vehicle.Update(packet);
				packet.PosX = thisConnection.Vehicle.Position.X;
				packet.PosY = thisConnection.Vehicle.Position.Y;
				packet.PosZ = thisConnection.Vehicle.Position.Z;
				foreach (IConnection otherConnection in Connections.LoggedIn.Exclude(thisConnection))
				{
					otherConnection.SendToClientStreamAsync(packet);
				}
				return true;
			}
		}
	}
}