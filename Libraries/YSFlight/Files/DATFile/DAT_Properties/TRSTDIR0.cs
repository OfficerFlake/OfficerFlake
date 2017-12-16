using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TRSTDIR0 : DAT_Vector3
    {
        public TRSTDIR0(Distance x, Distance y, Distance z) : base("TRSTDIR0", x, y, z)
        {
        }
    }
}
