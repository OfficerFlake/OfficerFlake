namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class Millilitre : Volume
            {
                public Millilitre(double value) : base(value, Conversion.Millilitre, "ML") { }

                public static Millilitre operator +(Millilitre firstMeasurement, Millilitre secondMeasurement)
                {
                    return new Millilitre((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Millilitre operator -(Millilitre firstMeasurement, Millilitre secondMeasurement)
                {
                    return new Millilitre((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Millilitre operator *(Millilitre firstMeasurement, Millilitre secondMeasurement)
                {
                    return new Millilitre((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Millilitre operator /(Millilitre firstMeasurement, Millilitre secondMeasurement)
                {
                    return new Millilitre((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Millilitre ToMillilitres(this Measurement input) => new Millilitre(input.ConvertToBase());

            public static Millilitre Millilitres(this byte input) => new Millilitre(input);
            public static Millilitre Millilitres(this short input) => new Millilitre(input);
            public static Millilitre Millilitres(this int input) => new Millilitre(input);
            public static Millilitre Millilitres(this long input) => new Millilitre(input);

            public static Millilitre Millilitres(this float input) => new Millilitre((double)input);
            public static Millilitre Millilitres(this double input) => new Millilitre((double)input);
            public static Millilitre Millilitres(this double input) => new Millilitre(input);
        }
    }
}
