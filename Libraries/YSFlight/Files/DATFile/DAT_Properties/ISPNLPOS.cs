using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class ISPNLPOS : DAT_Vector3
    {
        public ISPNLPOS(Distance x, Distance y, Distance z) : base("ISPNLPOS", x,y,z)
        {
        }
    }
}
