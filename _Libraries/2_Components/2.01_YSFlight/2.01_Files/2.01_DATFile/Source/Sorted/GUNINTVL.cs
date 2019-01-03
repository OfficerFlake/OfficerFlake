using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class GUNINTVL : DATProperty, IDAT_1_Parameter<ISecond>
	{
		public GUNINTVL(ISecond value) : base("GUNINTVL" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISecond Value { get; set; }
	}
}
