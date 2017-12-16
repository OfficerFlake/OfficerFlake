using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class MACHNGN3 : DAT_Vector3
    {
        public MACHNGN3(Distance x, Distance y, Distance z) : base("MACHNGN3", x, y, z)
        {
        }
    }
}
