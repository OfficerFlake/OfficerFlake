using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using Com.OfficerFlake.Libraries.YSFlight.Types;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
        public class DAT_Hardpoint : Property
        {
            private const string NullExceptionString = "<ERROR-DAT_Hardpoint>";

            public Length X
            {
                get
                {
                    Length output;
                    bool conversionSuccess =
                        Length.TryParse((GetParameterOrNull(0).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(0, value.ToString()); }
            }

            public Length Y
            {
                get
                {
                    Length output;
                    bool conversionSuccess =
                        Length.TryParse((GetParameterOrNull(1).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(1, value.ToString()); }
            }

            public Length Z
            {
                get
                {
                    Length output;
                    bool conversionSuccess =
                        Length.TryParse((GetParameterOrNull(2).ToString() ?? NullExceptionString), out output);
                    return output;
                }
                set { SetParameter(2, value.ToString()); }
            }

            public List<WeaponDescription> Descriptors
            {
                get
                {
                    List<WeaponDescription> Output = new List<WeaponDescription>();
                    if (NumberOfParameters < 3) return Output;
                    for (int i = 3; i < NumberOfParameters; i++)
                    {
                        var thisString = GetParameterOrNull(i);
                        var casted = new WeaponDescription(thisString.ToString());
                        Output.Add(casted);
                    }
                    return Output;
                }
                set {
                    for (var i = 0; i < value.Count; i++)
                    {
                        if ((value[i] == null)) continue;
                        SetParameter(i + 3, value[i].ToString());
                    }
                }
            }

            public int GetWeaponQuantity(WeaponCategory weaponCategory)
            {
                var a0 = Descriptors.ToArray();
                var a1 = a0.Where(x=>x.Weapon.ToString() == weaponCategory.ToString()).ToArray();
                var a2 = a1.Select(x => x.Quantity).ToArray();
                var a3 = a2.Sum();

                return a3;
            }

            protected DAT_Hardpoint(string command, Length x, Length y, Length z, WeaponDescription[] descriptors)
                : base(command, x, y, z, string.Join(" ", descriptors.Select(q=>q.ToString())))
            {
            }
        }
    }
}