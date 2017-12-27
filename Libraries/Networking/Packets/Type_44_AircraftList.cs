using System;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_44_AircraftList : GenericPacket
	{
		public Type_44_AircraftList() : base(44)
		{
		}

		public Type_44_AircraftList(string[] listOfAircraftIdentifys) : base(44)
		{
			List = listOfAircraftIdentifys;
		}

		public Byte Version
		{
			get => GetByte(0);
			set => SetByte(0, value);
		}
		public Byte Count
		{
			get => GetByte(1);
			set => SetByte(1, value);
		}
		public string[] List
		{
			get => GetString(4, Data.Length - 4).Split('\0');
			set
			{
				string ACList = "";
				foreach (string ThisString in value)
				{
					ACList += ThisString + "\0";
				}
				ResizeData(4);
				Count = (byte)(ACList.Split('\0').Length-1);
				SetString(4, ACList.Length, ACList);
			}
		}
	}
}
