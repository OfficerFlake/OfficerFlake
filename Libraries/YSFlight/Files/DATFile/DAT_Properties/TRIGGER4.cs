using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TRIGGER4 : DAT_Strings
    {
        private const string NullExceptionString = "<ERROR-TRIGGER4>";

        public WeaponCategory Value
        {
            get { return WeaponCategory.GetCategoryFromStringOrBlank((GetParameterOrNull(0).ToString() ?? NullExceptionString)); }
            set
            {
                SetParameter(0, value.Value[0]);
            }
        }
        public TRIGGER4(WeaponCategory value) : base("TRIGGER4", value.ToString())
        {
        }
    }
}
