using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_08_JoinRequest : GenericPacket, IPacket_08_JoinRequest
	{
		public Type_08_JoinRequest() : base(8)
		{
			ResizeData(72);
		}

		public UInt32 IFF
		{
			get => GetUInt32(0);
			set => SetUInt32(0, value);
		}
		public String AircraftIdentify
		{
			get => GetString(4, 32);
			set => SetString(4, 32, value);
		}
		public String StartPositionIdentify
		{
			get => GetString(36, 32);
			set => SetString(36, 32, value);
		}
		public Single FuelPercent
		{
			get => GetByte(70)/100f;
			set => SetByte(70, (byte)((value*100)%255));
		}
	}
}
