using System;
using System.Linq;
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
		public Type_64_11_FormationFlightData(short version) : base(64)
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

		public UInt32 FormationTargetID
		{
			get { return GetUInt32(4); }
			set { SetUInt32(4, value); }
		}

		public ITimeSpan Timestamp
		{
			get => GetSingle(0 + 8).Seconds().ToTimeSpan();
			set => SetSingle(0 + 8, (Single)value.TotalSeconds().RawValue);
		}

		public UInt32 ID
		{
			get => GetUInt32(4 + 8);
			set => SetUInt32(4 + 8, value);
		}

		public UInt16 Version
		{
			get => GetUInt16(8 + 8);
			set => SetUInt16(8 + 8, value);
		}

		public IDistance PosX
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(12 + 8).Meters();
					case 4:
						goto case 5;
					case 5:
						return GetSingle(10 + 8).Meters();
					default:
						return 0.Meters();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(12 + 8, (Single)value.ToMeters().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSingle(10 + 8, (Single)value.ToMeters().RawValue);
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
						return GetSingle(16 + 8).Meters();
					case 4:
						goto case 5;
					case 5:
						return GetSingle(14 + 8).Meters();
					default:
						return 0.Meters();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(16 + 8, (Single)value.ToMeters().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSingle(14 + 8, (Single)value.ToMeters().RawValue);
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
						return GetSingle(20 + 8).Meters();
					case 4:
						goto case 5;
					case 5:
						return GetSingle(18 + 8).Meters();
					default:
						return 0.Meters();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(20 + 8, (Single)value.ToMeters().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSingle(18 + 8, (Single)value.ToMeters().RawValue);
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
						return (GetInt16(24 + 8) / 32767f * Math.PI).Radians();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(22 + 8) / 32767f * Math.PI).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(24 + 8, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(22 + 8, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
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
						return (GetInt16(26 + 8) / 32767f * Math.PI).Radians();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(24 + 8) / 32767f * Math.PI).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(26 + 8, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(24 + 8, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
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
						return (GetInt16(28 + 8) / 32767f * Math.PI).Radians();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(26 + 8) / 32767f * Math.PI).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(28 + 8, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(26 + 8, (Int16)(value.ToRadians().RawValue / Math.PI * 32767f));
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
						return (GetInt16(30 + 8) / 10).MetersPerSecond();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(28 + 8) / 10).MetersPerSecond();
					default:
						return 0.MetersPerSecond();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(30 + 8, (Int16)(value.ToMetersPerSecond().RawValue * 10));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(28 + 8, (Int16)(value.ToMetersPerSecond().RawValue * 10));
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
						return (GetInt16(32 + 8) / 10).MetersPerSecond();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(30 + 8) / 10).MetersPerSecond();
					default:
						return 0.MetersPerSecond();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(32 + 8, (Int16)(value.ToMetersPerSecond().RawValue * 10));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(30 + 8, (Int16)(value.ToMetersPerSecond().RawValue * 10));
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
						return (GetInt16(34 + 8) / 10).MetersPerSecond();
					case 4:
						goto case 5;
					case 5:
						return (GetInt16(32 + 8) / 10).MetersPerSecond();
					default:
						return 0.MetersPerSecond();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(34 + 8, (Int16)(value.ToMetersPerSecond().RawValue * 10));
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(32 + 8, (Int16)(value.ToMetersPerSecond().RawValue * 10));
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
						return GetSingle(79 + 8).Radians();
					case 4:
						goto case 5;
					case 5:
						return GetInt16(34 + 8).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(79 + 8, (Single)value.ToRadians().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(34 + 8, (Int16)value.ToRadians().RawValue);
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
						return GetSingle(83 + 8).Radians();
					case 4:
						goto case 5;
					case 5:
						return GetInt16(36 + 8).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(83 + 8, (Single)value.ToRadians().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(36 + 8, (Int16)value.ToRadians().RawValue);
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
						return GetSingle(87 + 8).Radians();
					case 4:
						goto case 5;
					case 5:
						return GetInt16(38 + 8).Radians();
					default:
						return 0.Radians();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(87 + 8, (Single)value.ToRadians().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(38 + 8, (Int16)value.ToRadians().RawValue);
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
						return (Single)(GetInt16(42 + 8) / 10d);
					case 4:
						goto case 5;
					case 5:
						return (Single)(GetByte(62 + 8) / 10d);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(42 + 8, (Int16)(value * 10));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(62 + 8, (byte)(value * 10));
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
						return GetUInt16(44 + 8);
					case 4:
						goto case 5;
					case 5:
						return GetUInt16(54 + 8);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(44 + 8, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetUInt16(54 + 8, value);
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
						return GetUInt16(46 + 8);
					case 4:
						goto case 5;
					case 5:
						return GetByte(58 + 8);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(46 + 8, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(58 + 8, (byte)value);
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
						return GetUInt16(48 + 8);
					case 4:
						goto case 5;
					case 5:
						return GetByte(59 + 8);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(48 + 8, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(59 + 8, (byte)value);
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
						return GetUInt16(50 + 8);
					case 4:
						goto case 5;
					case 5:
						return GetByte(60 + 8);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(50 + 8, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(60 + 8, (byte)value);
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
						return GetInt16(52 + 8).KiloGrams();
					case 4:
						goto case 5;
					case 5:
						return GetByte(40 + 8).KiloGrams();
					default:
						return 0.KiloGrams();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(52 + 8, (Int16)value.ToKiloGrams().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(40 + 8, (byte)value.ToKiloGrams().RawValue);
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
						return GetSingle(54 + 8).KiloGrams();
					case 4:
						goto case 5;
					case 5:
						return GetInt32(42 + 8).KiloGrams();
					default:
						return 0.KiloGrams();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(54 + 8, (Single)value.ToKiloGrams().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt32(42 + 8, (int)value.ToKiloGrams().RawValue);
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
						return GetSingle(48 + 8).KiloGrams();
					case 4:
						goto case 5;
					case 5:
						return GetInt32(46 + 8).KiloGrams();
					default:
						return 0.KiloGrams();
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(48 + 8, (Single)value.ToKiloGrams().RawValue);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt32(46 + 8, (int)value.ToKiloGrams().RawValue);
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
					return GetUInt16(62 + 8);
				}
				if (Version == 4 | Version == 5)
				{
					return GetByte(61 + 8);
				}
				return 0;
			}
			set
			{
				if (Version == 3)
				{
					SetUInt16(62 + 8, value);
				}
				if (Version == 4 | Version == 5)
				{
					SetByte(61 + 8, (byte)value);
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
						return GetByte(64 + 8);
					case 4:
						goto case 5;
					case 5:
						return GetByte(48 + 8);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(64 + 8, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(48 + 8, value);
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
						return GetByte(65 + 8) / 100f;
					case 4:
						goto case 5;
					case 5:
						return GetByte(49 + 8) / 100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(65 + 8, (byte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(49 + 8, (byte)(value * 100));
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
						return GetByte(66 + 8) / 255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)((GetByte(50 + 8) & 240) / 16) / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(66 + 8, (byte)(value * 255));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(50 + 8, (byte)(((byte)(value * 15 * 16) & 240) | ((byte)(AnimGear * 15))));
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
						return GetByte(67 + 8) / 255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(50 + 8) & 15) / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(67 + 8, (byte)(value * 255));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(50 + 8, (byte)((byte)(AnimBoards * 16 * 15) | ((byte)(value * 15) & 15)));
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
						return GetByte(68 + 8) / 255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)((GetByte(51 + 8) & 240) / 16) / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(68 + 8, (byte)(value * 255));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(51 + 8, (byte)(((byte)(value * 15 * 16) & 240) | ((byte)(AnimGear * 15))));
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
						return GetByte(69 + 8) / 255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(51 + 8) & 15) / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(69 + 8, (byte)(value * 255));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(51 + 8, (byte)((byte)(AnimBoards * 16 * 15) | ((byte)(value * 15) & 15)));
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
						return GetByte(70 + 8);
					case 4:
						goto case 5;
					case 5:
						return GetByte(52 + 8);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(70 + 8, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(52 + 8, value);
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
						return GetByte(71 + 8);
					case 4:
						goto case 5;
					case 5:
						return GetByte(53 + 8);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(71 + 8, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(53 + 8, value);
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
						return GetByte(72 + 8) / 100f;
					case 4:
						goto case 5;
					case 5:
						return GetByte(63 + 8) / 100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(72 + 8, (Byte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(63 + 8, (Byte)(value * 100));
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
						return GetSByte(73 + 8) / 100f;
					case 4:
						goto case 5;
					case 5:
						return GetSByte(64 + 8) / 100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(73 + 8, (SByte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(64 + 8, (SByte)(value * 100));
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
						return GetSByte(74 + 8) / 100f;
					case 4:
						goto case 5;
					case 5:
						return GetSByte(65 + 8) / 100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(74 + 8, (SByte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(65 + 8, (SByte)(value * 100));
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
						return GetSByte(75 + 8) / 100f;
					case 4:
						goto case 5;
					case 5:
						return GetSByte(66 + 8) / 100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(75 + 8, (SByte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(66 + 8, (SByte)(value * 100));
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
						return GetSByte(76 + 8) / 100f;
					case 4:
						goto case 5;
					case 5:
						return GetSByte(67 + 8) / 100f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(76 + 8, (SByte)(value * 100));
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(67 + 8, (SByte)(value * 100));
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
						return GetUInt16(77 + 8);
					case 4:
						goto case 5;
					case 5:
						return GetUInt16(56 + 8);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetUInt16(77 + 8, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetUInt16(56 + 8, value);
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
						return GetByte(91 + 8) / 100f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(68 + 8) & 240) / 16 / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(91 + 8, (Byte)(value * 16 * 15));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(68 + 8, (byte)(((byte)(value * 15 * 16) & 240) | ((byte)(AnimThrustReverse * 15))));
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
						return GetByte(92 + 8) / 100f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(68 + 8) & 15) / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(92 + 8, (byte)(value * 15));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(68 + 8, (byte)((byte)(AnimThrustVector * 16 * 15) | ((byte)(value * 15) & 15)));
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
						return GetByte(93 + 8) / 255f;
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(69 + 8) & 240) / 16 / 15f;
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(93 + 8, (Byte)(value * 16 * 15));
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(69 + 8, (byte)(((byte)(value * 15 * 16) & 240) | (GetByte(69 + 8) & 15)));
						break;
				}
			}
		}

		public IPacket_64_11_FormationFlightData ConvertTo_IPacket_64_11_FormationFlightData(IWorldVehicle FormationTarget)
		{
			return this;
		}

		public IPacket_11_FlightData ConvertTo_IPacket_11_FlightData()
		{
			if (!YSFlight.World.Vehicles.Select(x => x.ID).Contains(FormationTargetID))
			{
				//ID not valid, ignore.
				return null;
			}
			IWorldVehicle FormationTarget = YSFlight.World.Vehicles.First(x => x.ID == FormationTargetID);
			IPacket_11_FlightData FlightDataOutput = ObjectFactory.CreatePacket11FlightData((short)Version);
			FlightDataOutput.ResizeData(Data.Length - 8);
			Data.Skip(8).ToArray().CopyTo(FlightDataOutput.Data, 0);
			ICoordinate3 EstimatedPosition = FormationTarget.GetCurrentPositionEstimate();
			FlightDataOutput.PosX = (EstimatedPosition.X.ToMeters().RawValue - PosX.ToMeters().RawValue).Meters();
			FlightDataOutput.PosY = (EstimatedPosition.Y.ToMeters().RawValue - PosY.ToMeters().RawValue).Meters();
			FlightDataOutput.PosZ = (EstimatedPosition.Z.ToMeters().RawValue - PosZ.ToMeters().RawValue).Meters();
			return FlightDataOutput;
		}
	}
}
