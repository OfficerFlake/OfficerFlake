using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_QuntifiedOrientation3 : Property
        {
            public int Quantifier
            {
                get
                {
                    int output;
                    bool conversionSuccess =
                        int.TryParse(Parameters[0], out output);
                    return output;
                }
                set { Parameters[0] = value.ToString(); }
            }

            public Length X
            {
                get
                {
                    Length output;
                    bool conversionSuccess =
                        Lengths.TryParse(Parameters[1], out output);
                    return output;
                }
                set { Parameters[1] = value; }
            }

            public Length Y
            {
                get
                {
                    Length output;
                    bool conversionSuccess =
                        Lengths.TryParse(Parameters[2], out output);
                    return output;
                }
                set { Parameters[2] = value; }
            }

            public Length Z
            {
                get
                {
                    Length output;
                    bool conversionSuccess =
                        Lengths.TryParse(Parameters[3], out output);
                    return output;
                }
                set { Parameters[3] = value; }
            }

            public Angle H
            {
                get
                {
                    Angle output;
                    bool conversionSuccess =
                        Angles.TryParse(Parameters[4], out output);
                    return output;
                }
                set { Parameters[4] = value; }
            }

            public Angle P
            {
                get
                {
                    Angle output;
                    bool conversionSuccess =
                        Angles.TryParse(Parameters[5], out output);
                    return output;
                }
                set { Parameters[5] = value; }
            }

            public Angle B
            {
                get
                {
                    Angle output;
                    bool conversionSuccess =
                        Angles.TryParse(Parameters[6], out output);
                    return output;
                }
                set { Parameters[6] = value; }
            }

            public DAT_QuntifiedOrientation3(string command, int quantifier, Length x, Length y, Length z, Angle h,
                Angle p, Angle b) : base(command, x, y, z, h, p, b)
            {
                Quantifier = quantifier;
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