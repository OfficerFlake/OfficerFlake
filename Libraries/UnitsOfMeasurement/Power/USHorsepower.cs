namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Powers
        {
            public class USHorsepower : Power
            {
                public USHorsepower(decimal value) : base(value, Conversion.USHorsepower, "HP") { }

                public static USHorsepower operator +(USHorsepower firstMeasurement, USHorsepower secondMeasurement)
                {
                    return new USHorsepower((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static USHorsepower operator -(USHorsepower firstMeasurement, USHorsepower secondMeasurement)
                {
                    return new USHorsepower((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static USHorsepower operator *(USHorsepower firstMeasurement, USHorsepower secondMeasurement)
                {
                    return new USHorsepower((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static USHorsepower operator /(USHorsepower firstMeasurement, USHorsepower secondMeasurement)
                {
                    return new USHorsepower((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static USHorsepower ToUSHorsepowers(this Measurement input) => new USHorsepower(input.ConvertToBase);

            public static USHorsepower USHorsepowers(this byte input) => new USHorsepower(input);
            public static USHorsepower USHorsepowers(this short input) => new USHorsepower(input);
            public static USHorsepower USHorsepowers(this int input) => new USHorsepower(input);
            public static USHorsepower USHorsepowers(this long input) => new USHorsepower(input);

            public static USHorsepower USHorsepowers(this float input) => new USHorsepower((decimal)input);
            public static USHorsepower USHorsepowers(this double input) => new USHorsepower((decimal)input);
            public static USHorsepower USHorsepowers(this decimal input) => new USHorsepower(input);
        }
    }
}
