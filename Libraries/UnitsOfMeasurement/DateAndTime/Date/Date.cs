using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public class OYSDate
		{
			public Int32 YYYY;
			public Int32 MM;
			public Int32 DD;

			public OYSDate(Int32 YYYY, Int32 MM, Int32 DD)
			{
				this.YYYY = YYYY;
				this.MM = MM;
				this.DD = DD;
			}

			public static implicit operator System.DateTime(OYSDate thisDate)
			{
				return new System.DateTime(thisDate.YYYY, thisDate.MM, thisDate.DD, 0, 0, 0);
			}

			public override string ToString()
			{
				return YYYY.ToString().ResizeOnLeft(4, '0') +
				       MM.ToString().ResizeOnLeft(2, '0') +
				       DD.ToString().ResizeOnLeft(2, '0');
			}
		}

		public static class DateExtension
		{
			public static bool TryParse(string input, out OYSDate output)
			{
				#region Initialise Output
				output = new OYSDate(0,0,0);
				#endregion
				#region Not enough Parameters!
				if (input.Length < 8) return false;
				#endregion
				#region Convert
				Int32 YYYY = 0;
				Int32 MM = 0;
				Int32 DD = 0;

				bool failed = false;
				failed |= !Int32.TryParse(input.Substring(0, 4), out YYYY);
				failed |= !Int32.TryParse(input.Substring(4, 2), out MM);
				failed |= !Int32.TryParse(input.Substring(6, 2), out DD);
				if (failed) return false;

				output = new OYSDate(YYYY,MM,DD);
				return true;
				#endregion
			}
		}
	}
}