using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TURRETPT : DAT_QuantifiedAngle3
    {
        public TURRETPT(int quantifier, Angle h, Angle p, Angle b) : base("TURRETPT", quantifier, h,p,b)
        {
        }
    }
}
