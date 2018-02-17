using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

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
