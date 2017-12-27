using System;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_48_FogColor : GenericPacket
	{
		public Type_48_FogColor() : base(48)
		{
		}
		public Type_48_FogColor(byte red, byte green, byte blue) : base(48)
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
