using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_08_JoinRequest : GenericPacket
	{
		public Type_08_JoinRequest() : base(8)
		{
			ResizeData(72);
		}

		public Int32 IFF
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}
		public String RequestedAircraftIdentify
		{
			get => GetString(4, 32);
			set => SetString(4, 32, value);
		}
		public String RequestedStartPositionIdentify
		{
			get => GetString(36, 32);
			set => SetString(36, 32, value);
		}
		public Byte RequestedFuelPerecent
		{
			get => GetByte(70);
			set => SetByte(70, value);
		}
	}
}
