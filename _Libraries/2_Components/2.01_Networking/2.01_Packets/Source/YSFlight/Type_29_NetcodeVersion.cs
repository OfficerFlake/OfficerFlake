using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_29_NetcodeVersion : GenericPacket, IPacket_29_NetcodeVersion
	{
		public Type_29_NetcodeVersion() : base(29)
		{
		}
		public Type_29_NetcodeVersion(UInt32 version) : base(29)
		{
			Version = version;
		}

		public UInt32 Version
		{
			get => GetUInt32(0);
			set => SetUInt32(0, value);
		}
	}
}
