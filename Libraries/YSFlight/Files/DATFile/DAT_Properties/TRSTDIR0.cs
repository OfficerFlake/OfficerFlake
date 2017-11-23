using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TRSTDIR0 : DAT_Vector3
    {
        public TRSTDIR0(Length x, Length y, Length z) : base("TRSTDIR0", x, y, z)
        {
        }
    }
}
