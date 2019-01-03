namespace Com.OfficerFlake.Libraries.UserInterfaces
{
	/// <summary>
	/// Interaction logic for ConsoleOutput.xaml
	/// </summary>
	public partial class MenuBar
	{
		public MenuBar()
		{
			InitializeComponent();
			if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this)) return;

			DataContext = SettingsLibrary.Settings;

			OpenYS_ConsoleOutput_ShowMessages_Console.DataContext = SettingsLibrary.Settings.UserInterface.Console.ShowMessages;
			OpenYS_ConsoleOutput_ShowMessages_Users.DataContext = SettingsLibrary.Settings.UserInterface.Console.ShowMessages;

			OpenYS_ConsoleOutput_ShowDebug_Summary.DataContext = SettingsLibrary.Settings.UserInterface.Console.ShowDebug;
			OpenYS_ConsoleOutput_ShowDebug_Detail.DataContext = SettingsLibrary.Settings.UserInterface.Console.ShowDebug;
			OpenYS_ConsoleOutput_ShowDebug_Warning.DataContext = SettingsLibrary.Settings.UserInterface.Console.ShowDebug;
			OpenYS_ConsoleOutput_ShowDebug_Error.DataContext = SettingsLibrary.Settings.UserInterface.Console.ShowDebug;
			OpenYS_ConsoleOutput_ShowDebug_Crash.DataContext = SettingsLibrary.Settings.UserInterface.Console.ShowDebug;
		}
	}
}
