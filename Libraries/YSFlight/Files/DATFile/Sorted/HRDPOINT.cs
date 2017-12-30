using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class HRDPOINT : DATProperty, IDAT_2_Parameters<IPoint3, IYSTypeHardpointDescription[]>
	{
		public HRDPOINT(IPoint3 value1, IYSTypeHardpointDescription[] value2) : base("HRDPOINT" + " " + value1 + " " + string.Join(" ", value2.Select(x=>x.ToString())))
		{
			Value1 = value1;
			Value2 = value2;
		}

		public IPoint3 Value1 { get; set; }
		public IYSTypeHardpointDescription[] Value2 { get; set; }

		public uint GetWeaponQuantity(IYSTypeWeaponCategory Weapon)
		{
			if (Value2.All(x => x.Weapon != Weapon)) return 0;
			return (uint)Value2.Where(x => x.Weapon == Weapon).Sum(x => x.Quantity);
		}
	}
}
