using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class HTRADIUS : DATProperty, IDAT_1_Parameter<IDistance>
	{
		public HTRADIUS(IDistance value) : base("HTRADIUS" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IDistance Value { get; set; }
	}
}
