namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
	    public static partial class Distances
	    {
			public class Foot : Distance
			{
                public Foot(decimal value) : base(value, Conversion.Foot, "FT") { }

                public static Foot operator +(Foot firstMeasurement, Foot secondMeasurement)
                {
                    return new Foot((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Foot operator -(Foot firstMeasurement, Foot secondMeasurement)
                {
                    return new Foot((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Foot operator *(Foot firstMeasurement, Foot secondMeasurement)
                {
                    return new Foot((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Foot operator /(Foot firstMeasurement, Foot secondMeasurement)
                {
                    return new Foot((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Foot ToFeet(this Measurement input) => new Foot(input.ConvertToBase);

            public static Foot Feet(this byte input) => new Foot(input);
            public static Foot Feet(this short input) => new Foot(input);
            public static Foot Feet(this int input) => new Foot(input);
            public static Foot Feet(this long input) => new Foot(input);

            public static Foot Feet(this float input) => new Foot((decimal)input);
            public static Foot Feet(this double input) => new Foot((decimal)input);
            public static Foot Feet(this decimal input) => new Foot(input);
        }
    }
}
