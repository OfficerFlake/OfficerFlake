using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_31_MissilesEnabled : GenericPacket
	{
		public Type_31_MissilesEnabled() : base(31)
		{
		}
		public Type_31_MissilesEnabled(Boolean enabled) : base(31)
		{
			Enabled = enabled;
		}

		public Boolean Enabled
		{
			get => (GetInt32(0) > 0);
			set => SetInt32(0, value ? 1 : 0);
		}
	}
}
