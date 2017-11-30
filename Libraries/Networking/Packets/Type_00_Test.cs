using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_00_Test : GenericPacket
	{
		const int maxSize = 4;
		public Type_00_Test() : base(0)
		{
		}

		public bool Bool
		{
			get => GetBit(0, 4);
			set => SetBit(0, 4, value);
		}

		public byte Byte
		{
			get => GetByte(0);
			set => SetByte(0, value);
		}
		public sbyte SByte
		{
			get => GetSByte(0);
			set => SetSByte(0, value);
		}

		public Int16 Int16
		{
			get => GetInt16(0);
			set => SetInt16(0, value);
		}
		public UInt16 UInt16
		{
			get => GetUInt16(0);
			set => SetUInt16(0, value);
		}

		public Int32 Int32
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}
		public UInt32 UInt32
		{
			get => GetUInt32(0);
			set => SetUInt32(0, value);
		}

		public Single Single
		{
			get => GetSingle(0);
			set => SetSingle(0, value);
		}

		public string String
		{
			get => GetString(0, 16) ?? "NULL";
			set => SetString(0, 16, value);
		}
	}
}
