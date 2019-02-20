using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

using static Com.OfficerFlake.Libraries.SettingsLibrary;
using static Com.OfficerFlake.Libraries.Extensions.YSFlight;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_12_LeaveFlight(IConnection thisConnection, IPacket_12_LeaveFlight packet)
			{
				IPacket_12_LeaveFlight Unjoin = packet;
				IPacket_13_RemoveAircraft RemoveAirplane = ObjectFactory.CreatePacket13RemoveAircraft();
				RemoveAirplane.ID = Unjoin.ID;

				if (Settings.Flight.Join.Notification)
				{
					Loggers.Console.AddInformationMessage("&9" + thisConnection.User.UserName.ToInternallyFormattedSystemString() + "&9 left the aircraft");
				}
				foreach (IConnection otherconnection in Connections.AllConnections)
				{
					IPacketWaiter PacketWaiter_AcknowledgeOtherLeavePacket = thisConnection.CreatePacketWaiter(6);
					PacketWaiter_AcknowledgeOtherLeavePacket.Require(0, 2);
					PacketWaiter_AcknowledgeOtherLeavePacket.Require(4, RemoveAirplane.ID);
					PacketWaiter_AcknowledgeOtherLeavePacket.StartListening(); 

					otherconnection.SendToClientStreamAsync(RemoveAirplane);

					if (!otherconnection.GetResponseOrResend(PacketWaiter_AcknowledgeOtherLeavePacket, RemoveAirplane))
					{
						otherconnection.SendToClientStreamAsync("Expected a Other Entity Leave Acknowldge and didn't get an answer. Disconnecting...");
						//otherconnection.Disconnect();
						//return false;
					}

					if (Settings.Flight.Leave.Notification) otherconnection.SendToClientStreamAsync(thisConnection.User.UserName.ToUnformattedSystemString() + " left the aircraft.");
				}
				lock (Extensions.YSFlight.World.Vehicles)
				{
					Extensions.YSFlight.World.Vehicles.RemoveAll(x=>x == thisConnection.Vehicle);
				}
				thisConnection.Vehicle.DestroyVehicle();
				thisConnection.Vehicle = World.NoVehicle;
				thisConnection.FlightStatus = FlightStatus.Idle;
				return true;
			}
		}
	}
}
