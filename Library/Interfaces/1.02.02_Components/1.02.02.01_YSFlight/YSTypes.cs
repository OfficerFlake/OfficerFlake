using System;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IYSTypeAircraftCategory
	{
		string[] Values { get; set; }
	}

	public interface IYSTypeHardpointDescription
	{
		IYSTypeWeaponCategory Weapon { get; set; }
		UInt32 Quantity { get; set; }
	}

	public interface IYSTypeWeaponCategory
	{
		string[] Values { get; set; }
	}

	public interface IYSTypeWeaponType
	{
		string[] Values { get; set; }
	}
}
