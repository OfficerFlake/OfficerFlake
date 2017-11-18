namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class UKPint : Volume
            {
                public UKPint(decimal value) : base(value, Conversion.UK.Pint, "UKPINT") { }

                public static UKPint operator +(UKPint firstMeasurement, UKPint secondMeasurement)
                {
                    return new UKPint((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static UKPint operator -(UKPint firstMeasurement, UKPint secondMeasurement)
                {
                    return new UKPint((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static UKPint operator *(UKPint firstMeasurement, UKPint secondMeasurement)
                {
                    return new UKPint((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static UKPint operator /(UKPint firstMeasurement, UKPint secondMeasurement)
                {
                    return new UKPint((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static UKPint ToUKPints(this Measurement input) => new UKPint(input.ConvertToBase);

            public static UKPint UKPints(this byte input) => new UKPint(input);
            public static UKPint UKPints(this short input) => new UKPint(input);
            public static UKPint UKPints(this int input) => new UKPint(input);
            public static UKPint UKPints(this long input) => new UKPint(input);

            public static UKPint UKPints(this float input) => new UKPint((decimal)input);
            public static UKPint UKPints(this double input) => new UKPint((decimal)input);
            public static UKPint UKPints(this decimal input) => new UKPint(input);
        }

    }
}
