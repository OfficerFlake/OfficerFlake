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
                    #region Update Flight Data
                    thisConnection.Vehicle.Update(packet);
                    #endregion
                    #region Check Formation Eligibility
                    double HitRadiusMaximumFormationRange = 5;

					IWorldVehicle ClosestVehicle = YSFlight.World.GetClosestVehicle(thisConnection.Vehicle, thisConnection.Vehicle.HitRadius.ToMeters().RawValue*HitRadiusMaximumFormationRange);
					Double ClosestVehicleDistance = YSFlight.World.GetClosestVehicleDistance(thisConnection.Vehicle);
				    HitRadiusMaximumFormationRange = 10;
                    #endregion
                    #region Not In Formation - Send Packet 11
                    if (ClosestVehicle == null)
					{
						Debug.AddDetailMessage("Formation Data Packet NOT created by Client: " + thisConnection.ConnectionNumber + ", ID: " + packet.ID);
						return thisConnection.SendToHostStream(packet);
					}
                    #endregion
                    #region In Formation - Send Packet 64-11
                    UInt32 ClosestVehicleID = ClosestVehicle.ID;
					IPacket_64_11_FormationFlightData formationPacket = packet.ConvertTo_IPacket_64_11_FormationFlightData(ClosestVehicle);

					formationPacket.PosX = (ClosestVehicle.Position.X.ToMeters().RawValue - packet.PosX.ToMeters().RawValue).Meters();
					formationPacket.PosY = (ClosestVehicle.Position.Y.ToMeters().RawValue - packet.PosY.ToMeters().RawValue).Meters();
                    formationPacket.PosZ = (ClosestVehicle.Position.Z.ToMeters().RawValue - packet.PosZ.ToMeters().RawValue).Meters();
                    //formationPacket.HdgH = ClosestVehicle.Attitude.H;
                    //formationPacket.HdgP = ClosestVehicle.Attitude.P;
                    //formationPacket.HdgB = ClosestVehicle.Attitude.B;
                    //formationPacket.V_PosX = ClosestVehicle.VelocityPosition.X;
                    //formationPacket.V_PosY = ClosestVehicle.VelocityPosition.Y;
                    //formationPacket.V_PosZ = ClosestVehicle.VelocityPosition.Z;
                    //formationPacket.V_HdgH = ClosestVehicle.VelocityAttitude.X;
                    //formationPacket.V_HdgP = ClosestVehicle.VelocityAttitude.Y;
                    //formationPacket.V_HdgB = ClosestVehicle.VelocityAttitude.Z;

					Debug.AddDetailMessage("Formation Data Packet Created by Client: " + thisConnection.ConnectionNumber + ", ID: " + formationPacket.ID + ", Target: " + formationPacket.FormationTargetID);
				    Debug.AddDetailMessage
                        (
                        
                        "Client " + thisConnection.ConnectionNumber + " is " +
                        Math.Round(ClosestVehicleDistance, 2) + "M away from " +
                        ClosestVehicle.ID + ", at (" +
                                           Math.Round(formationPacket.PosX.RawValue, 2) + "," +
                                           Math.Round(formationPacket.PosY.RawValue, 2) + "," +
                                           Math.Round(formationPacket.PosZ.RawValue, 2) + ")."

                        );
					return thisConnection.SendToHostStream(formationPacket);
                    #endregion
                }
                //Debug.AddDetailMessage("Packet 11 received from client in Proxy Mode doesn't belong to that clients registered vehicle. Not Sending It!");
			    return true;
			    //return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
