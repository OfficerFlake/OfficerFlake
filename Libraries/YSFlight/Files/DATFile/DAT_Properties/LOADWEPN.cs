using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class LOADWEPN : DAT_WeaponQuantity
    {
        public LOADWEPN(WeaponType weapon, int quantity) : base("LOADWEPN", weapon, quantity)
        {
        }
    }
}
