using System;
using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_38_QueryAirstate(IConnection thisConnection, IPacket_38_QueryAirstate packet)
			{
				UInt32[] AircraftIDs = Extensions.YSFlight.World.AllAircraft.Select(x => x.ID).ToArray();
				IPacket_38_QueryAirstate AirstatePakcket= ObjectFactory.CreatePacket38QueryAirstate();
				AirstatePakcket.AircraftIDs = AircraftIDs;
				//return thisConnection.SendToClientStream(AirstatePakcket);
				return true;
			}
		}
	}
}
