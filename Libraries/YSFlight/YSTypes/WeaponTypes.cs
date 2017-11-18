namespace Com.OfficerFlake.Libraries.YSFlight.Types
{
    public class WeaponType
    {
        private string[] Values;
        public string Value => Values.Length > 0 ? Values[0] : "ERR";

        private WeaponType(params string[] values)
        {
            Values = values;
        }

        public static WeaponType AGM65 => new WeaponType("AGM65");
        public static WeaponType AIM9 => new WeaponType("AIM9");
        public static WeaponType AIM9X => new WeaponType("AIM9X");
        public static WeaponType AIM120 => new WeaponType("AIM120");
        public static WeaponType B250 => new WeaponType("B250");
        public static WeaponType B500 => new WeaponType("B500");
        public static WeaponType B500HD => new WeaponType("B500HD");
        public static WeaponType RKT => new WeaponType("RKT");
        public static WeaponType FLR => new WeaponType("FLR", "IFLR");
        public static WeaponType FUEL => new WeaponType("FUEL");
        public static WeaponType SMK => new WeaponType("SMK");
        public static WeaponType GUN => new WeaponType("GUN");
        public static WeaponType BLANK => new WeaponType("");

        public static WeaponType[] CATEGORIES => new[]
        {
            AGM65,
            AIM9,
            AIM9X,
            AIM120,
            B250,
            B500,
            B500HD,
            RKT,
            FLR,
            FUEL,
            SMK,
            GUN,
        };

        public override string ToString()
        {
            return Value;
        }
    }
}
