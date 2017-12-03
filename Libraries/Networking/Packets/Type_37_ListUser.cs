using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_37_ListUser : GenericPacket
	{
		public Type_37_ListUser() : base(37)
		{
		}

		public Int16 ClientType
		{
			get => GetInt16(0);
			set => SetInt16(0, value);
		}
		public Int16 IFF
		{
			get => GetInt16(2);
			set => SetInt16(2, value);
		}
		public Int32 ID
		{
			get => GetInt32(4);
			set => SetInt32(4, value);
		}
		public String Identify
		{
			get => GetString(12, Data.Length - 12);
			set
			{
				ResizeData(12);
				SetString(12, value.Length+1, value+"\0");
			}
		}

		private static readonly List<int> ListOfClientTypes = new List<int>()
		{
			ClientTypes.ClientNotFlying,
			ClientTypes.ClientFlying,
			ClientTypes.ServerNotFlying,
			ClientTypes.ServerFlying,
	};
		public static class ClientTypes
		{
			public static int ClientNotFlying = 0;
			public static int ClientFlying = 1;
			public static int ServerNotFlying = 2;
			public static int ServerFlying = 3;
		}
	}
}
