using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class MACHNGN8 : DAT_Vector3
    {
        public MACHNGN8(Distance x, Distance y, Distance z) : base("MACHNGN8", x,y,z)
        {
        }
    }
}
