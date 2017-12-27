using System;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_33_Weather : GenericPacket
	{
		public Type_33_Weather() : base(33)
		{
		}

		public Int32 Lighting
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}
		public Int32 Options
		{
			get => GetInt32(4);
			set => SetInt32(4, value);
		}
		public Boolean ForceObeyLandEverywhere
		{
			get => (Options & (1 << 7)) == (1 << 7);
			set
			{
				if (value) Options |= (1 << 7);
				else Options &= (255-(1<<7));
			}
		}
		public Boolean EnableLandEverywhere
		{
			get => (Options & (1 << 6)) == (1 << 6);
			set
			{
				if (value) Options |= (1 << 6);
				else Options &= (255 - (1 << 6));
			}
		}
		public Boolean ForceObeyCollisions
		{
			get => (Options & (1 << 5)) == (1 << 5);
			set
			{
				if (value) Options |= (1 << 5);
				else Options &= (255 - (1 << 5));
			}
		}
		public Boolean EnableCollisions
		{
			get => (Options & (1 << 4)) == (1 << 4);
			set
			{
				if (value) Options |= (1 << 4);
				else Options &= (255 - (1 << 4));
			}
		}
		public Boolean ForceObeyBlackOut
		{
			get => (Options & (1 << 3)) == (1 << 3);
			set
			{
				if (value) Options |= (1 << 3);
				else Options &= (255 - (1 << 3));
			}
		}
		public Boolean EnableBlackOut
		{
			get => (Options & (1 << 2)) == (1 << 2);
			set
			{
				if (value) Options |= (1 << 2);
				else Options &= (255 - (1 << 2));
			}
		}
		public Boolean ForceObeyFog
		{
			get => (Options & (1 << 1)) == (1 << 1);
			set
			{
				if (value) Options |= (1 << 1);
				else Options &= (255 - (1 << 1));
			}
		}
		public Boolean EnableFog
		{
			get => (Options & (1 << 0)) == (1 << 0);
			set
			{
				if (value) Options |= (1 << 0);
				else Options &= (255 - (1 << 0));
			}
		}

		public Single WindX
		{
			get => GetSingle(8);
			set => SetSingle(8, value);
		}
		public Single WindY
		{
			get => GetSingle(12);
			set => SetSingle(12, value);
		}
		public Single WindZ
		{
			get => GetSingle(16);
			set => SetSingle(16, value);
		}
	}
}
