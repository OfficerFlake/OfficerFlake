using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Orientation3 : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_DescriptiveOrientation3>";

            public Length X
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

            public Length Y
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

            public Length Z
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

            public Angle H
            {
                get
                {
                    Angle output;
                    bool conversionSuccess =
                        Angle.TryParse((GetParameterOrNull(3).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(3, value.ToString()); }
            }

            public Angle P
            {
                get
                {
                    Angle output;
                    bool conversionSuccess =
                        Angle.TryParse((GetParameterOrNull(4).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(4, value.ToString()); }
            }

            public Angle B
            {
                get
                {
                    Angle output;
                    bool conversionSuccess =
                        Angle.TryParse((GetParameterOrNull(5).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(5, value.ToString()); }
            }

            public DAT_Orientation3(string command, Length x, Length y, Length z, Angle h, Angle p, Angle b)
                : base(command, x, y, z, h, p, b)
            {
                X = x;
                Y = y;
                Z = z;
                H = h;
                P = p;
                B = b;
            }
        }
    }
}