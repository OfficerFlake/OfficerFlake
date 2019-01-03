using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_22_Damage : GenericPacket, IPacket_22_Damage
	{
		public Type_22_Damage() : base(22)
		{
		}

		public UInt32 VictimType
		{
			get => GetUInt32(0);
			set => SetUInt32(0, value);
		}
		public UInt32 VictimID
		{
			get => GetUInt32(4);
			set => SetUInt32(4, value);
		}
		public UInt32 AttackerType
		{
			get => GetUInt32(8);
			set => SetUInt32(8, value);
		}
		public UInt16 Damage
		{
			get => GetUInt16(12);
			set => SetUInt16(12, value);
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
				UInt16 subData = GetUInt16(14);
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
						SetUInt16(14, 0);
						break;
					case Packet_OrdinanceType.AAM_Short:
						SetUInt16(14, 1);
						break;
					case Packet_OrdinanceType.AGM:
						SetUInt16(14, 2);
						break;
					case Packet_OrdinanceType.B500:
						SetUInt16(14, 3);
						break;
					case Packet_OrdinanceType.RKT:
						SetUInt16(14, 4);
						break;
					case Packet_OrdinanceType.FLR:
						SetUInt16(14, 5);
						break;
					case Packet_OrdinanceType.AAM_Mid:
						SetUInt16(14, 6);
						break;
					case Packet_OrdinanceType.B250:
						SetUInt16(14, 7);
						break;
					case Packet_OrdinanceType.Unknown_8:
						SetUInt16(14, 8);
						break;
					case Packet_OrdinanceType.B500_HD:
						SetUInt16(14, 9);
						break;
					case Packet_OrdinanceType.AAM_X:
						SetUInt16(14, 10);
						break;
					case Packet_OrdinanceType.Unknown_11:
						SetUInt16(14, 11);
						break;
					case Packet_OrdinanceType.FuelTank:
						SetUInt16(14, 12);
						break;
				}
			}
		}

		public UInt32 Unknown
		{
			get => GetUInt32(16);
			set => SetUInt32(16, value);
		}
	}
}
