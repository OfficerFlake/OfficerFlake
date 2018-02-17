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
	public partial class ConsoleOutput : IConsole, IDebug
	{
		public List<RichTextMessageTextBlockContainer> Messages = new List<RichTextMessageTextBlockContainer>();

		public List<RichTextMessageTextBlockContainer> SelectedMessages
		{
			get
			{
				return null;
				//TODO: [5] Add a RichTextMessage container, and a converter to convert from RTM to textblock and back again!
			}
		}

		public ConsoleOutput()
		{
			InitializeComponent();
			DataGridViewModel.DataContext = this;
			DataGridViewModel.ItemsSource = Messages;
			Type.Visibility = Visibility.Hidden;
		}

		private void AddMessageToWindow(RichTextMessageTextBlockContainer newMessage)
		{
			#region Add to Messages List
			Messages.Add(newMessage);
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
