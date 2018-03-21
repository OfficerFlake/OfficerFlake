using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class AAMSLOT_ : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
        public AAMSLOT_(ICoordinate3 value) : base("AAMSLOT_" + " " + string.Join(" ", value))
        {
	        Value = value;
        }

		public ICoordinate3 Value { get; set; }
	}
}
