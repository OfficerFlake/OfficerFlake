using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class REFVCRUS : DAT_Speed
    {
        public REFVCRUS(Speed value) : base("REFVCRUS", value)
        {
        }
    }
}
