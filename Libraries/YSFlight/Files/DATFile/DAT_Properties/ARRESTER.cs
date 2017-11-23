using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class ARRESTER : DAT_Vector3
    {
        public ARRESTER(Length x, Length y, Length z) : base("ARRESTER", x,y,z)
        {
        }
    }
}
