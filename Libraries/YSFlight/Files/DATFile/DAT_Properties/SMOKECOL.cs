using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class SMOKECOL : DAT_Bytes
    {
        public SMOKECOL(byte generator, byte r, byte g, byte b) : base("SMOKECOL", generator,r,g,b)
        {
        }
    }
}
