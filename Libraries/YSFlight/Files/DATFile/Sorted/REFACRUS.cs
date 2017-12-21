using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class REFACRUS : DATProperty, IDAT_1_Parameter<IDistance>
	{
		public REFACRUS(IDistance value) : base("REFACRUS" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IDistance Value { get; set; }
	}
}
