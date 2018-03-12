using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_33_Weather : GenericPacket, IPacket_33_Weather
	{
		public Type_33_Weather() : base(33)
		{
		}

		public void Initialise()
		{
			ResizeData(24);
			Lighting = Packet_33WeatherLighting.Day;
			ForceObeyLandEverywhere = true;
			EnableLandEverywhere = true;
			ForceObeyCollisions = true;
			EnableCollisions = false;
			ForceObeyBlackOut = false;
			EnableBlackOut = true;
			ForceObeyVisibility = true;
			EnableVisibility = true;
			WindX = 0.MetersPerSecond();
			WindY = 0.MetersPerSecond();
			WindZ = 0.MetersPerSecond();
			Visibility = 20000.Meters();
		}

		public Packet_33WeatherLighting Lighting
		{
			get
			{
				Int32 subData = GetInt32(0);
				return subData >= 65537 ? Packet_33WeatherLighting.Night : Packet_33WeatherLighting.Day;
			}
			set
			{
				switch (value)
				{
					default:
					case Packet_33WeatherLighting.Day:
						SetInt32(0, 0);
						break;
					case Packet_33WeatherLighting.Night:
						SetInt32(0, 65537);
						break;
				}
			}
		}
		public Byte Options
		{
			get => GetByte(4);
			set => SetByte(4, value);
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
		public Boolean ForceObeyVisibility
		{
			get => (Options & (1 << 1)) == (1 << 1);
			set
			{
				if (value) Options |= (1 << 1);
				else Options &= (255 - (1 << 1));
			}
		}
		public Boolean EnableVisibility
		{
			get => (Options & (1 << 0)) == (1 << 0);
			set
			{
				if (value) Options |= (1 << 0);
				else Options &= (255 - (1 << 0));
			}
		}

		public ISpeed WindX
		{
			get => GetSingle(8).MetersPerSecond();
			set => SetSingle(8, (Single)(value.ToMetersPerSecond().RawValue));
		}
		public ISpeed WindY
		{
			get => GetSingle(12).MetersPerSecond();
			set => SetSingle(12, (Single)(value.ToMetersPerSecond().RawValue));
		}
		public ISpeed WindZ
		{
			get => GetSingle(16).MetersPerSecond();
			set => SetSingle(16, (Single)(value.ToMetersPerSecond().RawValue));
		}

		public IDistance Visibility
		{
			get => GetSingle(20).Meters();
			set => SetSingle(20, (Single)(value.ToMeters().RawValue));
		}
	}
}
