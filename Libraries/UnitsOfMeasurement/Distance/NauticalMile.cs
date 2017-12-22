namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Distances
		{
            public class NauticalMile : Distance
			{
                public NauticalMile(double value) : base(value, Conversion.NauticalMile, "NM") { }

                public static NauticalMile operator +(NauticalMile firstMeasurement, NauticalMile secondMeasurement)
                {
                    return new NauticalMile((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static NauticalMile operator -(NauticalMile firstMeasurement, NauticalMile secondMeasurement)
                {
                    return new NauticalMile((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static NauticalMile operator *(NauticalMile firstMeasurement, NauticalMile secondMeasurement)
                {
                    return new NauticalMile((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static NauticalMile operator /(NauticalMile firstMeasurement, NauticalMile secondMeasurement)
                {
                    return new NauticalMile((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static NauticalMile ToNauticalMiles(this Measurement input) => new NauticalMile(input.ConvertToBase());

            public static NauticalMile NauticalMiles(this byte input) => new NauticalMile(input);
            public static NauticalMile NauticalMiles(this short input) => new NauticalMile(input);
            public static NauticalMile NauticalMiles(this int input) => new NauticalMile(input);
            public static NauticalMile NauticalMiles(this long input) => new NauticalMile(input);

            public static NauticalMile NauticalMiles(this float input) => new NauticalMile((double)input);
            public static NauticalMile NauticalMiles(this double input) => new NauticalMile((double)input);
        }
    }
}
