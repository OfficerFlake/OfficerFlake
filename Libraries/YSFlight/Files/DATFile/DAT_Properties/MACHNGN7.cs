using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class MACHNGN7 : DAT_Vector3
    {
        public MACHNGN7(Distance x, Distance y, Distance z) : base("MACHNGN7", x, y, z)
        {
        }
    }
}
