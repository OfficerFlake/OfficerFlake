using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class CubicYard : Volume, ICubicYard
			{
				#region CTOR
				public CubicYard(double value) : base(value, Conversion.CubicYard, Suffixes.CubicYard) { }
				#endregion
				#region Operators
				public static CubicYard operator +(CubicYard firstMeasurement, CubicYard secondMeasurement)
				{
					return new CubicYard((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static CubicYard operator -(CubicYard firstMeasurement, CubicYard secondMeasurement)
				{
					return new CubicYard((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static CubicYard operator *(CubicYard firstMeasurement, CubicYard secondMeasurement)
				{
					return new CubicYard((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static CubicYard operator /(CubicYard firstMeasurement, CubicYard secondMeasurement)
				{
					return new CubicYard((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].CubicYards
			public static CubicYard CubicYards(this Byte input) => new CubicYard(input);
			public static CubicYard CubicYards(this Int16 input) => new CubicYard(input);
			public static CubicYard CubicYards(this Int32 input) => new CubicYard(input);
			public static CubicYard CubicYards(this Int64 input) => new CubicYard(input);
			public static CubicYard CubicYards(this Single input) => new CubicYard(input);
			public static CubicYard CubicYards(this Double input) => new CubicYard(input);
			#endregion
		}
	}
}
