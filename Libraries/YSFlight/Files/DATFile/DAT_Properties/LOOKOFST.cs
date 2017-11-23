using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class LOOKOFST : DAT_Vector3
    {
        public LOOKOFST(Length x, Length y, Length z) : base("LOOKOFST", x,y,z)
        {
        }
    }
}
