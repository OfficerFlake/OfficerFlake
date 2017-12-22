namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class UKPint : Volume
            {
                public UKPint(double value) : base(value, Conversion.UK.Pint, "UKPINT") { }

                public static UKPint operator +(UKPint firstMeasurement, UKPint secondMeasurement)
                {
                    return new UKPint((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static UKPint operator -(UKPint firstMeasurement, UKPint secondMeasurement)
                {
                    return new UKPint((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static UKPint operator *(UKPint firstMeasurement, UKPint secondMeasurement)
                {
                    return new UKPint((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static UKPint operator /(UKPint firstMeasurement, UKPint secondMeasurement)
                {
                    return new UKPint((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static UKPint ToUKPints(this Measurement input) => new UKPint(input.ConvertToBase());

            public static UKPint UKPints(this byte input) => new UKPint(input);
            public static UKPint UKPints(this short input) => new UKPint(input);
            public static UKPint UKPints(this int input) => new UKPint(input);
            public static UKPint UKPints(this long input) => new UKPint(input);

            public static UKPint UKPints(this float input) => new UKPint((double)input);
            public static UKPint UKPints(this double input) => new UKPint((double)input);
        }

    }
}
