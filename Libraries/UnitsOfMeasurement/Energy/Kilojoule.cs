namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Energys
        {
            public class Kilojoule : Energy
            {
                public Kilojoule(decimal value) : base(value, Conversion.Kilojoule, "KJ") { }

                public static Kilojoule operator +(Kilojoule firstMeasurement, Kilojoule secondMeasurement)
                {
                    return new Kilojoule((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Kilojoule operator -(Kilojoule firstMeasurement, Kilojoule secondMeasurement)
                {
                    return new Kilojoule((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Kilojoule operator *(Kilojoule firstMeasurement, Kilojoule secondMeasurement)
                {
                    return new Kilojoule((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Kilojoule operator /(Kilojoule firstMeasurement, Kilojoule secondMeasurement)
                {
                    return new Kilojoule((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Kilojoule ToKilojoules(this Measurement input) => new Kilojoule(input.ConvertToBase);

            public static Kilojoule Kilojoules(this byte input) => new Kilojoule(input);
            public static Kilojoule Kilojoules(this short input) => new Kilojoule(input);
            public static Kilojoule Kilojoules(this int input) => new Kilojoule(input);
            public static Kilojoule Kilojoules(this long input) => new Kilojoule(input);

            public static Kilojoule Kilojoules(this float input) => new Kilojoule((decimal)input);
            public static Kilojoule Kilojoules(this double input) => new Kilojoule((decimal)input);
            public static Kilojoule Kilojoules(this decimal input) => new Kilojoule(input);
        }
    }
}
