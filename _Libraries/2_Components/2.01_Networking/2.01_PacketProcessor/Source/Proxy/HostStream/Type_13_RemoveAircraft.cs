using System;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_13_RemoveAircraft(IConnection thisConnection, IPacket_13_RemoveAircraft packet)
			{
				lock (Extensions.YSFlight.World.Vehicles)
				{
					Extensions.YSFlight.World.Vehicles.RemoveAll(x => x.ID == packet.ID);
				}
				Logger.Debug.AddSummaryMessage("Removed Vehicle(A) by Proxy: " + packet.ID);
                uint Id_at_01 = (Extensions.YSFlight.World.Vehicles.Any(x => x.Tag.Contains("#1")) ? (YSFlight.World.Vehicles.Last(y => y.Tag.Contains("#1")).ID) : 0);
                uint Id_at_02 = (Extensions.YSFlight.World.Vehicles.Any(x => x.Tag.Contains("#2")) ? (YSFlight.World.Vehicles.Last(y => y.Tag.Contains("#2")).ID) : 0);
                uint Id_at_03 = (Extensions.YSFlight.World.Vehicles.Any(x => x.Tag.Contains("#3")) ? (YSFlight.World.Vehicles.Last(y => y.Tag.Contains("#3")).ID) : 0);
                uint Id_at_04 = (Extensions.YSFlight.World.Vehicles.Any(x => x.Tag.Contains("#4")) ? (YSFlight.World.Vehicles.Last(y => y.Tag.Contains("#4")).ID) : 0);
                uint Id_at_05 = (Extensions.YSFlight.World.Vehicles.Any(x => x.Tag.Contains("#5")) ? (YSFlight.World.Vehicles.Last(y => y.Tag.Contains("#5")).ID) : 0);
                uint Id_at_06 = (Extensions.YSFlight.World.Vehicles.Any(x => x.Tag.Contains("#6")) ? (YSFlight.World.Vehicles.Last(y => y.Tag.Contains("#6")).ID) : 0);
                uint Id_at_07 = (Extensions.YSFlight.World.Vehicles.Any(x => x.Tag.Contains("#7")) ? (YSFlight.World.Vehicles.Last(y => y.Tag.Contains("#7")).ID) : 0);
                uint Id_at_08 = (Extensions.YSFlight.World.Vehicles.Any(x => x.Tag.Contains("#8")) ? (YSFlight.World.Vehicles.Last(y => y.Tag.Contains("#8")).ID) : 0);
                uint Id_at_09 = (Extensions.YSFlight.World.Vehicles.Any(x => x.Tag.Contains("#9")) ? (YSFlight.World.Vehicles.Last(y => y.Tag.Contains("#9")).ID) : 0);

                if (String.Equals(packet.ID.ToString(), Id_at_01)) FormationInspector.UpdateClientFormationHost(1, null, null);
                if (String.Equals(packet.ID.ToString(), Id_at_02)) FormationInspector.UpdateClientFormationHost(2, null, null);
                if (String.Equals(packet.ID.ToString(), Id_at_03)) FormationInspector.UpdateClientFormationHost(3, null, null);
                if (String.Equals(packet.ID.ToString(), Id_at_04)) FormationInspector.UpdateClientFormationHost(4, null, null);
                if (String.Equals(packet.ID.ToString(), Id_at_05)) FormationInspector.UpdateClientFormationHost(5, null, null);
                if (String.Equals(packet.ID.ToString(), Id_at_06)) FormationInspector.UpdateClientFormationHost(6, null, null);
                if (String.Equals(packet.ID.ToString(), Id_at_07)) FormationInspector.UpdateClientFormationHost(7, null, null);
                if (String.Equals(packet.ID.ToString(), Id_at_08)) FormationInspector.UpdateClientFormationHost(8, null, null);
                if (String.Equals(packet.ID.ToString(), Id_at_09)) FormationInspector.UpdateClientFormationHost(9, null, null);

			    if (Id_at_01 == 0) FormationInspector.UpdateClientFormationHost(1, null, null);
			    if (Id_at_02 == 0) FormationInspector.UpdateClientFormationHost(2, null, null);
			    if (Id_at_03 == 0) FormationInspector.UpdateClientFormationHost(3, null, null);
			    if (Id_at_04 == 0) FormationInspector.UpdateClientFormationHost(4, null, null);
			    if (Id_at_05 == 0) FormationInspector.UpdateClientFormationHost(5, null, null);
			    if (Id_at_06 == 0) FormationInspector.UpdateClientFormationHost(6, null, null);
			    if (Id_at_07 == 0) FormationInspector.UpdateClientFormationHost(7, null, null);
			    if (Id_at_08 == 0) FormationInspector.UpdateClientFormationHost(8, null, null);
			    if (Id_at_09 == 0) FormationInspector.UpdateClientFormationHost(9, null, null);
                return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
