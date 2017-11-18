namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class Stone : Mass
            {
                public Stone(decimal value) : base(value, Conversion.Stone, "ST") { }

                public static Stone operator +(Stone firstMeasurement, Stone secondMeasurement)
                {
                    return new Stone((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Stone operator -(Stone firstMeasurement, Stone secondMeasurement)
                {
                    return new Stone((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Stone operator *(Stone firstMeasurement, Stone secondMeasurement)
                {
                    return new Stone((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Stone operator /(Stone firstMeasurement, Stone secondMeasurement)
                {
                    return new Stone((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Stone ToStones(this Measurement input) => new Stone(input.ConvertToBase);

            public static Stone Stones(this byte input) => new Stone(input);
            public static Stone Stones(this short input) => new Stone(input);
            public static Stone Stones(this int input) => new Stone(input);
            public static Stone Stones(this long input) => new Stone(input);

            public static Stone Stones(this float input) => new Stone((decimal)input);
            public static Stone Stones(this double input) => new Stone((decimal)input);
            public static Stone Stones(this decimal input) => new Stone(input);
        }
    }
}
