namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_QuantifiedString : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_QuantifiedString>";

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

            public string Value
            {
                get
                {
                    return (GetParameterOrNull(1).ToString() ?? NullExceptionString);
                }
                set { SetParameter(1, value); }
            }

            public DAT_QuantifiedString(string command, int quantifier, string value) : base(command, quantifier, value)
            {
                Quantifier = quantifier;
                Value = value;
            }
        }
    }
}