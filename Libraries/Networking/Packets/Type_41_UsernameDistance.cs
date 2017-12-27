using System;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_41_UsernameDistance : GenericPacket
	{
		public Type_41_UsernameDistance() : base(41)
		{
		}

		public Type_41_UsernameDistance(Boolean AlwaysOrNeverVisible) : base(41)
		{
			Distance = AlwaysOrNeverVisible ? (UInt16)1 : (UInt16)2;
		}

		public Type_41_UsernameDistance(UInt16 distance) : base(41)
		{
			Distance = distance;
		}

		public UInt16 Distance
		{
			get => GetUInt16(0);
			set => SetUInt16(0, (value > 2) ? value : (UInt16)3);
		}

		public Boolean IsAlwaysVisible
		{
			get => (Distance == 1);
			set => Distance = value ? (UInt16) 1 : (UInt16) 2;
		}
		public void SetAlwaysVisible()
		{
			Distance = 1;
		}

		public Boolean IsNeverVisible
		{
			get => (Distance == 2);
		}
		public void SetNeverVisible()
		{
			Distance = 2;
		}
	}
}
