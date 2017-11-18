using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TRIGGER1 : DAT_Strings
    {
        private const string NullExceptionString = "<ERROR-TRIGGER1>";

        public WeaponCategory Value
        {
            get { return WeaponCategory.GetCategoryFromStringOrBlank((GetParameterOrNull(0).ToString() ?? NullExceptionString)); }
            set
            {
                SetParameter(0, value.Value[0]);
            }
        }
        public TRIGGER1(WeaponCategory value) : base("TRIGGER1", value.ToString())
        {
        }
    }
}
