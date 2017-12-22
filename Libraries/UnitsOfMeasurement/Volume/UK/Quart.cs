namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class UKQuart : Volume
            {
                public UKQuart(double value) : base(value, Conversion.UK.Quart, "UKQUART") { }

                public static UKQuart operator +(UKQuart firstMeasurement, UKQuart secondMeasurement)
                {
                    return new UKQuart((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static UKQuart operator -(UKQuart firstMeasurement, UKQuart secondMeasurement)
                {
                    return new UKQuart((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static UKQuart operator *(UKQuart firstMeasurement, UKQuart secondMeasurement)
                {
                    return new UKQuart((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static UKQuart operator /(UKQuart firstMeasurement, UKQuart secondMeasurement)
                {
                    return new UKQuart((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static UKQuart ToUKQuarts(this Measurement input) => new UKQuart(input.ConvertToBase());

            public static UKQuart UKQuarts(this byte input) => new UKQuart(input);
            public static UKQuart UKQuarts(this short input) => new UKQuart(input);
            public static UKQuart UKQuarts(this int input) => new UKQuart(input);
            public static UKQuart UKQuarts(this long input) => new UKQuart(input);

            public static UKQuart UKQuarts(this float input) => new UKQuart((double)input);
            public static UKQuart UKQuarts(this double input) => new UKQuart((double)input);
            public static UKQuart UKQuarts(this double input) => new UKQuart(input);
        }

    }
}
