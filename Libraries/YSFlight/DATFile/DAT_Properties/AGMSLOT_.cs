using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class AGMSLOT_ : DAT_Vector3
    {
        public AGMSLOT_(Length x, Length y, Length z) : base("AGMSLOT_", x,y,z)
        {
        }
    }
}
