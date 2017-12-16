using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class MACHNGN4 : DAT_Vector3
    {
        public MACHNGN4(Distance x, Distance y, Distance z) : base("MACHNGN4", x, y, z)
        {
        }
    }
}
