using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class ISPNLPOS : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public ISPNLPOS(IPoint3 value) : base("ISPNLPOS" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
