using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_01_Login : GenericPacket
	{
		public Type_01_Login() : base(1)
		{
		}

		public String Username
		{
			get
			{
				if (Data.Length > 20) return GetString(20, Data.Length - 20);
				else return GetString(0, 16);
			}
			set
			{
				ResizeData(20);
				SetString(0, 16, value);
				if (value.Length > 16)
				{
					SetString(20, value.Length, value);
				}
			}
		}
		public Int32 Version
		{
			get => GetInt32(16);
			set => SetInt32(16, value);
		}
	}
}
