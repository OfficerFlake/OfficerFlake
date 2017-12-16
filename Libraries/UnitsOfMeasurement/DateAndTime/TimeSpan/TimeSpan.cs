using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public class OYSTimeSpan
		{
			public Int32 Y;
			public Int32 M;
			public Int32 D;
			public Int32 h;
			public Int32 m;
			public Int32 s;

			public OYSTimeSpan(Int32 Y, Int32 M, Int32 D, Int32 h, Int32 m, Int32 s)
			{
				this.Y = Y;
				this.M = M;
				this.D = D;
				this.h = h;
				this.m = m;
				this.s = s;
			}

			public static implicit operator System.TimeSpan(OYSTimeSpan thisTimeSpan)
			{
				System.DateTime output = new System.DateTime(thisTimeSpan.Y,thisTimeSpan.M, thisTimeSpan.D, thisTimeSpan.h, thisTimeSpan.m, thisTimeSpan.s);
				return output - new System.DateTime(0,0,0,0,0,0);
			}

			public override string ToString()
			{
				return Y.ToString() + "Y" +
				       M.ToString() + "M" +
				       D.ToString() + "D" +
				       h.ToString() + "h" +
				       m.ToString() + "m" +
				       s.ToString() + "s";
			}
		}

		public static class TimeSpanExtension
		{
			public static bool TryParse(string input, out OYSTimeSpan output)
			{
				#region Initialise Output
				output = new OYSTimeSpan(0,0,0,0,0,0);
				#endregion
				#region Convert
				Int32 Y= 0;
				Int32 M = 0;
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
						remaining = remaining.Substring(convertable.Length+1, remaining.Length - convertable.Length+1);
						failed |= !Int32.TryParse(convertable, out Y);
						continue;
					}
					if (remaining.Contains("M"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("M"));
						remaining = remaining.Substring(convertable.Length+1, remaining.Length - convertable.Length+1);
						failed |= !Int32.TryParse(convertable, out M);
						continue;
					}
					if (remaining.Contains("D"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("D"));
						remaining = remaining.Substring(convertable.Length+1, remaining.Length - convertable.Length+1);
						failed |= !Int32.TryParse(convertable, out D);
						continue;
					}
					if (remaining.Contains("h"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("h"));
						remaining = remaining.Substring(convertable.Length+1, remaining.Length - convertable.Length+1);
						failed |= !Int32.TryParse(convertable, out h);
						continue;
					}
					if (remaining.Contains("m"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("m"));
						remaining = remaining.Substring(convertable.Length+1, remaining.Length - convertable.Length+1);
						failed |= !Int32.TryParse(convertable, out m);
						continue;
					}
					if (remaining.Contains("s"))
					{
						string convertable = remaining.Substring(0, remaining.IndexOf("s"));
						remaining = remaining.Substring(convertable.Length + 1, remaining.Length - convertable.Length + 1);
						failed |= !Int32.TryParse(convertable, out s);
						continue;
					}
					break;
				}
				if (failed) return false;

				output = new OYSTimeSpan(Y, M, D, h, m, s);
				return true;
				#endregion
			}
		}
	}
}