using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class MAXSPEED : DAT_Speed
    {
        public MAXSPEED(Speed value) : base("MAXSPEED", value)
        {
        }
    }
}
