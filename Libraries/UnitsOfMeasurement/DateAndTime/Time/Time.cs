using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public class OYSTime
		{
			public Int32 hh;
			public Int32 mm;
			public Int32 ss;

			public OYSTime(Int32 hh, Int32 mm, Int32 ss)
			{
				this.hh = hh;
				this.mm = mm;
				this.ss = ss;
			}

			public static implicit operator System.DateTime(OYSTime thistime)
			{
				return new System.DateTime(0, 0, 0, thistime.hh, thistime.mm, thistime.ss);
			}

			public override string ToString()
			{
				return hh.ToString().ResizeOnLeft(2, '0') + ":" +
				       mm.ToString().ResizeOnLeft(2, '0') + ":" +
				       ss.ToString().ResizeOnLeft(2, '0');
			}
		}

		public static class TimeExtension
		{
			public static bool TryParse(string input, out OYSTime output)
			{
				#region Initialise Output
				output = new OYSTime(0,0,0);
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

				output = new OYSTime(hh,mm,ss);
				return true;
				#endregion
			}
		}
	}
}