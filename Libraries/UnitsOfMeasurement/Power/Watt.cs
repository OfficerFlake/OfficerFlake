namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Powers
        {
            public class Watt : Power
            {
                public Watt(double value) : base(value, Conversion.Watt, "W") { }

                public static Watt operator +(Watt firstMeasurement, Watt secondMeasurement)
                {
                    return new Watt((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Watt operator -(Watt firstMeasurement, Watt secondMeasurement)
                {
                    return new Watt((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Watt operator *(Watt firstMeasurement, Watt secondMeasurement)
                {
                    return new Watt((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Watt operator /(Watt firstMeasurement, Watt secondMeasurement)
                {
                    return new Watt((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Watt ToWatts(this Measurement input) => new Watt(input.ConvertToBase());

            public static Watt Watts(this byte input) => new Watt(input);
            public static Watt Watts(this short input) => new Watt(input);
            public static Watt Watts(this int input) => new Watt(input);
            public static Watt Watts(this long input) => new Watt(input);

            public static Watt Watts(this float input) => new Watt((double)input);
            public static Watt Watts(this double input) => new Watt((double)input);
        }
    }
}
