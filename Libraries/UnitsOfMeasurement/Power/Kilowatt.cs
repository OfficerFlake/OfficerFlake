namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Powers
        {
            public class KiloWatt : Power
            {
                public KiloWatt(double value) : base(value, Conversion.KiloWatt, "KW") { }

                public static KiloWatt operator +(KiloWatt firstMeasurement, KiloWatt secondMeasurement)
                {
                    return new KiloWatt((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static KiloWatt operator -(KiloWatt firstMeasurement, KiloWatt secondMeasurement)
                {
                    return new KiloWatt((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static KiloWatt operator *(KiloWatt firstMeasurement, KiloWatt secondMeasurement)
                {
                    return new KiloWatt((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static KiloWatt operator /(KiloWatt firstMeasurement, KiloWatt secondMeasurement)
                {
                    return new KiloWatt((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static KiloWatt ToKiloWatts(this Measurement input) => new KiloWatt(input.ConvertToBase());

            public static KiloWatt KiloWatts(this byte input) => new KiloWatt(input);
            public static KiloWatt KiloWatts(this short input) => new KiloWatt(input);
            public static KiloWatt KiloWatts(this int input) => new KiloWatt(input);
            public static KiloWatt KiloWatts(this long input) => new KiloWatt(input);

            public static KiloWatt KiloWatts(this float input) => new KiloWatt((double)input);
            public static KiloWatt KiloWatts(this double input) => new KiloWatt((double)input);
        }
    }
}
