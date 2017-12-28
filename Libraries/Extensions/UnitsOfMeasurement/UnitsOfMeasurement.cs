using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class UnitsOfMeasurmentExtensions
	{
		public static IDate ToDate(this System.DateTime dateTime)
		{
			return ObjectFactory.CreateDate(dateTime);
		}
		public static ITime ToTime(this System.DateTime dateTime)
		{
			return ObjectFactory.CreateTime(dateTime);
		}
		public static IDateTime ToDateTime(this System.DateTime dateTime)
		{
			return ObjectFactory.CreateDateTime(dateTime);
		}
		public static ITimeSpan ToTimeSpan(this System.TimeSpan timeSpan)
		{
			return ObjectFactory.CreateTimeSpan(timeSpan);
		}
	}
}