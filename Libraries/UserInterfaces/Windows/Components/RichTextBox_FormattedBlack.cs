using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows.Components
{
	public class RichTextBox_FormattedBlack : RichTextBox
	{
		public static Random RandomNumberGenerator = new Random();
		public RichTextBox_FormattedBlack(IRichTextString _input)
		{
			SuspendLayout();

			Visible = true;
			ScrollBars = RichTextBoxScrollBars.None;
			//WordWrap = true;
			Margin = new Padding(0);
			Padding = new Padding(0);

			Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

			BackColor = System.Drawing.Color.FromArgb(255, 16, 16, 16);
			ForeColor = SimpleColors.White.ToSystemDrawingColor();

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


		public void PopulateRTB(IRichTextString _input)
		{
			//SuspendLayout();

			Clear();
			SelectionStart = 0;
			SelectionLength = 0;

			#region Populate RTB
			foreach (IRichTextElement thisElement in _input.Elements)
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
				if (thisElement.IsItallic) FontStyle |= FontStyle.Italic;
				if (thisElement.IsUnderlined) FontStyle |= FontStyle.Underline;
				if (thisElement.IsStrikeout) FontStyle |= FontStyle.Strikeout;

				SelectionFont = new Font("Courier New", 8, FontStyle);

				System.Drawing.Color ForeColor = System.Drawing.Color.FromArgb(
					255,
					(int)thisElement.ForeColor.Red,
					(int)thisElement.ForeColor.Green,
					(int)thisElement.ForeColor.Blue);
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

		public void AppendRichTextElement(IRichTextElement thisElement)
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
			if (thisElement.IsItallic) thisStyle |= FontStyle.Italic;
			if (thisElement.IsUnderlined) thisStyle |= FontStyle.Underline;
			if (thisElement.IsStrikeout) thisStyle |= FontStyle.Strikeout;

			SelectionFont = new Font("Courier New", 8, thisStyle);

			System.Drawing.Color ForeColor = System.Drawing.Color.FromArgb(
				255,
				(int)thisElement.ForeColor.Red,
				(int)thisElement.ForeColor.Green,
				(int)thisElement.ForeColor.Blue);
			System.Drawing.Color BackColor = System.Drawing.Color.FromArgb(
				255,
				(int)thisElement.BackColor.Red,
				(int)thisElement.BackColor.Green,
				(int)thisElement.BackColor.Blue);

			SelectionColor = ForeColor;
			SelectionBackColor = BackColor;

			SelectionStart = 0;
			SelectionLength = 0;
		}
	}
}
