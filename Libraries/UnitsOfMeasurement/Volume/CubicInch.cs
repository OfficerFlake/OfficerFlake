using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class CubicInch : Volume, ICubicInch
			{
				#region CTOR
				public CubicInch(double value) : base(value, Conversion.CubicInch, Suffixes.CubicInch) { }
				#endregion
				#region Operators
				public static CubicInch operator +(CubicInch firstMeasurement, CubicInch secondMeasurement)
				{
					return new CubicInch((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static CubicInch operator -(CubicInch firstMeasurement, CubicInch secondMeasurement)
				{
					return new CubicInch((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static CubicInch operator *(CubicInch firstMeasurement, CubicInch secondMeasurement)
				{
					return new CubicInch((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static CubicInch operator /(CubicInch firstMeasurement, CubicInch secondMeasurement)
				{
					return new CubicInch((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].CubicInches
			public static CubicInch CubicInches(this Byte input) => new CubicInch(input);
			public static CubicInch CubicInches(this Int16 input) => new CubicInch(input);
			public static CubicInch CubicInches(this Int32 input) => new CubicInch(input);
			public static CubicInch CubicInches(this Int64 input) => new CubicInch(input);
			public static CubicInch CubicInches(this Single input) => new CubicInch(input);
			public static CubicInch CubicInches(this Double input) => new CubicInch(input);
			#endregion
		}
	}
}
