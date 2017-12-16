using System;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TURRETIV : DAT_QuantifiedDuration
    {
        public TURRETIV(int quantifier, Duration value) : base("TURRETIV", quantifier, value)
        {
        }
    }
}
