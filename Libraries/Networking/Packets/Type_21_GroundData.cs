using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_21_GroundData : GenericPacket
	{
		public Type_21_GroundData() : base(21)
		{
		}

		public Single TimeStamp
		{
			get => GetSingle(0);
			set => SetSingle(0, value);
		}

		public Int32 ID
		{
			get => GetInt32(4);
			set => SetInt32(4, value);
		}

		public Int16 Strength
		{
			get => GetInt16(8);
			set => SetInt16(8, value);
		}

		public Int16 Version
		{
			get => GetInt16(10);
			set => SetInt16(10, value);
		}

		public Single PosX
		{
			get => GetSingle(12);
			set => SetSingle(12, value);
		}
		public Single PosY
		{
			get => GetSingle(16);
			set => SetSingle(16, value);
		}
		public Single PosZ
		{
			get => GetSingle(20);
			set => SetSingle(20, value);
		}

		public Int16 HdgX
		{
			get => GetInt16(24);
			set => SetInt16(24, value);
		}
		public Int16 HdgY
		{
			get => GetInt16(26);
			set => SetInt16(26, value);
		}
		public Int16 HdgZ
		{
			get => GetInt16(28);
			set => SetInt16(28, value);
		}

		public Byte AnimFlags
		{
			get => GetByte(30);
			set => SetByte(30, value);
		}
		public Boolean AnimGuns
		{
			get => ((AnimFlags & (1 << 0)) == (1<<0));
			set
			{
				if (value) AnimFlags |= 1 << 0;
				else AnimFlags &= (255 - (1 << 0));
			}
		}

		public Byte _CPU_Flags
		{
			get => GetByte(31);
			set => SetByte(31, value);
		}

		public Int16 V_PosX
		{
			get => GetInt16(32);
			set => SetInt16(32, value);
		}
		public Int16 V_PosY
		{
			get => GetInt16(34);
			set => SetInt16(34, value);
		}
		public Int16 V_PosZ
		{
			get => GetInt16(36);
			set => SetInt16(36, value);
		}

		public Int16 V_Rotation
		{
			get => GetInt16(38);
			set => SetInt16(38, value);
		}
	}
}
