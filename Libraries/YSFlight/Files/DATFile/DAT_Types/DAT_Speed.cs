using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Speed : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_Speed>";

            public Speed Value
            {
                get
                {
                    Speed conversion;
                    Speed.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out conversion);

                    return conversion;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public DAT_Speed(string command, Speed value) : base(command, value)
            {
            }
        }
    }
}