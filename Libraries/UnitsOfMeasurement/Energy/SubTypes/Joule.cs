using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Energys
		{
			public class Joule : Energy, IJoule
			{
				#region CTOR
				public Joule(double value) : base(value, Conversion.Joule, Suffixes.Joule) { }
				#endregion
				#region Operators
				public static Joule operator +(Joule firstMeasurement, Joule secondMeasurement)
				{
					return new Joule((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Joule operator -(Joule firstMeasurement, Joule secondMeasurement)
				{
					return new Joule((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Joule operator *(Joule firstMeasurement, Joule secondMeasurement)
				{
					return new Joule((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Joule operator /(Joule firstMeasurement, Joule secondMeasurement)
				{
					return new Joule((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Joules
			public static Joule Joules(this Byte input) => new Joule(input);
			public static Joule Joules(this Int16 input) => new Joule(input);
			public static Joule Joules(this Int32 input) => new Joule(input);
			public static Joule Joules(this Int64 input) => new Joule(input);
			public static Joule Joules(this Single input) => new Joule(input);
			public static Joule Joules(this Double input) => new Joule(input);
			#endregion
		}
	}
}
