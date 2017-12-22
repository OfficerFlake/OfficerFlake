namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class USPint : Volume
            {
                public USPint(double value) : base(value, Conversion.US.Pint, "PINT") { }

                public static USPint operator +(USPint firstMeasurement, USPint secondMeasurement)
                {
                    return new USPint((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static USPint operator -(USPint firstMeasurement, USPint secondMeasurement)
                {
                    return new USPint((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static USPint operator *(USPint firstMeasurement, USPint secondMeasurement)
                {
                    return new USPint((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static USPint operator /(USPint firstMeasurement, USPint secondMeasurement)
                {
                    return new USPint((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static USPint ToUSPints(this Measurement input) => new USPint(input.ConvertToBase());

            public static USPint USPints(this byte input) => new USPint(input);
            public static USPint USPints(this short input) => new USPint(input);
            public static USPint USPints(this int input) => new USPint(input);
            public static USPint USPints(this long input) => new USPint(input);

            public static USPint USPints(this float input) => new USPint((double)input);
            public static USPint USPints(this double input) => new USPint((double)input);
        }

    }
}
