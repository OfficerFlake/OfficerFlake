using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TURRETAM : DAT_QuantifiedInt32
    {
        public TURRETAM(int quantifier, int value) : base("TURRETAM", quantifier, value)
        {
        }
    }
}
