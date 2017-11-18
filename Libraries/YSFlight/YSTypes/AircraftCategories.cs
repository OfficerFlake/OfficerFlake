using System.Linq;

namespace Com.OfficerFlake.Libraries.YSFlight.Types
{
    public class AircraftCategory
    {
        public string Value { get; }
        public string SubValue { get; }

        private AircraftCategory(string value, string subvalue = null)
        {
            Value = value;
            SubValue = subvalue;
        }

        public static AircraftCategory FIGHTER => new AircraftCategory("FIGHTER");
        public static AircraftCategory NORMAL => new AircraftCategory("NORMAL");
        public static AircraftCategory BOMBER => new AircraftCategory("BOMBER");
        public static AircraftCategory HEAVYBOMBER => new AircraftCategory("HEAVYBOMBER");
        public static AircraftCategory WW2FIGHTER => new AircraftCategory("WW2FIGHTER");
        public static AircraftCategory WW2ATTACKER => new AircraftCategory("WW2ATTACKER");
        public static AircraftCategory WW2BOMBER => new AircraftCategory("WW2BOMBER");
        public static AircraftCategory WW2DIVEBOMBER => new AircraftCategory("WW2DIVEBOMBER");
        public static AircraftCategory ATTACKER => new AircraftCategory("ATTACKER");
        public static AircraftCategory UTILITY => new AircraftCategory("UTILITY");
        public static AircraftCategory AEROBATIC => new AircraftCategory("AEROBATIC");
        public static AircraftCategory TRAINER => new AircraftCategory("TRAINER");
        public static AircraftCategory HELICOPTER => new AircraftCategory("HELICOPTER");
        public static AircraftCategory BLANK => new AircraftCategory("");

        public static AircraftCategory[] CATEGORIES => new[]
        {
            FIGHTER,
            NORMAL,
            BOMBER,
            HEAVYBOMBER,
            WW2FIGHTER,
            WW2ATTACKER,
            WW2BOMBER,
            WW2DIVEBOMBER,
            ATTACKER,
            UTILITY,
            AEROBATIC,
            TRAINER,
            HELICOPTER,
        };

        public static AircraftCategory GetCategoryFromStringOrBlank(string input, string input2 = null)
        {
            var List = CATEGORIES.Where(x => (x.Value == null || x.Value.StartsWith(input) && (x.SubValue == null || x.SubValue.StartsWith(input2)))).ToList();
            return List.Count > 0 ? List[0] : BLANK;
        }

        public override string ToString()
        {
            return (Value + " " + SubValue).Trim();
        }
    }
}
