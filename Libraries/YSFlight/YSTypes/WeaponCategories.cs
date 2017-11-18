using System.Diagnostics;
using System.Linq;

namespace Com.OfficerFlake.Libraries.YSFlight.Types
{
    public class WeaponCategory
    {
        public string[] Value { get; }

        private WeaponCategory(params string[] value)
        {
            Value = value;
        }

        public static WeaponCategory BLANK => new WeaponCategory("NON", "NONE", "NULL", "BLANK");

        public static WeaponCategory GUN => new WeaponCategory("GUN");
        public static WeaponCategory AIM9 => new WeaponCategory("AIM9");
        public static WeaponCategory AIM9X => new WeaponCategory("AIM9X");
        public static WeaponCategory AIM120 => new WeaponCategory("AIM120");
        public static WeaponCategory AGM => new WeaponCategory("AGM65");
        public static WeaponCategory RKT => new WeaponCategory("RKT");
        public static WeaponCategory B250 => new WeaponCategory("B250");
        public static WeaponCategory B500 => new WeaponCategory("BOMB");
        public static WeaponCategory B500HD => new WeaponCategory("B500HD");
        public static WeaponCategory SMK => new WeaponCategory("SMK");
        public static WeaponCategory FLR => new WeaponCategory("FLR", "IFLR");
        public static WeaponCategory FUEL => new WeaponCategory("FUEL");


        public static WeaponCategory[] CATEGORIES => new[]
        {
            BLANK,
            GUN,
            AIM9,
            AIM9X,
            AIM120,
            AGM,
            RKT,
            B250,
            B500,
            B500HD,
            SMK,
            FLR,
            FUEL,
        };

        public static WeaponCategory GetCategoryFromStringOrBlank(string input, bool debug = false)
        {
            var List = CATEGORIES.Where(x => x.Value.Contains(input)).ToList();
            return List.Count > 0 ? List[0] : BLANK;
        }

        public override string ToString()
        {
            return Value.Any() ? Value[0] : "<ERROR>";
        }
    }
}
