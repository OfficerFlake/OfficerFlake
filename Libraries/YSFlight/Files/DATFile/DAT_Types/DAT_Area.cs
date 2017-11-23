using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Area : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_Area>";

            public Area Value
            {
                get
                {
                    Area conversion;
                    Area.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out conversion);

                    return conversion;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public DAT_Area(string command, Area value) : base(command, value)
            {
            }
        }
    }
}