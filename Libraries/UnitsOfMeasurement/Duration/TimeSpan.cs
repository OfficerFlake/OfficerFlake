using System;
using Com.OfficerFlake.Libraries.Interfaces;
using static Com.OfficerFlake.Libraries.UnitsOfMeasurement.Durations;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public class OYSTimeSpan : ITimeSpan
		{
			#region Properties
			public IYear Years { get; set; }
			public IMonth Months { get; set; }
			public IWeek Weeks { get; set; }
			public IDay Days { get; set; }
			public IHour Hours { get; set; }
			public IMinute Minutes { get; set; }
			public ISecond Seconds { get; set; }

			public IYear TotalYears()
			{
				return new Year(((System.TimeSpan) this).TotalDays / 365);
			}
			public IMonth TotalMonths()
			{
				return new Month(((System.TimeSpan)this).TotalDays / 365 * 12);
			}
			public IWeek TotalWeeks()
			{
				return new Week(((System.TimeSpan)this).TotalDays / 365 * 7);
			}
			public IDay TotalDays()
			{
				return new Day(((System.TimeSpan)this).TotalDays);
			}
			public IHour TotalHours()
			{
				return new Hour(((System.TimeSpan)this).TotalHours);
			}
			public IMinute TotalMinutes()
			{
				return new Minute(((System.TimeSpan)this).TotalMinutes);
			}
			public ISecond TotalSeconds()
			{
				return new Second(((System.TimeSpan)this).TotalSeconds);
			}
			#endregion
			#region CTOR
			public OYSTimeSpan(Year Y, Month M, Week W, Day D, Hour h, Minute m, Second s)
			{
				this.Years = Y;
				this.Months = M;
				this.Days = D;
				this.Hours = h;
				this.Minutes = m;
				this.Seconds = s;
			}
			public OYSTimeSpan(TimeSpan timespan)
			{
				Years = new Year((new DateTime(0, 0, 0, 0, 0, 0) + timespan).Year);
				Months = new Month((new DateTime(0, 0, 0, 0, 0, 0) + timespan).Month);
				Weeks = 0.Weeks();
				Days = new Day((new DateTime(0, 0, 0, 0, 0, 0) + timespan).Day);
				Hours = new Hour((new DateTime(0, 0, 0, 0, 0, 0) + timespan).Hour);
				Minutes = new Minute((new DateTime(0, 0, 0, 0, 0, 0) + timespan).Minute);
				Seconds = new Second((new DateTime(0, 0, 0, 0, 0, 0) + timespan).Second);
			}
			#endregion

			#region Operators
			public static bool operator <(OYSTimeSpan t1, OYSTimeSpan t2)
			{
				return (System.TimeSpan)t1 < (System.TimeSpan)t2;
			}
			public static bool operator >(OYSTimeSpan t1, OYSTimeSpan t2)
			{
				return (System.TimeSpan)t1 > (System.TimeSpan)t2;
			}
			public static OYSTimeSpan operator +(OYSTimeSpan t1, OYSTimeSpan t2)
			{
				return (System.TimeSpan)t1 + (System.TimeSpan)(t2);
			}
			public static OYSTimeSpan operator -(OYSTimeSpan t1, OYSTimeSpan t2)
			{
				return (System.TimeSpan)t1 - (System.TimeSpan)t2;
			}
			#endregion

			#region OYSTimeSpan <> TimeSpan
			public System.TimeSpan ToSystemTimeSpan()
			{
				return (System.TimeSpan)this;
			}
			public static implicit operator System.TimeSpan(OYSTimeSpan thisTimeSpan)
			{
				System.DateTime output = new System.DateTime(
					(int)thisTimeSpan.Years.RawValue,
					(int)thisTimeSpan.Months.RawValue,
					(int)thisTimeSpan.Days.RawValue,
					(int)thisTimeSpan.Hours.RawValue,
					(int)thisTimeSpan.Minutes.RawValue,
					(int)thisTimeSpan.Seconds.RawValue);
				return output - new System.DateTime(0, 0, 0, 0, 0, 0);
			}
			public static implicit operator OYSTimeSpan(System.TimeSpan thisTimeSpan)
			{
				return new OYSTimeSpan(thisTimeSpan);
			}
			#endregion
			#region OYSTimeSpan <> String
			public string ToSystemString() => ToString();
			public override string ToString()
			{
				return Years.ToString() + "Y" +
					   Months.ToString() + "M" +
					   Days.ToString() + "D" +
					   Hours.ToString() + "h" +
					   Minutes.ToString() + "m" +
					   Seconds.ToString() + "s";
			}
			public static bool TryParse(string input, out OYSTimeSpan output)
			{
				#region Initialise Output
				output = new OYSTimeSpan(0.Years(), 0.Months(), 0.Weeks(), 0.Days(), 0.Hours(), 0.Minutes(), 0.Seconds());
				#endregion
				#region Convert
				Int32 Y = 0;
				Int32 M = 0;
				Int32 W = 0;
				Int32 D = 0;
				Int32 h = 0;
				Int32 m = 0;
				Int32 s = 0;

				bool failed = false;
				string remaining = input;
				while (remaining.Length > 0)
				{
					if (remaining.Contains("Y"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("Y"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Int32.TryParse(convertable, out Int32 duration);
						Y = duration;
						continue;
					}
					if (remaining.Contains("M"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("M"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Int32.TryParse(convertable, out Int32 duration);
						M = duration;
						continue;
					}
					if (remaining.Contains("W"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("W"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Int32.TryParse(convertable, out Int32 duration);
						W = duration;
						continue;
					}
					if (remaining.Contains("D"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("D"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Int32.TryParse(convertable, out Int32 duration);
						D = duration;
						continue;
					}
					if (remaining.Contains("h"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("h"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Int32.TryParse(convertable, out Int32 duration);
						h = duration;
						continue;
					}
					if (remaining.Contains("m"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("m"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Int32.TryParse(convertable, out Int32 duration);
						m = duration;
						continue;
					}
					if (remaining.Contains("s"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("s"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Int32.TryParse(convertable, out Int32 duration);
						s = duration;
						continue;
					}
					break;
				}
				if (failed) return false;

				output = new OYSTimeSpan(Y.Years(), M.Months(), W.Weeks(), D.Days(), h.Hours(), m.Minutes(), s.Seconds());
				return true;
				#endregion
			}
			#endregion
		}
	}
}