namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface ISettingsFile : ICommandFile
	{
	}

	public interface ISettingsHandler
	{
		bool LoadAll();
		bool SaveAll();
	}
}
