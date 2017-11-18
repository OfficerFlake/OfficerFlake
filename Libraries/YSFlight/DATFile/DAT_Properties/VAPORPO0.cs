using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class VAPORPO0 : DAT_Vector3
    {
        public VAPORPO0(Length x, Length y, Length z) : base("VAPORPO0", x,y,z)
        {
        }
    }
}
