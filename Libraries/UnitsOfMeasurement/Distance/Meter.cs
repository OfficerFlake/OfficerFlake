namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Distances
		{
            public class Meter : Distance
			{
                public Meter(double value) : base(value, Conversion.Meter, "M") { }

                public static Meter operator +(Meter firstMeasurement, Meter secondMeasurement)
                {
                    return new Meter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Meter operator -(Meter firstMeasurement, Meter secondMeasurement)
                {
                    return new Meter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Meter operator *(Meter firstMeasurement, Meter secondMeasurement)
                {
                    return new Meter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Meter operator /(Meter firstMeasurement, Meter secondMeasurement)
                {
                    return new Meter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Meter ToMeters(this Distance input) => new Meter(input.ConvertToBase());

            public static Meter Meters(this byte input) => new Meter(input);
            public static Meter Meters(this short input) => new Meter(input);
            public static Meter Meters(this int input) => new Meter(input);
            public static Meter Meters(this long input) => new Meter(input);

            public static Meter Meters(this float input) => new Meter((double)input);
            public static Meter Meters(this double input) => new Meter((double)input);
        }
    }
}
