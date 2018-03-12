using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_41_UsernameDistance : GenericPacket, IPacket_41_UsernameDistance
	{
		public Type_41_UsernameDistance() : base(41)
		{
		}

		public Type_41_UsernameDistance(UInt16 distance) : base(41)
		{
			Distance = distance.Meters();
		}

		public IDistance Distance
		{
			get => GetUInt16(0).Meters();
			set => SetUInt16(0, (value.ToMeters().RawValue > 2) ? (UInt16)value.ToMeters().RawValue : (UInt16)3);
		}

		public Boolean IsAlwaysVisible
		{
			get => (Distance.ToMeters().RawValue == 1);
		}
		public void SetAlwaysVisible()
		{
			SetUInt16(0, 1);
		}

		public Boolean IsNeverVisible
		{
			get => (Distance.ToMeters().RawValue == 2);
		}
		public void SetNeverVisible()
		{
			SetUInt16(0, 2);
		}
	}
}
