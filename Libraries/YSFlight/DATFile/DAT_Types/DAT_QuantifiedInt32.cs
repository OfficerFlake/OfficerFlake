namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_QuantifiedInt32 : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_QuantifiedInt32>";

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

            public int Value
            {
                get
                {
                    int output;
                    var conversionSuccess =
                        int.TryParse((GetParameterOrNull(1).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(1, value.ToString()); }
            }

            public DAT_QuantifiedInt32(string command, int quantifier, int value) : base(command, quantifier, value)
            {
                Quantifier = quantifier;
                Value = value;
            }
        }
    }
}