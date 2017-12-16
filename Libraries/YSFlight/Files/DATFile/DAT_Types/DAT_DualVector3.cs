using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_DualVector3 : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_DualVector3>";

            public Distance X1
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

            public Distance Y1
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

            public Distance Z1
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

            public Distance X2
            {
                get
                {
                    Distance output;
                    bool conversionSuccess =
	                    Distance.TryParse((GetParameterOrNull(3).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(3, value.ToString()); }
            }

            public Distance Y2
            {
                get
                {
                    Distance output;
                    bool conversionSuccess =
	                    Distance.TryParse((GetParameterOrNull(4).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(4, value.ToString()); }
            }

            public Distance Z2
            {
                get
                {
                    Distance output;
                    bool conversionSuccess =
	                    Distance.TryParse((GetParameterOrNull(5).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(5, value.ToString()); }
            }

            public DAT_DualVector3(string command, Distance x1, Distance y1, Distance z1, Distance x2, Distance y2, Distance z2) : base(command, x1, y1, z1, x2,y2,z2)
            {
                X1 = x1;
                Y1 = y1;
                Z1 = z1;
                X2 = x2;
                Y2 = y2;
                Z2 = z2;
            }
        }
    }
}