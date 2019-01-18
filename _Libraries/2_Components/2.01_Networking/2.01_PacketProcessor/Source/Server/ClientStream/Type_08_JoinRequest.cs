using System;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;
using static Com.OfficerFlake.Libraries.SettingsLibrary;
using static Com.OfficerFlake.Libraries.Extensions.YSFlight;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_08_JoinRequest(IConnection thisConnection, IPacket_08_JoinRequest packet)
			{
				var ServerUpTime = ObjectFactory.ServerUpTime.TotalSeconds().RawValue;
				var ClientUpTime = thisConnection.LoginTime.TotalSeconds().RawValue;

				#region Join Request Pending
				if (thisConnection.JoinRequestPending)
				{
					Logger.Debug.AddWarningMessage("Join Request already pending for " + thisConnection.User.UserName.ToInternallyFormattedSystemString() + ".");
					thisConnection.SendToClientStream("Issue with last join request. Cancelling last join request...");
					IPacket_10_JoinRequestDenied JoinDenied = ObjectFactory.CreatePacket10JoinRequestDenied();
					thisConnection.SendToClientStream(JoinDenied);
					thisConnection.JoinRequestPending = false;
					return true;
				}
				thisConnection.JoinRequestPending = true;
				#endregion

				#region Convert To JoinRequest
				IPacket_08_JoinRequest JoinRequest = ObjectFactory.CreatePacket08JoinRequest();
				JoinRequest.Data = packet.Data;
				#endregion

				#region Deny Requests if server is join locked!
				if (Settings.Flight.Join.Lock)
				{
					//Reject the join request - don't have the start position requested!
					IPacket_10_JoinRequestDenied JoinDenied = ObjectFactory.CreatePacket10JoinRequestDenied();
					thisConnection.SendToClientStream(JoinDenied);
					thisConnection.SendToClientStream("Join request denied - Server is join locked!");
					thisConnection.JoinRequestPending = false;
					return false;
				}
				#endregion

				#region Acknowledge Join Request
				//Acknowledge Join Request.
				IPacket_06_Acknowledgement AcknowledgeRequest = ObjectFactory.CreatePacket06Acknowledgement();
				AcknowledgeRequest.Arguments = new uint[] { 5, 0 };
				thisConnection.SendToClientStream(AcknowledgeRequest);
				#endregion

				#region Check For Requested STP
				//Check if Server has STP - deny if it doesn't!
				if (!World.AllStartPositions.Select(x=>x.Identify.ToUpperInvariant()).Contains(JoinRequest.StartPositionIdentify.ToUpperInvariant()))
				{
					//Reject the join request - don't have the start position requested!
					IPacket_10_JoinRequestDenied JoinDenied = ObjectFactory.CreatePacket10JoinRequestDenied();
					thisConnection.SendToClientStream(JoinDenied);
					thisConnection.SendToClientStream("Join request denied - Server does not have that start position installed!");

					thisConnection.JoinRequestPending = false;
					return false;
				}
				IWorldStartPosition StartPosition = World.AllStartPositions.First(x => x.Identify == JoinRequest.StartPositionIdentify);
				#endregion

				#region Check For Requested Aircraft
				IMetaDataAircraft MetaAircraft = MetaData.Aircraft.FindByName(JoinRequest.AircraftIdentify);
				if (MetaAircraft == MetaData.Aircraft.None)
				{
					//Reject the join request - don't have the aircraft requested!
					IPacket_10_JoinRequestDenied JoinDenied = ObjectFactory.CreatePacket10JoinRequestDenied();
					thisConnection.SendToClientStream(JoinDenied);
					thisConnection.SendToClientStream("Join request denied - Server does not have that aircraft installed!");
					thisConnection.JoinRequestPending = false;
					return false;
				}

				//TODO: [4] Cache Aircraft!
				//CachedData.Aircraft CachedAircraft = MetaAircraft.Cache();
				#endregion

				#region Assign Vehicle
				thisConnection.Vehicle = ObjectFactory.CreateAircraft();
				lock (Extensions.YSFlight.World.Vehicles)
				{
					Extensions.YSFlight.World.Vehicles.Add(thisConnection.Vehicle);
				}
				thisConnection.Vehicle.Owner = thisConnection.User;
				thisConnection.Vehicle.Connection = thisConnection;
				Debug.AddDetailMessage("Assigned Vehicle " + thisConnection.Vehicle.ID + " to connection " + thisConnection.ConnectionNumber);
				thisConnection.Vehicle.MetaData = MetaAircraft;
				#endregion

				#region Build EntityJoined(05)
				IPacket_05_AddVehicle EntityJoined = ObjectFactory.CreatePacket05AddVehicle();
				EntityJoined.VehicleType = Packet_05VehicleType.Aircraft;
				EntityJoined.Version = 0;
				EntityJoined.ID = thisConnection.Vehicle.ID;
				EntityJoined.IFF = JoinRequest.IFF;
				EntityJoined.PosX = StartPosition.Position.X;
				EntityJoined.PosY = StartPosition.Position.Y;
				EntityJoined.PosZ = StartPosition.Position.Z;
				EntityJoined.HdgH = StartPosition.Attitude.H;
				EntityJoined.HdgP = StartPosition.Attitude.P;
				EntityJoined.HdgB = StartPosition.Attitude.B;
				EntityJoined.Identify = JoinRequest.AircraftIdentify;
				EntityJoined.OwnerName = thisConnection.User.UserName.ToUnformattedSystemString();
				EntityJoined.OwnerType = Packet_05OwnerType.Self;
				#endregion

				#region Build Flight Data Packet
				IPacket_11_FlightData FlightData = ObjectFactory.CreatePacket11FlightData(3);
				FlightData.ID = EntityJoined.ID;

				IDATFile CachedAircraft = ObjectFactory.CreateDATFileReference(Settings.YSFlight.Directory + MetaAircraft.Path_0_PropertiesFile);
				CachedAircraft.Load();

				FlightData.WeightFuel = (CachedAircraft.CachedData.WeightOfFuel.ToKiloGrams().RawValue * (JoinRequest.FuelPercent)).KiloGrams();
				FlightData.WeightSmokeOil = 100.KiloGrams();
				FlightData.AmmoGUN = CachedAircraft.CachedData.AmmoGun;
				if (!Settings.Options.AllowUnguidedWeapons) FlightData.AmmoGUN = 0;
				FlightData.Strength = CachedAircraft.CachedData.Strength;
				FlightData.AnimThrottle = StartPosition.Throttle;
				if (StartPosition.GearDown) FlightData.AnimGear = 1.0f;
				FlightData.Timestamp = (/*ServerUpTime - */ ClientUpTime).Seconds().ToTimeSpan();
				FlightData.PosX = EntityJoined.PosX;
				FlightData.PosY = EntityJoined.PosY;
				FlightData.PosZ = EntityJoined.PosZ;
				if (FlightData.PosY.ToMeters().RawValue < 1) FlightData.PosY = 1.Meters();
				FlightData.HdgH = EntityJoined.HdgH;
				FlightData.HdgP = EntityJoined.HdgP;
				FlightData.HdgB = EntityJoined.HdgB;
				FlightData.V_PosX = ((Math.Sin(-StartPosition.Attitude.H.ToRadians().RawValue) * (StartPosition.Speed.ToMetersPerSecond().RawValue))).MetersPerSecond();
				FlightData.V_PosZ = ((Math.Cos(-StartPosition.Attitude.H.ToRadians().RawValue) * (StartPosition.Speed.ToMetersPerSecond().RawValue))).MetersPerSecond();

				#region Turn on the brakes if Velocity == 0
				if (FlightData.V_PosX.ToMetersPerSecond().RawValue == 0 && FlightData.V_PosZ.ToMetersPerSecond().RawValue == 0 && Settings.Flight.Join.UseWheelChocks)
				{
					FlightData.AnimBrake = 100;
				}
				#endregion
				#endregion

				#region Prepare Acknolwedgement Reponse.
				IPacketWaiter PacketWaiter_AcknowledgeJoinPacket = thisConnection.CreatePacketWaiter(6);
				if (EntityJoined.VehicleType == Packet_05VehicleType.Aircraft)
				{
					PacketWaiter_AcknowledgeJoinPacket.Require(4, EntityJoined.ID);
				}
				else
				{
					PacketWaiter_AcknowledgeJoinPacket.Require(0, 1);
				}
				PacketWaiter_AcknowledgeJoinPacket.StartListening();
				#endregion

				#region Send Owner Join Data
				thisConnection.Vehicle.Update(EntityJoined);
				thisConnection.Vehicle.CreateVehicle();
				thisConnection.SendToClientStream(EntityJoined);
				if (!thisConnection.GetResponseOrResend(PacketWaiter_AcknowledgeJoinPacket, EntityJoined))
				{
					thisConnection.SendToClientStream("Expected an acknowledge Join Data Reply and didn't get an answer. Disconnecting...");
					foreach (var thisConnectionLast5Packet in thisConnection.Last5Packets)
					{
						Logger.Debug.AddDetailMessage("&aIn Packet (" + thisConnectionLast5Packet.Type + ")\n" +
						                              thisConnectionLast5Packet.Serialise().ToHexString() + "\n" +
						                              thisConnectionLast5Packet.Serialise().ToSystemString());
					}
					//thisConnection.Disconnect();
					//return false;
				}
				thisConnection.Vehicle.Update(FlightData);
				thisConnection.SendToClientStream(FlightData);
				#endregion

				#region Send Owner Join Approved
				IPacket_09_JoinRequestApproved JoinApproved = ObjectFactory.CreatePacket09JoinRequestApproved();
				#region Prepare Acknowledgement Reponse.
				IPacketWaiter PacketWaiter_AcknowledgeJoinApproved = thisConnection.CreatePacketWaiter(6);
				PacketWaiter_AcknowledgeJoinApproved.Require(0, 6);
				PacketWaiter_AcknowledgeJoinApproved.StartListening();
				#endregion
				//thisConnection.SendGetPacket(JoinApproved, AcknowledgeJoinApproved);
				thisConnection.SendToClientStream(JoinApproved);
				if (!thisConnection.GetResponseOrResend(PacketWaiter_AcknowledgeJoinApproved, JoinApproved))
				{
					thisConnection.SendToClientStream("Expected an acknowledge Join Approval and didn't get an answer. Disconnecting...");
					//thisConnection.Disconnect();
					//return false;
				}
				thisConnection.JoinRequestPending = false;
				thisConnection.FlightStatus = FlightStatus.Flying;
				thisConnection.SendToClientStream("You have been assigned flight number: " + EntityJoined.ID);
				#endregion

				#region Send Others Join Data
				if (Settings.Flight.Join.Notification)
				{
					Logger.Console.AddInformationMessage("&b" + thisConnection.User.UserName.ToInternallyFormattedSystemString() + "&b took off (" + EntityJoined.Identify + ")");
				}
				foreach (IConnection otherConnection in Connections.AllConnections.Exclude(thisConnection).ToArray())
				{
					if (Settings.Flight.Join.Notification)
					{
						otherConnection.SendToClientStreamAsync(thisConnection.User.UserName.ToUnformattedSystemString() + " took off (" + EntityJoined.Identify + ")");
					}

					IPacket_05_AddVehicle OtherJoinPacket = ObjectFactory.CreatePacket05AddVehicle();
					OtherJoinPacket.Data = EntityJoined.Data;
					OtherJoinPacket.OwnerType = Packet_05OwnerType.Other;

					IPacketWaiter PacketWaiter_AcknowledgeOtherJoinPacket = thisConnection.CreatePacketWaiter(6);
					if (EntityJoined.VehicleType == Packet_05VehicleType.Aircraft)
					{
						PacketWaiter_AcknowledgeOtherJoinPacket.Require(4, EntityJoined.ID);
					}
					else
					{
						PacketWaiter_AcknowledgeOtherJoinPacket.Require(0, 1);
					}
					PacketWaiter_AcknowledgeOtherJoinPacket.StartListening();
					Logger.Console.AddInformationMessage("Sending Join Notification.");
					otherConnection.SendToClientStreamAsync(OtherJoinPacket);

					if (!otherConnection.GetResponseOrResend(PacketWaiter_AcknowledgeOtherJoinPacket, OtherJoinPacket))
					{
						otherConnection.SendToClientStreamAsync("Expected a Other Entity Join Acknowldge for ID " + OtherJoinPacket.ID + " and didn't get an answer.");
						//thisConnection.Disconnect();
						//return false;
					}
					Logger.Console.AddInformationMessage("Sent Join Notification.");
				}
				#endregion
				return true;
			}
		}
	}
}
