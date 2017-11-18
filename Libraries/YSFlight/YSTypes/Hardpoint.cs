using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.YSFlight.Types
{
    public class WeaponDescription
    {
        public WeaponCategory Weapon = WeaponCategory.BLANK;
        public int Quantity = 1;

        public WeaponDescription(string value)
        {
            var strings = GetStrings(value);
            Weapon = (strings.Length > 0)
                ? WeaponCategory.GetCategoryFromStringOrBlank(strings[0])
                : WeaponCategory.BLANK;
            Quantity = 1;
            if (strings.Length > 1) int.TryParse(
                strings[1].ExtractNumberComponentFromMeasurementString(), out Quantity);
        }

        private string[] GetStrings(string input) => (input.Split('*', '&').Length < 2) ? new[] { input, "1" } : input.Split('*', '&');

        public override string ToString()
        {
            return Weapon.ToString();
        }
    }
}
