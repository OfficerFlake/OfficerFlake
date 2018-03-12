using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_45_GroundCommand : GenericPacket, IPacket_45_GroundCommand
	{
		public Type_45_GroundCommand() : base(45)
		{
		}

		public UInt32 ID
		{
			get => GetUInt32(0);
			set => SetUInt32(0, value);
		}

		public String Command
		{
			get
			{
				var Array = GetString(4, Data.Length - 4).Split(new[] { ' ' }, 1);
				return Array[0];
			}
			set
			{
				var Array = GetString(4, Data.Length - 4).Split(new [] {' '}, 1);
				var _arg = "";
				if (Array.Length > 1) _arg = Array[1];
				if (value == null) value = "";

				SetString(4, value.Length + _arg.Length, value + " " + _arg);
			}
		}
		public String Parameters
		{
			get
			{
				var Array = GetString(4, Data.Length - 4).Split(new[] { ' ' }, 1);
				var _arg = "";
				if (Array.Length > 1) _arg = Array[1];
				return _arg;
			}
			set
			{
				var Array = GetString(4, Data.Length - 4).Split(new[] { ' ' }, 1);
				if (value == null) value = "";

				SetString(4, value.Length + 1 + value.Length, Array[0] + " " + value);
			}
		}
	}
}
