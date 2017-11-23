using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Power : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_Power>";

            public Power Value
            {
                get
                {
                    Power output;
                    bool conversionSuccess =
                        Power.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public DAT_Power(string command, Power value) : base(command, value)
            {
            }
        }
    }
}