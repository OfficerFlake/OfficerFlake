using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_36_WeaponsLoadout : GenericPacket
	{
		public Type_36_WeaponsLoadout() : base(36)
		{
		}

		public Int32 ID
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}
		public Int16 Version
		{
			get => GetInt16(4);
			set => SetInt16(4, value);
		}

		private static readonly List<int> ListOfWeaponTypes = new List<int>()
		{
			WeaponTypes.Null,
			WeaponTypes.AAM_Short,
			WeaponTypes.AGM,
			WeaponTypes.B500,
			WeaponTypes.FLRPOD,
			WeaponTypes.RKT,
			WeaponTypes.FLR,
			WeaponTypes.AAM_Mid,
			WeaponTypes.B250,
			WeaponTypes.Unknown_8,
			WeaponTypes.B500_HD,
			WeaponTypes.AAM_X,
			WeaponTypes.Unknown_11,
			WeaponTypes.FuelTank,
	};

		public static class WeaponTypes
		{
			public static int Null = 0;
			public static int AAM_Short = 1;
			public static int AGM = 11;
			public static int B500 = 3;
			public static int FLRPOD = 5;
			public static int RKT = 4;
			public static int FLR = 200;
			public static int AAM_Mid = 6;
			public static int B250 = 7;
			public static int Unknown_8 = 8;
			public static int B500_HD = 9;
			public static int AAM_X = 10;
			public static int Unknown_11 = 11;
			public static int FuelTank = 12;
		}

		public class WeaponDescription
		{
			public ushort Weapon = 0;
			public ushort Ammo = 0;

			public int GetWeaponType()
			{
				if (ListOfWeaponTypes.Any(x => x == Weapon)) return ListOfWeaponTypes.First(y => y == Weapon);
				return WeaponTypes.Null;
			}
			public WeaponDescription(ushort _Weapon, ushort _Ammo)
			{
				Weapon = _Weapon;
				Ammo = _Ammo;
			}
		}
		public List<WeaponDescription> WeaponsInfo
		{
			get
			{
				List<WeaponDescription> _WeaponsInfoOutput = new List<WeaponDescription>();
				for (int i = 6; i <= Data.Length - 4; i += 4)
				{
					_WeaponsInfoOutput.Add(new WeaponDescription(GetUInt16(i), GetUInt16(i + 2)));
				}
				return _WeaponsInfoOutput;
			}
			set
			{
				for (int i = 0; i < value.Count; i++)
				{
					SetUInt16(6+i, value[i].Weapon);
					SetUInt16(6+i+2, value[i].Ammo);
				}
			}
		}

		public bool AddWeapon(ushort _WeaponType, ushort _Ammo)
		{
			List<WeaponDescription> UpdateInfo = WeaponsInfo;
			UpdateInfo.Add(new WeaponDescription(_WeaponType, _Ammo));
			WeaponsInfo = UpdateInfo;
			return true;
		}
		public bool RemoveWeapon(ushort _WeaponType)
		{
			List<WeaponDescription> UpdateInfo = WeaponsInfo;
			List<WeaponDescription> WeaponsToRemove = WeaponsInfo.Where(x => x.Weapon == _WeaponType).ToList();
			UpdateInfo.RemoveAll(x => x.Weapon == _WeaponType);
			for (int i = 0; i < WeaponsToRemove.Count - 1; i++)
			{
				UpdateInfo.Add(WeaponsToRemove[i]);
			}
			WeaponsInfo = UpdateInfo;
			return true;
		}
		public bool RemoveAllWeapon(ushort _WeaponType)
		{
			List<WeaponDescription> UpdateInfo = WeaponsInfo;
			UpdateInfo.RemoveAll(x => x.Weapon == _WeaponType);
			WeaponsInfo = UpdateInfo;
			return true;
		}
	}
}
