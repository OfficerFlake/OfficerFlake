namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Pressures
        {
            public class PoundsPerSquareInch : Pressure
            {
                public PoundsPerSquareInch(decimal value) : base(value, Conversion.PoundsPerSquareInch, "LB/IN^2") { }

                public static PoundsPerSquareInch operator +(PoundsPerSquareInch firstMeasurement, PoundsPerSquareInch secondMeasurement)
                {
                    return new PoundsPerSquareInch((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static PoundsPerSquareInch operator -(PoundsPerSquareInch firstMeasurement, PoundsPerSquareInch secondMeasurement)
                {
                    return new PoundsPerSquareInch((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static PoundsPerSquareInch operator *(PoundsPerSquareInch firstMeasurement, PoundsPerSquareInch secondMeasurement)
                {
                    return new PoundsPerSquareInch((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static PoundsPerSquareInch operator /(PoundsPerSquareInch firstMeasurement, PoundsPerSquareInch secondMeasurement)
                {
                    return new PoundsPerSquareInch((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static PoundsPerSquareInch ToPoundsPerSquareInchs(this Measurement input) => new PoundsPerSquareInch(input.ConvertToBase);

            public static PoundsPerSquareInch PoundsPerSquareInchs(this byte input) => new PoundsPerSquareInch(input);
            public static PoundsPerSquareInch PoundsPerSquareInchs(this short input) => new PoundsPerSquareInch(input);
            public static PoundsPerSquareInch PoundsPerSquareInchs(this int input) => new PoundsPerSquareInch(input);
            public static PoundsPerSquareInch PoundsPerSquareInchs(this long input) => new PoundsPerSquareInch(input);

            public static PoundsPerSquareInch PoundsPerSquareInchs(this float input) => new PoundsPerSquareInch((decimal)input);
            public static PoundsPerSquareInch PoundsPerSquareInchs(this double input) => new PoundsPerSquareInch((decimal)input);
            public static PoundsPerSquareInch PoundsPerSquareInchs(this decimal input) => new PoundsPerSquareInch(input);
        }
    }
}
