using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Mass : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_Mass>";

            public Mass Value
            {
                get
                {
                    Mass output;
                    bool conversionSuccess =
                        Mass.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public DAT_Mass(string command, Mass value) : base(command, value)
            {
            }
        }
    }
}