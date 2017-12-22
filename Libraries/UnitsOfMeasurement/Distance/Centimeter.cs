namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
	    public static partial class Distances
	    {
			public class Centimeter : Distance
            {
                public Centimeter(double value) : base(value, Conversion.Centimeter, "CM") { }

                public static Centimeter operator +(Centimeter firstMeasurement, Centimeter secondMeasurement)
                {
                    return new Centimeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Centimeter operator -(Centimeter firstMeasurement, Centimeter secondMeasurement)
                {
                    return new Centimeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Centimeter operator *(Centimeter firstMeasurement, Centimeter secondMeasurement)
                {
                    return new Centimeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Centimeter operator /(Centimeter firstMeasurement, Centimeter secondMeasurement)
                {
                    return new Centimeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Centimeter ToCentimeters(this Measurement input) => new Centimeter(input.ConvertToBase());

            public static Centimeter Centimeters(this byte input) => new Centimeter(input);
            public static Centimeter Centimeters(this short input) => new Centimeter(input);
            public static Centimeter Centimeters(this int input) => new Centimeter(input);
            public static Centimeter Centimeters(this long input) => new Centimeter(input);

            public static Centimeter Centimeters(this float input) => new Centimeter((double)input);
            public static Centimeter Centimeters(this double input) => new Centimeter((double)input);
        }
    }
}
