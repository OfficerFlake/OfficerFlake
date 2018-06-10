using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class WINGAREA : DATProperty, IDAT_1_Parameter<IArea>
	{
		public WINGAREA(IArea value) : base("WINGAREA" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IArea Value { get; set; }
	}
}
