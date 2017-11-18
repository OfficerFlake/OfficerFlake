namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class UKFluidOunce : Volume
            {
                public UKFluidOunce(decimal value) : base(value, Conversion.UK.FluidOunce, "UKFLOZ") { }

                public static UKFluidOunce operator +(UKFluidOunce firstMeasurement, UKFluidOunce secondMeasurement)
                {
                    return new UKFluidOunce((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static UKFluidOunce operator -(UKFluidOunce firstMeasurement, UKFluidOunce secondMeasurement)
                {
                    return new UKFluidOunce((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static UKFluidOunce operator *(UKFluidOunce firstMeasurement, UKFluidOunce secondMeasurement)
                {
                    return new UKFluidOunce((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static UKFluidOunce operator /(UKFluidOunce firstMeasurement, UKFluidOunce secondMeasurement)
                {
                    return new UKFluidOunce((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static UKFluidOunce ToUKFluidOunces(this Measurement input) => new UKFluidOunce(input.ConvertToBase);

            public static UKFluidOunce UKFluidOunces(this byte input) => new UKFluidOunce(input);
            public static UKFluidOunce UKFluidOunces(this short input) => new UKFluidOunce(input);
            public static UKFluidOunce UKFluidOunces(this int input) => new UKFluidOunce(input);
            public static UKFluidOunce UKFluidOunces(this long input) => new UKFluidOunce(input);

            public static UKFluidOunce UKFluidOunces(this float input) => new UKFluidOunce((decimal)input);
            public static UKFluidOunce UKFluidOunces(this double input) => new UKFluidOunce((decimal)input);
            public static UKFluidOunce UKFluidOunces(this decimal input) => new UKFluidOunce(input);
        }

    }
}
