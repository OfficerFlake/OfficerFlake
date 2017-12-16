using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TURRETRG : DAT_QuantifiedDistance
    {
        public TURRETRG(int quantifier, Distance value) : base("TURRETRG", quantifier, value)
        {
        }
    }
}
