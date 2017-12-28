using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static partial class UnitsOfMeasurmentExtensions
	{
		public static ISecond Seconds(this System.String input) => ObjectFactory.CreateSeconds(Seconds);

		public static IDate ToDate(this System.DateTime dateTime) => ObjectFactory.CreateDate(dateTime);
		public static ITime ToTime(this System.DateTime dateTime) => ObjectFactory.CreateTime(dateTime);
		public static IDateTime ToDateTime(this System.DateTime dateTime) => ObjectFactory.CreateDateTime(dateTime);
		public static ITimeSpan ToTimeSpan(this System.TimeSpan timeSpan) => ObjectFactory.CreateTimeSpan(timeSpan);
	}
}