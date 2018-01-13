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

namespace Com.OfficerFlake.Libraries.UserInterfacesWPF
{
	/// <summary>
	/// Interaction logic for ConsoleOutput.xaml
	/// </summary>
	public partial class ConsoleOutput : IConsole, IDebug
	{
		public List<RichTextMessageTextBlockContainer> Messages = new List<RichTextMessageTextBlockContainer>();

		public ConsoleOutput()
		{
			InitializeComponent();

			#region HideCells
			//Date
			ConsoleOutputViewModel.ColumnDefinitions[0].Width = new GridLength(62);

			//Time
			ConsoleOutputViewModel.ColumnDefinitions[1].Width = new GridLength(50);

			//Type
			ConsoleOutputViewModel.ColumnDefinitions[2].Width = new GridLength(0);

			//User
			ConsoleOutputViewModel.ColumnDefinitions[3].Width = new GridLength(100);

			//String
			ConsoleOutputViewModel.ColumnDefinitions[4].Width = new GridLength(1, GridUnitType.Star);
			#endregion
			//this.DataContext = this;
        }

		private void AddMessageToWindow(RichTextMessageTextBlockContainer newMessage)
		{

				#region Add to Messages List
				Messages.Add(newMessage);
				#endregion

				#region Create New Row
				RowDefinition newRow = new RowDefinition();
				//newRow.Height = new GridLength(18);

				int newRowPosition = ConsoleOutputViewModel.RowDefinitions.Count;
				ConsoleOutputViewModel.RowDefinitions.Add(newRow);
				#endregion
				#region Add Message Components To Window
				ConsoleOutputViewModel.Children.Add(newMessage.Datestamp);
				ConsoleOutputViewModel.Children.Add(newMessage.Timestamp);
				ConsoleOutputViewModel.Children.Add(newMessage.Type);
				ConsoleOutputViewModel.Children.Add(newMessage.User);
				ConsoleOutputViewModel.Children.Add(newMessage.String);
				#endregion
				#region Set Position of Message Components
				Grid.SetRow(newMessage.Datestamp, newRowPosition);
				Grid.SetColumn(newMessage.Datestamp, 0);

				Grid.SetRow(newMessage.Timestamp, newRowPosition);
				Grid.SetColumn(newMessage.Timestamp, 1);

				Grid.SetRow(newMessage.Type, newRowPosition);
				Grid.SetColumn(newMessage.Type, 2);

				Grid.SetRow(newMessage.User, newRowPosition);
				Grid.SetColumn(newMessage.User, 3);

				Grid.SetRow(newMessage.String, newRowPosition);
				Grid.SetColumn(newMessage.String, 4);
				#endregion
		}
		#region Console
		public void AddInformationMessage(string message)
		{
			Dispatcher.Invoke(() =>
			{
				RichTextMessageTextBlockContainer newMessage = new RichTextMessageTextBlockContainer
				(
					ObjectFactory.CreateConsoleInformationMessage(message.AsRichTextString())
				);
				AddMessageToWindow(newMessage);
			});
		}
		public void AddUserMessage(IUser user, string message)
		{
			Dispatcher.Invoke(() =>
			{
				RichTextMessageTextBlockContainer newMessage = new RichTextMessageTextBlockContainer
				(
					ObjectFactory.CreateConsoleUserMessage(user, message.AsRichTextString())
				);
				AddMessageToWindow(newMessage);
			});
		}
		#endregion
		#region Debug
		public void AddSummaryMessage(string message)
		{
			Dispatcher.Invoke(() =>
			{
				RichTextMessageTextBlockContainer newMessage = new RichTextMessageTextBlockContainer
				(
					ObjectFactory.CreateDebugSummaryMessage(message.AsRichTextString())
				);
				AddMessageToWindow(newMessage);
			});
		}
		public void AddDetailMessage(string message)
		{
			Dispatcher.Invoke(() =>
			{
				RichTextMessageTextBlockContainer newMessage = new RichTextMessageTextBlockContainer
				(
					ObjectFactory.CreateDebugDetailMessage(message.AsRichTextString())
				);
				AddMessageToWindow(newMessage);
			});
		}
		public void AddWarningMessage(string message)
		{
			Dispatcher.Invoke(() =>
			{
				RichTextMessageTextBlockContainer newMessage = new RichTextMessageTextBlockContainer
				(
					ObjectFactory.CreateDebugWarningMessage(message.AsRichTextString())
				);
				AddMessageToWindow(newMessage);
			});
		}
		public void AddErrorMessage(Exception e, string message)
		{
			Dispatcher.Invoke(() =>
			{
				RichTextMessageTextBlockContainer newMessage = new RichTextMessageTextBlockContainer
				(
					ObjectFactory.CreateDebugErrorMessage(e, message.AsRichTextString())
				);
				AddMessageToWindow(newMessage);
			});
		}
		public void AddCrashMessage(Exception e, string message)
		{
			Dispatcher.Invoke(() =>
			{
				RichTextMessageTextBlockContainer newMessage = new RichTextMessageTextBlockContainer
				(
					ObjectFactory.CreateDebugCrashMessage(e, message.AsRichTextString())
				);
				AddMessageToWindow(newMessage);
			});
		}
		#endregion
	}
}
