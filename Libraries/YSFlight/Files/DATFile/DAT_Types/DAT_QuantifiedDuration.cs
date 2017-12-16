using System;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_QuantifiedDuration : Property
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

            public Duration Value
            {
                get
                {
	                Duration output;
                    var conversionSuccess =
	                    Duration.TryParse((GetParameterOrNull(1).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(1, value.ToString()); }
            }

            public DAT_QuantifiedDuration(string command, int quantifier, Duration value) : base(command, quantifier, value)
            {
                Quantifier = quantifier;
                Value = value;
            }
        }
    }
}