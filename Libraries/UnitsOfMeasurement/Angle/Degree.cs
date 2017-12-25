using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Angles
        {
            public class Degree : Angle, IDegree
            {
				#region CTOR
				public Degree(double value) : base(value, Conversion.Degree, Suffixes.Degree) { }
				#endregion
				#region Operators
				public static Degree operator +(Degree firstMeasurement, Degree secondMeasurement)
                {
                    return new Degree((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Degree operator -(Degree firstMeasurement, Degree secondMeasurement)
                {
                    return new Degree((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Degree operator *(Degree firstMeasurement, Degree secondMeasurement)
                {
                    return new Degree((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Degree operator /(Degree firstMeasurement, Degree secondMeasurement)
                {
                    return new Degree((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
				#endregion
			}
			#region [Number].Degrees
			public static Degree Degrees(this Byte input) => new Degree(input);
            public static Degree Degrees(this Int16 input) => new Degree(input);
            public static Degree Degrees(this Int32 input) => new Degree(input);
            public static Degree Degrees(this Int64 input) => new Degree(input);
            public static Degree Degrees(this Single input) => new Degree(input);
            public static Degree Degrees(this Double input) => new Degree(input);
			#endregion
		}
    }
}
