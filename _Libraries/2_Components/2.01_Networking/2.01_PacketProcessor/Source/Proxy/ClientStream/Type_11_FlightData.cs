using System;
using System.Configuration;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_11_FlightData(IConnection thisConnection, IPacket_11_FlightData packet)
			{
				if (thisConnection.Vehicle != YSFlight.World.NoVehicle && thisConnection.Vehicle != null && packet.ID == thisConnection.Vehicle.ID)
				{
					#region Update FlightData
					if (YSFlight.World.Vehicles.Any(x => x.ID == packet.ID))
					{
						YSFlight.World.Vehicles.First(x => x.ID == packet.ID).Update(packet);
					}
					#endregion
					IWorldVehicle ClosestVehicle = YSFlight.World.GetClosestVehicle(thisConnection.Vehicle);
					Double ClosestVehicleDistance = YSFlight.World.GetClosestVehicleDistance(thisConnection.Vehicle);
					if (!packet.AnimLightBeacon || ClosestVehicle == null)
					{
						Debug.AddDetailMessage("Formation Data Packet NOT created by Client: " + thisConnection.ConnectionNumber + ", ID: " + packet.ID);
						return thisConnection.SendToHostStream(packet);
					}
					UInt32 ClosestVehicleID = ClosestVehicle.ID;
					IPacket_64_11_FormationFlightData formationPacket = packet.ConvertTo_IPacket_64_11_FormationFlightData(ClosestVehicle);

					formationPacket.PosX = 0.Meters();
					formationPacket.PosY = 0.Meters();
					formationPacket.PosZ = 0.Meters();
					formationPacket.V_PosX = ClosestVehicle.VelocityPosition.X;
					formationPacket.V_PosY = ClosestVehicle.VelocityPosition.Y;
					formationPacket.V_PosZ = ClosestVehicle.VelocityPosition.Z;
					formationPacket.V_HdgH = ClosestVehicle.VelocityAttitude.X;
					formationPacket.V_HdgP = ClosestVehicle.VelocityAttitude.Y;
					formationPacket.V_HdgB = ClosestVehicle.VelocityAttitude.Z;
					formationPacket.AnimSmoke = (formationPacket.Timestamp.TotalSeconds().RawValue % 2) > 0;

					Debug.AddDetailMessage("Formation Data Packet Created by Client: " + thisConnection.ConnectionNumber + ", ID: " + formationPacket.ID + ", Target: " + formationPacket.FormationTargetID);
					return thisConnection.SendToHostStream(formationPacket);
					//}
				}
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
