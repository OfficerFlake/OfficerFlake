namespace Com.OfficerFlake.Libraries
{
	public static partial class SettingsLibrary
	{
		public class SettingFile : IO.CommandFile
		{
			internal SettingFile(string filename) : base(filename)
			{

			}

		}
		public static SettingFile SettingsFile = new SettingFile(@"./Settings.Dat");
	}
}
