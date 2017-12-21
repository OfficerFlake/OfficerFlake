using System;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class PROPEFCY : DATProperty, IDAT_1_Parameter<Single>
	{
		public PROPEFCY(Single value) : base("PROPEFCY" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
