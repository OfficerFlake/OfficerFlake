using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TRSTDIR1 : DAT_Vector3
    {
        public TRSTDIR1(Distance x, Distance y, Distance z) : base("TRSTDIR1", x, y, z)
        {
        }
    }
}
