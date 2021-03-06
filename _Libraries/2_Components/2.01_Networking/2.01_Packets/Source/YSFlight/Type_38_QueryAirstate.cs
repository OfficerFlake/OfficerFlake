﻿using System;
using System.Collections.Generic;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_38_QueryAirstate : GenericPacket, IPacket_38_QueryAirstate
	{
		public Type_38_QueryAirstate() : base(38)
		{
		}
		public Type_38_QueryAirstate(params UInt32[] aircraftIDs) : base(38)
		{
			AircraftIDs = aircraftIDs;
		}

		public UInt32 AircraftCount
		{
			get => (uint)AircraftIDs.Length;
		}
		public UInt32[] AircraftIDs
		{
			get
			{
				List<UInt32> ArgumentsOut = new List<UInt32>();
				for (int i = 4; i <= Data.Length - 4; i += 4)
				{
					ArgumentsOut.Add(GetUInt32(i));
				}
				return ArgumentsOut.ToArray();
			}
			set
			{
				ResizeData(4+value.Length*4);
				SetUInt32(0, (uint) value.Length);
				for (int i = 0; i <= value.Length-1; i += 1)
				{
					SetUInt32(4+i*4,value[i]);
				}
			}
		}
	}
}
