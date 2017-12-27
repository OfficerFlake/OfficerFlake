using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	public static partial class ObjectFactory
	{
		#region Linking
		public static void LinkSlaveFactory(IObjectFactory newFactory)
		{
			slaveFactory = newFactory;
		}
		#endregion
	}
}
