namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class CubicMeter : Volume
            {
                public CubicMeter(double value) : base(value, Conversion.CubicMeter, "M^3") { }

                public static CubicMeter operator +(CubicMeter firstMeasurement, CubicMeter secondMeasurement)
                {
                    return new CubicMeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static CubicMeter operator -(CubicMeter firstMeasurement, CubicMeter secondMeasurement)
                {
                    return new CubicMeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static CubicMeter operator *(CubicMeter firstMeasurement, CubicMeter secondMeasurement)
                {
                    return new CubicMeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static CubicMeter operator /(CubicMeter firstMeasurement, CubicMeter secondMeasurement)
                {
                    return new CubicMeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static CubicMeter ToCubicMeters(this Measurement input) => new CubicMeter(input.ConvertToBase());

            public static CubicMeter CubicMeters(this byte input) => new CubicMeter(input);
            public static CubicMeter CubicMeters(this short input) => new CubicMeter(input);
            public static CubicMeter CubicMeters(this int input) => new CubicMeter(input);
            public static CubicMeter CubicMeters(this long input) => new CubicMeter(input);

            public static CubicMeter CubicMeters(this float input) => new CubicMeter((double)input);
            public static CubicMeter CubicMeters(this double input) => new CubicMeter((double)input);
        }
    }
}
