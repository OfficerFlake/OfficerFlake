using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_31_MissilesOption : GenericPacket, IPacket_31_MissilesOption
	{
		public Type_31_MissilesOption() : base(31)
		{
		}
		public Type_31_MissilesOption(Boolean enabled) : base(31)
		{
			Enabled = enabled;
		}

		public Boolean Enabled
		{
			get => (GetInt32(0) > 0);
			set => SetInt32(0, value ? 1 : 0);
		}
	}
}
