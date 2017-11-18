namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class CubicInch : Volume
            {
                public CubicInch(decimal value) : base(value, Conversion.CubicInch, "IN^3") { }

                public static CubicInch operator +(CubicInch firstMeasurement, CubicInch secondMeasurement)
                {
                    return new CubicInch((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static CubicInch operator -(CubicInch firstMeasurement, CubicInch secondMeasurement)
                {
                    return new CubicInch((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static CubicInch operator *(CubicInch firstMeasurement, CubicInch secondMeasurement)
                {
                    return new CubicInch((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static CubicInch operator /(CubicInch firstMeasurement, CubicInch secondMeasurement)
                {
                    return new CubicInch((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static CubicInch ToCubicInches(this Measurement input) => new CubicInch(input.ConvertToBase);

            public static CubicInch CubicInches(this byte input) => new CubicInch(input);
            public static CubicInch CubicInches(this short input) => new CubicInch(input);
            public static CubicInch CubicInches(this int input) => new CubicInch(input);
            public static CubicInch CubicInches(this long input) => new CubicInch(input);

            public static CubicInch CubicInches(this float input) => new CubicInch((decimal)input);
            public static CubicInch CubicInches(this double input) => new CubicInch((decimal)input);
            public static CubicInch CubicInches(this decimal input) => new CubicInch(input);
        }
    }
}
