using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_07_SmokeColor : GenericPacket, IPacket_07_SmokeColor
	{
		public Type_07_SmokeColor() : base(7)
		{
		}
		public Type_07_SmokeColor(Int32 vehicleID, byte smokeGeneratorID, I24BitColor color) : base(7)
		{
			VehicleID = (uint)vehicleID;
			SmokeGeneratorID = smokeGeneratorID;
			Red = color.Red;
			Green = color.Green;
			Blue = color.Blue;
		}

		public UInt32 VehicleID
		{
			get => GetUInt32(0);
			set => SetUInt32(0, value);
		}

		public Byte SmokeGeneratorID
		{
			get => GetByte(4);
			set => SetByte(4, value);
		}

		public I24BitColor Color
		{
			get
			{
				return new XRGBColor(Red, Green, Blue);
			}
			set
			{
				Red = value.Red;
				Green = value.Green;
				Blue = value.Blue;
			}
		}
		private Byte Red
		{
			get => GetByte(5);
			set => SetByte(5, value);
		}
		private Byte Green
		{
			get => GetByte(6);
			set => SetByte(6, value);
		}
		private Byte Blue
		{
			get => GetByte(7);
			set => SetByte(7, value);
		}
	}
}
