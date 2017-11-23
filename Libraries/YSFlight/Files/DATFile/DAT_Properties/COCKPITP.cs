using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class COCKPITP : DAT_Vector3
    {
        public COCKPITP(Length x, Length y, Length z) : base("COCKPITP", x,y,z)
        {
        }
    }
}
