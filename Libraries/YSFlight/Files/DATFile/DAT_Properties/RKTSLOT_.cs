using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class RKTSLOT_ : DAT_Vector3
    {
        public RKTSLOT_(Length x, Length y, Length z) : base("RKTSLOT_", x,y,z)
        {
        }
    }
}
