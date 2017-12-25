using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Speeds
		{
			public class MachAtSeaLevel : Speed, IMachAtSeaLevel
			{
				#region CTOR
				public MachAtSeaLevel(double value) : base(value, Conversion.MachAtSeaLevel, Suffixes.MachAtSeaLevel) { }
				#endregion
				#region Operators
				public static MachAtSeaLevel operator +(MachAtSeaLevel firstMeasurement, MachAtSeaLevel secondMeasurement)
				{
					return new MachAtSeaLevel((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static MachAtSeaLevel operator -(MachAtSeaLevel firstMeasurement, MachAtSeaLevel secondMeasurement)
				{
					return new MachAtSeaLevel((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static MachAtSeaLevel operator *(MachAtSeaLevel firstMeasurement, MachAtSeaLevel secondMeasurement)
				{
					return new MachAtSeaLevel((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static MachAtSeaLevel operator /(MachAtSeaLevel firstMeasurement, MachAtSeaLevel secondMeasurement)
				{
					return new MachAtSeaLevel((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].MachAtSeaLevels
			public static MachAtSeaLevel MachAtSeaLevels(this Byte input) => new MachAtSeaLevel(input);
			public static MachAtSeaLevel MachAtSeaLevels(this Int16 input) => new MachAtSeaLevel(input);
			public static MachAtSeaLevel MachAtSeaLevels(this Int32 input) => new MachAtSeaLevel(input);
			public static MachAtSeaLevel MachAtSeaLevels(this Int64 input) => new MachAtSeaLevel(input);
			public static MachAtSeaLevel MachAtSeaLevels(this Single input) => new MachAtSeaLevel(input);
			public static MachAtSeaLevel MachAtSeaLevels(this Double input) => new MachAtSeaLevel(input);
			#endregion
		}
	}
}
