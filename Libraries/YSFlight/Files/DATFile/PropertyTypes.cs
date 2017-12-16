using System.Linq;
using Com.OfficerFlake.Libraries.IO;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class Property : CommandFile.Line
        {
            protected Property(string command, params object[] parameters)
                : base(command + " " + string.Join(" ", parameters.Select(x => x.ToString()).ToArray()))
            {
            }
        }
    }
}
