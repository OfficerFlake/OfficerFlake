namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class MetricTonne : Mass
            {
                public MetricTonne(decimal value) : base(value, Conversion.MetricTonne, "T") { }

                public static MetricTonne operator +(MetricTonne firstMeasurement, MetricTonne secondMeasurement)
                {
                    return new MetricTonne((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static MetricTonne operator -(MetricTonne firstMeasurement, MetricTonne secondMeasurement)
                {
                    return new MetricTonne((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static MetricTonne operator *(MetricTonne firstMeasurement, MetricTonne secondMeasurement)
                {
                    return new MetricTonne((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static MetricTonne operator /(MetricTonne firstMeasurement, MetricTonne secondMeasurement)
                {
                    return new MetricTonne((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static MetricTonne ToMetricTonnes(this Measurement input) => new MetricTonne(input.ConvertToBase);

            public static MetricTonne MetricTonnes(this byte input) => new MetricTonne(input);
            public static MetricTonne MetricTonnes(this short input) => new MetricTonne(input);
            public static MetricTonne MetricTonnes(this int input) => new MetricTonne(input);
            public static MetricTonne MetricTonnes(this long input) => new MetricTonne(input);

            public static MetricTonne MetricTonnes(this float input) => new MetricTonne((decimal)input);
            public static MetricTonne MetricTonnes(this double input) => new MetricTonne((decimal)input);
            public static MetricTonne MetricTonnes(this decimal input) => new MetricTonne(input);
        }
    }
}
