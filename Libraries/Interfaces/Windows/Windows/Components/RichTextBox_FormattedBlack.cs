using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Com.OfficerFlake.Libraries.RichTextMessages;

using FlakeColors = Com.OfficerFlake.Libraries.Color;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows.Components
{
	public class RichTextBox_FormattedBlack : RichTextBox
	{
		public static Random RandomNumberGenerator = new Random();
		public RichTextBox_FormattedBlack(RichTextMessage _input)
		{
			SuspendLayout();

			Visible = true;
			ScrollBars = RichTextBoxScrollBars.None;
			//WordWrap = true;
			Margin = new Padding(0);
			Padding = new Padding(0);

			Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

			BackColor = Color.MinecraftColor.Black.AsSystemDrawingColor();
			ForeColor = Color.MinecraftColor.White.AsSystemDrawingColor();

			BorderStyle = BorderStyle.None;

			Font = new Font("Courier New", 8);

			PopulateRTB(_input);

			ContentsResized += (object sender, ContentsResizedEventArgs e) =>
			{
				var richTextBox = (RichTextBox)sender;
				//richTextBox.Width = e.NewRectangle.Width;
				richTextBox.Height = Margin.Vertical + e.NewRectangle.Height;
				Width += Margin.Horizontal + SystemInformation.HorizontalResizeBorderThickness;
			};

			ResumeLayout();
		}

		public RichTextBox_FormattedBlack()
		{
		}

		public void PopulateRTB(RichTextMessage _input)
		{
			//SuspendLayout();

			Clear();
			SelectionStart = 0;
			SelectionLength = 0;

			#region Populate RTB
			foreach (RichTextMessage.MessageElement thisElement in _input.Elements)
			{
				int _SelectionStart = Text.Length;

				#region Obfuscation
				var text = "";
				if (thisElement.IsObfuscated)
				{
					foreach (char thisChar in thisElement.Message)
					{
						if (thisChar != ' ')
						{
							text += (char)RandomNumberGenerator.Next(33, 172);
						}
						else
						{
							text += ' ';
						}
					}
				}
				else
				{
					text = thisElement.Message;
				}
				#endregion

				AppendText(text);

				SelectionStart = _SelectionStart;
				SelectionLength = text.Length;

				var FontStyle = System.Drawing.FontStyle.Regular;
				if (thisElement.IsBold) FontStyle |= FontStyle.Bold;
				if (thisElement.IsItalic) FontStyle |= FontStyle.Italic;
				if (thisElement.IsUnderlined) FontStyle |= FontStyle.Underline;
				if (thisElement.IsStrikeThrough) FontStyle |= FontStyle.Strikeout;

				SelectionFont = new Font("Courier New", 8, FontStyle);

				SelectionColor = thisElement.Color.AsSystemDrawingColor();

			}
			#endregion

			//ResumeLayout();
		}

		public void AppendRichTextElement(RichTextMessage.MessageElement thisElement)
		{
			SelectionStart = 0;
			SelectionLength = 0;

			string thisText;
			if (thisElement.IsObfuscated) thisText = new string('*', thisElement.Message.Length);
			else thisText = thisElement.Message;

			int start = Text.Length;
			int length = thisText.Length;
			AppendText(thisText);

			SelectionStart = start;
			SelectionLength = length;

			FontStyle thisStyle = FontStyle.Regular;
			if (thisElement.IsBold) thisStyle |= FontStyle.Bold;
			if (thisElement.IsItalic) thisStyle |= FontStyle.Italic;
			if (thisElement.IsUnderlined) thisStyle |= FontStyle.Underline;
			if (thisElement.IsStrikeThrough) thisStyle |= FontStyle.Strikeout;

			SelectionFont = new Font("Courier New", 8, thisStyle);

			SelectionColor = thisElement.Color.AsSystemDrawingColor();
		}
	}
}
