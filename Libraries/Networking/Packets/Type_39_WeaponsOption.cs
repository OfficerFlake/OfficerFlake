using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_39_WeaponsOption : GenericPacket, IPacket_39_WeaponsOption
	{
		public Type_39_WeaponsOption() : base(39)
		{
		}
		public Type_39_WeaponsOption(Boolean enabled) : base(39)
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
