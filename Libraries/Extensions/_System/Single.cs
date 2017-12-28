namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class PercentageExtensions
	{
		/// <summary>
		/// Trys to parse the string representation of a percentage to a floating put number .(1.0 == 100%)
		/// </summary>
		/// <param name="input">String representation to try and parse.</param>
		/// <param name="target">Output float to overwrite with result, if conversion succeeds.</param>
		/// <returns>True if conversion succeeds.</returns>
        public static bool TryParse(string input, out float target)
        {
            string clean = input.ExtractNumberComponentFromMeasurementString();
            var fail = !float.TryParse(clean, out target);
            if (fail) return false;
            if (input.EndsWith("%"))
            {
                target *= 0.01f;
            }
            return true;
        }
    }
}