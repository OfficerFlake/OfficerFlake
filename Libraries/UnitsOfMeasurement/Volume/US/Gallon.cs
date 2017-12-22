namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class USGallon : Volume
            {
                public USGallon(double value) : base(value, Conversion.US.Gallon, "GALLON") { }

                public static USGallon operator +(USGallon firstMeasurement, USGallon secondMeasurement)
                {
                    return new USGallon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static USGallon operator -(USGallon firstMeasurement, USGallon secondMeasurement)
                {
                    return new USGallon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static USGallon operator *(USGallon firstMeasurement, USGallon secondMeasurement)
                {
                    return new USGallon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static USGallon operator /(USGallon firstMeasurement, USGallon secondMeasurement)
                {
                    return new USGallon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static USGallon ToUSGallons(this Measurement input) => new USGallon(input.ConvertToBase());

            public static USGallon USGallons(this byte input) => new USGallon(input);
            public static USGallon USGallons(this short input) => new USGallon(input);
            public static USGallon USGallons(this int input) => new USGallon(input);
            public static USGallon USGallons(this long input) => new USGallon(input);

            public static USGallon USGallons(this float input) => new USGallon((double)input);
            public static USGallon USGallons(this double input) => new USGallon((double)input);
            public static USGallon USGallons(this double input) => new USGallon(input);
        }

    }
}
