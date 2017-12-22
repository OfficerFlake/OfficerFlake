namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class CubicCentimeter : Volume
            {
                public CubicCentimeter(double value) : base(value, Conversion.CubicCentimeter, "CM^3") { }

                public static CubicCentimeter operator +(CubicCentimeter firstMeasurement, CubicCentimeter secondMeasurement)
                {
                    return new CubicCentimeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static CubicCentimeter operator -(CubicCentimeter firstMeasurement, CubicCentimeter secondMeasurement)
                {
                    return new CubicCentimeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static CubicCentimeter operator *(CubicCentimeter firstMeasurement, CubicCentimeter secondMeasurement)
                {
                    return new CubicCentimeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static CubicCentimeter operator /(CubicCentimeter firstMeasurement, CubicCentimeter secondMeasurement)
                {
                    return new CubicCentimeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static CubicCentimeter ToCubicCentimeters(this Measurement input) => new CubicCentimeter(input.ConvertToBase());

            public static CubicCentimeter CubicCentimeters(this byte input) => new CubicCentimeter(input);
            public static CubicCentimeter CubicCentimeters(this short input) => new CubicCentimeter(input);
            public static CubicCentimeter CubicCentimeters(this int input) => new CubicCentimeter(input);
            public static CubicCentimeter CubicCentimeters(this long input) => new CubicCentimeter(input);

            public static CubicCentimeter CubicCentimeters(this float input) => new CubicCentimeter((double)input);
            public static CubicCentimeter CubicCentimeters(this double input) => new CubicCentimeter((double)input);
            public static CubicCentimeter CubicCentimeters(this double input) => new CubicCentimeter(input);
        }
    }
}
