using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_07_SmokeColor : GenericPacket
	{
		public Type_07_SmokeColor() : base(7)
		{
		}
		public Type_07_SmokeColor(Int32 entityId, byte smokeGeneratorIndex, byte red, byte green, byte blue) : base(7)
		{
			EntityId = entityId;
			SmokeGeneratorIndex = smokeGeneratorIndex;
			Red = red;
			Green = green;
			Blue = blue;
		}

		public Int32 EntityId
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}

		public Byte SmokeGeneratorIndex
		{
			get => GetByte(4);
			set => SetByte(4, value);
		}
		public Byte Red
		{
			get => GetByte(5);
			set => SetByte(5, value);
		}
		public Byte Green
		{
			get => GetByte(6);
			set => SetByte(6, value);
		}
		public Byte Blue
		{
			get => GetByte(7);
			set => SetByte(7, value);
		}
	}
}
