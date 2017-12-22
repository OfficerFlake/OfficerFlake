namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Distances
		{
            public class Micron : Distance
			{
                public Micron(double value) : base(value, Conversion.Micron, "UM") { }

                public static Micron operator +(Micron firstMeasurement, Micron secondMeasurement)
                {
                    return new Micron((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Micron operator -(Micron firstMeasurement, Micron secondMeasurement)
                {
                    return new Micron((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Micron operator *(Micron firstMeasurement, Micron secondMeasurement)
                {
                    return new Micron((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Micron operator /(Micron firstMeasurement, Micron secondMeasurement)
                {
                    return new Micron((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Micron ToMicrons(this Measurement input) => new Micron(input.ConvertToBase());

            public static Micron Microns(this byte input) => new Micron(input);
            public static Micron Microns(this short input) => new Micron(input);
            public static Micron Microns(this int input) => new Micron(input);
            public static Micron Microns(this long input) => new Micron(input);

            public static Micron Microns(this float input) => new Micron((double)input);
            public static Micron Microns(this double input) => new Micron((double)input);
        }
    }
}
