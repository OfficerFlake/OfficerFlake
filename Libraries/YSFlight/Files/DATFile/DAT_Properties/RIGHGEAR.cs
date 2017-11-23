using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class RIGHGEAR : DAT_Vector3
    {
        public RIGHGEAR(Length x, Length y, Length z) : base("RIGHGEAR", x,y,z)
        {
        }
    }
}
