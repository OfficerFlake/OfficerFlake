namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Areas
        {
            public class SquareKilometer : Area
            {
                public SquareKilometer(decimal value) : base(value, Conversion.SquareKilometer, "KM^2") { }

                public static SquareKilometer operator +(SquareKilometer firstMeasurement, SquareKilometer secondMeasurement)
                {
                    return new SquareKilometer((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static SquareKilometer operator -(SquareKilometer firstMeasurement, SquareKilometer secondMeasurement)
                {
                    return new SquareKilometer((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static SquareKilometer operator *(SquareKilometer firstMeasurement, SquareKilometer secondMeasurement)
                {
                    return new SquareKilometer((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static SquareKilometer operator /(SquareKilometer firstMeasurement, SquareKilometer secondMeasurement)
                {
                    return new SquareKilometer((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static SquareKilometer ToSquareKilometers(this Measurement input) => new SquareKilometer(input.ConvertToBase);

            public static SquareKilometer SquareKilometers(this byte input) => new SquareKilometer(input);
            public static SquareKilometer SquareKilometers(this short input) => new SquareKilometer(input);
            public static SquareKilometer SquareKilometers(this int input) => new SquareKilometer(input);
            public static SquareKilometer SquareKilometers(this long input) => new SquareKilometer(input);

            public static SquareKilometer SquareKilometers(this float input) => new SquareKilometer((decimal)input);
            public static SquareKilometer SquareKilometers(this double input) => new SquareKilometer((decimal)input);
            public static SquareKilometer SquareKilometers(this decimal input) => new SquareKilometer(input);
        }
    }
}
