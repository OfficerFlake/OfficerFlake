using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Angle : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_Angle>";

            public Angle Value
            {
                get
                {
                    Angle output;
                    bool conversionSuccess =
                        Angle.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public DAT_Angle(string command, Angle value) : base(command, value)
            {
            }
        }
    }
}