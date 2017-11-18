using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class REFVLAND : DAT_Speed
    {
        public REFVLAND(Speed value) : base("REFVLAND", value)
        {
        }
    }
}
