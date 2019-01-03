using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_64_01_OYSVersion : GenericPacket, IPacket_64_01_OYSVersion
	{
		public Type_64_01_OYSVersion() : base(64)
		{
			ResizeData(8);
			OYSVersion = SettingsLibrary.Settings.Options.OYSNetcodeVersion;
		}

		public UInt32 UserPacketHeader
		{
			get { return GetUInt32(0); }
			set { SetUInt32(0, value); }
		}

		public UInt32 OYSVersion
		{
			get { return GetUInt32(4); }
			set { SetUInt32(4, value); }
		}
	}
}
