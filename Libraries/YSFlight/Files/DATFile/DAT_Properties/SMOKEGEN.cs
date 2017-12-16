using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class SMOKEGEN : DAT_Vector3
    {
        public SMOKEGEN(Distance x, Distance y, Distance z) : base("SMOKEGEN", x,y,z)
        {
        }
    }
}
