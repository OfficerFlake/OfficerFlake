using System;
using System.Collections.Generic;
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

                    #region What is our position in the formation?
                    string thisUsername = thisConnection.User.UserName.ToUnformattedSystemString().ToUpperInvariant();
				    int thisFormationPosition = 0;
				    if (thisUsername.Contains("#1")) thisFormationPosition = 1;
				    if (thisUsername.Contains("#2")) thisFormationPosition = 2;
				    if (thisUsername.Contains("#3")) thisFormationPosition = 3;
				    if (thisUsername.Contains("#4")) thisFormationPosition = 4;
				    if (thisUsername.Contains("#5")) thisFormationPosition = 5;
				    if (thisUsername.Contains("#6")) thisFormationPosition = 6;
				    if (thisUsername.Contains("#7")) thisFormationPosition = 7;
				    if (thisUsername.Contains("#8")) thisFormationPosition = 8;
				    if (thisUsername.Contains("#9")) thisFormationPosition = 9;
                    #endregion
                    #region Get a list of compatible vehicles to form off.
                    List<IWorldVehicle> CompatableVehiclesList = new List<IWorldVehicle>();
				    IWorldVehicle[] AllAircraft = YSFlight.World.AllAircraft.ToArray();
                    switch (thisFormationPosition)
                    {
                        default:
                            goto case 0;
                        case 0:
                            CompatableVehiclesList = YSFlight.World.AllAircraft.Where(x => x.ID != thisConnection.Vehicle.ID).ToList();
                            break;
                        case 1:
                            //CompatableVehiclesList.Clear(); //clear it, nothing to form off!
                            break;
                        case 2:
                            if (AllAircraft.Any(x => x.Tag.ToUpperInvariant().Contains("#1")))
                                CompatableVehiclesList.Add(AllAircraft.First(x => x.Tag.ToUpperInvariant().Contains("#1")));
                            goto case 1;
                        case 3:
                            if (AllAircraft.Any(x => x.Tag.ToUpperInvariant().Contains("#2")))
                                CompatableVehiclesList.Add(AllAircraft.First(x => x.Tag.ToUpperInvariant().Contains("#2")));
                            goto case 2;
                        case 4:
                            if (AllAircraft.Any(x => x.Tag.ToUpperInvariant().Contains("#3")))
                                CompatableVehiclesList.Add(AllAircraft.First(x => x.Tag.ToUpperInvariant().Contains("#3")));
                            goto case 3;
                        case 5:
                            if (AllAircraft.Any(x => x.Tag.ToUpperInvariant().Contains("#4")))
                                CompatableVehiclesList.Add(YSFlight.World.AllAircraft.First(x => x.Tag.ToUpperInvariant().Contains("#4")));
                            goto case 4;
                        case 6:
                            if (AllAircraft.Any(x => x.Tag.Contains("#5")))
                                CompatableVehiclesList.Add(AllAircraft.First(x => x.Tag.ToUpperInvariant().Contains("#5")));
                            goto case 5;
                        case 7:
                            if (AllAircraft.Any(x => x.Tag.ToUpperInvariant().Contains("#6")))
                                CompatableVehiclesList.Add(AllAircraft.First(x => x.Tag.ToUpperInvariant().Contains("#6")));
                            goto case 6;
                        case 8:
                            if (AllAircraft.Any(x => x.Tag.ToUpperInvariant().Contains("#7")))
                                CompatableVehiclesList.Add(AllAircraft.First(x => x.Tag.ToUpperInvariant().Contains("#7")));
                            goto case 7;
                        case 9:
                            if (AllAircraft.Any(x => x.Tag.ToUpperInvariant().Contains("#8")))
                                CompatableVehiclesList.Add(AllAircraft.First(x => x.Tag.ToUpperInvariant().Contains("#8")));
                            goto case 8;
                    }
				    CompatableVehiclesList.RemoveAll(x => x.ID == thisConnection.Vehicle.ID);
				    CompatableVehiclesList.Reverse(); // Need the #1 at the front of the list, and vice versa. We take the first of the list to form off.
                    #endregion
                    //Get the first vehicle off that list.
				    IWorldVehicle FormationTarget = null;
				    Double FormationTargetDistance = double.MaxValue;
				    foreach (IWorldVehicle potentialTargetVehicle in CompatableVehiclesList)
				    {
				        FormationTargetDistance = Math.Sqrt
				        (
				            Math.Pow(potentialTargetVehicle.Position.X.ToMeters().RawValue - thisConnection.Vehicle.Position.X.ToMeters().RawValue, 2) +
				            Math.Pow(potentialTargetVehicle.Position.Y.ToMeters().RawValue - thisConnection.Vehicle.Position.Y.ToMeters().RawValue, 2) +
				            Math.Pow(potentialTargetVehicle.Position.Z.ToMeters().RawValue - thisConnection.Vehicle.Position.Z.ToMeters().RawValue, 2)
				        );
				        if (FormationTargetDistance <= thisConnection.Vehicle.HitRadius.ToMeters().RawValue * HitRadiusMaximumFormationRange)
				        {
				            FormationTarget = potentialTargetVehicle;
				            break;
				        }
                    }
                    #endregion
                    #region Not In Formation - Send Packet 11
                    if (FormationTarget == null)
					{
						Debug.AddDetailMessage("Formation Data Packet NOT created by Client: " + thisConnection.ConnectionNumber + ", ID: " + packet.ID);
						return thisConnection.SendToHostStream(packet);
					}
                    #endregion
                    #region In Formation - Send Packet 64-11
                    UInt32 ClosestVehicleID = FormationTarget.ID;
					IPacket_64_11_FormationFlightData formationPacket = packet.ConvertTo_IPacket_64_11_FormationFlightData(FormationTarget);
				    ICoordinate3 FormationTargetEstimatedPosition = FormationTarget.GetCurrentPositionEstimate();
					formationPacket.PosX = (FormationTargetEstimatedPosition.X.ToMeters().RawValue - packet.PosX.ToMeters().RawValue).Meters();
					formationPacket.PosY = (FormationTargetEstimatedPosition.Y.ToMeters().RawValue - packet.PosY.ToMeters().RawValue).Meters();
                    formationPacket.PosZ = (FormationTargetEstimatedPosition.Z.ToMeters().RawValue - packet.PosZ.ToMeters().RawValue).Meters();
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
                        Math.Round(FormationTargetDistance, 2) + "M away from " +
                        FormationTarget.ID + ", at (" +
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
