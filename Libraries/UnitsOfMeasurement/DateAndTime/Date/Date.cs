using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using static Com.OfficerFlake.Libraries.UnitsOfMeasurement.Durations;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public class OYSDate : IDate
		{
			#region Properties
			public IYear Year { get; set; }
			public IMonth Month { get; set; }
			public IDay Day { get; set; }
			#endregion
			#region CTOR
			public OYSDate(IYear YYYY, IMonth MM, IDay DD)
			{
				this.Year = YYYY;
				this.Month = MM;
				this.Day = DD;
			}
			public OYSDate(DateTime datetime)
			{
				this.Year = new Year(datetime.Year);
				this.Month = new Month(datetime.Month);
				this.Day = new Day(datetime.Day);
			}
			#endregion

			#region Operators
			public static bool operator <(OYSDate date1, OYSDate date2)
			{
				return (System.DateTime)date1 < (System.DateTime)date2;
			}
			public static bool operator >(OYSDate date1, OYSDate date2)
			{
				return (System.DateTime)date1 > (System.DateTime)date2;
			}
			public static OYSDate operator +(OYSDate date, OYSTimeSpan time)
			{
				return (OYSDate)((System.DateTime)date + (System.TimeSpan)time);
			}
			public static OYSDate operator -(OYSDate date, OYSTimeSpan time)
			{
				return (OYSDate)((System.DateTime)date - (System.TimeSpan)time);
			}
			#endregion

			#region OYSDate <> DateTime
			public DateTime ToDateTime()
			{
				return (System.DateTime)this;
			}
			public static implicit operator System.DateTime(OYSDate thisDate)
			{
				return new System.DateTime(
					(int)thisDate.Year.RawValue,
					(int)thisDate.Month.RawValue,
					(int)thisDate.Day.RawValue,
					0,
					0,
					0);
			}
			public static implicit operator OYSDate(System.DateTime thisDate)
			{
				return new OYSDate(thisDate);
			}
			#endregion
			#region OYSDate <> String
			public override string ToString()
			{
				return Year.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(4, '0') +
					   Month.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0') +
					   Day.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0');
			}
			public static bool TryParse(string input, out OYSDate output)
			{
				#region Initialise Output
				output = new OYSDate(0.Years(), 0.Months(), 0.Days());
				#endregion
				#region Not enough Parameters!
				if (input.Length < 8) return false;
				#endregion
				#region Convert
				Int32 YYYY = 0.Years();
				Int32 MM = 0.Months();
				Int32 DD = 0.Days();

				bool failed = false;
				failed |= !Int32.TryParse(input.Substring(0, 4), out YYYY);
				failed |= !Int32.TryParse(input.Substring(4, 2), out MM);
				failed |= !Int32.TryParse(input.Substring(6, 2), out DD);
				if (failed) return false;

				output = new OYSDate(YYYY.Years(), MM.Months(), DD.Days());
				return true;
				#endregion
			}
			#endregion
		}
	}
}