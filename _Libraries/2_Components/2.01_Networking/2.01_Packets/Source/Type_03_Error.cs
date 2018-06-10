using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_03_Error : GenericPacket, IPacket_03_Error
	{
		public Type_03_Error() : base(03)
		{
		}
		public Type_03_Error(Int32 errorCode) : base(03)
		{
			ErrorCode = (uint)errorCode;
		}

		public UInt32 ErrorCode
		{
			get => GetUInt32(0);
			set => SetUInt32(0, value);
		}
	}
}
