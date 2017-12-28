using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class Litre : Volume, ILitre
			{
				#region CTOR
				public Litre(double value) : base(value, Conversion.Litre, Suffixes.Litre) { }
				#endregion
				#region Operators
				public static Litre operator +(Litre firstMeasurement, Litre secondMeasurement)
				{
					return new Litre((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Litre operator -(Litre firstMeasurement, Litre secondMeasurement)
				{
					return new Litre((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Litre operator *(Litre firstMeasurement, Litre secondMeasurement)
				{
					return new Litre((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Litre operator /(Litre firstMeasurement, Litre secondMeasurement)
				{
					return new Litre((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Litres
			public static Litre Litres(this Byte input) => new Litre(input);
			public static Litre Litres(this Int16 input) => new Litre(input);
			public static Litre Litres(this Int32 input) => new Litre(input);
			public static Litre Litres(this Int64 input) => new Litre(input);
			public static Litre Litres(this Single input) => new Litre(input);
			public static Litre Litres(this Double input) => new Litre(input);
			#endregion
		}
	}
}
