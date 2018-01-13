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
	public static class RichTextStringConverter
	{
		public static TextBlock ToTextBlock(IRichTextString input)
		{
			TextBlock output = new TextBlock();
			output.Margin = new Thickness(5, 0, 5, 0);
			foreach (IRichTextElement thisElement in input.Elements)
			{
				#region Set String
				Run thisRun = new Run(thisElement.Message);
				#endregion
				#region Set Formatting
				if (thisElement.IsBold) thisRun.FontWeight = FontWeights.Bold;
				if (thisElement.IsItallic) thisRun.FontStyle = FontStyles.Italic;
				if (thisElement.IsUnderlined) thisRun.TextDecorations = TextDecorations.Underline;
				if (thisElement.IsStrikeout) thisRun.TextDecorations = TextDecorations.Strikethrough;
				#endregion
				#region Set Color
				thisRun.Foreground = new SolidColorBrush
				(
					Color.FromArgb(
						thisElement.ForeColor.Alpha,
						thisElement.ForeColor.Red,
						thisElement.ForeColor.Green,
						thisElement.ForeColor.Blue)
				);
				//thisRun.Background = new SolidColorBrush
				//(
				//	Color.FromArgb(
				//		thisElement.BackColor.Alpha,
				//		thisElement.BackColor.Red,
				//		thisElement.BackColor.Green,
				//		thisElement.BackColor.Blue)
				//);
				thisRun.Background = new SolidColorBrush
				(
					Color.FromArgb(0,0,0,0)
				);
				#endregion
				output.Inlines.Add(thisRun);
			}
			return output;
		}
		public static Border ToFormattedTextBlock(this TextBlock textBlock, IColor BackColor)
		{
			Border border = new Border();
			border.Background = new SolidColorBrush
				(
					Color.FromArgb(
						BackColor.Alpha,
						BackColor.Red,
						BackColor.Green,
						BackColor.Blue)
				);
			border.Child = textBlock;
			return border;
		}
	}

	public class RichTextMessageTextBlockContainer
	{
		public RichTextMessageTextBlockContainer(IRichTextMessage input)
		{
			#region Color BG
			byte BGAlpha = (byte)(0.25f * 255);
			IColor BGColor = ObjectFactory.CreateColor(BGAlpha, 16, 16, 16);
			switch (input.Type)
			{
				case MessageType.Unknown:
				default:
					BGColor = ObjectFactory.CreateColor(BGAlpha, 100, 0, 100);
					break;
				case MessageType.User:
					BGColor = ObjectFactory.CreateColor(BGAlpha, 16, 16, 16);
					break;
				case MessageType.ConsoleInformation:
					BGColor = ObjectFactory.CreateColor(BGAlpha, 0, 32, 48);
					break;
				case MessageType.DebugSummary:
					BGColor = ObjectFactory.CreateColor(BGAlpha, 0, 100, 150);
					break;
				case MessageType.DebugDetail:
					BGColor = ObjectFactory.CreateColor(BGAlpha, 0, 50, 100);
					break;
				case MessageType.DebugWarning:
					BGColor = ObjectFactory.CreateColor(BGAlpha, 150, 150, 0);
					break;
				case MessageType.DebugError:
					BGColor = ObjectFactory.CreateColor(BGAlpha, 200, 100, 0);
					break;
				case MessageType.DebugCrash:
					BGColor = ObjectFactory.CreateColor(BGAlpha, 120, 0, 0);
					break;

			}
			#endregion

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

			Datestamp = RichTextStringConverter.ToTextBlock(dateStampString).ToFormattedTextBlock(BGColor);

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

			Timestamp = RichTextStringConverter.ToTextBlock(timeStampString).ToFormattedTextBlock(BGColor);

			#endregion
			#region User

			User = RichTextStringConverter.ToTextBlock(input.User.UserName).ToFormattedTextBlock(BGColor);

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

			Type = RichTextStringConverter.ToTextBlock(typeRichTextString).ToFormattedTextBlock(BGColor);

			#endregion
			#region String
			String = RichTextStringConverter.ToTextBlock(input.String).ToFormattedTextBlock(BGColor);
			#endregion
		}

		public Border Datestamp { get; }
		public Border Timestamp { get; }
		public Border User { get; }
		public Border Type { get; }
		public Border String { get; }
	}
}