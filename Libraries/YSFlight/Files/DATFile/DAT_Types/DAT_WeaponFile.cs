using System.Linq;
using Com.OfficerFlake.Libraries.YSFlight.Types;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_WeaponFile : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_WeaponFile>";

            public WeaponType Weapon
            {
                get
                {
                    return WeaponType.CATEGORIES.FirstOrDefault(x =>
                            x.Value == (GetParameterOrNull(0).ToString() ?? NullExceptionString));
                }
                set
                {
                    SetParameter(0, value.Value);
                }
            }

            public bool IsStatic
            {
                get { return ((GetParameterOrNull(1).ToString() ?? NullExceptionString).ToUpperInvariant() == "STATIC"); }
                set { SetParameter(1, value ? "STATIC" : "FLYING"); }
            }

            public string FilePath
            {
                get { return (GetParameterOrNull(2).ToString() ?? NullExceptionString); }
                set { SetParameter(2, value); }
            }

            public DAT_WeaponFile(string command, WeaponType weapon, bool isstatic, string filepath)
                : base(command, weapon, isstatic, filepath)
            {
                Weapon = weapon;
                IsStatic = isstatic;
                FilePath = filepath;
            }
        }
    }
}