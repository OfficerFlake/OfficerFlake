using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRSTDIR0 : DATProperty, IDAT_1_Parameter<IVector3>
	{
		public TRSTDIR0(IVector3 value) : base("TRSTDIR0" + " " + value)
		{
			Value = value;
		}

		public IVector3 Value { get; set; }
	}
}
