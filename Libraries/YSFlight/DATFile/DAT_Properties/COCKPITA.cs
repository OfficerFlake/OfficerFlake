using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class COCKPITA : DAT_Angle3
    {
        public COCKPITA(Angle h, Angle p, Angle b) : base("COCKPITA", h,p,b)
        {
        }
    }
}
