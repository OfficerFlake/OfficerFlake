using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Energys
		{
			public class ElectronVolt : Energy, IElectronVolt
			{
				#region CTOR
				public ElectronVolt(double value) : base(value, Conversion.ElectronVolt, Suffixes.ElectronVolt) { }
				#endregion
				#region Operators
				public static ElectronVolt operator +(ElectronVolt firstMeasurement, ElectronVolt secondMeasurement)
				{
					return new ElectronVolt((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static ElectronVolt operator -(ElectronVolt firstMeasurement, ElectronVolt secondMeasurement)
				{
					return new ElectronVolt((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static ElectronVolt operator *(ElectronVolt firstMeasurement, ElectronVolt secondMeasurement)
				{
					return new ElectronVolt((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static ElectronVolt operator /(ElectronVolt firstMeasurement, ElectronVolt secondMeasurement)
				{
					return new ElectronVolt((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].ElectronVolts
			public static ElectronVolt ElectronVolts(this Byte input) => new ElectronVolt(input);
			public static ElectronVolt ElectronVolts(this Int16 input) => new ElectronVolt(input);
			public static ElectronVolt ElectronVolts(this Int32 input) => new ElectronVolt(input);
			public static ElectronVolt ElectronVolts(this Int64 input) => new ElectronVolt(input);
			public static ElectronVolt ElectronVolts(this Single input) => new ElectronVolt(input);
			public static ElectronVolt ElectronVolts(this Double input) => new ElectronVolt(input);
			#endregion
		}
	}
}
