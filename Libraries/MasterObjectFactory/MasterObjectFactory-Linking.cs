namespace Com.OfficerFlake.Libraries
{
	public static partial class MasterObjectFactory
	{
		#region Linking
		public static void LinkMasterFactory()
		{
			ObjectFactory.LinkSlaveFactory(masterFactory);
		}
		#endregion
	}
}
