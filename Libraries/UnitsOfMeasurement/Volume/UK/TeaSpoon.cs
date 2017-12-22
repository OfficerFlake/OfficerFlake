namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class UKTeaSpoon : Volume
            {
                public UKTeaSpoon(double value) : base(value, Conversion.UK.TeaSpoon, "UKTSP") { }

                public static UKTeaSpoon operator +(UKTeaSpoon firstMeasurement, UKTeaSpoon secondMeasurement)
                {
                    return new UKTeaSpoon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static UKTeaSpoon operator -(UKTeaSpoon firstMeasurement, UKTeaSpoon secondMeasurement)
                {
                    return new UKTeaSpoon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static UKTeaSpoon operator *(UKTeaSpoon firstMeasurement, UKTeaSpoon secondMeasurement)
                {
                    return new UKTeaSpoon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static UKTeaSpoon operator /(UKTeaSpoon firstMeasurement, UKTeaSpoon secondMeasurement)
                {
                    return new UKTeaSpoon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static UKTeaSpoon ToUKTeaSpoons(this Measurement input) => new UKTeaSpoon(input.ConvertToBase());

            public static UKTeaSpoon UKTeaSpoons(this byte input) => new UKTeaSpoon(input);
            public static UKTeaSpoon UKTeaSpoons(this short input) => new UKTeaSpoon(input);
            public static UKTeaSpoon UKTeaSpoons(this int input) => new UKTeaSpoon(input);
            public static UKTeaSpoon UKTeaSpoons(this long input) => new UKTeaSpoon(input);

            public static UKTeaSpoon UKTeaSpoons(this float input) => new UKTeaSpoon((double)input);
            public static UKTeaSpoon UKTeaSpoons(this double input) => new UKTeaSpoon((double)input);
            public static UKTeaSpoon UKTeaSpoons(this double input) => new UKTeaSpoon(input);
        }

    }
}
