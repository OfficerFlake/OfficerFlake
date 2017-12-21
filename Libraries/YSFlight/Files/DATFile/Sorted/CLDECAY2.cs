using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class CLDECAY2 : DAT_Angle
    {
        public CLDECAY2(Angle value) : base("CLDECAY2", value)
        {
        }
    }
	public class ARRESTER : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public ARRESTER(IPoint3 value) : base("AAMSLOT_" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
