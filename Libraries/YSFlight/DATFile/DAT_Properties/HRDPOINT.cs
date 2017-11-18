using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class HRDPOINT : DAT_Hardpoint
    {
        public HRDPOINT(Length x, Length y, Length z, WeaponDescription[] descriptors) : base("HRDPOINT", x,y,z,descriptors)
        {
        }
    }
}
