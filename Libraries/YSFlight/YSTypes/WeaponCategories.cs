using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Types
{
    public class WeaponCategory : IYSTypeWeaponCategory
    {
        public string[] Values { get; set; }

		public WeaponCategory(params string[] values)
        {
	        Values = values;
        }

        public override string ToString()
        {
            return Values.Any() ? Values[0] : "<ERROR>";
        }
    }
}
