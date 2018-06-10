using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Energys
		{
			public class FoodCalorie : Energy, IFoodCalorie
			{
				#region CTOR
				public FoodCalorie(double value) : base(value, Conversion.FoodCalorie, Suffixes.FoodCalorie) { }
				#endregion
				#region Operators
				public static FoodCalorie operator +(FoodCalorie firstMeasurement, FoodCalorie secondMeasurement)
				{
					return new FoodCalorie((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static FoodCalorie operator -(FoodCalorie firstMeasurement, FoodCalorie secondMeasurement)
				{
					return new FoodCalorie((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static FoodCalorie operator *(FoodCalorie firstMeasurement, FoodCalorie secondMeasurement)
				{
					return new FoodCalorie((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static FoodCalorie operator /(FoodCalorie firstMeasurement, FoodCalorie secondMeasurement)
				{
					return new FoodCalorie((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].FoodCalories
			public static FoodCalorie FoodCalories(this Byte input) => new FoodCalorie(input);
			public static FoodCalorie FoodCalories(this Int16 input) => new FoodCalorie(input);
			public static FoodCalorie FoodCalories(this Int32 input) => new FoodCalorie(input);
			public static FoodCalorie FoodCalories(this Int64 input) => new FoodCalorie(input);
			public static FoodCalorie FoodCalories(this Single input) => new FoodCalorie(input);
			public static FoodCalorie FoodCalories(this Double input) => new FoodCalorie(input);
			#endregion
		}
	}
}
