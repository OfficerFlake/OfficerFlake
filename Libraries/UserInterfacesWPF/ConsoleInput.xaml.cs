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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Console = Com.OfficerFlake.Libraries.Logger.Console;

namespace Com.OfficerFlake.Libraries.UserInterfaces
{
	/// <summary>
	/// Interaction logic for ConsoleOutput.xaml
	/// </summary>
	public partial class ConsoleInput
	{
		public ConsoleInput()
		{
			InitializeComponent();
			if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this)) return;
		}

		private void ConsoleInput_GotFocus(object sender, RoutedEventArgs e)
		{
			if (ConsoleInputViewModel.Text == "<Console Input Ready>") ConsoleInputViewModel.Text = "";
			ConsoleInputViewModel.Foreground = new SolidColorBrush(Color.FromRgb(255,255,255));
		}

		private void ConsoleInput_LostFocus(object sender, RoutedEventArgs e)
		{
			if (ConsoleInputViewModel.Text == "") ConsoleInputViewModel.Text = "<Console Input Ready>";
			ConsoleInputViewModel.Foreground = new SolidColorBrush(Color.FromRgb(128, 128, 128));
		}

		private void ConsoleInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key != Key.Enter) return;
			if (ConsoleInputViewModel.Text == "") return;
			//TODO : Link to CommandHandler
			Console.AddUserMessage(Users.Console, ConsoleInputViewModel.Text);
			IPacket_32_ChatMessage messagePacket = ObjectFactory.CreatePacket32ChatMessage(Users.Console, ConsoleInputViewModel.Text);
			Connections.AllConnections.SendAsync(messagePacket);
			ConsoleInputViewModel.Text = "";
		}
	}
}
