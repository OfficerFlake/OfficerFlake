using System;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_11_FlightData(IConnection thisConnection, IPacket_11_FlightData packet)
			{
				if (thisConnection.Vehicle != YSFlight.World.NoVehicle && thisConnection.Vehicle != null)
				{
					if (YSFlight.World.Vehicles.Any(x => x.ID == packet.ID))
					{
						YSFlight.World.Vehicles.First(x => x.ID == packet.ID).Update(packet);
					}
					IWorldVehicle ClosestVehicle = YSFlight.World.GetClosestVehicle(thisConnection.Vehicle);
					UInt32 ClosetVehicleID = ClosestVehicle.ID;
					//TODO: [5] Create Formation Packet
					//All vars ditto EXCEPT: X,Y,Z => Relative Distance.
				}
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
