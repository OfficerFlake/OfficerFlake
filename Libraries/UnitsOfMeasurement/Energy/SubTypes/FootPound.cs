using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Energys
		{
			public class FootPound : Energy, IFootPound
			{
				#region CTOR
				public FootPound(double value) : base(value, Conversion.FootPound, Suffixes.FootPound) { }
				#endregion
				#region Operators
				public static FootPound operator +(FootPound firstMeasurement, FootPound secondMeasurement)
				{
					return new FootPound((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static FootPound operator -(FootPound firstMeasurement, FootPound secondMeasurement)
				{
					return new FootPound((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static FootPound operator *(FootPound firstMeasurement, FootPound secondMeasurement)
				{
					return new FootPound((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static FootPound operator /(FootPound firstMeasurement, FootPound secondMeasurement)
				{
					return new FootPound((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].FootPounds
			public static FootPound FootPounds(this Byte input) => new FootPound(input);
			public static FootPound FootPounds(this Int16 input) => new FootPound(input);
			public static FootPound FootPounds(this Int32 input) => new FootPound(input);
			public static FootPound FootPounds(this Int64 input) => new FootPound(input);
			public static FootPound FootPounds(this Single input) => new FootPound(input);
			public static FootPound FootPounds(this Double input) => new FootPound(input);
			#endregion
		}
	}
}
