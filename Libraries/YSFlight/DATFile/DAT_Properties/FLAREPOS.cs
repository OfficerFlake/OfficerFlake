using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class FLAREPOS : DAT_DualVector3
    {
        public FLAREPOS(Length x1, Length y1, Length z1, Length x2, Length y2, Length z2) : base("FLAREPOS", x1, y1, z1, x2, y2, z2)
        {
        }
    }
}
