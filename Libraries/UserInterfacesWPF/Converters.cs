using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using Com.OfficerFlake.Libraries;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Converters
{
	public abstract class BaseConverter : MarkupExtension
		{
			public override object ProvideValue(IServiceProvider serviceProvider)
			{
				return this;
			}
		}
	public static class RichTextStringToBorderConverter
	{
		public static Border Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			IRichTextString input = value as IRichTextString;
			IColor color = parameter as IColor;

			#region Create TextBlock
			TextBlock outputTextBlock = new TextBlock
			{
				Padding = new Thickness(5, 0, 5, 0),
				Margin = new Thickness(0, 0, 0, 0),
				TextWrapping = TextWrapping.WrapWithOverflow
			};
			#endregion
			#region Fill TextBlock
			if (input != null)
			{

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
					#region Foreground
					thisRun.Foreground = new SolidColorBrush
					(
						Color.FromArgb(
							thisElement.ForeColor.Alpha,
							thisElement.ForeColor.Red,
							thisElement.ForeColor.Green,
							thisElement.ForeColor.Blue)
					);
					#endregion
					#region Background
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
						Color.FromArgb(0, 0, 0, 0)
					);
					#endregion
					#endregion
					outputTextBlock.Inlines.Add(thisRun);
				}
			}
			#endregion
			#region Create Border
			if (color == null) color = ObjectFactory.CreateColor(0, 32, 0, 32);
			Border outputBorder = new Border
			{
				Background = new SolidColorBrush(
					Color.FromArgb(
						color.Alpha,
						color.Red,
						color.Green,
						color.Blue
					)
				),
				Child = outputTextBlock
			};
			#endregion

			return outputBorder;
		}
		public static object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
