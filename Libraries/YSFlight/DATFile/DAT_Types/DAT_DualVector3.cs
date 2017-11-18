using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_DualVector3 : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_DualVector3>";

            public Length X1
            {
                get
                {
                    Length output;
                    bool conversionSuccess =
                        Length.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public Length Y1
            {
                get
                {
                    Length output;
                    bool conversionSuccess =
                        Length.TryParse((GetParameterOrNull(1).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(1, value.ToString()); }
            }

            public Length Z1
            {
                get
                {
                    Length output;
                    bool conversionSuccess =
                        Length.TryParse((GetParameterOrNull(2).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(2, value.ToString()); }
            }

            public Length X2
            {
                get
                {
                    Length output;
                    bool conversionSuccess =
                        Length.TryParse((GetParameterOrNull(3).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(3, value.ToString()); }
            }

            public Length Y2
            {
                get
                {
                    Length output;
                    bool conversionSuccess =
                        Length.TryParse((GetParameterOrNull(4).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(4, value.ToString()); }
            }

            public Length Z2
            {
                get
                {
                    Length output;
                    bool conversionSuccess =
                        Length.TryParse((GetParameterOrNull(5).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(5, value.ToString()); }
            }

            public DAT_DualVector3(string command, Length x1, Length y1, Length z1, Length x2, Length y2, Length z2) : base(command, x1, y1, z1, x2,y2,z2)
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