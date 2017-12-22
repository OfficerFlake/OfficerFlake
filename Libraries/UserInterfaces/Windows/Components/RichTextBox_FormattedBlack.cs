using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Com.OfficerFlake.Libraries.Color;
using Com.OfficerFlake.Libraries.RichText;
using static Com.OfficerFlake.Libraries.RichText.RichTextString;

using FlakeColors = Com.OfficerFlake.Libraries.Color;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows.Components
{
	public class RichTextBox_FormattedBlack : RichTextBox
	{
		public static Random RandomNumberGenerator = new Random();
		public RichTextBox_FormattedBlack(RichTextString _input)
		{
			SuspendLayout();

			Visible = true;
			ScrollBars = RichTextBoxScrollBars.None;
			//WordWrap = true;
			Margin = new Padding(0);
			Padding = new Padding(0);

			Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

			BackColor = Color.SimpleColors.Black.ToSystemDrawingColor();
			ForeColor = Color.SimpleColors.White.ToSystemDrawingColor();

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

			Enter += (object sender, EventArgs e) =>
			{
				var richTextBox = (RichTextBox)sender;
				HideCaret(richTextBox.Handle);
			};

			ResumeLayout();
		}

		public RichTextBox_FormattedBlack()
		{
		}

		[DllImport("user32.dll")]
		private static extern bool HideCaret(IntPtr hWnd);


		public void PopulateRTB(RichTextString _input)
		{
			//SuspendLayout();

			Clear();
			SelectionStart = 0;
			SelectionLength = 0;

			#region Populate RTB
			foreach (RichTextString.MessageElement thisElement in _input.Elements)
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

				System.Drawing.Color ForeColor = System.Drawing.Color.FromArgb(
					255,
					(int)thisElement.Color.Color.Red,
					(int)thisElement.Color.Color.Green,
					(int)thisElement.Color.Color.Blue);
				System.Drawing.Color BackColor = System.Drawing.Color.FromArgb(
					255,
					16,
					16,
					16);

				SelectionColor = ForeColor;
				SelectionBackColor = BackColor;

			}
			#endregion

			HideCaret(Handle);
			//ResumeLayout();
		}

		public void AppendRichTextElement(RichTextString.MessageElement thisElement)
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

			System.Drawing.Color ForeColor = System.Drawing.Color.FromArgb(
				255,
				(int)thisElement.Color.Color.Red,
				(int)thisElement.Color.Color.Green,
				(int)thisElement.Color.Color.Blue);
			System.Drawing.Color BackColor = System.Drawing.Color.FromArgb(
				255,
				16,
				16,
				16);

			SelectionColor = ForeColor;
			SelectionBackColor = BackColor;

			SelectionStart = 0;
			SelectionLength = 0;
		}
	}
}
