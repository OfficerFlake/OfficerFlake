using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_06_Acknowledgement : GenericPacket
	{
		public Type_06_Acknowledgement() : base(6)
		{
		}
		public Type_06_Acknowledgement(params Int32[] arguments) : base(6)
		{
			Arguments = arguments;
		}

		public Int32[] Arguments
		{
			get
			{
				List<Int32> ArgumentsOut = new List<Int32>();
				for (int i = 0; i <= Data.Length - 4; i += 4)
				{
					ArgumentsOut.Add(GetInt32(i));
				}
				return ArgumentsOut.ToArray();
			}
			set
			{
				ResizeData(0);
				for (int i = 0; i <= value.Length - 1; i += 1)
				{
					SetInt32(i*4,value[i]);
				}
			}
		}
	}
}
