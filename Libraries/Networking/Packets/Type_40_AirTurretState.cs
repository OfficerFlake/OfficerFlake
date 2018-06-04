using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_40_AirTurretState : GenericPacket, IPacket_40_AirTurretState
	{
		public Type_40_AirTurretState() : base(40)
		{
		}
	}
}
