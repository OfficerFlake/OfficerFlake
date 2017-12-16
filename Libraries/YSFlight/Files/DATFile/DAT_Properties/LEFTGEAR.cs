using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class LEFTGEAR : DAT_Vector3
    {
        public LEFTGEAR(Distance x, Distance y, Distance z) : base("LEFTGEAR", x,y,z)
        {
        }
    }
}
