namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class UKTableSpoon : Volume
            {
                public UKTableSpoon(double value) : base(value, Conversion.UK.TableSpoon, "UKTBLSP") { }

                public static UKTableSpoon operator +(UKTableSpoon firstMeasurement, UKTableSpoon secondMeasurement)
                {
                    return new UKTableSpoon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static UKTableSpoon operator -(UKTableSpoon firstMeasurement, UKTableSpoon secondMeasurement)
                {
                    return new UKTableSpoon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static UKTableSpoon operator *(UKTableSpoon firstMeasurement, UKTableSpoon secondMeasurement)
                {
                    return new UKTableSpoon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static UKTableSpoon operator /(UKTableSpoon firstMeasurement, UKTableSpoon secondMeasurement)
                {
                    return new UKTableSpoon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static UKTableSpoon ToUKTableSpoons(this Measurement input) => new UKTableSpoon(input.ConvertToBase());

            public static UKTableSpoon UKTableSpoons(this byte input) => new UKTableSpoon(input);
            public static UKTableSpoon UKTableSpoons(this short input) => new UKTableSpoon(input);
            public static UKTableSpoon UKTableSpoons(this int input) => new UKTableSpoon(input);
            public static UKTableSpoon UKTableSpoons(this long input) => new UKTableSpoon(input);

            public static UKTableSpoon UKTableSpoons(this float input) => new UKTableSpoon((double)input);
            public static UKTableSpoon UKTableSpoons(this double input) => new UKTableSpoon((double)input);
            public static UKTableSpoon UKTableSpoons(this double input) => new UKTableSpoon(input);
        }

    }
}
