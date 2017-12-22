namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Durations
        {
            public class Year : Duration
            {
                public Year(double value) : base(value, Conversion.Year, "D") { }

                public static Year operator +(Year firstMeasurement, Year secondMeasurement)
                {
                    return new Year((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Year operator -(Year firstMeasurement, Year secondMeasurement)
                {
                    return new Year((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Year operator *(Year firstMeasurement, Year secondMeasurement)
                {
                    return new Year((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Year operator /(Year firstMeasurement, Year secondMeasurement)
                {
                    return new Year((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Year ToYears(this Measurement input) => new Year(input.ConvertToBase());

            public static Year Years(this byte input) => new Year(input);
            public static Year Years(this short input) => new Year(input);
            public static Year Years(this int input) => new Year(input);
            public static Year Years(this long input) => new Year(input);

            public static Year Years(this float input) => new Year((double)input);
            public static Year Years(this double input) => new Year((double)input);
        }
    }
}
