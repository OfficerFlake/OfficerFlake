using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class SquareKilometer : Area, ISquareKilometer
			{
				#region CTOR
				public SquareKilometer(double value) : base(value, Conversion.SquareKilometer, Suffixes.SquareKilometer) { }
				#endregion
				#region Operators
				public static SquareKilometer operator +(SquareKilometer firstMeasurement, SquareKilometer secondMeasurement)
				{
					return new SquareKilometer((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static SquareKilometer operator -(SquareKilometer firstMeasurement, SquareKilometer secondMeasurement)
				{
					return new SquareKilometer((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static SquareKilometer operator *(SquareKilometer firstMeasurement, SquareKilometer secondMeasurement)
				{
					return new SquareKilometer((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static SquareKilometer operator /(SquareKilometer firstMeasurement, SquareKilometer secondMeasurement)
				{
					return new SquareKilometer((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].SquareKilometers
			public static SquareKilometer SquareKilometers(this Byte input) => new SquareKilometer(input);
			public static SquareKilometer SquareKilometers(this Int16 input) => new SquareKilometer(input);
			public static SquareKilometer SquareKilometers(this Int32 input) => new SquareKilometer(input);
			public static SquareKilometer SquareKilometers(this Int64 input) => new SquareKilometer(input);
			public static SquareKilometer SquareKilometers(this Single input) => new SquareKilometer(input);
			public static SquareKilometer SquareKilometers(this Double input) => new SquareKilometer(input);
			#endregion
		}
	}
}
