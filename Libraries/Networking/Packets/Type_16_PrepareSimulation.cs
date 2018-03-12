using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_16_PrepareSimulation : GenericPacket, IPacket_16_PrepareSimulation
	{
		public Type_16_PrepareSimulation() : base(16)
		{
		}
	}
}
