using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Distance : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_Distance>";

            public Distance Value
            {
                get
                {
                    Distance output;
                    bool conversionSuccess =
	                    Distance.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public DAT_Distance(string command, Distance value) : base(command, value)
            {
            }
        }
    }
}