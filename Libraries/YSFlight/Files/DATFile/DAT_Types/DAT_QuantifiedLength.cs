using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_QuantifiedLength : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_QuantifiedLength>";

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

            public Length Value
            {
                get
                {
                    Length output;
                    var conversionSuccess =
                        Length.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public DAT_QuantifiedLength(string command, int quantifier, Length value) : base(command, quantifier, value)
            {
                Quantifier = quantifier;
                Value = value;
            }
        }
    }
}