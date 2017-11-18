﻿using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_DescriptiveOrientation3 : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_DescriptiveOrientation3>";

            public string Description
            {
                get { return (GetParameterOrNull(0).ToString() ?? NullExceptionString); }
                set { SetParameter(0, value.ToString()); }
            }

            public Length X
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

            public Length Y
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

            public Length Z
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

            public Angle H
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

            public Angle P
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

            public Angle B
            {
                get
                {
                    Angle output;
                    bool conversionSuccess =
                        Angle.TryParse((GetParameterOrNull(6).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(6, value.ToString()); }
            }

            public DAT_DescriptiveOrientation3(string command, string description, Length x, Length y, Length z, Angle h,
                Angle p, Angle b) : base(command, x, y, z, h, p, b)
            {
                Description = description;
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