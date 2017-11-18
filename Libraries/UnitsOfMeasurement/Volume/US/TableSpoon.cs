namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class USTableSpoon : Volume
            {
                public USTableSpoon(decimal value) : base(value, Conversion.US.TableSpoon, "TBLSP") { }

                public static USTableSpoon operator +(USTableSpoon firstMeasurement, USTableSpoon secondMeasurement)
                {
                    return new USTableSpoon((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static USTableSpoon operator -(USTableSpoon firstMeasurement, USTableSpoon secondMeasurement)
                {
                    return new USTableSpoon((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static USTableSpoon operator *(USTableSpoon firstMeasurement, USTableSpoon secondMeasurement)
                {
                    return new USTableSpoon((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static USTableSpoon operator /(USTableSpoon firstMeasurement, USTableSpoon secondMeasurement)
                {
                    return new USTableSpoon((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static USTableSpoon ToUSTableSpoons(this Measurement input) => new USTableSpoon(input.ConvertToBase);

            public static USTableSpoon USTableSpoons(this byte input) => new USTableSpoon(input);
            public static USTableSpoon USTableSpoons(this short input) => new USTableSpoon(input);
            public static USTableSpoon USTableSpoons(this int input) => new USTableSpoon(input);
            public static USTableSpoon USTableSpoons(this long input) => new USTableSpoon(input);

            public static USTableSpoon USTableSpoons(this float input) => new USTableSpoon((decimal)input);
            public static USTableSpoon USTableSpoons(this double input) => new USTableSpoon((decimal)input);
            public static USTableSpoon USTableSpoons(this decimal input) => new USTableSpoon(input);
        }

    }
}
