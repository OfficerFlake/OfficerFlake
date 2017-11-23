using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TURRETHD : DAT_QuantifiedAngle3
    {
        public TURRETHD(int quantifier, Angle h, Angle p, Angle b) : base("TURRETHD", quantifier, h,p,b)
        {
        }
    }
}
