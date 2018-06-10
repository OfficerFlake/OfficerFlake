namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IFile
	{
		string Filename { get; }
		string[] Contents { get; set; }

		bool Load();
		bool Save();
	}
}
