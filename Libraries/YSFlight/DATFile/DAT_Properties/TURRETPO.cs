using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TURRETPO : DAT_QuantifiedOrientation3
    {
        public TURRETPO(int quantifier, Length x, Length y, Length z, Angle h, Angle p, Angle b) : base("TURRETPO", quantifier, x,y,z,h,p,b)
        {
        }
    }
}
