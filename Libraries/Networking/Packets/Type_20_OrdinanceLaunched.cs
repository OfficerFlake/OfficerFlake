using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_20_OrdinanceLaunched : GenericPacket, IPacket_20_OrdinanceSpawn
	{
		public Type_20_OrdinanceLaunched() : base(20)
		{
		}

		public static class OrdinanceTypes
		{
			public const ushort Null = 0;
			public const ushort AAM_Short = 1;
			public const ushort AGM = 2;
			public const ushort B500 = 3;
			public const ushort RKT = 4;
			public const ushort FLR = 5;
			public const ushort AAM_Mid = 6;
			public const ushort B250 = 7;
			public const ushort Unknown_8 = 8;
			public const ushort B500_HD = 9;
			public const ushort AAM_X = 10;
			public const ushort Unknown_11 = 11;
			public const ushort FuelTank = 12;
		}

		public Packet_OrdinanceType OrdinanceType
		{
			//0:2 - OrdinanceType (USHORT)
			//1	    AAM(S)
			//2	    AGM
			//3	    B500
			//4	    RKT
			//5	    FLR
			//6	    AAM(M)
			//7	    B250
			//8	    ???
			//9	    B500HD
			//10	A-AAM
			//11	???
			//12	FUEL
			get
			{
				Int16 subData = GetInt16(0);
				Packet_OrdinanceType subType;

				switch (subData)
				{
					case 1:
						subType = Packet_OrdinanceType.AAM_Short;
						break;
					case 2:
						subType = Packet_OrdinanceType.AGM;
						break;
					case 3:
						subType = Packet_OrdinanceType.B500;
						break;
					case 4:
						subType = Packet_OrdinanceType.RKT;
						break;
					case 5:
						subType = Packet_OrdinanceType.FLR;
						break;
					case 6:
						subType = Packet_OrdinanceType.AAM_Mid;
						break;
					case 7:
						subType = Packet_OrdinanceType.B250;
						break;
					case 8:
						subType = Packet_OrdinanceType.Unknown_8;
						break;
					case 9:
						subType = Packet_OrdinanceType.B500_HD;
						break;
					case 10:
						subType = Packet_OrdinanceType.AAM_X;
						break;
					case 11:
						subType = Packet_OrdinanceType.Unknown_11;
						break;
					case 12:
						subType = Packet_OrdinanceType.FuelTank;
						break;
					default:
						subType = Packet_OrdinanceType.Null;
						break;
				}

				return subType;
			}
			set
			{
				switch (value)
				{
					default:
					case Packet_OrdinanceType.Null:
						SetInt16(0, 0);
						break;
					case Packet_OrdinanceType.AAM_Short:
						SetInt16(0, 1);
						break;
					case Packet_OrdinanceType.AGM:
						SetInt16(0, 2);
						break;
					case Packet_OrdinanceType.B500:
						SetInt16(0, 3);
						break;
					case Packet_OrdinanceType.RKT:
						SetInt16(0, 4);
						break;
					case Packet_OrdinanceType.FLR:
						SetInt16(0, 5);
						break;
					case Packet_OrdinanceType.AAM_Mid:
						SetInt16(0, 6);
						break;
					case Packet_OrdinanceType.B250:
						SetInt16(0, 7);
						break;
					case Packet_OrdinanceType.Unknown_8:
						SetInt16(0, 8);
						break;
					case Packet_OrdinanceType.B500_HD:
						SetInt16(0, 9);
						break;
					case Packet_OrdinanceType.AAM_X:
						SetInt16(0, 10);
						break;
					case Packet_OrdinanceType.Unknown_11:
						SetInt16(0, 11);
						break;
					case Packet_OrdinanceType.FuelTank:
						SetInt16(0, 12);
						break;
				}
			}
		}
		public IDistance PosX
		{
			//2:6 - PosX (Meters) (FLOAT)
			get => GetSingle(2).Meters();
			set => SetSingle(2, (Single)(value.ToMeters().RawValue));
		}
		public IDistance PosY
		{
			//6:10 - PosY (Meters) (FLOAT)
			get => GetSingle(6).Meters();
			set => SetSingle(6, (Single)(value.ToMeters().RawValue));
		}
		public IDistance PosZ
		{
			//10:14- PosZ (Meters) (FLOAT)
			get => GetSingle(10).Meters();
			set => SetSingle(10, (Single)(value.ToMeters().RawValue));
		}

		public IAngle HdgX
		{
			//14:18 - HdgX (Radians) (FLOAT)
			get => GetSingle(14).Radians();
			set => SetSingle(14, (Single)(value.ToRadians().RawValue));
		}
		public IAngle HdgY
		{
			//18:22 - HdgY (Radians) (FLOAT)
			get => GetSingle(18).Radians();
			set => SetSingle(18, (Single)(value.ToRadians().RawValue));
		}
		public IAngle HdgZ
		{
			//22:26 - HdgZ (Radians) (FLOAT)
			get => GetSingle(22).Radians();
			set => SetSingle(22, (Single)(value.ToRadians().RawValue));
		}

		public ISpeed LaunchVelocity
		{
			//26:30 - InitVelocity (M/S) (FLOAT)
			get => GetSingle(26).MetersPerSecond();
			set => SetSingle(26, (Single)(value.ToMetersPerSecond().RawValue));
		}

		public IDistance BurnoutDistance
		{
			//30:34 - Burnout Distance (FLOAT)
			//1 = No Burnout.
			//0 = Instant Burnout??? (Shrug?)
			get => GetSingle(30).Meters();
			set => SetSingle(30, (Single)(value.ToMeters().RawValue));
		}

		public UInt32 MaximumDamage
		{
			//34:38 - MaximumDamage (UINT)
			get => GetUInt32(34);
			set => SetUInt32(34, value);
		}

		public UInt16 SenderType
		{
			//38:40 - SenderType (USHORT)
			get => GetUInt16(38);
			set => SetUInt16(38, value);
		}
		public UInt32 SenderID
		{
			//40:44 - Sender ID. (UINT)
			get => GetUInt32(40);
			set => SetUInt32(44, value);
		}

		public ISpeed MaximumVelocity
		{
			//44:48 - Maximum Velocity. (Optional!) (FLOAT)
			get => GetSingle(44).MetersPerSecond();
			set => SetSingle(44, (Single)(value.ToMetersPerSecond().RawValue));
		}
	}
}
