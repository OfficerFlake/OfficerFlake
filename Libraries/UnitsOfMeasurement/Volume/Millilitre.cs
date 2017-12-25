using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class MilliLitre : Volume, IMilliLitre
			{
				#region CTOR
				public MilliLitre(double value) : base(value, Conversion.MilliLitre, Suffixes.MilliLitre) { }
				#endregion
				#region Operators
				public static MilliLitre operator +(MilliLitre firstMeasurement, MilliLitre secondMeasurement)
				{
					return new MilliLitre((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static MilliLitre operator -(MilliLitre firstMeasurement, MilliLitre secondMeasurement)
				{
					return new MilliLitre((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static MilliLitre operator *(MilliLitre firstMeasurement, MilliLitre secondMeasurement)
				{
					return new MilliLitre((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static MilliLitre operator /(MilliLitre firstMeasurement, MilliLitre secondMeasurement)
				{
					return new MilliLitre((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].MilliLitres
			public static MilliLitre MilliLitres(this Byte input) => new MilliLitre(input);
			public static MilliLitre MilliLitres(this Int16 input) => new MilliLitre(input);
			public static MilliLitre MilliLitres(this Int32 input) => new MilliLitre(input);
			public static MilliLitre MilliLitres(this Int64 input) => new MilliLitre(input);
			public static MilliLitre MilliLitres(this Single input) => new MilliLitre(input);
			public static MilliLitre MilliLitres(this Double input) => new MilliLitre(input);
			#endregion
		}
	}
}
