using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class TimeExtensions
	{
        public static DateTime StartTime => Process.GetCurrentProcess().StartTime;

        public class TimeContainer
        {
			#region Variables
			//These variables are filled by the constructor...
			public string YYYY;
            public string MM;
            public string DD;

            public string hh;
            public string mm;
            public string ss;
            public string ms;
			#endregion

			internal TimeContainer(DateTime input)
            {
                YYYY = input.Year.ToString().ResizeOnLeft(4, '0');
                MM = input.Month.ToString().ResizeOnLeft(2, '0');
                DD = input.Day.ToString().ResizeOnLeft(2, '0');

                hh = input.Hour.ToString().ResizeOnLeft(2, '0');
                mm = input.Minute.ToString().ResizeOnLeft(2, '0');
                ss = input.Second.ToString().ResizeOnLeft(2, '0');
                ms = input.Millisecond.ToString().ResizeOnLeft(3, '0');
            }

			#region String Expressions
			public string YYYYMMDD_hhmmss_ => YYYYMMDD + "(" + hhmmss + ")";
            public string YYYYMMDD => YYYY + MM + DD;
	        public string hhmmss => hh + mm + ss;
            public string hh_mm_ss => hh + ":" + mm + ":" + ss;
            public string hh_mm_ss_ms => hh + ":" + mm + ":" + ss + "." + ms;
			#endregion
		}
        public static TimeContainer InStandardForm(this DateTime input)
        {
            return new TimeContainer(input);
        }
    }
}