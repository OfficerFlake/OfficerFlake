using System;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TURRETIV : DAT_QuantifiedTimeSpan
    {
        public TURRETIV(int quantifier, TimeSpan value) : base("TURRETIV", quantifier, value)
        {
        }
    }
}
