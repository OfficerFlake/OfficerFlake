using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_11_FlightData : GenericPacket, IPacket_11_FlightData
	{
		public Type_11_FlightData() : base(11)
		{
			Initialise(3);
		}
		public Type_11_FlightData(short version) : base(11)
		{
			Initialise(version);
		}
		private void Initialise(short version)
		{
			Version = (ushort)version;
			if (Version == 3)
			{
				ResizeData(93);
			}
			else
			{
				ResizeData(63);
			}
		}

		public ITime Timestamp
		{
			get => GetSingle(0).Seconds().ToTime();
			set => SetSingle(0, (Single)value.Second.RawValue);
		}

		public UInt32 ID
		{
			get => GetUInt32(4);
			set => SetUInt32(4, value);
		}

		public UInt16 Version
		{
			get => GetUInt16(8);
			set => SetUInt16(8, value);
		}

		public IDistance PosX
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(12).Meters();
					case 4:
						goto case 5;
					case 5:
						return GetSingle(10).Meters();
					default:
						return 0.Meters();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(12, (Single)value.ToMeters().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSingle(10, (Single)value.ToMeters().RawValue);
						break;
				}
			}
		}
		public IDistance PosY
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(16).Meters();
					case 4:
						goto case 5;
					case 5:
						return GetSingle(14).Meters();
					default:
						return 0.Meters();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(16, (Single)value.ToMeters().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSingle(14, (Single)value.ToMeters().RawValue);
						break;
				}
			}
		}
		public IDistance PosZ
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(20).Meters();
					case 4:
						goto case 5;
					case 5:
						return GetSingle(18).Meters();
					default:
						return 0.Meters();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(20, (Single)value.ToMeters().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSingle(18, (Single)value.ToMeters().RawValue);
						break;
				}
			}
		}

		public IAngle HdgH
		{
			get
			{
				switch (Version)
				{
					case 3:
						return (GetInt16(24) / 32767f * Math.PI).Radians();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(22) / 32767f * Math.PI).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(24, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(22, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
						break;
				}
			}
		}
		public IAngle HdgP
		{
			get
			{
				switch (Version)
				{
					case 3:
						return (GetInt16(26) / 32767f * Math.PI).Radians();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(24) / 32767f * Math.PI).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(26, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(24, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
						break;
				}
			}
		}
		public IAngle HdgB
		{
			get
			{
				switch (Version)
				{
					case 3:
						return (GetInt16(28) / 32767f * Math.PI).Radians();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(26) / 32767f * Math.PI).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(28, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(26, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
						break;
				}
			}
		}

		public ISpeed V_PosX
		{
			get
			{
				switch (Version)
				{
					case 3:
						return (GetInt16(30)/10).MetersPerSecond();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(28)/10).MetersPerSecond();
					default:
						return 0.MetersPerSecond();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(30, (Int16)(value.ToMetersPerSecond().RawValue * 10));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(28, (Int16)(value.ToMetersPerSecond().RawValue * 10));
						break;
				}
			}
		}
		public ISpeed V_PosY
		{
			get
			{
				switch (Version)
				{
					case 3:
						return (GetInt16(32) / 10).MetersPerSecond();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(30) / 10).MetersPerSecond();
					default:
						return 0.MetersPerSecond();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(32, (Int16)(value.ToMetersPerSecond().RawValue * 10));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(30, (Int16)(value.ToMetersPerSecond().RawValue * 10));
						break;
				}
			}
		}
		public ISpeed V_PosZ
		{
			get
			{
				switch (Version)
				{
					case 3:
						return (GetInt16(34) / 10).MetersPerSecond();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(32) / 10).MetersPerSecond();
					default:
						return 0.MetersPerSecond();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(34, (Int16)(value.ToMetersPerSecond().RawValue * 10));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(32, (Int16)(value.ToMetersPerSecond().RawValue * 10));
						break;
				}
			}
		}

		public IAngle V_HdgH
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(79).Radians();
					case 4:
						goto case 5;
					case 5:
						return GetInt16(34).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(79, (Single)value.ToRadians().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(34, (Int16)value.ToRadians().RawValue);
						break;
				}
			}
		}
		public IAngle V_HdgP
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(83).Radians();
					case 4:
						goto case 5;
					case 5:
						return GetInt16(36).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(83, (Single)value.ToRadians().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(36, (Int16)value.ToRadians().RawValue);
						break;
				}
			}
		}
		public IAngle V_HdgB
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(87).Radians();
					case 4:
						goto case 5;
					case 5:
						return GetInt16(38).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(87, (Single)value.ToRadians().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(38, (Int16)value.ToRadians().RawValue);
						break;
				}
			}
		}

		public Single LoadFactor
		{
			get
			{
				switch (Version)
				{
					case 3:
						return (Single)(GetInt16(42)/10d);
					case 4:
						goto case 5;
					case 5:
						return (Single)(GetByte(62)/10d);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(42, (Int16)(value*10));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(62, (byte)(value*10));
						break;
				}
			}
		}

		public UInt16 AmmoGUN
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetUInt16(44);
					case 4:
						goto case 5;
					case 5:
						return GetUInt16(54);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(44, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetUInt16(54, value);
						break;
				}
			}
		}
		public UInt16 AmmoAAM
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetUInt16(46);
					case 4:
						goto case 5;
					case 5:
						return GetByte(58);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(46, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(58, (byte)value);
						break;
				}
			}
		}
		public UInt16 AmmoAGM
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetUInt16(48);
					case 4:
						goto case 5;
					case 5:
						return GetByte(59);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(48, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(59, (byte)value);
						break;
				}
			}
		}
		public UInt16 AmmoB500
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetUInt16(50);
					case 4:
						goto case 5;
					case 5:
						return GetByte(60);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(50, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(60, (byte)value);
						break;
				}
			}
		}

		public IMass WeightSmokeOil
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(52).KiloGrams();
					case 4:
						goto case 5;
					case 5:
						return GetByte(40).KiloGrams();
					default:
						return 0.KiloGrams();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(52, (Int16)value.ToKiloGrams().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(40, (byte)value.ToKiloGrams().RawValue);
						break;
				}
			}
		}
		public IMass WeightFuel
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(54).KiloGrams();
					case 4:
						goto case 5;
					case 5:
						return GetInt32(42).KiloGrams();
					default:
						return 0.KiloGrams();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(54, (Single)value.ToKiloGrams().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt32(42, (int)value.ToKiloGrams().RawValue);
						break;
				}
			}
		}
		public IMass WeightClean
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(48).KiloGrams();
					case 4:
						goto case 5;
					case 5:
						return GetInt32(46).KiloGrams();
					default:
						return 0.KiloGrams();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(48, (Single)value.ToKiloGrams().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt32(46, (int)value.ToKiloGrams().RawValue);
						break;
				}
			}
		}

		public UInt16 Strength
		{
			get
			{
				if (Version == 3)
				{
					return GetUInt16(62);
				}
				if (Version == 4 | Version == 5)
				{
					return GetByte(61);
				}
				return 0;
			}
			set
			{
				if (Version == 3)
				{
					SetUInt16(62, value);
				}
				if (Version == 4 | Version == 5)
				{
					SetByte(61, (byte)value);
				}
			}
		}

		public Byte FlightState
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(64);
					case 4:
						goto case 5;
					case 5:
						return GetByte(48);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(64, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(48, value);
						break;
				}
			}
		}

		public Single AnimVGW
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(65)/100f;
					case 4:
						goto case 5;
					case 5:
						return GetByte(49)/100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(65, (byte)(value*100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(49, (byte)(value * 100));
						break;
				}
			}
		}

		public Single AnimBoards
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(66)/255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)((GetByte(50) & 240)/16)/15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(66, (byte)(value*255));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(50, (byte)(((byte)(value*15*16) & 240)|((byte)(AnimGear*15))));
						break;
				}
			}
		}
		public Single AnimGear
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(67)/255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(50) & 15)/15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(67, (byte)(value*255));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(50, (byte)((byte)(AnimBoards*16*15)|((byte)(value*15) & 15)));
						break;
				}
			}
		}
		public Single AnimFlaps
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(68) / 255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)((GetByte(51) & 240) / 16) / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(68, (byte)(value * 255));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(51, (byte)(((byte)(value * 15 * 16) & 240) | ((byte)(AnimGear * 15))));
						break;
				}
			}
		}
		public Single AnimBrake
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(69) / 255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(51) & 15) / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(69, (byte)(value * 255));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(51, (byte)((byte)(AnimBoards * 16 * 15) | ((byte)(value * 15) & 15)));
						break;
				}
			}
		}

		public Byte AnimFlags
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(70);
					case 4:
						goto case 5;
					case 5:
						return GetByte(52);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(70, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(52, value);
						break;
				}
			}
		}
		public Boolean AnimLightLand
		{
			get => ((byte)(AnimFlags & (1<<7)) == (1<<7));		
			set
			{
				if (value) AnimFlags |= (1<<7);
				else AnimFlags &= (byte)(255 - (1<<7));
			}
		}
		public Boolean AnimLightStrobe
		{
			get => ((byte)(AnimFlags & (1 << 6)) == (1 << 6));
			set
			{
				if (value) AnimFlags |= (1 << 6);
				else AnimFlags &= (byte)(255 - (1 << 6));
			}
		}
		public Boolean AnimLightNav
		{
			get => ((byte)(AnimFlags & (1 << 5)) == (1 << 5));
			set
			{
				if (value) AnimFlags |= (1 << 5);
				else AnimFlags &= (byte)(255 - (1 << 5));
			}
		}
		public Boolean AnimLightBeacon
		{
			get => ((byte)(AnimFlags & (1 << 4)) == (1 << 4));
			set
			{
				if (value) AnimFlags |= (1 << 4);
				else AnimFlags &= (byte)(255 - (1 << 4));
			}
		}
		public Boolean AnimGuns
		{
			get => ((byte)(AnimFlags & (1 << 3)) == (1 << 3));
			set
			{
				if (value) AnimFlags |= (1 << 3);
				else AnimFlags &= (byte)(255 - (1 << 3));
			}
		}
		public Boolean AnimContrails
		{
			get => ((byte)(AnimFlags & (1 << 2)) == (1 << 2));
			set
			{
				if (value) AnimFlags |= (1 << 2);
				else AnimFlags &= (byte)(255 - (1 << 2));
			}
		}
		public Boolean AnimSmoke
		{
			get => ((byte)(AnimFlags & (1 << 1)) == (1 << 1));
			set
			{
				if (value) AnimFlags |= (1 << 1);
				else AnimFlags &= (byte)(255 - (1 << 1));
			}
		}
		public Boolean AnimBurners
		{
			get => ((byte)(AnimFlags & (1 << 0)) == (1 << 0));
			set
			{
				if (value) AnimFlags |= (1 << 0);
				else AnimFlags &= (byte)(255 - (1 << 0));
			}
		}

		public Byte CPUFlags
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(71);
					case 4:
						goto case 5;
					case 5:
						return GetByte(53);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(71, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(53, value);
						break;
				}
			}
		}

		public Single AnimThrottle
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(72)/100f;
					case 4:
						goto case 5;
					case 5:
						return GetByte(63)/100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(72, (Byte)(value*100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(63, (Byte)(value*100));
						break;
				}
			}
		}
		public Single AnimElevator
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSByte(73)/100f;
					case 4:
						goto case 5;
					case 5:
						return GetSByte(64)/100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(73, (SByte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(64, (SByte)(value * 100));
						break;
				}
			}
		}
		public Single AnimAileron
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSByte(74)/100f;
					case 4:
						goto case 5;
					case 5:
						return GetSByte(65)/100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(74, (SByte)(value*100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(65, (SByte)(value * 100));
						break;
				}
			}
		}
		public Single AnimRudder
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSByte(75)/100f;
					case 4:
						goto case 5;
					case 5:
						return GetSByte(66)/100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(75, (SByte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(66, (SByte)(value * 100));
						break;
				}
			}
		}
		public Single AnimTrim
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSByte(76)/100f;
					case 4:
						goto case 5;
					case 5:
						return GetSByte(67)/100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(76, (SByte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(67, (SByte)(value * 100));
						break;
				}
			}
		}

		public UInt16 AmmoRKT
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetUInt16(77);
					case 4:
						goto case 5;
					case 5:
						return GetUInt16(56);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(77, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetUInt16(56, value);
						break;
				}
			}
		}

		public Single AnimThrustVector
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(91)/100f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(68) & 240)/16/15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(91, (Byte)(value*16*15));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(68, (byte)(((byte)(value * 15 * 16) & 240) | ((byte)(AnimThrustReverse * 15))));
						break;
				}
			}
		}
		public Single AnimThrustReverse
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(92)/100f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(68) & 15)/15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(92, (byte)(value*15));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(68, (byte)((byte)(AnimThrustVector * 16 * 15) | ((byte)(value * 15) & 15)));
						break;
				}
			}
		}

		public Single AnimBombBay
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(93)/255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(69) & 240)/16/15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(93, (Byte)(value*16*15));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(69, (byte)(((byte)(value * 15 * 16) & 240) | (GetByte(69) & 15)));
						break;
				}
			}
		}

		public IPacket_64_11_FormationFlightData ConvertTo_IPacket_64_11_FormationFlightData(IWorldVehicle FormationTarget)
		{
			IPacket_64_11_FormationFlightData FlightDataOutput = ObjectFactory.CreatePacket64_11FormationFlightData((short)Version);
			Data.CopyTo(FlightDataOutput.Data, 4);
			FlightDataOutput.PosX = (PosX.ToMeters().RawValue - FormationTarget.Position.X.ToMeters().RawValue).Meters();
			FlightDataOutput.PosY = (PosY.ToMeters().RawValue - FormationTarget.Position.Y.ToMeters().RawValue).Meters();
			FlightDataOutput.PosZ = (PosZ.ToMeters().RawValue - FormationTarget.Position.Z.ToMeters().RawValue).Meters();
			return FlightDataOutput;
		}
	}
}
