namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Lengths
        {
            public class Nanometer : Length
            {
                public Nanometer(decimal value) : base(value, Conversion.Nanometer, "NM") { }

                public static Nanometer operator +(Nanometer firstMeasurement, Nanometer secondMeasurement)
                {
                    return new Nanometer((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Nanometer operator -(Nanometer firstMeasurement, Nanometer secondMeasurement)
                {
                    return new Nanometer((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Nanometer operator *(Nanometer firstMeasurement, Nanometer secondMeasurement)
                {
                    return new Nanometer((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Nanometer operator /(Nanometer firstMeasurement, Nanometer secondMeasurement)
                {
                    return new Nanometer((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Nanometer ToNanometers(this Measurement input) => new Nanometer(input.ConvertToBase);

            public static Nanometer Nanometers(this byte input) => new Nanometer(input);
            public static Nanometer Nanometers(this short input) => new Nanometer(input);
            public static Nanometer Nanometers(this int input) => new Nanometer(input);
            public static Nanometer Nanometers(this long input) => new Nanometer(input);

            public static Nanometer Nanometers(this float input) => new Nanometer((decimal)input);
            public static Nanometer Nanometers(this double input) => new Nanometer((decimal)input);
            public static Nanometer Nanometers(this decimal input) => new Nanometer(input);
        }
    }
}
