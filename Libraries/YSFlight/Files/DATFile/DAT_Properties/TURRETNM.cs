using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TURRETNM : DAT_QuantifiedString
    {
        public TURRETNM(int quantifier, string value) : base("TURRETNM", quantifier, value)
        {
        }
    }
}
