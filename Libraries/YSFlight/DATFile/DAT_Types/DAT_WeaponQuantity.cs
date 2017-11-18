using System.Linq;
using Com.OfficerFlake.Libraries.YSFlight.Types;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_WeaponQuantity : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_WeaponQuantity>";

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

            public int Quantity
            {
                get
                {
                    int output;
                    var conversionSuccess =
                        int.TryParse(GetParameterOrNull(1).ToString() ?? NullExceptionString, out output);
                    return output;
                }
                set
                {
                    SetParameter(1, value.ToString());
                }
            }

            public DAT_WeaponQuantity(string command, WeaponType weapon, int quantity)
                : base(command, weapon, quantity)
            {
                Weapon = weapon;
                Quantity = quantity;
            }
        }
    }
}