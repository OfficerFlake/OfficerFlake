using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class REFACRUS : DAT_Distance
    {
        public REFACRUS(Distance value) : base("REFACRUS", value)
        {
        }
    }
}
