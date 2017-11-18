using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class ISPNLATT : DAT_Angle3
    {
        public ISPNLATT(Angle h, Angle p, Angle b) : base("ISPNLATT", h,p,b)
        {
        }
    }
}
