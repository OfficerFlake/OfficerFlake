using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class MACHNGN5 : DAT_Vector3
    {
        public MACHNGN5(Distance x, Distance y, Distance z) : base("MACHNGN5", x, y, z)
        {
        }
    }
}
