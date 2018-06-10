using System;
using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_44_AircraftList : GenericPacket, IPacket_44_AircraftList
	{
		public Type_44_AircraftList() : base(44)
		{
		}

		public Type_44_AircraftList(List<string> listOfAircraftIdentifys) : base(44)
		{
			AircraftIdentities = listOfAircraftIdentifys;
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
		public List<string> AircraftIdentities
		{
			get => GetString(4, Data.Length - 4).Split('\0').ToList();
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
