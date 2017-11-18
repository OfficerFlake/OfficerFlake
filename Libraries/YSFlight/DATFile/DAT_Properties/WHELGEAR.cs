using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class WHELGEAR : DAT_Vector3
    {
        public WHELGEAR(Length x, Length y, Length z) : base("WHELGEAR", x,y,z)
        {
        }
    }
}
