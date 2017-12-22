namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Energys
        {
            public class FoodCalories : Energy
            {
                public FoodCalories(double value) : base(value, Conversion.FoodCalories, "CAL") { }

                public static FoodCalories operator +(FoodCalories firstMeasurement, FoodCalories secondMeasurement)
                {
                    return new FoodCalories((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static FoodCalories operator -(FoodCalories firstMeasurement, FoodCalories secondMeasurement)
                {
                    return new FoodCalories((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static FoodCalories operator *(FoodCalories firstMeasurement, FoodCalories secondMeasurement)
                {
                    return new FoodCalories((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static FoodCalories operator /(FoodCalories firstMeasurement, FoodCalories secondMeasurement)
                {
                    return new FoodCalories((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static FoodCalories ToFoodCaloriess(this Measurement input) => new FoodCalories(input.ConvertToBase());

            public static FoodCalories FoodCaloriess(this byte input) => new FoodCalories(input);
            public static FoodCalories FoodCaloriess(this short input) => new FoodCalories(input);
            public static FoodCalories FoodCaloriess(this int input) => new FoodCalories(input);
            public static FoodCalories FoodCaloriess(this long input) => new FoodCalories(input);

            public static FoodCalories FoodCaloriess(this float input) => new FoodCalories((double)input);
            public static FoodCalories FoodCaloriess(this double input) => new FoodCalories((double)input);
        }
    }
}
