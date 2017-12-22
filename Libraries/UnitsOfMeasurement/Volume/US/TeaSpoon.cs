namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class USTeaSpoon : Volume
            {
                public USTeaSpoon(double value) : base(value, Conversion.US.TeaSpoon, "TSP") { }

                public static USTeaSpoon operator +(USTeaSpoon firstMeasurement, USTeaSpoon secondMeasurement)
                {
                    return new USTeaSpoon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static USTeaSpoon operator -(USTeaSpoon firstMeasurement, USTeaSpoon secondMeasurement)
                {
                    return new USTeaSpoon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static USTeaSpoon operator *(USTeaSpoon firstMeasurement, USTeaSpoon secondMeasurement)
                {
                    return new USTeaSpoon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static USTeaSpoon operator /(USTeaSpoon firstMeasurement, USTeaSpoon secondMeasurement)
                {
                    return new USTeaSpoon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static USTeaSpoon ToUSTeaSpoons(this Measurement input) => new USTeaSpoon(input.ConvertToBase());

            public static USTeaSpoon USTeaSpoons(this byte input) => new USTeaSpoon(input);
            public static USTeaSpoon USTeaSpoons(this short input) => new USTeaSpoon(input);
            public static USTeaSpoon USTeaSpoons(this int input) => new USTeaSpoon(input);
            public static USTeaSpoon USTeaSpoons(this long input) => new USTeaSpoon(input);

            public static USTeaSpoon USTeaSpoons(this float input) => new USTeaSpoon((double)input);
            public static USTeaSpoon USTeaSpoons(this double input) => new USTeaSpoon((double)input);
        }

    }
}
