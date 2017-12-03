using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_49_SkyColor : GenericPacket
	{
		public Type_49_SkyColor() : base(49)
		{
		}
		public Type_49_SkyColor(byte red, byte green, byte blue) : base(49)
		{
			Red = red;
			Green = green;
			Blue = blue;
		}

		public Byte Red
		{
			get => GetByte(0);
			set => SetByte(0, value);
		}
		public Byte Green
		{
			get => GetByte(1);
			set => SetByte(1, value);
		}
		public Byte Blue
		{
			get => GetByte(2);
			set => SetByte(2, value);
		}
	}
}
