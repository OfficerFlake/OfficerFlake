using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class MACHNGN2 : DAT_Vector3
    {
        public MACHNGN2(Distance x, Distance y, Distance z) : base("MACHNGN2", x, y, z)
        {
        }
    }
}
