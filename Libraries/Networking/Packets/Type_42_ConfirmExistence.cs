using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_42_ConfirmExistence : GenericPacket, IPacket_42_ConfirmExistence
	{
		public Type_42_ConfirmExistence() : base(42)
		{
		}
	}
}
