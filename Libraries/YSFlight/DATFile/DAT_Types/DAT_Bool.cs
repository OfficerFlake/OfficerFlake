namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Bool : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_Bool>";

            public bool Value
            {
                get
                {
                    bool conversion;
                    bool.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out conversion);

                    return conversion;
                }
                set { SetParameter(0, value ? "TRUE" : "FALSE"); }
            }

            public DAT_Bool(string command, bool value) : base(command, value)
            {
            }
        }
    }
}