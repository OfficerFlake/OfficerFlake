using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public class OYSDateTime
		{
			public Int32 YYYY;
			public Int32 MM;
			public Int32 DD;
			public Int32 hh;
			public Int32 mm;
			public Int32 ss;

			public OYSDateTime(Int32 YYYY, Int32 MM, Int32 DD, Int32 hh, Int32 mm, Int32 ss)
			{
				this.YYYY = YYYY;
				this.MM = MM;
				this.DD = DD;
				this.hh = hh;
				this.mm = mm;
				this.ss = ss;
			}

			public static implicit operator System.DateTime(OYSDateTime thisDate)
			{
				return new System.DateTime(thisDate.YYYY, thisDate.MM, thisDate.DD, thisDate.hh, thisDate.mm, thisDate.ss);
			}

			public override string ToString()
			{
				return YYYY.ToString().ResizeOnLeft(4, '0') +
				       MM.ToString().ResizeOnLeft(2, '0') +
				       DD.ToString().ResizeOnLeft(2, '0') +
				       hh.ToString().ResizeOnLeft(2, '0') +
				       mm.ToString().ResizeOnLeft(2, '0') +
				       ss.ToString().ResizeOnLeft(2, '0');
			}
		}

		public static class DateTimeExtension
		{
			public static bool TryParse(string input, out DateTime output)
			{
				#region Initialise Output
				output = new DateTime(0,0,0,0,0,0);
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

				output = new DateTime(YYYY,MM,DD, hh, mm, ss);
				return true;
				#endregion
			}
		}
	}
}