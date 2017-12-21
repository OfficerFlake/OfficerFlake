using System;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class STALHORN : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public STALHORN(Boolean value) : base("STALHORN" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
