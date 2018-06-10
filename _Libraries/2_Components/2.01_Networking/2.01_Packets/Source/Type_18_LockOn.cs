using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_18_LockOn : GenericPacket, IPacket_18_LockOn
	{
		public Type_18_LockOn() : base(18)
		{
		}
		public Type_18_LockOn(UInt32 lockedOnBy_ID, UInt32 lockedOnBy_Type, UInt32 lockedOnTo_ID, UInt32 lockedOnTo_Type) : base(18)
		{
			LockedOnByID = lockedOnBy_ID;
			LockedOnByType = lockedOnBy_Type;
			LockedOnToID = lockedOnTo_ID;
			LockedOnToType = lockedOnTo_Type;
		}

		public UInt32 LockedOnByID
		{
			get => GetUInt32(0);
			set => SetUInt32(0, value);
		}

		public UInt32 LockedOnByType
		{
			get => GetUInt32(4);
			set => SetUInt32(4, value);
		}

		public UInt32 LockedOnToID
		{
			get => GetUInt32(8);
			set => SetUInt32(8, value);
		}

		public UInt32 LockedOnToType
		{
			get => GetUInt32(12);
			set => SetUInt32(12, value);
		}
	}
}
