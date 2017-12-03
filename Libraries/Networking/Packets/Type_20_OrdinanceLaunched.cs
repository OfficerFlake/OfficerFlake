using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_20_OrdinanceLaunched : GenericPacket
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

		public Int16 OrdinanceType
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
			get => GetInt16(0);
			set => SetInt16(0, value);
		}
		public Single PosX
		{
			//2:6 - PosX (Meters) (FLOAT)
			get => GetSingle(2);
			set => SetSingle(2, value);
		}
		public Single PosY
		{
			//6:10 - PosY (Meters) (FLOAT)
			get => GetSingle(6);
			set => SetSingle(6, value);
		}
		public Single PosZ
		{
			//10:14- PosZ (Meters) (FLOAT)
			get => GetSingle(10);
			set => SetSingle(10, value);
		}

		public Single HdgX
		{
			//14:18 - HdgX (Radians) (FLOAT)
			get => GetSingle(14);
			set => SetSingle(14, value);
		}
		public Single HdgY
		{
			//18:22 - HdgY (Radians) (FLOAT)
			get => GetSingle(18);
			set => SetSingle(18, value);
		}
		public Single HdgZ
		{
			//22:26 - HdgZ (Radians) (FLOAT)
			get => GetSingle(22);
			set => SetSingle(22, value);
		}

		public Single InitVelocity
		{
			//26:30 - InitVelocity (M/S) (FLOAT)
			get => GetSingle(26);
			set => SetSingle(26, value);
		}

		public Single BurnoutDistance
		{
			//30:34 - Burnout Distance (FLOAT)
			//1 = No Burnout.
			//0 = Instant Burnout??? (Shrug?)
			get => GetSingle(30);
			set => SetSingle(30, value);
		}

		public UInt32 MaximumDamage
		{
			//34:38 - MaximumDamage (UINT)
			get => GetUInt32(34);
			set => SetUInt32(34, value);
		}

		public Int16 SenderType
		{
			//38:40 - SenderType (USHORT)
			get => GetInt16(38);
			set => SetInt16(38, value);
		}
		public Int32 SenderID
		{
			//40:44 - Sender ID. (UINT)
			get => GetInt32(40);
			set => SetInt32(44, value);
		}

		public Single MaximumVelocity
		{
			//44:48 - Maximum Velocity. (Optional!) (FLOAT)
			get => GetSingle(44);
			set => SetSingle(44, value);
		}
	}
}
