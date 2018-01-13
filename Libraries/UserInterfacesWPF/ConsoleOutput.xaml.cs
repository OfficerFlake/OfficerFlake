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
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.UserInterfacesWPF
{
	/// <summary>
	/// Interaction logic for ConsoleOutput.xaml
	/// </summary>
	public partial class ConsoleOutput : IConsole, INotifyPropertyChanged
	{
		public static DataTable ConsoleOutputDataTable = new DataTable()
		{
			Columns = { new DataColumn("Date") }
		};

		public static class RichTextStringConverter
		{
			public static TextBlock Convert(IRichTextString input)
			{
				TextBlock output = new TextBlock();
				output.Margin = new Thickness(5,0,5,0);
				foreach (IRichTextElement thisElement in input.Elements)
				{
					Run thisRun = new Run(thisElement.Message);
					if (thisElement.IsBold) thisRun.FontWeight = FontWeights.Bold;
					if (thisElement.IsItallic) thisRun.FontStyle = FontStyles.Italic;
					if (thisElement.IsUnderlined) thisRun.TextDecorations = TextDecorations.Underline;
					if (thisElement.IsStrikeout) thisRun.TextDecorations = TextDecorations.Strikethrough;

					thisRun.Foreground = new SolidColorBrush
					(
						Color.FromArgb(
							thisElement.ForeColor.Alpha,
							thisElement.ForeColor.Red,
							thisElement.ForeColor.Green,
							thisElement.ForeColor.Blue)
					);
					thisRun.Background = new SolidColorBrush
					(
						Color.FromArgb(
							thisElement.BackColor.Alpha,
							thisElement.BackColor.Red,
							thisElement.BackColor.Green,
							thisElement.BackColor.Blue)
					);
					output.Inlines.Add(thisRun);
				}
				return output;
			}
		}
		public class RichTextMessageContainer
		{
			public RichTextMessageContainer(IRichTextMessage input)
			{
				#region Datestamp
				IFormattingDescriptor dateFormattingDescriptor = ObjectFactory.CreateFormattingDescriptor
				(
					foreColor: SimpleColors.DarkGray.Color,
					backColor: ObjectFactory.CreateColor(16, 16, 16),
					isBold: false,
					isItallic: true,
					isUnderlined: false,
					isStrikeout: false,
					isObfuscated: false
				);
				IRichTextString dateStampString = ObjectFactory.CreateRichTextString(dateFormattingDescriptor);
				dateStampString.AddFormattedString(input.Datestamp.ToSystemString());

				Datestamp = RichTextStringConverter.Convert(dateStampString);
				#endregion
				#region Timestamp
				IFormattingDescriptor timeFormattingDescriptor = ObjectFactory.CreateFormattingDescriptor
				(
					foreColor: SimpleColors.Gray.Color,
					backColor: ObjectFactory.CreateColor(16, 16, 16),
					isBold: false,
					isItallic: true,
					isUnderlined: false,
					isStrikeout: false,
					isObfuscated: false
				);
				IRichTextString timeStampString = ObjectFactory.CreateRichTextString(timeFormattingDescriptor);
				timeStampString.AddFormattedString(input.Timestamp.ToSystemString());

				Timestamp = RichTextStringConverter.Convert(timeStampString);
				#endregion
				#region User
				User = RichTextStringConverter.Convert(input.User.UserName);
				#endregion
				#region Type
				IFormattingDescriptor typeFormattingDescriptor;
				typeFormattingDescriptor = ObjectFactory.CreateFormattingDescriptor
				(
					foreColor: SimpleColors.DarkGray.Color,
					backColor: ObjectFactory.CreateColor(16, 16, 16),
					isBold: false,
					isItallic: true,
					isUnderlined: false,
					isStrikeout: false,
					isObfuscated: false
				);
				switch (input.Type)
				{
					case MessageType.Unknown:
					default:
						{
							typeFormattingDescriptor.ForeColor = SimpleColors.White.Color;
							typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(16, 16, 16);
							typeFormattingDescriptor.IsBold = false;
							typeFormattingDescriptor.IsItallic = true;
							typeFormattingDescriptor.IsUnderlined = false;
							typeFormattingDescriptor.IsStrikeout = false;
							typeFormattingDescriptor.IsObfuscated = false;
							break;
						}
					case MessageType.User:
						{
							typeFormattingDescriptor.ForeColor = SimpleColors.White.Color;
							typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(16, 16, 16);
							typeFormattingDescriptor.IsBold = false;
							typeFormattingDescriptor.IsItallic = false;
							typeFormattingDescriptor.IsUnderlined = false;
							typeFormattingDescriptor.IsStrikeout = false;
							typeFormattingDescriptor.IsObfuscated = false;
							break;
						}
					case MessageType.ConsoleInformation:
						{
							typeFormattingDescriptor.ForeColor = SimpleColors.DarkTeal.Color;
							typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(16, 16, 16);
							typeFormattingDescriptor.IsBold = false;
							typeFormattingDescriptor.IsItallic = true;
							typeFormattingDescriptor.IsUnderlined = false;
							typeFormattingDescriptor.IsStrikeout = false;
							typeFormattingDescriptor.IsObfuscated = false;
							break;
						}
					case MessageType.DebugSummary:
						{
							typeFormattingDescriptor.ForeColor = SimpleColors.Blue.Color;
							typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(16, 16, 16);
							typeFormattingDescriptor.IsBold = false;
							typeFormattingDescriptor.IsItallic = true;
							typeFormattingDescriptor.IsUnderlined = false;
							typeFormattingDescriptor.IsStrikeout = false;
							typeFormattingDescriptor.IsObfuscated = false;
							break;
						}
					case MessageType.DebugDetail:
						{
							typeFormattingDescriptor.ForeColor = SimpleColors.DarkBlue.Color;
							typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(16, 16, 16);
							typeFormattingDescriptor.IsBold = false;
							typeFormattingDescriptor.IsItallic = true;
							typeFormattingDescriptor.IsUnderlined = false;
							typeFormattingDescriptor.IsStrikeout = false;
							typeFormattingDescriptor.IsObfuscated = false;
							break;
						}
					case MessageType.DebugWarning:
						{
							typeFormattingDescriptor.ForeColor = SimpleColors.Yellow.Color;
							typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(16, 16, 16);
							typeFormattingDescriptor.IsBold = false;
							typeFormattingDescriptor.IsItallic = false;
							typeFormattingDescriptor.IsUnderlined = false;
							typeFormattingDescriptor.IsStrikeout = false;
							typeFormattingDescriptor.IsObfuscated = false;
							break;
						}
					case MessageType.DebugError:
						{
							typeFormattingDescriptor.ForeColor = SimpleColors.Gray.Color;
							typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(240, 200, 16);
							typeFormattingDescriptor.IsBold = true;
							typeFormattingDescriptor.IsItallic = false;
							typeFormattingDescriptor.IsUnderlined = false;
							typeFormattingDescriptor.IsStrikeout = false;
							typeFormattingDescriptor.IsObfuscated = false;
							break;
						}
					case MessageType.DebugCrash:
						{
							typeFormattingDescriptor.ForeColor = SimpleColors.White.Color;
							typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(240, 16, 16);
							typeFormattingDescriptor.IsBold = true;
							typeFormattingDescriptor.IsItallic = false;
							typeFormattingDescriptor.IsUnderlined = false;
							typeFormattingDescriptor.IsStrikeout = false;
							typeFormattingDescriptor.IsObfuscated = false;
							break;
						}

				}


				IRichTextString typeRichTextString = ObjectFactory.CreateRichTextString(typeFormattingDescriptor);
				string typeString = "???";
				switch (input.Type)
				{
					case MessageType.Unknown:
					default:
						typeString = "???";
						break;
					case MessageType.User:
						typeString = "User";
						break;
					case MessageType.ConsoleInformation:
						typeString = "Console Information";
						break;
					case MessageType.DebugSummary:
						typeString = "Debug Summary";
						break;
					case MessageType.DebugDetail:
						typeString = "Debug Detail";
						break;
					case MessageType.DebugWarning:
						typeString = "Debug Warning";
						break;
					case MessageType.DebugError:
						typeString = "Debug Error";
						break;
					case MessageType.DebugCrash:
						typeString = "Debug Crash";
						break;

				}

				typeRichTextString.AddFormattedString(typeString);

				Type = RichTextStringConverter.Convert(typeRichTextString);
				#endregion
				#region String
				String = RichTextStringConverter.Convert(input.String);
				#endregion
			}

			public TextBlock Datestamp { get; set; }
			public TextBlock Timestamp { get; set; }
			public TextBlock User { get; set; }
			public TextBlock Type { get; set; }
			public TextBlock String { get; set; }
		}

		private ObservableCollection<RichTextMessageContainer> _messages = new ObservableCollection<RichTextMessageContainer>();
	    public ObservableCollection<RichTextMessageContainer> Messages
		{
		    get => _messages;
		    set
		    {
			    _messages = value;
			    OnPropertyChanged();
		    }
	    }

		public ConsoleOutput()
		{
			InitializeComponent();

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
			this.DataContext = this;
        }
		public void AddInformationMessage(string message)
		{
			Dispatcher.Invoke(() =>
			{
				RichTextMessageContainer newMessage = new RichTextMessageContainer
				(
					ObjectFactory.CreateConsoleInformationMessage(message.AsRichTextString())
				);
				Messages.Add(newMessage);

				RowDefinition newRow = new RowDefinition();
				newRow.Height = new GridLength(18);

				int newRowPosition = ConsoleOutputViewModel.RowDefinitions.Count;
				ConsoleOutputViewModel.RowDefinitions.Add(newRow);

				ConsoleOutputViewModel.Children.Add(newMessage.Datestamp);
				ConsoleOutputViewModel.Children.Add(newMessage.Timestamp);
				ConsoleOutputViewModel.Children.Add(newMessage.Type);
				ConsoleOutputViewModel.Children.Add(newMessage.User);
				ConsoleOutputViewModel.Children.Add(newMessage.String);

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
			});
		}
		public void AddUserMessage(IUser user, string message)
		{
			Dispatcher.Invoke(() =>
				Messages.Add
				(
					new RichTextMessageContainer
					(
						ObjectFactory.CreateConsoleUserMessage(user, message.AsRichTextString())
					)
				));
		}

	    private void ConsoleOutput_OnLoaded(object sender, RoutedEventArgs e)
	    {
		    Messages.Add(new RichTextMessageContainer(ObjectFactory.CreateRichTextMessage("TEST".AsRichTextString())));
	    }

	    public event PropertyChangedEventHandler PropertyChanged;
	    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }
    }

	public class BindableTextBlock : TextBlock
	{
		/// <summary>
		/// A Dependancy List of Inline objects that can be bound to.
		/// </summary>
		public ObservableCollection<Inline> InlineList
		{
			get { return (ObservableCollection<Inline>)GetValue(InlineListProperty); }
			set { SetValue(InlineListProperty, value); }
		}

		public static readonly DependencyProperty InlineListProperty =
			DependencyProperty.Register("InlineList", typeof(ObservableCollection<Inline>), typeof(BindableTextBlock), new UIPropertyMetadata(null, OnPropertyChanged));

		private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			BindableTextBlock textBlock = (BindableTextBlock)sender;
			textBlock.Inlines.AddRange((ObservableCollection<Inline>)e.NewValue);
		}
	}
}
