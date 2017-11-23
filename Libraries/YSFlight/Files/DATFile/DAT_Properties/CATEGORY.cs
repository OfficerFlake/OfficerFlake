using System.Linq;
using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class CATEGORY : DAT_String
    {
        private const string NullExceptionString = "<ERROR-CATEGORY>";

        public AircraftCategory Category
        {
            get
            {
                return AircraftCategory.CATEGORIES.FirstOrDefault(x =>
                    x.Value == (string)(GetParameterOrNull(0) ?? NullExceptionString) &&
                    x.SubValue == (string)(GetParameterOrNull(1) ?? NullExceptionString));
            }
            set
            {
                SetParameter(0, value.Value);
                SetParameter(1, value.Value);
            }
        }

        public CATEGORY(AircraftCategory value) : base("CATEGORY", value.ToString())
        {
        }
    }
}
