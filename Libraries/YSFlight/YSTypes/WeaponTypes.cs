using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Types
{
    public class WeaponType : IYSTypeWeaponType
    {
	    public string[] Values { get; set; } = {"ERR"};
        public WeaponType(params string[] values)
        {
            if (values != null) Values = values;
        }
		
        public override string ToString()
        {
            return string.Join(" ", Values);
        }
    }
}
