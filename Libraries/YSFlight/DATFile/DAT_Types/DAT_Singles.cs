using System.Globalization;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_DualSingles : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_DualSingles>";

            public float Value1
            {
                get
                {
                    float conversion;
                    float.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out conversion);

                    return conversion;
                }
                set { SetParameter(0, value.ToString(CultureInfo.InvariantCulture)); }
            }
            public float Value2
            {
                get
                {
                    float conversion;
                    float.TryParse((GetParameterOrNull(1).ToString() ?? NullExceptionString), out conversion);

                    return conversion;
                }
                set { SetParameter(1, value.ToString(CultureInfo.InvariantCulture)); }
            }

            public DAT_DualSingles(string command, float value1, float value2) : base(command, value1, value2)
            {
            }
        }
    }
}