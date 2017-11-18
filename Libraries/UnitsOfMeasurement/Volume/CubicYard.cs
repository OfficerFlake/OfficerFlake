namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class CubicYard : Volume
            {
                public CubicYard(decimal value) : base(value, Conversion.CubicYard, "YD^3") { }

                public static CubicYard operator +(CubicYard firstMeasurement, CubicYard secondMeasurement)
                {
                    return new CubicYard((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static CubicYard operator -(CubicYard firstMeasurement, CubicYard secondMeasurement)
                {
                    return new CubicYard((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static CubicYard operator *(CubicYard firstMeasurement, CubicYard secondMeasurement)
                {
                    return new CubicYard((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static CubicYard operator /(CubicYard firstMeasurement, CubicYard secondMeasurement)
                {
                    return new CubicYard((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static CubicYard ToCubicYards(this Measurement input) => new CubicYard(input.ConvertToBase);

            public static CubicYard CubicYards(this byte input) => new CubicYard(input);
            public static CubicYard CubicYards(this short input) => new CubicYard(input);
            public static CubicYard CubicYards(this int input) => new CubicYard(input);
            public static CubicYard CubicYards(this long input) => new CubicYard(input);

            public static CubicYard CubicYards(this float input) => new CubicYard((decimal)input);
            public static CubicYard CubicYards(this double input) => new CubicYard((decimal)input);
            public static CubicYard CubicYards(this decimal input) => new CubicYard(input);
        }
    }
}
