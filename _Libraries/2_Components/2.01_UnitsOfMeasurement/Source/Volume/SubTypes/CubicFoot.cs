using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class CubicFoot : Volume, ICubicFoot
			{
				#region CTOR
				public CubicFoot(double value) : base(value, Conversion.CubicFoot, Suffixes.CubicFoot) { }
				#endregion
				#region Operators
				public static CubicFoot operator +(CubicFoot firstMeasurement, CubicFoot secondMeasurement)
				{
					return new CubicFoot((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static CubicFoot operator -(CubicFoot firstMeasurement, CubicFoot secondMeasurement)
				{
					return new CubicFoot((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static CubicFoot operator *(CubicFoot firstMeasurement, CubicFoot secondMeasurement)
				{
					return new CubicFoot((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static CubicFoot operator /(CubicFoot firstMeasurement, CubicFoot secondMeasurement)
				{
					return new CubicFoot((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].CubicFeet
			public static CubicFoot CubicFeet(this Byte input) => new CubicFoot(input);
			public static CubicFoot CubicFeet(this Int16 input) => new CubicFoot(input);
			public static CubicFoot CubicFeet(this Int32 input) => new CubicFoot(input);
			public static CubicFoot CubicFeet(this Int64 input) => new CubicFoot(input);
			public static CubicFoot CubicFeet(this Single input) => new CubicFoot(input);
			public static CubicFoot CubicFeet(this Double input) => new CubicFoot(input);
			#endregion
		}
	}
}
