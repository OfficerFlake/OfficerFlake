using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class WEAPONCH : DAT_String
    {
        private const string NullExceptionString = "<ERROR-WEAPONCH>";

        public WeaponCategory Category
        {
            get { return WeaponCategory.GetCategoryFromStringOrBlank((GetParameter(0).ToString() ?? NullExceptionString)); }
            set
            {
                SetParameter(0, value.Value[0]);
            }
        }

        public WEAPONCH(WeaponCategory value) : base("WEAPONCH", value.ToString())
        {
        }
    }
}
