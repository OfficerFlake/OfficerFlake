namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Int32 : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_Int32>";

            public int Value
            {
                get
                {
                    int conversion;
                    int.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out conversion);

                    return conversion;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public DAT_Int32(string command, int value) : base(command, value)
            {
            }
        }
    }
}