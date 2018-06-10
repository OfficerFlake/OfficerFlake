using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class Foot : Distance, IFoot
			{
				#region CTOR
				public Foot(double value) : base(value, Conversion.Foot, Suffixes.Foot) { }
				#endregion
				#region Operators
				public static Foot operator +(Foot firstMeasurement, Foot secondMeasurement)
				{
					return new Foot((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Foot operator -(Foot firstMeasurement, Foot secondMeasurement)
				{
					return new Foot((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Foot operator *(Foot firstMeasurement, Foot secondMeasurement)
				{
					return new Foot((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Foot operator /(Foot firstMeasurement, Foot secondMeasurement)
				{
					return new Foot((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Foots
			public static Foot Foots(this Byte input) => new Foot(input);
			public static Foot Foots(this Int16 input) => new Foot(input);
			public static Foot Foots(this Int32 input) => new Foot(input);
			public static Foot Foots(this Int64 input) => new Foot(input);
			public static Foot Foots(this Single input) => new Foot(input);
			public static Foot Foots(this Double input) => new Foot(input);
			#endregion
		}
	}
}
