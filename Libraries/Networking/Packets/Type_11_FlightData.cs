using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_11_FlightData : GenericPacket
	{
		public Type_11_FlightData() : base(11)
		{
			Initialise(3);
		}
		public Type_11_FlightData(short version)
		{
			Initialise(version);
		}
		private void Initialise(short version)
		{
			Version = version;
			if (Version == 3)
			{
				ResizeData(93);
			}
			else
			{
				ResizeData(63);
			}
		}

		public Single Timestamp
		{
			get => GetSingle(0);
			set => SetSingle(0, value);
		}

		public Int32 EntityID
		{
			get => GetInt32(4);
			set => SetInt32(4, value);
		}

		public Int16 Version
		{
			get => GetInt16(8);
			set => SetInt16(8, value);
		}

		public Single PosX
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(12);
					case 4:
						goto case 5;
					case 5:
						return GetSingle(10);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(12, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSingle(10, value);
						break;
				}
			}
		}
		public Single PosY
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(16);
					case 4:
						goto case 5;
					case 5:
						return GetSingle(14);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(16, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSingle(14, value);
						break;
				}
			}
		}
		public Single PosZ
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(20);
					case 4:
						goto case 5;
					case 5:
						return GetSingle(18);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(20, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSingle(18, value);
						break;
				}
			}
		}

		public Int16 HdgX
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(24);
					case 4:
						goto case 5;
					case 5:
						return GetInt16(22);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(24, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(22, value);
						break;
				}
			}
		}
		public Int16 HdgY
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(26);
					case 4:
						goto case 5;
					case 5:
						return GetInt16(24);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(26, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(24, value);
						break;
				}
			}
		}
		public Int16 HdgZ
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(28);
					case 4:
						goto case 5;
					case 5:
						return GetInt16(26);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(28, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(26, value);
						break;
				}
			}
		}

		public Int16 V_PosX
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(30);
					case 4:
						goto case 5;
					case 5:
						return GetInt16(28);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(30, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(28, value);
						break;
				}
			}
		}
		public Int16 V_PosY
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(32);
					case 4:
						goto case 5;
					case 5:
						return GetInt16(30);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(32, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(30, value);
						break;
				}
			}
		}
		public Int16 V_PosZ
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(34);
					case 4:
						goto case 5;
					case 5:
						return GetInt16(32);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(34, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(32, value);
						break;
				}
			}
		}

		public Single V_HdgX
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(79);
					case 4:
						goto case 5;
					case 5:
						return GetInt16(34);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(79, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(34, (Int16)value);
						break;
				}
			}
		}
		public Single V_HdgY
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(83);
					case 4:
						goto case 5;
					case 5:
						return GetInt16(36);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(83, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(36, (Int16)value);
						break;
				}
			}
		}
		public Single V_HdgZ
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(87);
					case 4:
						goto case 5;
					case 5:
						return GetInt16(38);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(87, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(38, (Int16)value);
						break;
				}
			}
		}

		public Int16 LoadFactor
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(42);
					case 4:
						goto case 5;
					case 5:
						return GetByte(62);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(42, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(62, (byte)value);
						break;
				}
			}
		}

		public Int16 AmmoGUN
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(44);
					case 4:
						goto case 5;
					case 5:
						return GetInt16(54);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(44, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(54, value);
						break;
				}
			}
		}
		public Int16 AmmoAAM
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(46);
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
						SetInt16(46, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(58, (byte)value);
						break;
				}
			}
		}
		public Int16 AmmoAGM
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(48);
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
						SetInt16(48, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(59, (byte)value);
						break;
				}
			}
		}
		public Int16 AmmoB500
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(50);
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
						SetInt16(50, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(60, (byte)value);
						break;
				}
			}
		}

		public Int16 WeightSmokeOil
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(52);
					case 4:
						goto case 5;
					case 5:
						return GetByte(40);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(52, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(40, (byte)value);
						break;
				}
			}
		}
		public Single WeightFuel
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(54);
					case 4:
						goto case 5;
					case 5:
						return GetInt32(42);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(54, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt32(42, (int)value);
						break;
				}
			}
		}
		public Single WeightEmpty
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSingle(48);
					case 4:
						goto case 5;
					case 5:
						return GetInt32(46);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSingle(48, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt32(46, (int)value);
						break;
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

		public Byte AnimVGW
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(65);
					case 4:
						goto case 5;
					case 5:
						return GetByte(49);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(65, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(49, value);
						break;
				}
			}
		}

		public Byte AnimBoards
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(66);
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(50) & 240);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(66, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(50, (byte)((value & 240)|(AnimGear)));
						break;
				}
			}
		}
		public Byte AnimGear
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(67);
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(50) & 15);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(67, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(50, (byte)((AnimBoards)|(value & 15)));
						break;
				}
			}
		}
		public Byte AnimFlap
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(68);
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(51) & 240);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(66, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(50, (byte)((value & 240) | (AnimBrake)));
						break;
				}
			}
		}
		public Byte AnimBrake
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(69);
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(51) & 15);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(69, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(51, (byte)((AnimFlap) | (value & 15)));
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
		public Boolean Anim_Light_Land
		{
			get => ((byte)(AnimFlags & (1<<7)) == (1<<7));		
			set
			{
				if (value) AnimFlags |= (1<<7);
				else AnimFlags &= (byte)(255 - (1<<7));
			}
		}
		public Boolean Anim_Light_Strobe
		{
			get => ((byte)(AnimFlags & (1 << 6)) == (1 << 6));
			set
			{
				if (value) AnimFlags |= (1 << 6);
				else AnimFlags &= (byte)(255 - (1 << 6));
			}
		}
		public Boolean Anim_Light_Nav
		{
			get => ((byte)(AnimFlags & (1 << 5)) == (1 << 5));
			set
			{
				if (value) AnimFlags |= (1 << 5);
				else AnimFlags &= (byte)(255 - (1 << 5));
			}
		}
		public Boolean Anim_Light_Beacon
		{
			get => ((byte)(AnimFlags & (1 << 4)) == (1 << 4));
			set
			{
				if (value) AnimFlags |= (1 << 4);
				else AnimFlags &= (byte)(255 - (1 << 4));
			}
		}
		public Boolean Anim_Guns
		{
			get => ((byte)(AnimFlags & (1 << 3)) == (1 << 3));
			set
			{
				if (value) AnimFlags |= (1 << 3);
				else AnimFlags &= (byte)(255 - (1 << 3));
			}
		}
		public Boolean Anim_Contrails
		{
			get => ((byte)(AnimFlags & (1 << 2)) == (1 << 2));
			set
			{
				if (value) AnimFlags |= (1 << 2);
				else AnimFlags &= (byte)(255 - (1 << 2));
			}
		}
		public Boolean Anim_Smoke
		{
			get => ((byte)(AnimFlags & (1 << 1)) == (1 << 1));
			set
			{
				if (value) AnimFlags |= (1 << 1);
				else AnimFlags &= (byte)(255 - (1 << 1));
			}
		}
		public Boolean Anim_Burners
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

		public Byte AnimThrottle
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(72);
					case 4:
						goto case 5;
					case 5:
						return GetByte(63);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(72, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(63, value);
						break;
				}
			}
		}
		public SByte AnimElevator
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSByte(73);
					case 4:
						goto case 5;
					case 5:
						return GetSByte(64);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(73, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(64, value);
						break;
				}
			}
		}
		public SByte AnimAileron
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSByte(74);
					case 4:
						goto case 5;
					case 5:
						return GetSByte(65);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(74, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(65, value);
						break;
				}
			}
		}
		public SByte AnimRudder
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSByte(75);
					case 4:
						goto case 5;
					case 5:
						return GetSByte(66);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(75, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(66, value);
						break;
				}
			}
		}
		public SByte AnimTrim
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetSByte(76);
					case 4:
						goto case 5;
					case 5:
						return GetSByte(67);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetSByte(76, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetSByte(67, value);
						break;
				}
			}
		}

		public Int16 AmmoRKT
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetInt16(77);
					case 4:
						goto case 5;
					case 5:
						return GetInt16(56);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetInt16(77, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetInt16(56, value);
						break;
				}
			}
		}

		public Byte AnimNozzle
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(91);
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(68) & 240);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(91, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(68, (byte)((value & 240) | (AnimReverse)));
						break;
				}
			}
		}
		public Byte AnimReverse
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(92);
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(68) & 15);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(92, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(68, (byte)((AnimNozzle) | (value & 15)));
						break;
				}
			}
		}

		public Byte AnimBombBay
		{
			get
			{
				switch (Version)
				{
					case 3:
						return GetByte(93);
					case 4:
						goto case 5;
					case 5:
						return (byte)(GetByte(69) & 240);
					default:
						return 0;
				}
			}
			set
			{
				switch (Version)
				{
					case 3:
						SetByte(93, value);
						break;
					case 4:
						goto case 5;
					case 5:
						SetByte(69, (byte)((value & 240) | (GetByte(69) & 15)));
						break;
				}
			}
		}
	}
}
