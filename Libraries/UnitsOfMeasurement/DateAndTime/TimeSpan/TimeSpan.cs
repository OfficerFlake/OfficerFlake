using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using static Com.OfficerFlake.Libraries.UnitsOfMeasurement.Durations;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public class OYSTimeSpan : ITimeSpan
		{
			#region Properties
			public Year Y;
			public Month M;
			public Day D;
			public Hour h;
			public Minute m;
			public Second s;
			#endregion
			#region CTOR
			public OYSTimeSpan(Year Y, Month M, Day D, Hour h, Minute m, Second s)
			{
				this.Y = Y;
				this.M = M;
				this.D = D;
				this.h = h;
				this.m = m;
				this.s = s;
			}
			public OYSTimeSpan(TimeSpan timespan)
			{
				Y = new Year((new DateTime(0, 0, 0, 0, 0, 0) + timespan).Year);
				M = new Month((new DateTime(0, 0, 0, 0, 0, 0) + timespan).Month);
				D = new Day((new DateTime(0, 0, 0, 0, 0, 0) + timespan).Day);
				h = new Hour((new DateTime(0, 0, 0, 0, 0, 0) + timespan).Hour);
				m = new Minute((new DateTime(0, 0, 0, 0, 0, 0) + timespan).Minute);
				s = new Second((new DateTime(0, 0, 0, 0, 0, 0) + timespan).Second);
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
			public static implicit operator System.TimeSpan(OYSTimeSpan thisTimeSpan)
			{
				System.DateTime output = new System.DateTime(thisTimeSpan.Y, thisTimeSpan.M, thisTimeSpan.D, thisTimeSpan.h, thisTimeSpan.m, thisTimeSpan.s);
				return output - new System.DateTime(0, 0, 0, 0, 0, 0);
			}
			public static implicit operator OYSTimeSpan(System.TimeSpan thisTimeSpan)
			{
				return new OYSTimeSpan(thisTimeSpan);
			}
			#endregion
			#region OYSTimeSpan <> String
			public override string ToString()
			{
				return Y.ToString() + "Y" +
					   M.ToString() + "M" +
					   D.ToString() + "D" +
					   h.ToString() + "h" +
					   m.ToString() + "m" +
					   s.ToString() + "s";
			}
			public static bool TryParse(string input, out OYSTimeSpan output)
			{
				#region Initialise Output
				output = new OYSTimeSpan(0.Years(), 0.Months(), 0.Days(), 0.Hours(), 0.Minutes(), 0.Seconds());
				#endregion
				#region Convert
				Year Y = 0.Years();
				Month M = 0.Months();
				Day D = 0.Days();
				Hour h = 0.Hours();
				Minute m = 0.Minutes();
				Second s = 0.Seconds();

				bool failed = false;
				string remaining = input;
				while (remaining.Length > 0)
				{
					if (remaining.Contains("Y"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("Y"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Duration.TryParse(convertable, out Duration duration);
						Y = duration.ToYears();
						continue;
					}
					if (remaining.Contains("M"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("M"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Duration.TryParse(convertable, out Duration duration);
						M = duration.ToMonths();
						continue;
					}
					if (remaining.Contains("D"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("D"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Duration.TryParse(convertable, out Duration duration);
						D = duration.ToDays();
						continue;
					}
					if (remaining.Contains("h"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("h"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Duration.TryParse(convertable, out Duration duration);
						h = duration.ToHours();
						continue;
					}
					if (remaining.Contains("m"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("m"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Duration.TryParse(convertable, out Duration duration);
						m = duration.ToMinutes();
						continue;
					}
					if (remaining.Contains("s"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("s"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Duration.TryParse(convertable, out Duration duration);
						s = duration.ToSeconds();
						continue;
					}
					break;
				}
				if (failed) return false;

				output = new OYSTimeSpan(Y, M, D, h, m, s);
				return true;
				#endregion
			}
			#endregion
		}
	}
}