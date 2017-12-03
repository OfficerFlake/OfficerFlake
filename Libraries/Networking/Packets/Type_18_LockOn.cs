using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_18_LockOn : GenericPacket
	{
		public Type_18_LockOn() : base(18)
		{
		}
		public Type_18_LockOn(Int32 lockedOnBy_ID, Int32 lockedOnBy_Type, Int32 lockedOnTo_ID, Int32 lockedOnTo_Type) : base(18)
		{
			LockedOnBy_ID = lockedOnBy_ID;
			LockedOnBy_Type = lockedOnBy_Type;
			LockedOnTo_ID = lockedOnTo_ID;
			LockedOnTo_Type = lockedOnTo_Type;
		}

		public Int32 LockedOnBy_ID
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}

		public Int32 LockedOnBy_Type
		{
			get => GetInt32(4);
			set => SetInt32(4, value);
		}

		public Int32 LockedOnTo_ID
		{
			get => GetInt32(8);
			set => SetInt32(8, value);
		}

		public Int32 LockedOnTo_Type
		{
			get => GetInt32(12);
			set => SetInt32(12, value);
		}
	}
}
