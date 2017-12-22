namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Areas
        {
            public class Hectare : Area
            {
                public Hectare(double value) : base(value, Conversion.Hectare, "HA") { }

                public static Hectare operator +(Hectare firstMeasurement, Hectare secondMeasurement)
                {
                    return new Hectare((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Hectare operator -(Hectare firstMeasurement, Hectare secondMeasurement)
                {
                    return new Hectare((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Hectare operator *(Hectare firstMeasurement, Hectare secondMeasurement)
                {
                    return new Hectare((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Hectare operator /(Hectare firstMeasurement, Hectare secondMeasurement)
                {
                    return new Hectare((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Hectare ToHectares(this Measurement input) => new Hectare(input.ConvertToBase());

            public static Hectare Hectares(this byte input) => new Hectare(input);
            public static Hectare Hectares(this short input) => new Hectare(input);
            public static Hectare Hectares(this int input) => new Hectare(input);
            public static Hectare Hectares(this long input) => new Hectare(input);

            public static Hectare Hectares(this float input) => new Hectare((double)input);
            public static Hectare Hectares(this double input) => new Hectare((double)input);
        }
    }
}
