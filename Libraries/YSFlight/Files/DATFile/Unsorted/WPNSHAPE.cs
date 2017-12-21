using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class WPNSHAPE : DAT_WeaponFile
    {
        public WPNSHAPE(WeaponType weapon, bool isstatic, string filepath) : base("WPNSHAPE", weapon,isstatic,filepath)
        {
        }
    }
}
