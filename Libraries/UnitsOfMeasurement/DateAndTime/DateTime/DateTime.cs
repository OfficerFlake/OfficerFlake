using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using static Com.OfficerFlake.Libraries.UnitsOfMeasurement.Durations;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public class OYSDateTime : IDateTime
		{
			#region Properties
			public IYear Year { get; set; }
			public IMonth Month { get; set; }
			public IDay Day { get; set; }
			public IHour Hour { get; set; }
			public IMinute Minute { get; set; }
			public ISecond Second { get; set; }
			#endregion
			#region CTOR
			public OYSDateTime(IYear YYYY, IMonth MM, IDay DD, IHour hh, IMinute mm, ISecond ss)
			{
				this.Year = YYYY;
				this.Month = MM;
				this.Day = DD;
				this.Hour = hh;
				this.Minute = mm;
				this.Second = ss;
			}
			public OYSDateTime(DateTime datetime)
			{
				Year = new Year(datetime.Year);
				Month = new Month(datetime.Month);
				Day = new Day(datetime.Day);
				Hour = new Hour(datetime.Hour);
				Minute = new Minute(datetime.Minute);
				Second = new Second(datetime.Second);
			}
			#endregion

			#region Operators
			public static bool operator <(OYSDateTime date1, OYSDateTime date2)
			{
				return (System.DateTime)date1 < (System.DateTime)date2;
			}
			public static bool operator >(OYSDateTime date1, OYSDateTime date2)
			{
				return (System.DateTime)date1 > (System.DateTime)date2;
			}
			public static OYSDateTime operator +(OYSDateTime date, OYSTimeSpan time)
			{
				return (OYSDateTime)((System.DateTime)date + (System.TimeSpan)time);
			}
			public static OYSDateTime operator -(OYSDateTime date, OYSTimeSpan time)
			{
				return (OYSDateTime)((System.DateTime)date - (System.TimeSpan)time);
			}
			#endregion

			#region OYSDateTime <> DateTime

			public System.DateTime ToDateTime()
			{
				return (System.DateTime)this;
			}
			public static implicit operator System.DateTime(OYSDateTime thisDate)
			{
				return new System.DateTime(
					(int)thisDate.Year.RawValue,
					(int)thisDate.Month.RawValue,
					(int)thisDate.Day.RawValue,
					(int)thisDate.Hour.RawValue,
					(int)thisDate.Minute.RawValue,
					(int)thisDate.Second.RawValue);
			}
			public static implicit operator OYSDateTime(System.DateTime thisDate)
			{
				return new OYSDateTime(thisDate);
			}
			#endregion
			#region OYSDateTime <> String
			public static bool TryParse(string input, out OYSDateTime output)
			{
				#region Initialise Output
				output = new DateTime(0, 0, 0, 0, 0, 0);
				#endregion
				#region Not enough Parameters!
				if (input.Length < 14) return false;
				#endregion
				#region Convert
				Int32 YYYY = 0;
				Int32 MM = 0;
				Int32 DD = 0;
				Int32 hh = 0;
				Int32 mm = 0;
				Int32 ss = 0;

				bool failed = false;
				failed |= !Int32.TryParse(input.Substring(0, 4), out YYYY);
				failed |= !Int32.TryParse(input.Substring(4, 2), out MM);
				failed |= !Int32.TryParse(input.Substring(6, 2), out DD);
				failed |= !Int32.TryParse(input.Substring(8, 2), out hh);
				failed |= !Int32.TryParse(input.Substring(10, 2), out mm);
				failed |= !Int32.TryParse(input.Substring(12, 2), out ss);
				if (failed) return false;

				output = new OYSDateTime(YYYY.Years(), MM.Months(), DD.Days(), hh.Hours(), mm.Minutes(), ss.Seconds());
				return true;
				#endregion
			}
			public override string ToString()
			{
				return Year.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(4, '0') +
					   Month.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0') +
					   Day.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0') +
					   Hour.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0') +
					   Minute.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0') +
					   Second.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0');
			}
			#endregion
		}
	}
}