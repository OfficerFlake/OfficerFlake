namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Lengths
        {
            public class Micron : Length
            {
                public Micron(decimal value) : base(value, Conversion.Micron, "UM") { }

                public static Micron operator +(Micron firstMeasurement, Micron secondMeasurement)
                {
                    return new Micron((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Micron operator -(Micron firstMeasurement, Micron secondMeasurement)
                {
                    return new Micron((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Micron operator *(Micron firstMeasurement, Micron secondMeasurement)
                {
                    return new Micron((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Micron operator /(Micron firstMeasurement, Micron secondMeasurement)
                {
                    return new Micron((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Micron ToMicrons(this Measurement input) => new Micron(input.ConvertToBase);

            public static Micron Microns(this byte input) => new Micron(input);
            public static Micron Microns(this short input) => new Micron(input);
            public static Micron Microns(this int input) => new Micron(input);
            public static Micron Microns(this long input) => new Micron(input);

            public static Micron Microns(this float input) => new Micron((decimal)input);
            public static Micron Microns(this double input) => new Micron((decimal)input);
            public static Micron Microns(this decimal input) => new Micron(input);
        }
    }
}
