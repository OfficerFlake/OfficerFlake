namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Energys
        {
            public class ThermalCalorie : Energy
            {
                public ThermalCalorie(double value) : base(value, Conversion.ThermalCalorie, "THCAL") { }

                public static ThermalCalorie operator +(ThermalCalorie firstMeasurement, ThermalCalorie secondMeasurement)
                {
                    return new ThermalCalorie((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static ThermalCalorie operator -(ThermalCalorie firstMeasurement, ThermalCalorie secondMeasurement)
                {
                    return new ThermalCalorie((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static ThermalCalorie operator *(ThermalCalorie firstMeasurement, ThermalCalorie secondMeasurement)
                {
                    return new ThermalCalorie((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static ThermalCalorie operator /(ThermalCalorie firstMeasurement, ThermalCalorie secondMeasurement)
                {
                    return new ThermalCalorie((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static ThermalCalorie ToThermalCalories(this Measurement input) => new ThermalCalorie(input.ConvertToBase());

            public static ThermalCalorie ThermalCalories(this byte input) => new ThermalCalorie(input);
            public static ThermalCalorie ThermalCalories(this short input) => new ThermalCalorie(input);
            public static ThermalCalorie ThermalCalories(this int input) => new ThermalCalorie(input);
            public static ThermalCalorie ThermalCalories(this long input) => new ThermalCalorie(input);

            public static ThermalCalorie ThermalCalories(this float input) => new ThermalCalorie((double)input);
            public static ThermalCalorie ThermalCalories(this double input) => new ThermalCalorie((double)input);
        }
    }
}
