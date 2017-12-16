namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Distances
		{
            public class Millimeter : Distance
			{
                public Millimeter(decimal value) : base(value, Conversion.Millimeter, "MM") { }

                public static Millimeter operator +(Millimeter firstMeasurement, Millimeter secondMeasurement)
                {
                    return new Millimeter((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Millimeter operator -(Millimeter firstMeasurement, Millimeter secondMeasurement)
                {
                    return new Millimeter((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Millimeter operator *(Millimeter firstMeasurement, Millimeter secondMeasurement)
                {
                    return new Millimeter((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Millimeter operator /(Millimeter firstMeasurement, Millimeter secondMeasurement)
                {
                    return new Millimeter((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Millimeter ToMillimeters(this Measurement input) => new Millimeter(input.ConvertToBase);

            public static Millimeter Millimeters(this byte input) => new Millimeter(input);
            public static Millimeter Millimeters(this short input) => new Millimeter(input);
            public static Millimeter Millimeters(this int input) => new Millimeter(input);
            public static Millimeter Millimeters(this long input) => new Millimeter(input);

            public static Millimeter Millimeters(this float input) => new Millimeter((decimal)input);
            public static Millimeter Millimeters(this double input) => new Millimeter((decimal)input);
            public static Millimeter Millimeters(this decimal input) => new Millimeter(input);
        }
    }
}
