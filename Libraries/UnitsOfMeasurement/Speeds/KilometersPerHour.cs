namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Speeds
        {
            public class KilometersPerHour : Speed
            {
                public KilometersPerHour(double value) : base(value, Conversion.KilometersPerHour, "KPH") { }

                public static KilometersPerHour operator +(KilometersPerHour firstMeasurement, KilometersPerHour secondMeasurement)
                {
                    return new KilometersPerHour((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static KilometersPerHour operator -(KilometersPerHour firstMeasurement, KilometersPerHour secondMeasurement)
                {
                    return new KilometersPerHour((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static KilometersPerHour operator *(KilometersPerHour firstMeasurement, KilometersPerHour secondMeasurement)
                {
                    return new KilometersPerHour((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static KilometersPerHour operator /(KilometersPerHour firstMeasurement, KilometersPerHour secondMeasurement)
                {
                    return new KilometersPerHour((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static KilometersPerHour ToKilometersPerHours(this Measurement input) => new KilometersPerHour(input.ConvertToBase());

            public static KilometersPerHour KilometersPerHours(this byte input) => new KilometersPerHour(input);
            public static KilometersPerHour KilometersPerHours(this short input) => new KilometersPerHour(input);
            public static KilometersPerHour KilometersPerHours(this int input) => new KilometersPerHour(input);
            public static KilometersPerHour KilometersPerHours(this long input) => new KilometersPerHour(input);

            public static KilometersPerHour KilometersPerHours(this float input) => new KilometersPerHour((double)input);
            public static KilometersPerHour KilometersPerHours(this double input) => new KilometersPerHour((double)input);
            public static KilometersPerHour KilometersPerHours(this double input) => new KilometersPerHour(input);
        }
    }
}
