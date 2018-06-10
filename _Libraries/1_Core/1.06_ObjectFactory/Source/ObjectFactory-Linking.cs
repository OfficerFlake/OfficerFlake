using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	public static partial class ObjectFactory
	{
		#region Linking
		public static void LinkObjectFactory(IObjectFactory newFactory)
		{
			objectFactory = newFactory;
		}
		#endregion
	}
}
