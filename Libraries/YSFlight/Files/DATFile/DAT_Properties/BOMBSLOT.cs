using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class BOMBSLOT : DAT_Vector3
    {
        public BOMBSLOT(Distance x, Distance y, Distance z) : base("BOMBSLOT", x,y,z)
        {
        }
    }
}
