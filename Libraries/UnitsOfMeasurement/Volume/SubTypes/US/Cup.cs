using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class Cup : Volume, ICup
			{
				#region CTOR
				public Cup(double value) : base(value, Conversion.US.Cup, Suffixes.US.Cup) { }
				#endregion
				#region Operators
				public static Cup operator +(Cup firstMeasurement, Cup secondMeasurement)
				{
					return new Cup((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Cup operator -(Cup firstMeasurement, Cup secondMeasurement)
				{
					return new Cup((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Cup operator *(Cup firstMeasurement, Cup secondMeasurement)
				{
					return new Cup((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Cup operator /(Cup firstMeasurement, Cup secondMeasurement)
				{
					return new Cup((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Cups
			public static Cup Cups(this Byte input) => new Cup(input);
			public static Cup Cups(this Int16 input) => new Cup(input);
			public static Cup Cups(this Int32 input) => new Cup(input);
			public static Cup Cups(this Int64 input) => new Cup(input);
			public static Cup Cups(this Single input) => new Cup(input);
			public static Cup Cups(this Double input) => new Cup(input);
			#endregion
		}
	}
}
