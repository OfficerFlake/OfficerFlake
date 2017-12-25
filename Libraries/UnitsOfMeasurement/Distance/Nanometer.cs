using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class Nanometer : Distance, INanometer
			{
				#region CTOR
				public Nanometer(double value) : base(value, Conversion.Nanometer, Suffixes.Nanometer) { }
				#endregion
				#region Operators
				public static Nanometer operator +(Nanometer firstMeasurement, Nanometer secondMeasurement)
				{
					return new Nanometer((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Nanometer operator -(Nanometer firstMeasurement, Nanometer secondMeasurement)
				{
					return new Nanometer((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Nanometer operator *(Nanometer firstMeasurement, Nanometer secondMeasurement)
				{
					return new Nanometer((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Nanometer operator /(Nanometer firstMeasurement, Nanometer secondMeasurement)
				{
					return new Nanometer((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Nanometers
			public static Nanometer Nanometers(this Byte input) => new Nanometer(input);
			public static Nanometer Nanometers(this Int16 input) => new Nanometer(input);
			public static Nanometer Nanometers(this Int32 input) => new Nanometer(input);
			public static Nanometer Nanometers(this Int64 input) => new Nanometer(input);
			public static Nanometer Nanometers(this Single input) => new Nanometer(input);
			public static Nanometer Nanometers(this Double input) => new Nanometer(input);
			#endregion
		}
	}
}
