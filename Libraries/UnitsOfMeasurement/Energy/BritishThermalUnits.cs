namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Energys
        {
            public class BritishThermalUnits : Energy
            {
                public BritishThermalUnits(decimal value) : base(value, Conversion.BritishThermalUnits, "BTU") { }

                public static BritishThermalUnits operator +(BritishThermalUnits firstMeasurement, BritishThermalUnits secondMeasurement)
                {
                    return new BritishThermalUnits((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static BritishThermalUnits operator -(BritishThermalUnits firstMeasurement, BritishThermalUnits secondMeasurement)
                {
                    return new BritishThermalUnits((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static BritishThermalUnits operator *(BritishThermalUnits firstMeasurement, BritishThermalUnits secondMeasurement)
                {
                    return new BritishThermalUnits((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static BritishThermalUnits operator /(BritishThermalUnits firstMeasurement, BritishThermalUnits secondMeasurement)
                {
                    return new BritishThermalUnits((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static BritishThermalUnits ToBritishThermalUnitss(this Measurement input) => new BritishThermalUnits(input.ConvertToBase);

            public static BritishThermalUnits BritishThermalUnitss(this byte input) => new BritishThermalUnits(input);
            public static BritishThermalUnits BritishThermalUnitss(this short input) => new BritishThermalUnits(input);
            public static BritishThermalUnits BritishThermalUnitss(this int input) => new BritishThermalUnits(input);
            public static BritishThermalUnits BritishThermalUnitss(this long input) => new BritishThermalUnits(input);

            public static BritishThermalUnits BritishThermalUnitss(this float input) => new BritishThermalUnits((decimal)input);
            public static BritishThermalUnits BritishThermalUnitss(this double input) => new BritishThermalUnits((decimal)input);
            public static BritishThermalUnits BritishThermalUnitss(this decimal input) => new BritishThermalUnits(input);
        }
    }
}
