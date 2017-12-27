using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Angles
		{
			public class Gradian : Angle, IGradian
			{
				#region CTOR
				public Gradian(double value) : base(value, Conversion.Gradian, Suffixes.Gradian) { }
				#endregion
				#region Operators
				public static Gradian operator +(Gradian firstMeasurement, Gradian secondMeasurement)
				{
					return new Gradian((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Gradian operator -(Gradian firstMeasurement, Gradian secondMeasurement)
				{
					return new Gradian((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Gradian operator *(Gradian firstMeasurement, Gradian secondMeasurement)
				{
					return new Gradian((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Gradian operator /(Gradian firstMeasurement, Gradian secondMeasurement)
				{
					return new Gradian((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Gradians
			public static Gradian Gradians(this Byte input) => new Gradian(input);
			public static Gradian Gradians(this Int16 input) => new Gradian(input);
			public static Gradian Gradians(this Int32 input) => new Gradian(input);
			public static Gradian Gradians(this Int64 input) => new Gradian(input);
			public static Gradian Gradians(this Single input) => new Gradian(input);
			public static Gradian Gradians(this Double input) => new Gradian(input);
			#endregion
		}
	}
}
