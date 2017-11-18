namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class USCup : Volume
            {
                public USCup(decimal value) : base(value, Conversion.US.Cup, "CUP") { }

                public static USCup operator +(USCup firstMeasurement, USCup secondMeasurement)
                {
                    return new USCup((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static USCup operator -(USCup firstMeasurement, USCup secondMeasurement)
                {
                    return new USCup((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static USCup operator *(USCup firstMeasurement, USCup secondMeasurement)
                {
                    return new USCup((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static USCup operator /(USCup firstMeasurement, USCup secondMeasurement)
                {
                    return new USCup((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static USCup ToUSCups(this Measurement input) => new USCup(input.ConvertToBase);

            public static USCup USCups(this byte input) => new USCup(input);
            public static USCup USCups(this short input) => new USCup(input);
            public static USCup USCups(this int input) => new USCup(input);
            public static USCup USCups(this long input) => new USCup(input);

            public static USCup USCups(this float input) => new USCup((decimal)input);
            public static USCup USCups(this double input) => new USCup((decimal)input);
            public static USCup USCups(this decimal input) => new USCup(input);
        }

    }
}
