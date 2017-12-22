using System;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CROLLMAN : DATProperty, IDAT_1_Parameter<Single>
	{
		public CROLLMAN(Single value) : base("CROLLMAN" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
