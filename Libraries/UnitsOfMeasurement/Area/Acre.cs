namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Areas
        {
            public class Acre : Area
            {
                public Acre(decimal value) : base(value, Conversion.Acre, "ACRE") { }

                public static Acre operator +(Acre firstMeasurement, Acre secondMeasurement)
                {
                    return new Acre((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Acre operator -(Acre firstMeasurement, Acre secondMeasurement)
                {
                    return new Acre((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Acre operator *(Acre firstMeasurement, Acre secondMeasurement)
                {
                    return new Acre((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Acre operator /(Acre firstMeasurement, Acre secondMeasurement)
                {
                    return new Acre((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Acre ToAcres(this Measurement input) => new Acre(input.ConvertToBase);

            public static Acre Acres(this byte input) => new Acre(input);
            public static Acre Acres(this short input) => new Acre(input);
            public static Acre Acres(this int input) => new Acre(input);
            public static Acre Acres(this long input) => new Acre(input);

            public static Acre Acres(this float input) => new Acre((decimal)input);
            public static Acre Acres(this double input) => new Acre((decimal)input);
            public static Acre Acres(this decimal input) => new Acre(input);
        }
    }
}
