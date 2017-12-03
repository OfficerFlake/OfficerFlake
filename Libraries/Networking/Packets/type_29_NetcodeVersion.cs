using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_29_NetcodeVersion : GenericPacket
	{
		public Type_29_NetcodeVersion() : base(29)
		{
		}
		public Type_29_NetcodeVersion(Int32 version) : base(29)
		{
			Version = version;
		}

		public Int32 Version
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}
	}
}
