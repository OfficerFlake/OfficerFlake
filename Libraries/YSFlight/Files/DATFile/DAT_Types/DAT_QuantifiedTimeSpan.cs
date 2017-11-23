using System;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_QuantifiedTimeSpan : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_QuantifiedTimeSpan>";

            public int Quantifier
            {
                get
                {
                    int output;
                    bool conversionSuccess =
                        int.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public TimeSpan Value
            {
                get
                {
                    TimeSpan output;
                    var conversionSuccess =
                        Time.TryParse((GetParameterOrNull(1).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(1, value.ToString()); }
            }

            public DAT_QuantifiedTimeSpan(string command, int quantifier, TimeSpan value) : base(command, quantifier, value)
            {
                Quantifier = quantifier;
                Value = value;
            }
        }
    }
}