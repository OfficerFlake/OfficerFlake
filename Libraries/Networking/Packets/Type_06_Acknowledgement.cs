using System;
using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_06_Acknowledgement : GenericPacket, IPacket_06_Acknowledgement
	{
		public Type_06_Acknowledgement() : base(6)
		{
		}
		public Type_06_Acknowledgement(params Int32[] arguments) : base(6)
		{
			Arguments = arguments.Select(x=>(uint)x).ToArray();
		}

		public UInt32[] Arguments
		{
			get
			{
				List<UInt32> ArgumentsOut = new List<UInt32>();
				for (int i = 0; i <= Data.Length - 4; i += 4)
				{
					ArgumentsOut.Add(GetUInt32(i));
				}
				return ArgumentsOut.ToArray();
			}
			set
			{
				ResizeData(0);
				for (int i = 0; i <= value.Length - 1; i += 1)
				{
					SetUInt32(i*4,value[i]);
				}
			}
		}
	}
}
