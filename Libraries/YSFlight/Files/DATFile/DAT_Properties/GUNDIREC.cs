using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class GUNDIREC : DAT_Vector3
    {
        public GUNDIREC(Length x, Length y, Length z) : base("GUNDIREC", x,y,z)
        {
        }
    }
}
