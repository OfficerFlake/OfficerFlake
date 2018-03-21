using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class DurationExtensions
	{
		#region Seconds
		public static ISecond Seconds(this Byte input) => ObjectFactory.CreateSecond(input);
		public static ISecond Seconds(this SByte input) => ObjectFactory.CreateSecond(input);
		public static ISecond Seconds(this UInt16 input) => ObjectFactory.CreateSecond(input);
		public static ISecond Seconds(this Int16 input) => ObjectFactory.CreateSecond(input);
		public static ISecond Seconds(this UInt32 input) => ObjectFactory.CreateSecond(input);
		public static ISecond Seconds(this Int32 input) => ObjectFactory.CreateSecond(input);
		public static ISecond Seconds(this UInt64 input) => ObjectFactory.CreateSecond(input);
		public static ISecond Seconds(this Int64 input) => ObjectFactory.CreateSecond(input);
		public static ISecond Seconds(this Single input) => ObjectFactory.CreateSecond(input);
		public static ISecond Seconds(this Double input) => ObjectFactory.CreateSecond(input);
		#endregion
		#region Minutes
		public static IMinute Minutes(this Byte input) => ObjectFactory.CreateMinute(input);
		public static IMinute Minutes(this SByte input) => ObjectFactory.CreateMinute(input);
		public static IMinute Minutes(this UInt16 input) => ObjectFactory.CreateMinute(input);
		public static IMinute Minutes(this Int16 input) => ObjectFactory.CreateMinute(input);
		public static IMinute Minutes(this UInt32 input) => ObjectFactory.CreateMinute(input);
		public static IMinute Minutes(this Int32 input) => ObjectFactory.CreateMinute(input);
		public static IMinute Minutes(this UInt64 input) => ObjectFactory.CreateMinute(input);
		public static IMinute Minutes(this Int64 input) => ObjectFactory.CreateMinute(input);
		public static IMinute Minutes(this Single input) => ObjectFactory.CreateMinute(input);
		public static IMinute Minutes(this Double input) => ObjectFactory.CreateMinute(input);
		#endregion
		#region Hours
		public static IHour Hours(this Byte input) => ObjectFactory.CreateHour(input);
		public static IHour Hours(this SByte input) => ObjectFactory.CreateHour(input);
		public static IHour Hours(this UInt16 input) => ObjectFactory.CreateHour(input);
		public static IHour Hours(this Int16 input) => ObjectFactory.CreateHour(input);
		public static IHour Hours(this UInt32 input) => ObjectFactory.CreateHour(input);
		public static IHour Hours(this Int32 input) => ObjectFactory.CreateHour(input);
		public static IHour Hours(this UInt64 input) => ObjectFactory.CreateHour(input);
		public static IHour Hours(this Int64 input) => ObjectFactory.CreateHour(input);
		public static IHour Hours(this Single input) => ObjectFactory.CreateHour(input);
		public static IHour Hours(this Double input) => ObjectFactory.CreateHour(input);
		#endregion
		#region Days
		public static IDay Days(this Byte input) => ObjectFactory.CreateDay(input);
		public static IDay Days(this SByte input) => ObjectFactory.CreateDay(input);
		public static IDay Days(this UInt16 input) => ObjectFactory.CreateDay(input);
		public static IDay Days(this Int16 input) => ObjectFactory.CreateDay(input);
		public static IDay Days(this UInt32 input) => ObjectFactory.CreateDay(input);
		public static IDay Days(this Int32 input) => ObjectFactory.CreateDay(input);
		public static IDay Days(this UInt64 input) => ObjectFactory.CreateDay(input);
		public static IDay Days(this Int64 input) => ObjectFactory.CreateDay(input);
		public static IDay Days(this Single input) => ObjectFactory.CreateDay(input);
		public static IDay Days(this Double input) => ObjectFactory.CreateDay(input);
		#endregion
		#region Weeks
		public static IWeek Weeks(this Byte input) => ObjectFactory.CreateWeek(input);
		public static IWeek Weeks(this SByte input) => ObjectFactory.CreateWeek(input);
		public static IWeek Weeks(this UInt16 input) => ObjectFactory.CreateWeek(input);
		public static IWeek Weeks(this Int16 input) => ObjectFactory.CreateWeek(input);
		public static IWeek Weeks(this UInt32 input) => ObjectFactory.CreateWeek(input);
		public static IWeek Weeks(this Int32 input) => ObjectFactory.CreateWeek(input);
		public static IWeek Weeks(this UInt64 input) => ObjectFactory.CreateWeek(input);
		public static IWeek Weeks(this Int64 input) => ObjectFactory.CreateWeek(input);
		public static IWeek Weeks(this Single input) => ObjectFactory.CreateWeek(input);
		public static IWeek Weeks(this Double input) => ObjectFactory.CreateWeek(input);
		#endregion
		#region Months
		public static IMonth Months(this Byte input) => ObjectFactory.CreateMonth(input);
		public static IMonth Months(this SByte input) => ObjectFactory.CreateMonth(input);
		public static IMonth Months(this UInt16 input) => ObjectFactory.CreateMonth(input);
		public static IMonth Months(this Int16 input) => ObjectFactory.CreateMonth(input);
		public static IMonth Months(this UInt32 input) => ObjectFactory.CreateMonth(input);
		public static IMonth Months(this Int32 input) => ObjectFactory.CreateMonth(input);
		public static IMonth Months(this UInt64 input) => ObjectFactory.CreateMonth(input);
		public static IMonth Months(this Int64 input) => ObjectFactory.CreateMonth(input);
		public static IMonth Months(this Single input) => ObjectFactory.CreateMonth(input);
		public static IMonth Months(this Double input) => ObjectFactory.CreateMonth(input);
		#endregion
		#region Years
		public static IYear Years(this Byte input) => ObjectFactory.CreateYear(input);
		public static IYear Years(this SByte input) => ObjectFactory.CreateYear(input);
		public static IYear Years(this UInt16 input) => ObjectFactory.CreateYear(input);
		public static IYear Years(this Int16 input) => ObjectFactory.CreateYear(input);
		public static IYear Years(this UInt32 input) => ObjectFactory.CreateYear(input);
		public static IYear Years(this Int32 input) => ObjectFactory.CreateYear(input);
		public static IYear Years(this UInt64 input) => ObjectFactory.CreateYear(input);
		public static IYear Years(this Int64 input) => ObjectFactory.CreateYear(input);
		public static IYear Years(this Single input) => ObjectFactory.CreateYear(input);
		public static IYear Years(this Double input) => ObjectFactory.CreateYear(input);
		#endregion

		public static IDate ToDate(this System.DateTime dateTime) => ObjectFactory.CreateDate(dateTime);
		#region [Duration].ToDate
		public static IDate ToDate(this ISecond input) => ObjectFactory.CreateDate(new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, (int)input.RawValue));
		public static IDate ToDate(this IMinute input) => ObjectFactory.CreateDate(new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, (int)input.RawValue, 0));
		public static IDate ToDate(this IHour input) => ObjectFactory.CreateDate(new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (int)input.RawValue, 0, 0));
		public static IDate ToDate(this IDay input) => ObjectFactory.CreateDate(new System.DateTime(0, 0, (int)input.RawValue, 0, 0, 0));
		public static IDate ToDate(this IWeek input) => ObjectFactory.CreateDate(new System.DateTime(0, 0, (int)input.RawValue*7, 0, 0, 0));
		public static IDate ToDate(this IMonth input) => ObjectFactory.CreateDate(new System.DateTime(0, (int)input.RawValue, 0, 0, 0, 0));
		public static IDate ToDate(this IYear input) => ObjectFactory.CreateDate(new System.DateTime((int)input.RawValue, 0, 0, 0, 0, 0));
		#endregion

		public static ITime ToTime(this System.DateTime dateTime) => ObjectFactory.CreateTime(dateTime);
		#region [Duration].ToTime
		public static ITime ToTime(this ISecond input) => ObjectFactory.CreateTime(new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, (int)input.RawValue));
		public static ITime ToTime(this IMinute input) => ObjectFactory.CreateTime(new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, (int)input.RawValue, 0));
		public static ITime ToTime(this IHour input) => ObjectFactory.CreateTime(new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (int)input.RawValue, 0, 0));
		public static ITime ToTime(this IDay input) => ObjectFactory.CreateTime(new System.DateTime(0, 0, (int)input.RawValue, 0, 0, 0));
		public static ITime ToTime(this IWeek input) => ObjectFactory.CreateTime(new System.DateTime(0, 0, (int)input.RawValue * 7, 0, 0, 0));
		public static ITime ToTime(this IMonth input) => ObjectFactory.CreateTime(new System.DateTime(0, (int)input.RawValue, 0, 0, 0, 0));
		public static ITime ToTime(this IYear input) => ObjectFactory.CreateTime(new System.DateTime((int)input.RawValue, 0, 0, 0, 0, 0));
		#endregion

		public static IDateTime ToDateTime(this System.DateTime dateTime) => ObjectFactory.CreateDateTime(dateTime);
		#region [Duration].ToDateTime
		public static IDateTime ToDateTime(this ISecond input) => ObjectFactory.CreateDateTime(new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, (int)input.RawValue));
		public static IDateTime ToDateTime(this IMinute input) => ObjectFactory.CreateDateTime(new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, (int)input.RawValue, 0));
		public static IDateTime ToDateTime(this IHour input) => ObjectFactory.CreateDateTime(new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (int)input.RawValue, 0, 0));
		public static IDateTime ToDateTime(this IDay input) => ObjectFactory.CreateDateTime(new System.DateTime(0, 0, (int)input.RawValue, 0, 0, 0));
		public static IDateTime ToDateTime(this IWeek input) => ObjectFactory.CreateDateTime(new System.DateTime(0, 0, (int)input.RawValue * 7, 0, 0, 0));
		public static IDateTime ToDateTime(this IMonth input) => ObjectFactory.CreateDateTime(new System.DateTime(0, (int)input.RawValue, 0, 0, 0, 0));
		public static IDateTime ToDateTime(this IYear input) => ObjectFactory.CreateDateTime(new System.DateTime((int)input.RawValue, 0, 0, 0, 0, 0));
		#endregion

		public static ITimeSpan ToTimeSpan(this System.TimeSpan timeSpan) => ObjectFactory.CreateTimeSpan(timeSpan);
		#region [Duration].ToTimeSpan
		public static ITimeSpan ToTimeSpan(this ISecond input) => ObjectFactory.CreateTimeSpan(new System.TimeSpan(0, 0, 0, (int)input.RawValue));
		public static ITimeSpan ToTimeSpan(this IMinute input) => ObjectFactory.CreateTimeSpan(new System.TimeSpan(0, 0, (int)input.RawValue, 0));
		public static ITimeSpan ToTimeSpan(this IHour input) => ObjectFactory.CreateTimeSpan(new System.TimeSpan(0, (int)input.RawValue, 0, 0));
		public static ITimeSpan ToTimeSpan(this IDay input) => ObjectFactory.CreateTimeSpan(new System.TimeSpan((int)input.RawValue, 0, 0, 0));
		public static ITimeSpan ToTimeSpan(this IWeek input) => ObjectFactory.CreateTimeSpan(new System.TimeSpan((int)input.RawValue * 7, 0, 0, 0));
		public static ITimeSpan ToTimeSpan(this IMonth input) => ObjectFactory.CreateTimeSpan(new System.TimeSpan((int)input.RawValue * 31, 0, 0, 0));
		public static ITimeSpan ToTimeSpan(this IYear input) => ObjectFactory.CreateTimeSpan(new System.TimeSpan((int)input.RawValue * 365, 0, 0, 0));
		#endregion
	}
}