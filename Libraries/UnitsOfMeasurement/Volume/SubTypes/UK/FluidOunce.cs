using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class FluidOunce : Volume, IFluidOunce
			{
				#region CTOR
				public FluidOunce(double value) : base(value, Conversion.UK.FluidOunce, Suffixes.UK.FluidOunce) { }
				#endregion
				#region Operators
				public static FluidOunce operator +(FluidOunce firstMeasurement, FluidOunce secondMeasurement)
				{
					return new FluidOunce((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static FluidOunce operator -(FluidOunce firstMeasurement, FluidOunce secondMeasurement)
				{
					return new FluidOunce((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static FluidOunce operator *(FluidOunce firstMeasurement, FluidOunce secondMeasurement)
				{
					return new FluidOunce((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static FluidOunce operator /(FluidOunce firstMeasurement, FluidOunce secondMeasurement)
				{
					return new FluidOunce((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].FluidOunces
			public static FluidOunce FluidOunces(this Byte input) => new FluidOunce(input);
			public static FluidOunce FluidOunces(this Int16 input) => new FluidOunce(input);
			public static FluidOunce FluidOunces(this Int32 input) => new FluidOunce(input);
			public static FluidOunce FluidOunces(this Int64 input) => new FluidOunce(input);
			public static FluidOunce FluidOunces(this Single input) => new FluidOunce(input);
			public static FluidOunce FluidOunces(this Double input) => new FluidOunce(input);
			#endregion
		}
	}
}
