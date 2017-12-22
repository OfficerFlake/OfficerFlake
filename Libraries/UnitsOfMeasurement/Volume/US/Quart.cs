namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class USQuart : Volume
            {
                public USQuart(double value) : base(value, Conversion.US.Quart, "QUART") { }

                public static USQuart operator +(USQuart firstMeasurement, USQuart secondMeasurement)
                {
                    return new USQuart((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static USQuart operator -(USQuart firstMeasurement, USQuart secondMeasurement)
                {
                    return new USQuart((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static USQuart operator *(USQuart firstMeasurement, USQuart secondMeasurement)
                {
                    return new USQuart((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static USQuart operator /(USQuart firstMeasurement, USQuart secondMeasurement)
                {
                    return new USQuart((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static USQuart ToUSQuarts(this Measurement input) => new USQuart(input.ConvertToBase());

            public static USQuart USQuarts(this byte input) => new USQuart(input);
            public static USQuart USQuarts(this short input) => new USQuart(input);
            public static USQuart USQuarts(this int input) => new USQuart(input);
            public static USQuart USQuarts(this long input) => new USQuart(input);

            public static USQuart USQuarts(this float input) => new USQuart((double)input);
            public static USQuart USQuarts(this double input) => new USQuart((double)input);
            public static USQuart USQuarts(this double input) => new USQuart(input);
        }

    }
}
