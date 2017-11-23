using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TURRETCT : DAT_QuantifiedString
    {
        public TURRETCT(int quantifier, string value) : base("TURRETCT", quantifier, value)
        {
        }
    }
}
