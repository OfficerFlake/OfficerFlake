using System.Linq;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Strings : Property
        {
            protected DAT_Strings(string command, params string[] values) : base(command, values.ToArray<object>())
            {
            }
        }
    }
}