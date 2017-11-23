using System.Globalization;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Single : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_Single>";

            public float Value
            {
                get
                {
                    float conversion;
                    float.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString).ExtractNumberComponentFromMeasurementString(), out conversion);

                    return conversion;
                }
                set { SetParameter(0, value.ToString(CultureInfo.InvariantCulture)); }
            }

            public DAT_Single(string command, float value) : base(command, value)
            {
            }
        }
    }
}