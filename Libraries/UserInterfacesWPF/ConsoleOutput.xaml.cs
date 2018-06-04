using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.UserInterfaces
{
	/// <summary>
	/// Interaction logic for ConsoleOutput.xaml
	/// </summary>
	public partial class ConsoleOutput : IConsole, IDebug
	{
		private readonly List<IRichTextMessage> _messageList = new List<IRichTextMessage>();
		private byte column_Date = 0;
		private byte column_Time = 1;
		private byte column_Type = 2;
		private byte column_User = 3;
		private byte column_String = 4;
		private GridLength column_Date_Width = new GridLength(62);
		private GridLength column_Time_Width = new GridLength(50);
		private GridLength column_Type_Width = new GridLength(70);
		private GridLength column_User_Width = new GridLength(100);
		private GridLength column_String_Width = new GridLength(1, GridUnitType.Star);

		public ConsoleOutput()
		{
			InitializeComponent();
			HideColumn(column_Type);
			SettingsLibrary.Settings.UserInterface.Console.ShowMessages.PropertyChanged += OnSettingChanged;
			SettingsLibrary.Settings.UserInterface.Console.ShowDebug.PropertyChanged += OnSettingChanged;
		}

		#region Grid Control
		private void ClearRows()
		{
			lock (_messageList)
			{
				ConsoleOutputGrid.RowDefinitions.Clear();
				ConsoleOutputGrid.Children.Clear();
			}
		}
		private void AddMessage(IRichTextMessage newMessage)
		{
			bool scrollToEnd = (ConsoleOutputScrollViewer.VerticalOffset == ConsoleOutputScrollViewer.ScrollableHeight);
			AddMessageToList(newMessage);
			AddMessageToGrid(newMessage);
			if (scrollToEnd) ConsoleOutputScrollViewer.ScrollToBottom();
		}
		private void AddMessageToList(IRichTextMessage newMessage)
		{
			lock (_messageList)
			{
				#region Add to List
				_messageList.Add(newMessage);
				#endregion
			}
		}
		private void AddMessageToGrid(IRichTextMessage newMessage)
		{
			lock (_messageList)
			{
				#region Limit Grid Size
				if (_messageList.Count >= 10000)
				{
					_messageList.RemoveRange(0, _messageList.Count - 8000);
					RefreshGrid();
					return;
				}
				#endregion

				#region RETURN if Row should be Hidden
				if (newMessage.Type == MessageType.ConsoleInformation && !SettingsLibrary.Settings.UserInterface.Console.ShowMessages.Console) return;
				if (newMessage.Type == MessageType.User && !SettingsLibrary.Settings.UserInterface.Console.ShowMessages.User) return;

				if (newMessage.Type == MessageType.DebugSummary && !SettingsLibrary.Settings.UserInterface.Console.ShowDebug.Summary) return;
				if (newMessage.Type == MessageType.DebugDetail && !SettingsLibrary.Settings.UserInterface.Console.ShowDebug.Detail) return;
				if (newMessage.Type == MessageType.DebugWarning && !SettingsLibrary.Settings.UserInterface.Console.ShowDebug.Warning) return;
				if (newMessage.Type == MessageType.DebugError && !SettingsLibrary.Settings.UserInterface.Console.ShowDebug.Error) return;
				if (newMessage.Type == MessageType.DebugCrash && !SettingsLibrary.Settings.UserInterface.Console.ShowDebug.Crash) return;
				#endregion
				#region ELSE, Add to Grid
				#region Convert
				RichTextMessageTextBlockContainer newTextBlockContainer = new RichTextMessageTextBlockContainer(newMessage);
				#endregion
				#region Borders
				Border border_Date = newTextBlockContainer.Datestamp;
				Border border_Time = newTextBlockContainer.Timestamp;
				Border border_Type = newTextBlockContainer.Type;
				Border border_User = newTextBlockContainer.User;
				Border border_String = newTextBlockContainer.String;
				#endregion
				#region Row
				RowDefinition newRow = new RowDefinition();
				newRow.Height = new GridLength(1, GridUnitType.Auto);
				#endregion
				#region Add Borders to Grid
				if (DatestampColumn.Width.Value > 0) ConsoleOutputGrid.Children.Add(border_Date);
				if (TimestampColumn.Width.Value > 0) ConsoleOutputGrid.Children.Add(border_Time);
				if (TypeColumn.Width.Value > 0) ConsoleOutputGrid.Children.Add(border_Type);
				if (UserColumn.Width.Value > 0) ConsoleOutputGrid.Children.Add(border_User);
				if (StringColumn.Width.Value > 0) ConsoleOutputGrid.Children.Add(border_String);
				#endregion
				#region Add Row to Grid
				ConsoleOutputGrid.RowDefinitions.Add(newRow);
				#endregion
				#region Position TextBlocks in Grid
				#region Position Row
				if (DatestampColumn.Width.Value > 0) Grid.SetRow(border_Date, ConsoleOutputGrid.RowDefinitions.Count - 1);
				if (TimestampColumn.Width.Value > 0) Grid.SetRow(border_Time, ConsoleOutputGrid.RowDefinitions.Count - 1);
				if (TypeColumn.Width.Value > 0) Grid.SetRow(border_Type, ConsoleOutputGrid.RowDefinitions.Count - 1);
				if (UserColumn.Width.Value > 0) Grid.SetRow(border_User, ConsoleOutputGrid.RowDefinitions.Count - 1);
				if (StringColumn.Width.Value > 0) Grid.SetRow(border_String, ConsoleOutputGrid.RowDefinitions.Count - 1);
				#endregion
				#region Position Column
				if (DatestampColumn.Width.Value > 0) Grid.SetColumn(border_Date, 0);
				if (TimestampColumn.Width.Value > 0) Grid.SetColumn(border_Time, 1);
				if (TypeColumn.Width.Value > 0) Grid.SetColumn(border_Type, 2);
				if (UserColumn.Width.Value > 0) Grid.SetColumn(border_User, 3);
				if (StringColumn.Width.Value > 0) Grid.SetColumn(border_String, 4);
				#endregion
				#endregion
				#endregion
			}
		}
		private void RefreshGrid()
		{
			lock (_messageList)
			{
				ClearRows();
				#region Add Each Message from List...
				foreach (IRichTextMessage thisMessage in _messageList)
				{
					AddMessageToGrid(thisMessage);
				}
				#endregion
			}
		}
		private void HideColumn(byte columnNumber)
		{
			if (columnNumber > ConsoleOutputGrid.ColumnDefinitions.Count - 1)
			{
				throw new ArgumentOutOfRangeException("Trying to hide a column outside of definitions!");
			}
			ConsoleOutputGrid.ColumnDefinitions[columnNumber].Width = new GridLength(0);
			RefreshGrid();
		}
		private void ShowColumn(byte columnNumber)
		{
			if (columnNumber > ConsoleOutputGrid.ColumnDefinitions.Count - 1)
			{
				throw new ArgumentOutOfRangeException("Trying to hide a column outside of definitions!");
			}
			switch (columnNumber)
			{
				case 0:
					ConsoleOutputGrid.ColumnDefinitions[columnNumber].Width = column_Date_Width;
					break;
				case 1:
					ConsoleOutputGrid.ColumnDefinitions[columnNumber].Width = column_Time_Width;
					break;
				case 2:
					ConsoleOutputGrid.ColumnDefinitions[columnNumber].Width = column_Type_Width;
					break;
				case 3:
					ConsoleOutputGrid.ColumnDefinitions[columnNumber].Width = column_User_Width;
					break;
				case 4:
					ConsoleOutputGrid.ColumnDefinitions[columnNumber].Width = column_String_Width;
					break;
			}
			RefreshGrid();
		}
		#endregion

		#region Add New Messages
		#region Console
		public void AddInformationMessage(string message)
		{
			try
			{
				Dispatcher.Invoke(() =>
				{
					IRichTextMessage informationMessage = ObjectFactory.CreateConsoleInformationMessage(message.AsRichTextString());
					AddMessage(informationMessage);
				});
			}
			catch
			{
			}
		}
		public void AddUserMessage(IUser user, string message)
		{
			try
			{
				Dispatcher.Invoke(() =>
				{
					IRichTextMessage userMessage = ObjectFactory.CreateConsoleUserMessage(user, message.AsRichTextString());
					AddMessage(userMessage);
				});
			}
			catch
			{
			}
		}
		#endregion
		#region Debug
		public void AddSummaryMessage(string message)
		{
			Dispatcher.Invoke(() =>
			{
				IRichTextMessage summaryMessage = ObjectFactory.CreateDebugSummaryMessage(message.AsRichTextString());
				AddMessage(summaryMessage);
			});
		}
		public void AddDetailMessage(string message)
		{
			Dispatcher.Invoke(() =>
			{
				IRichTextMessage detailMessage = ObjectFactory.CreateDebugDetailMessage(message.AsRichTextString());
				AddMessage(detailMessage);
			});
		}
		public void AddWarningMessage(string message)
		{
			Dispatcher.Invoke(() =>
			{
				IRichTextMessage warningMessage = ObjectFactory.CreateDebugWarningMessage(message.AsRichTextString());
				AddMessage(warningMessage);
			});
		}
		public void AddErrorMessage(Exception e, string message)
		{
			Dispatcher.Invoke(() =>
			{
				IRichTextMessage errorMessage = ObjectFactory.CreateDebugErrorMessage(e, message.AsRichTextString());
				AddMessage(errorMessage);
			});
		}
		public void AddCrashMessage(Exception e, string message)
		{
			Dispatcher.Invoke(() =>
			{
				IRichTextMessage crashMessage = ObjectFactory.CreateDebugCrashMessage(e, message.AsRichTextString());
				AddMessage(crashMessage);
			});
		}
		#endregion
		#endregion
		#region Clear Messages
		public void ClearAllMessages()
		{
			_messageList.RemoveAll(x => x is IConsoleUserMessage | x is IConsoleInformationMessage | x is IDebugSummaryMessage | x is IDebugDetailMessage | x is IDebugWarningMessage | x is IDebugErrorMessage | x is IDebugCrashMessage);
			RefreshGrid();
		}
		public void ClearConsoleMessages()
		{
			_messageList.RemoveAll(x => x is IConsoleUserMessage | x is IConsoleInformationMessage);
			RefreshGrid();
		}
		public void ClearDebugMessages()
		{
			_messageList.RemoveAll(x => x is IDebugSummaryMessage | x is IDebugDetailMessage | x is IDebugWarningMessage | x is IDebugErrorMessage | x is IDebugCrashMessage);
			RefreshGrid();
		}
		#endregion

		private void OnSettingChanged(object obj, PropertyChangedEventArgs e)
		{
			RefreshGrid();
		}
	}
}
