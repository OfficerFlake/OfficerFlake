using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRSTDIR1 : DATProperty, IDAT_1_Parameter<IVector3>
	{
		public TRSTDIR1(IVector3 value) : base("TRSTDIR1" + " " + value)
		{
			Value = value;
		}

		public IVector3 Value { get; set; }
	}
}
