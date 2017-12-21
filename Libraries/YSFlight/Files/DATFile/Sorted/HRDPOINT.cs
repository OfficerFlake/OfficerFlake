using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class HRDPOINT : DATProperty, IDAT_2_Parameters<IPoint3, WeaponDescription[]>
	{
		public HRDPOINT(IPoint3 value1, WeaponDescription[] value2) : base("HRDPOINT" + " " + value1 + " " + string.Join(" ", value2.Select(x=>x.ToString())))
		{
			Value1 = value1;
			Value2 = value2;
		}

		public IPoint3 Value1 { get; set; }
		public WeaponDescription[] Value2 { get; set; }
	}
}
