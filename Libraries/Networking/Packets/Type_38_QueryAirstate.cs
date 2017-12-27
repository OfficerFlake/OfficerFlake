using System;
using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_38_QueryAirstate : GenericPacket
	{
		public Type_38_QueryAirstate() : base(38)
		{
		}
		public Type_38_QueryAirstate(params Int32[] aircraftIDs) : base(38)
		{
			AircraftIDs = aircraftIDs;
		}

		public Int32 Count
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}
		public Int32[] AircraftIDs
		{
			get
			{
				List<Int32> ArgumentsOut = new List<Int32>();
				for (int i = 4; i <= Data.Length - 4; i += 4)
				{
					ArgumentsOut.Add(GetInt32(i));
				}
				return ArgumentsOut.ToArray();
			}
			set
			{
				ResizeData(0);
				for (int i = 4; i <= value.Length - 1; i += 1)
				{
					SetInt32(i*4,value[i]);
				}
				Count = value.Length;
			}
		}
	}
}
