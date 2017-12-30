using System;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class AngleExtensions
	{
		#region Degrees
		public static IDegree Degrees(this Byte input) => ObjectFactory.CreateDegree(input);
		public static IDegree Degrees(this SByte input) => ObjectFactory.CreateDegree(input);
		public static IDegree Degrees(this UInt16 input) => ObjectFactory.CreateDegree(input);
		public static IDegree Degrees(this Int16 input) => ObjectFactory.CreateDegree(input);
		public static IDegree Degrees(this UInt32 input) => ObjectFactory.CreateDegree(input);
		public static IDegree Degrees(this Int32 input) => ObjectFactory.CreateDegree(input);
		public static IDegree Degrees(this UInt64 input) => ObjectFactory.CreateDegree(input);
		public static IDegree Degrees(this Int64 input) => ObjectFactory.CreateDegree(input);
		public static IDegree Degrees(this Single input) => ObjectFactory.CreateDegree(input);
		public static IDegree Degrees(this Double input) => ObjectFactory.CreateDegree(input);
		#endregion
		#region Gradians
		public static IGradian Gradians(this Byte input) => ObjectFactory.CreateGradian(input);
		public static IGradian Gradians(this SByte input) => ObjectFactory.CreateGradian(input);
		public static IGradian Gradians(this UInt16 input) => ObjectFactory.CreateGradian(input);
		public static IGradian Gradians(this Int16 input) => ObjectFactory.CreateGradian(input);
		public static IGradian Gradians(this UInt32 input) => ObjectFactory.CreateGradian(input);
		public static IGradian Gradians(this Int32 input) => ObjectFactory.CreateGradian(input);
		public static IGradian Gradians(this UInt64 input) => ObjectFactory.CreateGradian(input);
		public static IGradian Gradians(this Int64 input) => ObjectFactory.CreateGradian(input);
		public static IGradian Gradians(this Single input) => ObjectFactory.CreateGradian(input);
		public static IGradian Gradians(this Double input) => ObjectFactory.CreateGradian(input);
		#endregion
		#region Radians
		public static IRadian Radians(this Byte input) => ObjectFactory.CreateRadian(input);
		public static IRadian Radians(this SByte input) => ObjectFactory.CreateRadian(input);
		public static IRadian Radians(this UInt16 input) => ObjectFactory.CreateRadian(input);
		public static IRadian Radians(this Int16 input) => ObjectFactory.CreateRadian(input);
		public static IRadian Radians(this UInt32 input) => ObjectFactory.CreateRadian(input);
		public static IRadian Radians(this Int32 input) => ObjectFactory.CreateRadian(input);
		public static IRadian Radians(this UInt64 input) => ObjectFactory.CreateRadian(input);
		public static IRadian Radians(this Int64 input) => ObjectFactory.CreateRadian(input);
		public static IRadian Radians(this Single input) => ObjectFactory.CreateRadian(input);
		public static IRadian Radians(this Double input) => ObjectFactory.CreateRadian(input);
		#endregion
	}
}