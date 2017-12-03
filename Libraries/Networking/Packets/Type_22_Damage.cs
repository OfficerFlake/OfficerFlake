using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_22_Damage : GenericPacket
	{
		public Type_22_Damage() : base(22)
		{
		}

		public Int32 VictimType
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}
		public Int32 VictimID
		{
			get => GetInt32(4);
			set => SetInt32(4, value);
		}
		public Int32 AttackerType
		{
			get => GetInt32(8);
			set => SetInt32(8, value);
		}
		public UInt16 Damage
		{
			get => GetUInt16(12);
			set => SetUInt16(12, value);
		}
		public UInt16 Weapon
		{
			get => GetUInt16(14);
			set => SetUInt16(14, value);
		}
		public Int32 Unknown
		{
			get => GetInt32(16);
			set => SetInt32(16, value);
		}
	}
}
