using System;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_30_AircraftCommand : GenericPacket
	{
		public Type_30_AircraftCommand() : base(30)
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
				var Array = GetString(4, Data.Length - 4).Split(new [] {' '}, 2);
				var _arg = "";
				if (Array.Length > 1) _arg = Array[1];
				if (value == null) value = "";

				SetString(4, value.Length + _arg.Length, value + " " + _arg + "\0");
			}
		}
		public String Argument
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
				var Array = GetString(4, Data.Length - 4).Split(new[] { ' ' }, 2);
				if (value == null) value = "";

				SetString(4, value.Length + 1 + value.Length, Array[0] + " " + value + "\0");
			}
		}
	}
}
