using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Vector3 : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_Vector3>";

            public Distance X
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

            public Distance Y
            {
                get
                {
                    Distance output;
                    bool conversionSuccess =
	                    Distance.TryParse((GetParameterOrNull(1).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(1, value.ToString()); }
            }

            public Distance Z
            {
                get
                {
                    Distance output;
                    bool conversionSuccess =
	                    Distance.TryParse((GetParameterOrNull(2).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(2, value.ToString()); }
            }

            public DAT_Vector3(string command, Distance x, Distance y, Distance z) : base(command, x, y, z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }
    }
}