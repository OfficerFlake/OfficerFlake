using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	public static partial class ObjectFactory
	{
		#region Variables
		private static IObjectFactory slaveFactory = new DefaultObjectFactory();
		#endregion
	}
}
