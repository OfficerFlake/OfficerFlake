using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class MACHNGN7 : DAT_Vector3
    {
        public MACHNGN7(Length x, Length y, Length z) : base("MACHNGN7", x, y, z)
        {
        }
    }
}
