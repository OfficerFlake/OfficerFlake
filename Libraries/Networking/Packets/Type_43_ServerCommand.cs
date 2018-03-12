using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_43_ServerCommand : GenericPacket, IPacket_43_ServerCommand
	{
		public Type_43_ServerCommand() : base(43)
		{
		}

		public Int32 ID
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}

		public String Command
		{
			get
			{
				var Array = GetString(4, Data.Length - 4).Split(new[] { ' ' }, 2);
				return Array[0];
			}
			set
			{
				if (Data.Length < 4) ResizeData(4);
				var Array = GetString(4, Data.Length - 4).Split(new [] {' '}, 2);
				var _arg = "";
				if (Array.Length > 1) _arg = Array[1];
				if (value == null) value = "";

				SetString(4, value.Length + _arg.Length, value + " " + _arg + "\0");
			}
		}
		public String Parameters
		{
			get
			{
				var Array = GetString(4, Data.Length - 4).Split(new[] { ' ' }, 2);
				var _arg = "";
				if (Array.Length > 1) _arg = Array[1];
				return _arg;
			}
			set
			{
				if (Data.Length < 4) ResizeData(4);
				var Array = GetString(4, Data.Length - 4).Split(new[] { ' ' }, 2);
				if (value == null) value = "";
				value = value.Split('\0')[0];

				SetString(4, Command.Length + 1 + value.Length, Command + " " + value + "\0");
			}
		}
	}
}
