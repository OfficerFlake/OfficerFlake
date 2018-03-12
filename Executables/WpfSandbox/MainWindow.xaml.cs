using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfSandbox
{
	public partial class Testing : Window
	{
		public Testing()
		{
			InitializeComponent();
			this.DataContext = this;
		}

		private readonly List<Message> _messageList = new List<Message>();
		private class Message
		{
			public string Date = "YYYYMMDD";
			public string Time = "hhmmss";
			public string Type = "Console Information";
			public string User = "Console";
			public string String = "Hello World";

			public Message(Testing Parent, string input)
			{
				Date = DateTime.Now.ToString("yyyyMMdd");
				Time = DateTime.Now.ToString("hhmmss");
				Type = "Console Information";
				User = "Console";
				String = input;
			}
		}
		
		private void ClearRows()
		{
			lock (_messageList)
			{
				TestGrid.RowDefinitions.Clear();
				TestGrid.Children.Clear();
			}
		}
		private void AddMessage(Message newMessage)
		{
			AddMessageToList(newMessage);
			AddMessageToGrid(newMessage);
		}
		private void AddMessageToList(Message newMessage)
		{
			lock (_messageList)
			{
				#region Add to List
				_messageList.Add(newMessage);
				#endregion
			}
		}
		private void AddMessageToGrid(Message newMessage)
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
				if (newMessage.Type == "Hidden") return;
				#endregion
				#region ELSE, Add to Grid
				#region TextBlocks
				TextBlock textBlock_Date = new TextBlock()
				{
					Text = newMessage.Date,
					Padding = new Thickness(0),
					Margin = new Thickness(0),
					Background = new SolidColorBrush(Color.FromRgb(200, 200, 200)),
					//TextWrapping = TextWrapping.Wrap
				};
				TextBlock textBlock_Time = new TextBlock()
				{
					Text = newMessage.Time,
					Padding = new Thickness(0),
					Margin = new Thickness(0),
					Background = new SolidColorBrush(Color.FromRgb(200, 200, 200)),
					//TextWrapping = TextWrapping.Wrap
				};
				TextBlock textBlock_Type = new TextBlock()
				{
					Text = newMessage.Type,
					Padding = new Thickness(0),
					Margin = new Thickness(0),
					Background = new SolidColorBrush(Color.FromRgb(200, 200, 200)),
					//TextWrapping = TextWrapping.Wrap
				};
				TextBlock textBlock_User = new TextBlock()
				{
					Text = newMessage.User,
					Padding = new Thickness(0),
					Margin = new Thickness(0),
					Background = new SolidColorBrush(Color.FromRgb(200, 200, 200)),
					//TextWrapping = TextWrapping.Wrap
				};
				TextBlock textBlock_String = new TextBlock()
				{
					Text = newMessage.String,
					Padding = new Thickness(0),
					Margin = new Thickness(0),
					Background = new SolidColorBrush(Color.FromRgb(200, 200, 200)),
					TextWrapping = TextWrapping.Wrap
				};
				#endregion
				#region Row
				RowDefinition newRow = new RowDefinition();
				newRow.Height = new GridLength(1, GridUnitType.Auto);
				#endregion
				#region Add TextBlocks to Grid
				TestGrid.Children.Add(textBlock_Date);
				TestGrid.Children.Add(textBlock_Time);
				TestGrid.Children.Add(textBlock_Type);
				TestGrid.Children.Add(textBlock_User);
				TestGrid.Children.Add(textBlock_String);
				#endregion
				#region Add Row to Grid
				TestGrid.RowDefinitions.Add(newRow);
				#endregion
				#region Position TextBlocks in Grid
				#region Position Row
				Grid.SetRow(textBlock_Date, TestGrid.RowDefinitions.Count - 1);
				Grid.SetRow(textBlock_Time, TestGrid.RowDefinitions.Count - 1);
				Grid.SetRow(textBlock_Type, TestGrid.RowDefinitions.Count - 1);
				Grid.SetRow(textBlock_User, TestGrid.RowDefinitions.Count - 1);
				Grid.SetRow(textBlock_String, TestGrid.RowDefinitions.Count - 1);
				#endregion
				#region Position Column
				Grid.SetColumn(textBlock_Date, 0);
				Grid.SetColumn(textBlock_Time, 1);
				Grid.SetColumn(textBlock_Type, 2);
				Grid.SetColumn(textBlock_User, 3);
				Grid.SetColumn(textBlock_String, 4);
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
				foreach (Message thisMessage in _messageList)
				{
					AddMessageToGrid(thisMessage);
				}
				#endregion
			}
		}

		private void TestButton_OnClick(object sender, RoutedEventArgs e)
		{
			lock (_messageList)
			{
				TestButton.IsEnabled = false;
				TestButton2.IsEnabled = false;
				for (int i = 0; i < 1024; i++)
				{
					Message newMessage = new Message(this,(_messageList.Count + 1).ToString());
					AddMessage(newMessage);
				}
				TestButton.IsEnabled = true;
				TestButton2.IsEnabled = true;
			}
		}
		private void TestButton2_OnClick(object sender, RoutedEventArgs e)
		{
			lock (_messageList)
			{
				TestButton.IsEnabled = false;
				TestButton2.IsEnabled = false;

				//Hide every second message in the window right now...
				var filtered = _messageList.Where(x => x.Type != "Hidden").ToList();
				for (int i = 0; i < filtered.Count(); i++)
				{
					Message thisMessage = filtered[i];

					if (i % 2 == 0) thisMessage.Type = "Hidden";
				}

				RefreshGrid();

				TestButton.IsEnabled = true;
				TestButton2.IsEnabled = true;
			}
		}
	}
}