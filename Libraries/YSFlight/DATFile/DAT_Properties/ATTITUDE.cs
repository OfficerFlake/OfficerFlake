using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class ATTITUDE : DAT_Angle3
    {
        public ATTITUDE(Angle h, Angle p, Angle b) : base("ATTITUDE", h,p,b)
        {
        }
    }
}
