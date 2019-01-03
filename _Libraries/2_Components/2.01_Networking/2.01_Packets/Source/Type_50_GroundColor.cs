using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_50_GroundColor : GenericPacket, IPacket_50_GroundColor
	{
		public Type_50_GroundColor() : base(50)
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
