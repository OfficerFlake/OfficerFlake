namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class CubicFoot : Volume
            {
                public CubicFoot(double value) : base(value, Conversion.CubicFoot, "FT^3") { }

                public static CubicFoot operator +(CubicFoot firstMeasurement, CubicFoot secondMeasurement)
                {
                    return new CubicFoot((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static CubicFoot operator -(CubicFoot firstMeasurement, CubicFoot secondMeasurement)
                {
                    return new CubicFoot((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static CubicFoot operator *(CubicFoot firstMeasurement, CubicFoot secondMeasurement)
                {
                    return new CubicFoot((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static CubicFoot operator /(CubicFoot firstMeasurement, CubicFoot secondMeasurement)
                {
                    return new CubicFoot((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static CubicFoot ToCubicFeet(this Measurement input) => new CubicFoot(input.ConvertToBase());

            public static CubicFoot CubicFeet(this byte input) => new CubicFoot(input);
            public static CubicFoot CubicFeet(this short input) => new CubicFoot(input);
            public static CubicFoot CubicFeet(this int input) => new CubicFoot(input);
            public static CubicFoot CubicFeet(this long input) => new CubicFoot(input);

            public static CubicFoot CubicFeet(this float input) => new CubicFoot((double)input);
            public static CubicFoot CubicFeet(this double input) => new CubicFoot((double)input);
        }
    }
}
