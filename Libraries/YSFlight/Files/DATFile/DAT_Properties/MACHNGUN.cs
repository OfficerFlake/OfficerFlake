using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class MACHNGUN : DAT_Vector3
    {
        public MACHNGUN(Distance x, Distance y, Distance z) : base("MACHNGUN", x,y,z)
        {
        }
    }
}
