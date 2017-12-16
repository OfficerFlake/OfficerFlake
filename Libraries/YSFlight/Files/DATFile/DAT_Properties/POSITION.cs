using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class POSITION : DAT_Vector3
    {
        public POSITION(Distance x, Distance y, Distance z) : base("POSITION", x,y,z)
        {
        }
    }
}
