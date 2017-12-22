namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Speeds
        {
            public class MachAtSeaLevel : Speed
            {
                public MachAtSeaLevel(double value) : base(value, Conversion.MachAtSeaLevel, "MACH") { }

                public static MachAtSeaLevel operator +(MachAtSeaLevel firstMeasurement, MachAtSeaLevel secondMeasurement)
                {
                    return new MachAtSeaLevel((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static MachAtSeaLevel operator -(MachAtSeaLevel firstMeasurement, MachAtSeaLevel secondMeasurement)
                {
                    return new MachAtSeaLevel((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static MachAtSeaLevel operator *(MachAtSeaLevel firstMeasurement, MachAtSeaLevel secondMeasurement)
                {
                    return new MachAtSeaLevel((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static MachAtSeaLevel operator /(MachAtSeaLevel firstMeasurement, MachAtSeaLevel secondMeasurement)
                {
                    return new MachAtSeaLevel((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static MachAtSeaLevel ToMachAtSeaLevels(this Measurement input) => new MachAtSeaLevel(input.ConvertToBase());

            public static MachAtSeaLevel MachAtSeaLevels(this byte input) => new MachAtSeaLevel(input);
            public static MachAtSeaLevel MachAtSeaLevels(this short input) => new MachAtSeaLevel(input);
            public static MachAtSeaLevel MachAtSeaLevels(this int input) => new MachAtSeaLevel(input);
            public static MachAtSeaLevel MachAtSeaLevels(this long input) => new MachAtSeaLevel(input);

            public static MachAtSeaLevel MachAtSeaLevels(this float input) => new MachAtSeaLevel((double)input);
            public static MachAtSeaLevel MachAtSeaLevels(this double input) => new MachAtSeaLevel((double)input);
        }
    }
}
