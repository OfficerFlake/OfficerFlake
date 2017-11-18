namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class UKLongTon : Mass
            {
                public UKLongTon(decimal value) : base(value, Conversion.UKLongTon, "LONGTON") { }

                public static UKLongTon operator +(UKLongTon firstMeasurement, UKLongTon secondMeasurement)
                {
                    return new UKLongTon((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static UKLongTon operator -(UKLongTon firstMeasurement, UKLongTon secondMeasurement)
                {
                    return new UKLongTon((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static UKLongTon operator *(UKLongTon firstMeasurement, UKLongTon secondMeasurement)
                {
                    return new UKLongTon((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static UKLongTon operator /(UKLongTon firstMeasurement, UKLongTon secondMeasurement)
                {
                    return new UKLongTon((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static UKLongTon ToUKLongTons(this Measurement input) => new UKLongTon(input.ConvertToBase);

            public static UKLongTon UKLongTons(this byte input) => new UKLongTon(input);
            public static UKLongTon UKLongTons(this short input) => new UKLongTon(input);
            public static UKLongTon UKLongTons(this int input) => new UKLongTon(input);
            public static UKLongTon UKLongTons(this long input) => new UKLongTon(input);

            public static UKLongTon UKLongTons(this float input) => new UKLongTon((decimal)input);
            public static UKLongTon UKLongTons(this double input) => new UKLongTon((decimal)input);
            public static UKLongTon UKLongTons(this decimal input) => new UKLongTon(input);
        }
    }
}
