using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class PSTMSPD2 : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public PSTMSPD2(ISpeed value) : base("PSTMSPD2" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
