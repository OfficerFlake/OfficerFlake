namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Energys
        {
            public class ElectronVolt : Energy
            {
                public ElectronVolt(decimal value) : base(value, Conversion.ElectronVolt, "EV") { }

                public static ElectronVolt operator +(ElectronVolt firstMeasurement, ElectronVolt secondMeasurement)
                {
                    return new ElectronVolt((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static ElectronVolt operator -(ElectronVolt firstMeasurement, ElectronVolt secondMeasurement)
                {
                    return new ElectronVolt((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static ElectronVolt operator *(ElectronVolt firstMeasurement, ElectronVolt secondMeasurement)
                {
                    return new ElectronVolt((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static ElectronVolt operator /(ElectronVolt firstMeasurement, ElectronVolt secondMeasurement)
                {
                    return new ElectronVolt((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static ElectronVolt ToElectronVolts(this Measurement input) => new ElectronVolt(input.ConvertToBase);

            public static ElectronVolt ElectronVolts(this byte input) => new ElectronVolt(input);
            public static ElectronVolt ElectronVolts(this short input) => new ElectronVolt(input);
            public static ElectronVolt ElectronVolts(this int input) => new ElectronVolt(input);
            public static ElectronVolt ElectronVolts(this long input) => new ElectronVolt(input);

            public static ElectronVolt ElectronVolts(this float input) => new ElectronVolt((decimal)input);
            public static ElectronVolt ElectronVolts(this double input) => new ElectronVolt((decimal)input);
            public static ElectronVolt ElectronVolts(this decimal input) => new ElectronVolt(input);
        }
    }
}
