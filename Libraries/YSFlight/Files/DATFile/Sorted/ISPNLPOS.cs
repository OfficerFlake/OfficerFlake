using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class ISPNLPOS : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public ISPNLPOS(ICoordinate3 value) : base("ISPNLPOS" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
