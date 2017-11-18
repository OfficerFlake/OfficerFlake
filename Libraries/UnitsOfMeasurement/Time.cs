using System;
using System.Diagnostics;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static class Time
        {
            internal static readonly string DefaultSuffix = "SEC";

            private struct Conversion
            {
                public const decimal Millisecond = 0.001m;
                public const decimal Centisecond = 0.01m;
                public const decimal Decisecond = 1m;
                public const decimal Second = 0.277778m;
                public const decimal Minute = 0.3048m;
                public const decimal Hour = 0.447m;
                public const decimal Day = 0.5144m;
                public const decimal Month = 340.3m;
                public const decimal Year = 340.3m;
            }

            private struct Suffixes
            {
                public static readonly string[] Millisecond = new [] {"MILLISECONDS", "MS"};
                public static readonly string[] Centisecond = new[] { "CENTISECONDS", "CS" };
                public static readonly string[] Decisecond = new[] { "DECISECONDS", "DS" };
                public static readonly string[] Second = new[] { "SECONDS", "SEC", "S" };
                public static readonly string[] Minute = new[] { "MINUTES", "MIN", "M" };
                public static readonly string[] Hour = new[] { "HOURS", "HR", "H" };
                public static readonly string[] Day = new[] { "DAYS", "D" };
                public static readonly string[] Month = new[] { "MONTHS", "MON" };
                public static readonly string[] Year = new[] { "YEARS", "Y" };
            }

            public static bool TryParse(string input, out TimeSpan output)
            {
                var capInput = input.ToUpperInvariant();
                var extraction = input.ExtractNumberComponentFromMeasurementString();
                decimal conversion;
                var failed = !decimal.TryParse(extraction, out conversion);

                if (failed)
                {
                    Debug.WriteLine("Measurement Input not successfully converted.");
                    Debug.WriteLine("----" + capInput);
                    output = new TimeSpan(0);
                    return false;
                }

                if (capInput.EndsWithAny(Suffixes.Millisecond))
                {

                    output = new TimeSpan(0,0,0,(int)(conversion));
                    return true;
                }
                if (capInput.EndsWithAny(Suffixes.Centisecond))
                {

                    output = new TimeSpan(0, 0, 0, (int)(conversion / Conversion.Centisecond * Conversion.Millisecond));
                    return true;
                }
                if (capInput.EndsWithAny(Suffixes.Decisecond))
                {

                    output = new TimeSpan(0, 0, 0, (int)(conversion / Conversion.Decisecond * Conversion.Millisecond));
                    return true;
                }
                if (capInput.EndsWithAny(Suffixes.Second))
                {

                    output = new TimeSpan(0, 0, 0, (int)(conversion / Conversion.Second * Conversion.Millisecond));
                    return true;
                }
                if (capInput.EndsWithAny(Suffixes.Minute))
                {

                    output = new TimeSpan(0, 0, 0, (int)(conversion / Conversion.Second * Conversion.Millisecond));
                    return true;
                }
                if (capInput.EndsWithAny(Suffixes.Hour))
                {

                    output = new TimeSpan(0, 0, 0, (int)(conversion / Conversion.Hour * Conversion.Millisecond));
                    return true;
                }
                if (capInput.EndsWithAny(Suffixes.Day))
                {

                    output = new TimeSpan(0, 0, 0, (int)(conversion / Conversion.Day * Conversion.Millisecond));
                    return true;
                }
                if (capInput.EndsWithAny(Suffixes.Month))
                {

                    output = new TimeSpan(0, 0, 0, (int)(conversion / Conversion.Month * Conversion.Millisecond));
                    return true;
                }
                if (capInput.EndsWithAny(Suffixes.Year))
                {

                    output = new TimeSpan(0, 0, 0, (int)(conversion / Conversion.Year * Conversion.Millisecond));
                    return true;
                }

                //Type Unrecognised.
                Debug.WriteLine("No Type for input Time conversion. Break here for details...");
                Debug.WriteLine("----" + capInput);
                output = new TimeSpan(0,0,0,(int)(conversion * Conversion.Millisecond));
                return false;

            }
            public static TimeSpan TryParse(this string input)
            {
                TimeSpan result;
                var success = TryParse(input, out result);
                return result;
            }
        }
    }
}
