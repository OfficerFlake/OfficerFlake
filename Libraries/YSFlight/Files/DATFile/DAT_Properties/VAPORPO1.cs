using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class VAPORPO1 : DAT_Vector3
    {
        public VAPORPO1(Distance x, Distance y, Distance z) : base("VAPORPO1", x,y,z)
        {
        }
    }
}
