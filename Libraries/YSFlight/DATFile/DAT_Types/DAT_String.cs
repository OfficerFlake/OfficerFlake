namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_String : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_String>";

            public DAT_String(string command, string value) : base(command, value)
            {
            }

            public string Value
            {
                get
                {
                    return (GetParameterOrNull(0).ToString() ?? NullExceptionString);
                    
                }
                set { SetParameter(1, value.ToString()); }
            }
        }
    }
}