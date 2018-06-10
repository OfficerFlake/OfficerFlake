using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class PSTMSPD1 : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public PSTMSPD1(ISpeed value) : base("PSTMSPD1" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
