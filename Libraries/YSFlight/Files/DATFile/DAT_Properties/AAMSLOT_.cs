using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class AAMSLOT_ : DAT_Vector3
    {
        public AAMSLOT_(Distance x, Distance y, Distance z) : base("AAMSLOT_", x,y,z)
        {
        }
    }
}
