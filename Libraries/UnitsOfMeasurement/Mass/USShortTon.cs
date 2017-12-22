namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class USShortTon : Mass
            {
                public USShortTon(double value) : base(value, Conversion.USShortTon, "SHORTTON") { }

                public static USShortTon operator +(USShortTon firstMeasurement, USShortTon secondMeasurement)
                {
                    return new USShortTon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static USShortTon operator -(USShortTon firstMeasurement, USShortTon secondMeasurement)
                {
                    return new USShortTon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static USShortTon operator *(USShortTon firstMeasurement, USShortTon secondMeasurement)
                {
                    return new USShortTon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static USShortTon operator /(USShortTon firstMeasurement, USShortTon secondMeasurement)
                {
                    return new USShortTon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static USShortTon ToUSShortTons(this Measurement input) => new USShortTon(input.ConvertToBase());

            public static USShortTon USShortTons(this byte input) => new USShortTon(input);
            public static USShortTon USShortTons(this short input) => new USShortTon(input);
            public static USShortTon USShortTons(this int input) => new USShortTon(input);
            public static USShortTon USShortTons(this long input) => new USShortTon(input);

            public static USShortTon USShortTons(this float input) => new USShortTon((double)input);
            public static USShortTon USShortTons(this double input) => new USShortTon((double)input);
        }
    }
}
