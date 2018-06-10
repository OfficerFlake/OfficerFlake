using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Energys
		{
			public class KiloJoule : Energy, IKiloJoule
			{
				#region CTOR
				public KiloJoule(double value) : base(value, Conversion.KiloJoule, Suffixes.KiloJoule) { }
				#endregion
				#region Operators
				public static KiloJoule operator +(KiloJoule firstMeasurement, KiloJoule secondMeasurement)
				{
					return new KiloJoule((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static KiloJoule operator -(KiloJoule firstMeasurement, KiloJoule secondMeasurement)
				{
					return new KiloJoule((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static KiloJoule operator *(KiloJoule firstMeasurement, KiloJoule secondMeasurement)
				{
					return new KiloJoule((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static KiloJoule operator /(KiloJoule firstMeasurement, KiloJoule secondMeasurement)
				{
					return new KiloJoule((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].KiloJoules
			public static KiloJoule KiloJoules(this Byte input) => new KiloJoule(input);
			public static KiloJoule KiloJoules(this Int16 input) => new KiloJoule(input);
			public static KiloJoule KiloJoules(this Int32 input) => new KiloJoule(input);
			public static KiloJoule KiloJoules(this Int64 input) => new KiloJoule(input);
			public static KiloJoule KiloJoules(this Single input) => new KiloJoule(input);
			public static KiloJoule KiloJoules(this Double input) => new KiloJoule(input);
			#endregion
		}
	}
}
