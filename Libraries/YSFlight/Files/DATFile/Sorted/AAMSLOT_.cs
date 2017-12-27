using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class AAMSLOT_ : DATProperty, IDAT_1_Parameter<IPoint3>
	{
        public AAMSLOT_(IPoint3 value) : base("AAMSLOT_" + " " + string.Join(" ", value))
        {
	        Value = value;
        }

		public IPoint3 Value { get; set; }
	}
}
