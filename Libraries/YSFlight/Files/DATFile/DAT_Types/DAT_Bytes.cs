namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Bytes : Property
        {
            protected DAT_Bytes(string command, params byte[] values) : base(command, values)
            {
            }
        }
    }
}