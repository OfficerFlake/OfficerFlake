using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class RIGHGEAR : DAT_Vector3
    {
        public RIGHGEAR(Distance x, Distance y, Distance z) : base("RIGHGEAR", x,y,z)
        {
        }
    }
}
