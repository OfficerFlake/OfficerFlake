﻿using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	public static partial class MasterObjectFactory
	{
		#region Variables
		private static IObjectFactory masterFactory = new _MasterObjectFactory();
		#endregion
	}
}
