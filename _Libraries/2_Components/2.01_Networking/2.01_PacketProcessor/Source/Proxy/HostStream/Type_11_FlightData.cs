using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Loggers;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_11_FlightData(IConnection thisConnection, IPacket_11_FlightData packet)
			{
				if (YSFlight.World.Vehicles.Any(x => x.ID == packet.ID))
				{
					YSFlight.World.Vehicles.First(x => x.ID == packet.ID).Update(packet);
				}
			    if (thisConnection.Vehicle?.ID == packet.ID)
			    {
                    Logger.AddDebugMessage("Got a Flight Data packet from the host that belongs to this connection. Ignoring it.");
			        return true;
			    }
			    else
			    {
			        return thisConnection.SendToClientStream(packet);
			    }
			}
		}
	}
}
