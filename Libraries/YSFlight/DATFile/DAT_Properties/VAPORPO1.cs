using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class VAPORPO1 : DAT_Vector3
    {
        public VAPORPO1(Length x, Length y, Length z) : base("VAPORPO1", x,y,z)
        {
        }
    }
}
