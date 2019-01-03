using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_64_11_FormationFlightData : GenericPacket, IPacket_64_11_FormationFlightData
	{
		public Type_64_11_FormationFlightData() : base(64)
		{
			Initialise(3);
		}
		public Type_64_11_FormationFlightData(short version) : base(11)
		{
			Initialise(version);
		}
		private void Initialise(short version)
		{
			Version = (ushort)version;
			if (Version == 3)
			{
				UserPacketHeader = 11;
				ResizeData(4+93);
			}
			else
			{
				UserPacketHeader = 11;
				ResizeData(4+63);
			}
		}

		public UInt32 UserPacketHeader
		{
			get { return GetUInt32(0); }
			set { SetUInt32(0, value); }
		}

		public ITime Timestamp
		{
			get => GetSingle(0 + 4).Seconds().ToTime();
			set => SetSingle(0 + 4, (Single)value.Second.RawValue);
		}

		public UInt32 ID
		{
			get => GetUInt32(4 + 4);
			set => SetUInt32(4 + 4, value);
		}

		public UInt16 Version
		{
			get => GetUInt16(8 + 4);
			set => SetUInt16(8 + 4, value);
		}

		public IDistance PosX
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(12 + 4).Meters();
					case 4:
						goto case 5;
					case 5:
						return GetSingle(10 + 4).Meters();
					default:
						return 0.Meters();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(12 + 4, (Single)value.ToMeters().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSingle(10 + 4, (Single)value.ToMeters().RawValue);
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
						return GetSingle(16 + 4).Meters();
					case 4:
						goto case 5;
					case 5:
						return GetSingle(14 + 4).Meters();
					default:
						return 0.Meters();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(16 + 4, (Single)value.ToMeters().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSingle(14 + 4, (Single)value.ToMeters().RawValue);
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
						return GetSingle(20 + 4).Meters();
					case 4:
						goto case 5;
					case 5:
						return GetSingle(18 + 4).Meters();
					default:
						return 0.Meters();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(20 + 4, (Single)value.ToMeters().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSingle(18 + 4, (Single)value.ToMeters().RawValue);
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
						return (GetInt16(24 + 4) / 32767f * Math.PI).Radians();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(22 + 4) / 32767f * Math.PI).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(24 + 4, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(22 + 4, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
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
						return (GetInt16(26 + 4) / 32767f * Math.PI).Radians();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(24 + 4) / 32767f * Math.PI).Radians();
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
						return (GetInt16(28 + 4) / 32767f * Math.PI).Radians();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(26 + 4) / 32767f * Math.PI).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(28 + 4, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(26 + 4, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
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
						return (GetInt16(30 + 4) / 10).MetersPerSecond();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(28 + 4) / 10).MetersPerSecond();
					default:
						return 0.MetersPerSecond();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(30 + 4, (Int16)(value.ToMetersPerSecond().RawValue * 10));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(28 + 4, (Int16)(value.ToMetersPerSecond().RawValue * 10));
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
						return (GetInt16(32 + 4) / 10).MetersPerSecond();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(30 + 4) / 10).MetersPerSecond();
					default:
						return 0.MetersPerSecond();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(32 + 4, (Int16)(value.ToMetersPerSecond().RawValue * 10));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(30 + 4, (Int16)(value.ToMetersPerSecond().RawValue * 10));
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
						return (GetInt16(34 + 4) / 10).MetersPerSecond();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(32 + 4) / 10).MetersPerSecond();
					default:
						return 0.MetersPerSecond();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(34 + 4, (Int16)(value.ToMetersPerSecond().RawValue * 10));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(32 + 4, (Int16)(value.ToMetersPerSecond().RawValue * 10));
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
						return GetSingle(79 + 4).Radians();
					case 4:
						goto case 5;
					case 5:
						return GetInt16(34 + 4).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(79 + 4, (Single)value.ToRadians().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(34 + 4, (Int16)value.ToRadians().RawValue);
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
						return GetSingle(83 + 4).Radians();
					case 4:
						goto case 5;
					case 5:
						return GetInt16(36 + 4).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(83 + 4, (Single)value.ToRadians().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(36 + 4, (Int16)value.ToRadians().RawValue);
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
						return GetSingle(87 + 4).Radians();
					case 4:
						goto case 5;
					case 5:
						return GetInt16(38 + 4).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(87 + 4, (Single)value.ToRadians().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(38 + 4, (Int16)value.ToRadians().RawValue);
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
						return (Single)(GetInt16(42 + 4) / 10d);
					case 4:
						goto case 5;
					case 5:
						return (Single)(GetByte(62 + 4) / 10d);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(42 + 4, (Int16)(value * 10));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(62 + 4, (byte)(value * 10));
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
						return GetUInt16(44 + 4);
					case 4:
						goto case 5;
					case 5:
						return GetUInt16(54 + 4);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(44 + 4, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetUInt16(54 + 4, value);
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
						return GetUInt16(46 + 4);
					case 4:
						goto case 5;
					case 5:
						return GetByte(58 + 4);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(46 + 4, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(58 + 4, (byte)value);
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
						return GetUInt16(48 + 4);
					case 4:
						goto case 5;
					case 5:
						return GetByte(59 + 4);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(48 + 4, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(59 + 4, (byte)value);
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
						return GetUInt16(50 + 4);
					case 4:
						goto case 5;
					case 5:
						return GetByte(60 + 4);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(50 + 4, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(60 + 4, (byte)value);
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
						return GetInt16(52 + 4).KiloGrams();
					case 4:
						goto case 5;
					case 5:
						return GetByte(40 + 4).KiloGrams();
					default:
						return 0.KiloGrams();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(52 + 4, (Int16)value.ToKiloGrams().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(40 + 4, (byte)value.ToKiloGrams().RawValue);
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
						return GetSingle(54 + 4).KiloGrams();
					case 4:
						goto case 5;
					case 5:
						return GetInt32(42 + 4).KiloGrams();
					default:
						return 0.KiloGrams();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(54 + 4, (Single)value.ToKiloGrams().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt32(42 + 4, (int)value.ToKiloGrams().RawValue);
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
						return GetSingle(48 + 4).KiloGrams();
					case 4:
						goto case 5;
					case 5:
						return GetInt32(46 + 4).KiloGrams();
					default:
						return 0.KiloGrams();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(48 + 4, (Single)value.ToKiloGrams().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt32(46 + 4, (int)value.ToKiloGrams().RawValue);
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
					return GetUInt16(62 + 4);
				}
				if (Version == 4 | Version == 5)
				{
					return GetByte(61 + 4);
				}
				return 0;
			}
			set
			{
				if (Version == 3)
				{
					SetUInt16(62 + 4, value);
				}
				if (Version == 4 | Version == 5)
				{
					SetByte(61 + 4, (byte)value);
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
						return GetByte(64 + 4);
					case 4:
						goto case 5;
					case 5:
						return GetByte(48 + 4);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(64 + 4, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(48 + 4, value);
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
						return GetByte(65 + 4) / 100f;
					case 4:
						goto case 5;
					case 5:
						return GetByte(49 + 4) / 100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(65 + 4, (byte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(49 + 4, (byte)(value * 100));
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
						return GetByte(66 + 4) / 255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)((GetByte(50 + 4) & 240) / 16) / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(66 + 4, (byte)(value * 255));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(50 + 4, (byte)(((byte)(value * 15 * 16) & 240) | ((byte)(AnimGear * 15))));
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
						return GetByte(67 + 4) / 255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(50 + 4) & 15) / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(67 + 4, (byte)(value * 255));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(50 + 4, (byte)((byte)(AnimBoards * 16 * 15) | ((byte)(value * 15) & 15)));
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
						return GetByte(68 + 4) / 255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)((GetByte(51 + 4) & 240) / 16) / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(68 + 4, (byte)(value * 255));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(51 + 4, (byte)(((byte)(value * 15 * 16) & 240) | ((byte)(AnimGear * 15))));
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
						return GetByte(69 + 4) / 255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(51 + 4) & 15) / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(69 + 4, (byte)(value * 255));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(51 + 4, (byte)((byte)(AnimBoards * 16 * 15) | ((byte)(value * 15) & 15)));
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
						return GetByte(70 + 4);
					case 4:
						goto case 5;
					case 5:
						return GetByte(52 + 4);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(70 + 4, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(52 + 4, value);
						break;
				}
			}
		}
		public Boolean AnimLightLand
		{
			get => ((byte)(AnimFlags & (1 << 7)) == (1 << 7));
			set
			{
				if (value) AnimFlags |= (1 << 7);
				else AnimFlags &= (byte)(255 - (1 << 7));
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
						return GetByte(71 + 4);
					case 4:
						goto case 5;
					case 5:
						return GetByte(53 + 4);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(71 + 4, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(53 + 4, value);
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
						return GetByte(72 + 4) / 100f;
					case 4:
						goto case 5;
					case 5:
						return GetByte(63 + 4) / 100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(72 + 4, (Byte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(63 + 4, (Byte)(value * 100));
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
						return GetSByte(73 + 4) / 100f;
					case 4:
						goto case 5;
					case 5:
						return GetSByte(64 + 4) / 100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(73 + 4, (SByte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(64 + 4, (SByte)(value * 100));
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
						return GetSByte(74 + 4) / 100f;
					case 4:
						goto case 5;
					case 5:
						return GetSByte(65 + 4) / 100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(74 + 4, (SByte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(65 + 4, (SByte)(value * 100));
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
						return GetSByte(75 + 4) / 100f;
					case 4:
						goto case 5;
					case 5:
						return GetSByte(66 + 4) / 100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(75 + 4, (SByte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(66 + 4, (SByte)(value * 100));
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
						return GetSByte(76 + 4) / 100f;
					case 4:
						goto case 5;
					case 5:
						return GetSByte(67 + 4) / 100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(76 + 4, (SByte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(67 + 4, (SByte)(value * 100));
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
						return GetUInt16(77 + 4);
					case 4:
						goto case 5;
					case 5:
						return GetUInt16(56 + 4);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(77 + 4, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetUInt16(56 + 4, value);
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
						return GetByte(91 + 4) / 100f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(68 + 4) & 240) / 16 / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(91 + 4, (Byte)(value * 16 * 15));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(68 + 4, (byte)(((byte)(value * 15 * 16) & 240) | ((byte)(AnimThrustReverse * 15))));
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
						return GetByte(92 + 4) / 100f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(68 + 4) & 15) / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(92 + 4, (byte)(value * 15));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(68 + 4, (byte)((byte)(AnimThrustVector * 16 * 15) | ((byte)(value * 15) & 15)));
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
						return GetByte(93 + 4) / 255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(69 + 4) & 240) / 16 / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(93 + 4, (Byte)(value * 16 * 15));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(69 + 4, (byte)(((byte)(value * 15 * 16) & 240) | (GetByte(69 + 4) & 15)));
						break;
				}
			}
		}

		public IPacket_11_FlightData ConvertTo_IPacket_11_FlightData(IWorldVehicle FormationTarget)
		{
			IPacket_11_FlightData FlightDataOutput = ObjectFactory.CreatePacket11FlightData((short)Version);
			FlightDataOutput.ResizeData(FlightDataOutput.Data.Length + 4);
			Data.CopyTo(FlightDataOutput.Data, 0);
			FlightDataOutput.PosX = (PosX.ToMeters().RawValue - FormationTarget.Position.X.ToMeters().RawValue).Meters();
			FlightDataOutput.PosY = (PosY.ToMeters().RawValue - FormationTarget.Position.Y.ToMeters().RawValue).Meters();
			FlightDataOutput.PosZ = (PosZ.ToMeters().RawValue - FormationTarget.Position.Z.ToMeters().RawValue).Meters();
			return FlightDataOutput;
		}
	}
}
