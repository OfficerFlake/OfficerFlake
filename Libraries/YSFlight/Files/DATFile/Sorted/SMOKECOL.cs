using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class SMOKECOL : DATProperty, IDAT_1_Parameter<I24BitColor>
	{
		public SMOKECOL(I24BitColor value) : base("SMOKECOL" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public I24BitColor Value { get; set; }
	}
}
