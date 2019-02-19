using System;
using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

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
				    if (packet.OwnerName.Contains("#1")) FormationInspector.UpdateClientFormationHost(1, packet.OwnerName, (int)packet.ID);
				    if (packet.OwnerName.Contains("#2")) FormationInspector.UpdateClientFormationHost(2, packet.OwnerName, (int)packet.ID);
				    if (packet.OwnerName.Contains("#3")) FormationInspector.UpdateClientFormationHost(3, packet.OwnerName, (int)packet.ID);
				    if (packet.OwnerName.Contains("#4")) FormationInspector.UpdateClientFormationHost(4, packet.OwnerName, (int)packet.ID);
				    if (packet.OwnerName.Contains("#5")) FormationInspector.UpdateClientFormationHost(5, packet.OwnerName, (int)packet.ID);
				    if (packet.OwnerName.Contains("#6")) FormationInspector.UpdateClientFormationHost(6, packet.OwnerName, (int)packet.ID);
				    if (packet.OwnerName.Contains("#7")) FormationInspector.UpdateClientFormationHost(7, packet.OwnerName, (int)packet.ID);
				    if (packet.OwnerName.Contains("#8")) FormationInspector.UpdateClientFormationHost(8, packet.OwnerName, (int)packet.ID);
				    if (packet.OwnerName.Contains("#9")) FormationInspector.UpdateClientFormationHost(9, packet.OwnerName, (int)packet.ID);
                    return thisConnection.SendToClientStream(packet);
				}
			}
		}
	}
}
