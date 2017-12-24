using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	public static partial class ObjectFactory
	{
		#region Linking
		public static void LinkSlaveFactory(IObjectFactory newFactory)
		{
			factory = newFactory;
		}
		#endregion
	}
}
