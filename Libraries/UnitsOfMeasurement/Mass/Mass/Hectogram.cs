using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class Hectogram : Mass, IHectogram
			{
				#region CTOR
				public Hectogram(double value) : base(value, Conversion.Hectogram, Suffixes.Hectogram) { }
				#endregion
				#region Operators
				public static Hectogram operator +(Hectogram firstMeasurement, Hectogram secondMeasurement)
				{
					return new Hectogram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Hectogram operator -(Hectogram firstMeasurement, Hectogram secondMeasurement)
				{
					return new Hectogram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Hectogram operator *(Hectogram firstMeasurement, Hectogram secondMeasurement)
				{
					return new Hectogram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Hectogram operator /(Hectogram firstMeasurement, Hectogram secondMeasurement)
				{
					return new Hectogram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Hectograms
			public static Hectogram Hectograms(this Byte input) => new Hectogram(input);
			public static Hectogram Hectograms(this Int16 input) => new Hectogram(input);
			public static Hectogram Hectograms(this Int32 input) => new Hectogram(input);
			public static Hectogram Hectograms(this Int64 input) => new Hectogram(input);
			public static Hectogram Hectograms(this Single input) => new Hectogram(input);
			public static Hectogram Hectograms(this Double input) => new Hectogram(input);
			#endregion
		}
	}
}
