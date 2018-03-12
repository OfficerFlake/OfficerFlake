using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_49_SkyColor : GenericPacket, IPacket_49_SkyColor
	{
		public Type_49_SkyColor() : base(49)
		{
		}

		public I24BitColor Color
		{
			get
			{
				return ObjectFactory.CreateColor(
					GetByte(0),
					GetByte(1),
					GetByte(2)
				).Get24BitColor();
			}
			set
			{
				SetByte(0, value.Red);
				SetByte(1, value.Green);
				SetByte(2, value.Blue);
			}
		}
	}
}
