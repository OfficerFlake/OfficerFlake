using System;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_39_WeaponsEnabled : GenericPacket
	{
		public Type_39_WeaponsEnabled() : base(39)
		{
		}
		public Type_39_WeaponsEnabled(Boolean enabled) : base(39)
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
