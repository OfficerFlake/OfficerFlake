using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class HTRADIUS : DAT_Distance
    {
        public HTRADIUS(Distance value) : base("HTRADIUS", value)
        {
        }
    }
}
