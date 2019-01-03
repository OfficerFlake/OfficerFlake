using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Types
{
    public class HardPointDescription : IYSTypeHardpointDescription
    {
        public IYSTypeWeaponCategory Weapon { get; set; } = Extensions.YSFlight.WeaponCategories.BLANK;
        public UInt32 Quantity { get; set; } = 0;

        public HardPointDescription(string value)
        {
            var strings = GetStrings(value);
            Weapon = (strings.Length > 0)
                ? Extensions.YSFlight.WeaponCategories.GetCategoryFromStringOrBlank(strings[0])
                : Extensions.YSFlight.WeaponCategories.BLANK;
	        uint _Quantity = 0;
            if (strings.Length > 1) uint.TryParse(
                strings[1].ExtractNumberComponentFromMeasurementString(), out _Quantity);
	        Quantity = _Quantity;
        }

        private string[] GetStrings(string input) => (input.Split('*', '&').Length < 2) ? new[] { input, "1" } : input.Split('*', '&');

        public override string ToString()
        {
            return Weapon.ToString();
        }
    }
}
