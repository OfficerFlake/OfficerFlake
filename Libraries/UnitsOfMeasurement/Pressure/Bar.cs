namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Pressures
        {
            public class Bar : Pressure
            {
                public Bar(decimal value) : base(value, Conversion.Bar, "BAR") { }

                public static Bar operator +(Bar firstMeasurement, Bar secondMeasurement)
                {
                    return new Bar((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Bar operator -(Bar firstMeasurement, Bar secondMeasurement)
                {
                    return new Bar((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Bar operator *(Bar firstMeasurement, Bar secondMeasurement)
                {
                    return new Bar((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Bar operator /(Bar firstMeasurement, Bar secondMeasurement)
                {
                    return new Bar((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Bar ToBars(this Measurement input) => new Bar(input.ConvertToBase);

            public static Bar Bars(this byte input) => new Bar(input);
            public static Bar Bars(this short input) => new Bar(input);
            public static Bar Bars(this int input) => new Bar(input);
            public static Bar Bars(this long input) => new Bar(input);

            public static Bar Bars(this float input) => new Bar((decimal)input);
            public static Bar Bars(this double input) => new Bar((decimal)input);
            public static Bar Bars(this decimal input) => new Bar(input);
        }
    }
}
