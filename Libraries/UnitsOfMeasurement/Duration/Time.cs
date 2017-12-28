using System;
using System.Globalization;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using static Com.OfficerFlake.Libraries.UnitsOfMeasurement.Durations;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public class OYSTime : ITime
		{
			#region Properties
			public IHour Hour { get; set; }
			public IMinute Minute { get; set; }
			public ISecond Second { get; set; }
			#endregion
			#region CTOR
			public OYSTime(IHour hh, IMinute mm, ISecond ss)
			{
				this.Hour = hh;
				this.Minute = mm;
				this.Second = ss;
			}
			public OYSTime(DateTime datetime)
			{
				Hour = new Hour(datetime.Hour);
				Minute = new Minute(datetime.Minute);
				Second = new Second(datetime.Second);
			}
			#endregion

			#region Operators
			public static bool operator <(OYSTime date1, OYSTime date2)
			{
				return (System.DateTime)date1 < (System.DateTime)date2;
			}
			public static bool operator >(OYSTime date1, OYSTime date2)
			{
				return (System.DateTime)date1 > (System.DateTime)date2;
			}
			public static OYSTime operator +(OYSTime t1, OYSTime t2)
			{
				return (System.DateTime)t1 + new System.TimeSpan((int)(t2.Hour.RawValue), (int)t2.Minute.RawValue, (int)t2.Second.RawValue);
			}
			public static OYSTime operator -(OYSTime t1, OYSTime t2)
			{
				return (System.DateTime)t1 - new System.TimeSpan((int)(t2.Hour.RawValue), (int)t2.Minute.RawValue, (int)t2.Second.RawValue);
			}
			#endregion

			#region OYSTime <> DateTime
			public System.DateTime ToSystemDateTime()
			{
				return (System.DateTime)this;
			}
			public static implicit operator System.DateTime(OYSTime thistime)
			{
				return new System.DateTime(0, 0, 0, (int)thistime.Hour.RawValue, (int)thistime.Minute.RawValue, (int)thistime.Second.RawValue);
			}
			public static implicit operator OYSTime(System.DateTime thisDate)
			{
				return new OYSTime(thisDate);
			}
			#endregion
			#region OYSTime <> String
			public string ToSystemString() => ToString();
			public override string ToString()
			{
				return Hour.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0') +
					   Minute.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0') +
					   Second.RawValue.ToString(CultureInfo.InvariantCulture).ResizeOnLeft(2, '0');
			}
			public static bool TryParse(string input, out OYSTime output)
			{
				#region Initialise Output
				output = new OYSTime(0.Hours(), 0.Minutes(), 0.Seconds());
				#endregion
				#region Not enough Parameters!
				if (input.Count(x => x == ':') < 2) return false;
				#endregion
				#region Convert
				string[] split = input.Split(':');

				Int32 hh = 0;
				Int32 mm = 0;
				Int32 ss = 0;

				bool failed = false;
				failed |= !Int32.TryParse(split[0], out hh);
				failed |= !Int32.TryParse(split[1], out mm);
				failed |= !Int32.TryParse(split[2], out ss);
				if (failed) return false;

				output = new OYSTime(hh.Hours(), mm.Minutes(), ss.Seconds());
				return true;
				#endregion
			}
			#endregion
		}
	}
}