using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class EXCAMERA : DAT_DescriptiveOrientation3
    {
        public EXCAMERA(string name, Length x, Length y, Length z, Angle h, Angle p, Angle b) : base("EXCAMERA", name,x,y,z,h,p,b)
        {
        }
    }
}
