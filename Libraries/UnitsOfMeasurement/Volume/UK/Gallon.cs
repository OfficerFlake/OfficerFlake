namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class UKGallon : Volume
            {
                public UKGallon(decimal value) : base(value, Conversion.UK.Gallon, "UKGALLON") { }

                public static UKGallon operator +(UKGallon firstMeasurement, UKGallon secondMeasurement)
                {
                    return new UKGallon((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static UKGallon operator -(UKGallon firstMeasurement, UKGallon secondMeasurement)
                {
                    return new UKGallon((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static UKGallon operator *(UKGallon firstMeasurement, UKGallon secondMeasurement)
                {
                    return new UKGallon((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static UKGallon operator /(UKGallon firstMeasurement, UKGallon secondMeasurement)
                {
                    return new UKGallon((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static UKGallon ToUKGallons(this Measurement input) => new UKGallon(input.ConvertToBase);

            public static UKGallon UKGallons(this byte input) => new UKGallon(input);
            public static UKGallon UKGallons(this short input) => new UKGallon(input);
            public static UKGallon UKGallons(this int input) => new UKGallon(input);
            public static UKGallon UKGallons(this long input) => new UKGallon(input);

            public static UKGallon UKGallons(this float input) => new UKGallon((decimal)input);
            public static UKGallon UKGallons(this double input) => new UKGallon((decimal)input);
            public static UKGallon UKGallons(this decimal input) => new UKGallon(input);
        }

    }
}
