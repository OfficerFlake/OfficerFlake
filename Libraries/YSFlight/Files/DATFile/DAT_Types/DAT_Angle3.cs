using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Angle3 : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_Angle3>";

            public Angle H
            {
                get
                {
                    Angle output;
                    bool conversionSuccess =
                        Angle.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public Angle P
            {
                get
                {
                    Angle output;
                    bool conversionSuccess =
                        Angle.TryParse((GetParameterOrNull(1).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(1, value.ToString()); }
            }

            public Angle B
            {
                get
                {
                    Angle output;
                    bool conversionSuccess =
                        Angle.TryParse((GetParameterOrNull(2).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(2, value.ToString()); }
            }

            public DAT_Angle3(string command, Angle h, Angle p, Angle b) : base(command, h, p, b)
            {
                H = h;
                P = p;
                B = b;
            }
        }
    }
}