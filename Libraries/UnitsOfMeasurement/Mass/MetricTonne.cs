using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class MetricTonne : Mass, IMetricTonne
			{
				#region CTOR
				public MetricTonne(double value) : base(value, Conversion.MetricTonne, Suffixes.MetricTonne) { }
				#endregion
				#region Operators
				public static MetricTonne operator +(MetricTonne firstMeasurement, MetricTonne secondMeasurement)
				{
					return new MetricTonne((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static MetricTonne operator -(MetricTonne firstMeasurement, MetricTonne secondMeasurement)
				{
					return new MetricTonne((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static MetricTonne operator *(MetricTonne firstMeasurement, MetricTonne secondMeasurement)
				{
					return new MetricTonne((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static MetricTonne operator /(MetricTonne firstMeasurement, MetricTonne secondMeasurement)
				{
					return new MetricTonne((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].MetricTonnes
			public static MetricTonne MetricTonnes(this Byte input) => new MetricTonne(input);
			public static MetricTonne MetricTonnes(this Int16 input) => new MetricTonne(input);
			public static MetricTonne MetricTonnes(this Int32 input) => new MetricTonne(input);
			public static MetricTonne MetricTonnes(this Int64 input) => new MetricTonne(input);
			public static MetricTonne MetricTonnes(this Single input) => new MetricTonne(input);
			public static MetricTonne MetricTonnes(this Double input) => new MetricTonne(input);
			#endregion
		}
	}
}
