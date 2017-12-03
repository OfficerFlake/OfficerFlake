using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_03_Error : GenericPacket
	{
		public Type_03_Error() : base(03)
		{
		}
		public Type_03_Error(Int32 errorCode) : base(03)
		{
			ErrorCode = errorCode;
		}

		public Int32 ErrorCode
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}
	}
}
