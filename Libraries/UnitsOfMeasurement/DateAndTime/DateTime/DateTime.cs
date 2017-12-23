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
			public Year YYYY { get; set; }
			public Month MM { get; set; }
			public Day DD { get; set; }
			public Hour hh { get; set; }
			public Minute mm { get; set; }
			public Second ss { get; set; }
			#endregion
			#region CTOR
			public OYSDateTime(Year YYYY, Month MM, Day DD, Hour hh, Minute mm, Second ss)
			{
				this.YYYY = YYYY;
				this.MM = MM;
				this.DD = DD;
				this.hh = hh;
				this.mm = mm;
				this.ss = ss;
			}
			public OYSDateTime(DateTime datetime)
			{
				YYYY = new Year(datetime.Year);
				MM = new Month(datetime.Month);
				DD = new Day(datetime.Day);
				hh = new Hour(datetime.Hour);
				mm = new Minute(datetime.Minute);
				ss = new Second(datetime.Second);
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
			public static implicit operator System.DateTime(OYSDateTime thisDate)
			{
				return new System.DateTime(
					(int)thisDate.YYYY.RawValue,
					(int)thisDate.MM.RawValue,
					(int)thisDate.DD.RawValue,
					(int)thisDate.hh.RawValue,
					(int)thisDate.mm.RawValue,
					(int)thisDate.ss.RawValue);
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
				return YYYY.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(4, '0') +
					   MM.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0') +
					   DD.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0') +
					   hh.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0') +
					   mm.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0') +
					   ss.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0');
			}
			#endregion
		}
	}
}