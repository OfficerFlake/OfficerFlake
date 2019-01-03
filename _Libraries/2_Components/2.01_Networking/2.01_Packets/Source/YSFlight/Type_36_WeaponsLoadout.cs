using System;
using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_36_WeaponsLoadout : GenericPacket, IPacket_36_WeaponsLoadout
	{
		public Type_36_WeaponsLoadout() : base(36)
		{
		}

		public UInt32 ID
		{
			get => GetUInt32(0);
			set => SetUInt32(0, value);
		}
		public UInt16 Version
		{
			get => GetUInt16(4);
			set => SetUInt16(4, value);
		}

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

		public class WeaponDescription : IPacket_36_WeaponLoadingDescription
		{
			public Packet_OrdinanceType WeaponType { get; set; } = Packet_OrdinanceType.Null;
			public UInt16 Ammo { get; set; } = 0;

			public WeaponDescription(Packet_OrdinanceType _weaponType, ushort _ammo)
			{
				WeaponType = _weaponType;
				Ammo = _ammo;
			}
		}
		public List<IPacket_36_WeaponLoadingDescription> Weapons
		{
			get
			{
				List<IPacket_36_WeaponLoadingDescription> _WeaponsInfoOutput = new List<IPacket_36_WeaponLoadingDescription>();
				for (int i = 6; i <= Data.Length - 4; i += 4)
				{
					Packet_OrdinanceType subOrdinanceType = Packet_OrdinanceType.Null;
					switch (GetUInt16(i))
					{
						case 1:
							subOrdinanceType = Packet_OrdinanceType.AAM_Short;
							break;
						case 2:
							subOrdinanceType = Packet_OrdinanceType.AGM;
							break;
						case 3:
							subOrdinanceType = Packet_OrdinanceType.B500;
							break;
						case 4:
							subOrdinanceType = Packet_OrdinanceType.RKT;
							break;
						case 5:
							subOrdinanceType = Packet_OrdinanceType.FLR;
							break;
						case 6:
							subOrdinanceType = Packet_OrdinanceType.AAM_Mid;
							break;
						case 7:
							subOrdinanceType = Packet_OrdinanceType.B250;
							break;
						case 8:
							subOrdinanceType = Packet_OrdinanceType.Unknown_8;
							break;
						case 9:
							subOrdinanceType = Packet_OrdinanceType.B500_HD;
							break;
						case 10:
							subOrdinanceType = Packet_OrdinanceType.AAM_X;
							break;
						case 11:
							subOrdinanceType = Packet_OrdinanceType.Unknown_11;
							break;
						case 12:
							subOrdinanceType = Packet_OrdinanceType.FuelTank;
							break;
						default:
							subOrdinanceType = Packet_OrdinanceType.Null;
							break;
					}
					_WeaponsInfoOutput.Add(new WeaponDescription(subOrdinanceType, GetUInt16(i + 2)));
				}
				return _WeaponsInfoOutput;
			}
			set
			{
				for (int i = 0; i < value.Count; i++)
				{
					switch (value[i].WeaponType)
					{
						default:
						case Packet_OrdinanceType.Null:
							SetUInt16(6 + i, 0);
							break;
						case Packet_OrdinanceType.AAM_Short:
							SetUInt16(6 + i, 1);
							break;
						case Packet_OrdinanceType.AGM:
							SetUInt16(6 + i, 2);
							break;
						case Packet_OrdinanceType.B500:
							SetUInt16(6 + i, 3);
							break;
						case Packet_OrdinanceType.RKT:
							SetUInt16(6 + i, 4);
							break;
						case Packet_OrdinanceType.FLR:
							SetUInt16(6 + i, 5);
							break;
						case Packet_OrdinanceType.AAM_Mid:
							SetUInt16(6 + i, 6);
							break;
						case Packet_OrdinanceType.B250:
							SetUInt16(6 + i, 7);
							break;
						case Packet_OrdinanceType.Unknown_8:
							SetUInt16(6 + i, 8);
							break;
						case Packet_OrdinanceType.B500_HD:
							SetUInt16(6 + i, 9);
							break;
						case Packet_OrdinanceType.AAM_X:
							SetUInt16(6 + i, 10);
							break;
						case Packet_OrdinanceType.Unknown_11:
							SetUInt16(6 + i, 11);
							break;
						case Packet_OrdinanceType.FuelTank:
							SetUInt16(6 + i, 12);
							break;
					}
					SetUInt16(6+i+2, value[i].Ammo);
				}
			}
		}

		public bool AddWeapon(Packet_OrdinanceType _WeaponType, ushort _Ammo)
		{
			List<IPacket_36_WeaponLoadingDescription> UpdateInfo = Weapons;
			UpdateInfo.Add(new WeaponDescription(_WeaponType, _Ammo));
			Weapons = UpdateInfo;
			return true;
		}
		public bool RemoveWeapon(Packet_OrdinanceType _WeaponType)
		{
			List<IPacket_36_WeaponLoadingDescription> UpdateInfo = Weapons;
			List<IPacket_36_WeaponLoadingDescription> WeaponsToRemove = Weapons.Where(x => x.WeaponType == _WeaponType).ToList();
			UpdateInfo.RemoveAll(x => x.WeaponType == _WeaponType);
			for (int i = 0; i < WeaponsToRemove.Count - 1; i++)
			{
				UpdateInfo.Add(WeaponsToRemove[i]);
			}
			Weapons = UpdateInfo;
			return true;
		}
		public bool RemoveAllWeapon(Packet_OrdinanceType _WeaponType)
		{
			List<IPacket_36_WeaponLoadingDescription> UpdateInfo = Weapons;
			UpdateInfo.RemoveAll(x => x.WeaponType == _WeaponType);
			Weapons = UpdateInfo;
			return true;
		}
	}
}
