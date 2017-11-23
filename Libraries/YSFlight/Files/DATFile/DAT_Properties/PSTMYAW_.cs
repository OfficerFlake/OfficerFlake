using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class PSTMYAW_ : DAT_Angle
    {
        public PSTMYAW_(Angle value) : base("PSTMYAW_", value)
        {
        }
    }
}
