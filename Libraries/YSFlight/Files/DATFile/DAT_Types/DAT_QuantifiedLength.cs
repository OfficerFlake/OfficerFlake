using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_QuantifiedDistance : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_QuantifiedDistance>";

            public int Quantifier
            {
                get
                {
                    int output;
                    var conversionSuccess =
                        int.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public Distance Value
            {
                get
                {
                    Distance output;
                    var conversionSuccess =
                        Distance.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public DAT_QuantifiedDistance(string command, int quantifier, Distance value) : base(command, quantifier, value)
            {
                Quantifier = quantifier;
                Value = value;
            }
        }
    }
}