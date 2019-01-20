using System;
using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_05_AddVehicle(IConnection thisConnection, IPacket_05_AddVehicle packet)
			{
				lock (Extensions.YSFlight.World.Vehicles) //Enum is volatile and will crash if we try and add to while enumerating.
				{
					IWorldVehicle newVehicle = ObjectFactory.CreateVehicle();
					lock (Extensions.YSFlight.World.Vehicles)
					{
						Extensions.YSFlight.World.Vehicles.Add(newVehicle);
					}
                    newVehicle.Update(packet);
                    if (Extensions.YSFlight.World.Vehicles.Select(x => x.ID).Contains(packet.ID))
					{
						lock (Extensions.YSFlight.World.Vehicles)
						{
							Extensions.YSFlight.World.Vehicles.RemoveAll(x => x.ID == newVehicle.ID);
						}
					}
					else
					{
						Logger.Debug.AddSummaryMessage("Added Vehicle by Proxy: " + packet.ID);
					}
					lock (Extensions.YSFlight.World.Vehicles)
					{
						Extensions.YSFlight.World.Vehicles.Add(newVehicle);
					}
					if (packet.OwnerType == Packet_05OwnerType.Self) thisConnection.Vehicle = newVehicle;
					return thisConnection.SendToClientStream(packet);
				}
			}
		}
	}
}
