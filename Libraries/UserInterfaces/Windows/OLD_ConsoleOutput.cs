using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
	/// <summary>
	/// A RichTextBox built to accept RichTextMessages through the AddMessage method.
	/// </summary>
	/// 
	/// Sealed and completed. Please do not add any new public methods without reviewing the architecture first!
	public sealed partial class _ConsoleOutput : UserControl
    {
		#region Constructor
		internal _ConsoleOutput()
	    {
		    InitializeComponent();
		    if (DesignMode) return;
		    new Thread(() => RichTextBoxUpdaterThread()).Start();
		}
		#endregion

		#region Variables
		//private bool performRichTextBoxUpdates = true;
	    internal ManualResetEvent FormClosing = new ManualResetEvent(false);
	    internal bool IsFormClosing => FormClosing.WaitOne(0);

	    private const int DateSize = 8;
	    private const int TimeSize = 6;
	    private const int UsernameSize = 16;

	    private int MessageSize =>
		    91 -
		    (checkBox_ShowDate.Checked ? DateSize+1 : 0) -
		    (checkBox_ShowTime.Checked ? TimeSize+1 : 0) -
		    (checkBox_ShowUsername.Checked ? UsernameSize+1 : 0);
	    private int OverflowSize =>
		    91 -
		    (checkBox_ShowDate.Checked ? DateSize + 1 : 0) -
		    (checkBox_ShowTime.Checked ? TimeSize + 1 : 0) -
		    (checkBox_ShowUsername.Checked ? UsernameSize + 1 : 0) -
		    (checkBox_ShowMessage.Checked ? MessageSize : 0);
		#endregion
		#region Control Events
		private void CheckBox_ShowDate_CheckedChanged(object sender, EventArgs e)
	    {
		    RepopulateRichTextBoxFromList();
	    }
	    private void CheckBox_ShowTime_CheckedChanged(object sender, EventArgs e)
	    {
		    RepopulateRichTextBoxFromList();
	    }
	    private void CheckBox_ShowUsername_CheckedChanged(object sender, EventArgs e)
	    {
		    RepopulateRichTextBoxFromList();
	    }
	    private void CheckBox_ShowMessage_CheckedChanged(object sender, EventArgs e)
	    {
		    RepopulateRichTextBoxFromList();
	    }

	    private void richTextBox_ConsoleOutput_MouseUp(object sender, MouseEventArgs e)
	    {
		    if (e.Button == MouseButtons.Right)
		    {
			    richTextBox_ConsoleOutput_MouseRightClick(sender, e);
		    }
	    }
	    private void richTextBox_ConsoleOutput_MouseRightClick(object sender, MouseEventArgs e)
	    {
		    var currentTextIndex = richTextBox_ConsoleOutput.GetCharIndexFromPosition(e.Location);
		    var wordRegex = new Regex(@"(\w+)");
		    var words = wordRegex.Matches(richTextBox_ConsoleOutput.Text);
		    if (words.Count < 1) return;

		    var currentWord = string.Empty;
		    for (var i = words.Count - 1; i >= 0; i--)
		    {
			    if (words[i].Index <= currentTextIndex)
			    {
				    currentWord = words[i].Value;
				    break;
			    }
		    }
		    if (currentWord == string.Empty) return;
		    MessageBox.Show(
			    "Mouse Row: " + GetMouseRow(currentTextIndex) + "\n\n" +
			    "Console Index: " + GetMessageIndexFromPosition(GetMouseRow(currentTextIndex)) + "\n\n" +
			    "Message: " + GetMessageFromPosition(GetMouseRow(currentTextIndex)).String.ToUnformattedSystemString());
	    }
		#endregion

		#region RichTextMessages List
		private class RichTextMessageDictionaryItem
	    {
		    private static _ConsoleOutput Parent;
		    public int StartIndex;
			public IRichTextMessage Message;

		    public RichTextMessageDictionaryItem(_ConsoleOutput _Parent, IRichTextMessage _Message)
		    {
			    Parent = _Parent;
				StartIndex = Parent.richTextBox_ConsoleOutput.Lines.Length;
			    Message = _Message;
		    }
	    }

		private List<RichTextMessageDictionaryItem> richTextMessages = new List<RichTextMessageDictionaryItem>();
	    private int maximumMessages = 1000; //Stress tested okay to ~25,000 objects.
	    private int richTextMessagesCount => richTextMessages.Count + incomingRichTextMessages.Count;

		private ConcurrentQueue<IRichTextMessage> incomingRichTextMessages = new ConcurrentQueue<IRichTextMessage>();
		private ManualResetEvent notifyIncomingRichTextMessages = new ManualResetEvent(false);

		/// <summary>
		/// Thread safe method of adding a RichTextMessage to the Output Console.
		/// </summary>
		/// <param name="thisRichTextMessage"></param>
	    public void AddMessage(IRichTextMessage thisRichTextMessage)
	    {
		    incomingRichTextMessages.Enqueue(thisRichTextMessage);
		    notifyIncomingRichTextMessages.Set();
	    }

	    private int GetIndentSize()
	    {
		    int output = -1; //Factor the newline seperator...
		    if (checkBox_ShowDate.Checked) output += (DateSize+1);
		    if (checkBox_ShowTime.Checked) output += (TimeSize+1);
		    if (checkBox_ShowUsername.Checked) output += (UsernameSize+1);
		    return output;
	    }
	    private int GetFullLineSize()
	    {
		    return GetIndentSize() + MessageSize + 2;
	    }

		/// <summary>
		/// Gets the first message from the messages list, closest to this index, but always below this index. Can return null.
		/// </summary>
		/// <param name="Row">Minimum row number.</param>
		/// <returns>The message object if found, otherwise null.</returns>
	    private IRichTextMessage GetMessageFromPosition(int Row)
	    {
		    IRichTextMessage output = null;
		    try
		    {
			    var output0 = richTextMessages.ToArray();
				var output1 = output0.Where(x => x.StartIndex <= Row).ToArray();
			    var output2 = output1.OrderByDescending(y => y.StartIndex).ToArray();
				var output3 = output2.First();
				var output4 = output3.Message;
			    output = output4;
			    return output;
		    }
		    catch
		    {
			    //not found.
		    }
		    return output;
	    }
	    private int GetMessageIndexFromPosition(int Row)
	    {
			int output = -1;
		    try
		    {
			    var output0 = richTextMessages.ToArray();
			    var output1 = output0.Where(x => x.StartIndex <= Row).ToArray();
			    var output2 = output1.OrderByDescending(y => y.StartIndex).ToArray();
			    var output3 = output2.First();
			    var output4 = output3.StartIndex;
			    output = output4;
			    return output;
		    }
		    catch
		    {
			    //not found.
		    }
		    return output;
		}

	    private int GetMouseRow(int charIndex)
	    {
		    return charIndex / GetFullLineSize();
	    }
	    private int GetMouseColumn(int charIndex)
	    {
		    return charIndex % GetFullLineSize();
	    }
		#endregion
		#region RichTextBox Updating
		private void RepopulateRichTextBoxFromList()
	    {


			//The lag is real. Need to clear >100 messages old...
		    if (richTextMessages.Count > 100)
		    {
			    richTextMessages.RemoveRange(0, richTextMessages.Count-100);
		    }

		    //redraw the entire textbox.
			richTextBox_ConsoleOutput.Clear();
		    foreach (RichTextMessageDictionaryItem thisRichTextMessageDictionaryItem in richTextMessages)
		    {
			    AppendRichTextMessageDirect(thisRichTextMessageDictionaryItem.Message);
		    }
	    }

		private void AppendRichTextMessageDirect(IRichTextMessage thisRichTextMessage)
		{
			#region Skip Unselected Messages
			switch (thisRichTextMessage.Type)
			{
				default:
					goto case MessageType.Unknown;
				case MessageType.Unknown:
					break;
				case MessageType.User:
					return;
				case MessageType.ConsoleInformation:
					return;
				case MessageType.DebugSummary:
					break;
				case MessageType.DebugDetail:
					break;
				case MessageType.DebugWarning:
					break;
				case MessageType.DebugError:
					break;
				case MessageType.DebugCrash:
					break;
			}

			#endregion

			#region PreFormatting

			#region date

			IFormattingDescriptor dateFormattingDescriptor = ObjectFactory.CreateFormattingDescriptor(
				backColor: ObjectFactory.CreateColor(16, 16, 16),
				foreColor: ObjectFactory.CreateColor(240, 240, 240),
				isBold: false,
				isItallic: false,
				isUnderlined: false,
				isStrikeout: false,
				isObfuscated: false);
			switch (thisRichTextMessage.Type)
			{
				case MessageType.Unknown:
					return;
				case MessageType.User:
					dateFormattingDescriptor.BackColor = ObjectFactory.CreateColor(16, 16, 16);
					dateFormattingDescriptor.ForeColor = SimpleColors.Gray.Color;
					dateFormattingDescriptor.IsBold = false;
					dateFormattingDescriptor.IsItallic = false;
					dateFormattingDescriptor.IsUnderlined = false;
					dateFormattingDescriptor.IsStrikeout = false;
					dateFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.ConsoleInformation:
					dateFormattingDescriptor.BackColor = ObjectFactory.CreateColor(10, 20, 25);
					dateFormattingDescriptor.ForeColor = SimpleColors.Gray.Color;
					dateFormattingDescriptor.IsBold = false;
					dateFormattingDescriptor.IsItallic = false;
					dateFormattingDescriptor.IsUnderlined = false;
					dateFormattingDescriptor.IsStrikeout = false;
					dateFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugSummary:
					dateFormattingDescriptor.BackColor = ObjectFactory.CreateColor(10, 20, 25);
					dateFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(85, 200, 240);
					dateFormattingDescriptor.IsBold = false;
					dateFormattingDescriptor.IsItallic = false;
					dateFormattingDescriptor.IsUnderlined = false;
					dateFormattingDescriptor.IsStrikeout = false;
					dateFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugDetail:
					dateFormattingDescriptor.BackColor = ObjectFactory.CreateColor(10, 10, 25);
					dateFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(50, 50, 200);
					dateFormattingDescriptor.IsBold = false;
					dateFormattingDescriptor.IsItallic = false;
					dateFormattingDescriptor.IsUnderlined = false;
					dateFormattingDescriptor.IsStrikeout = false;
					dateFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugWarning:
					dateFormattingDescriptor.BackColor = ObjectFactory.CreateColor(25, 20, 10);
					dateFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(240, 200, 85);
					dateFormattingDescriptor.IsBold = false;
					dateFormattingDescriptor.IsItallic = false;
					dateFormattingDescriptor.IsUnderlined = false;
					dateFormattingDescriptor.IsStrikeout = false;
					dateFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugError:
					dateFormattingDescriptor.BackColor = ObjectFactory.CreateColor(50, 25, 10);
					dateFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(200, 200, 200);
					dateFormattingDescriptor.IsBold = true;
					dateFormattingDescriptor.IsItallic = false;
					dateFormattingDescriptor.IsUnderlined = false;
					dateFormattingDescriptor.IsStrikeout = false;
					dateFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugCrash:
					dateFormattingDescriptor.BackColor = ObjectFactory.CreateColor(50, 10, 10);
					dateFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(255, 255, 255);
					dateFormattingDescriptor.IsBold = true;
					dateFormattingDescriptor.IsItallic = false;
					dateFormattingDescriptor.IsUnderlined = false;
					dateFormattingDescriptor.IsStrikeout = false;
					dateFormattingDescriptor.IsObfuscated = false;
					break;
			}

			#endregion

			#region time

			IFormattingDescriptor timeFormattingDescriptor = ObjectFactory.CreateFormattingDescriptor(
				backColor: ObjectFactory.CreateColor(16, 16, 16),
				foreColor: ObjectFactory.CreateColor(240, 240, 240),
				isBold: false,
				isItallic: false,
				isUnderlined: false,
				isStrikeout: false,
				isObfuscated: false);
			switch (thisRichTextMessage.Type)
			{
				case MessageType.Unknown:
					return;
				case MessageType.User:
					timeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(16, 16, 16);
					timeFormattingDescriptor.ForeColor = SimpleColors.DarkGray.Color;
					timeFormattingDescriptor.IsBold = false;
					timeFormattingDescriptor.IsItallic = false;
					timeFormattingDescriptor.IsUnderlined = false;
					timeFormattingDescriptor.IsStrikeout = false;
					timeFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.ConsoleInformation:
					timeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(10, 20, 25);
					timeFormattingDescriptor.ForeColor = SimpleColors.DarkGray.Color;
					timeFormattingDescriptor.IsBold = false;
					timeFormattingDescriptor.IsItallic = false;
					timeFormattingDescriptor.IsUnderlined = false;
					timeFormattingDescriptor.IsStrikeout = false;
					timeFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugSummary:
					timeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(10, 20, 25);
					timeFormattingDescriptor.ForeColor = SimpleColors.DarkGray.Color;
					timeFormattingDescriptor.IsBold = false;
					timeFormattingDescriptor.IsItallic = false;
					timeFormattingDescriptor.IsUnderlined = false;
					timeFormattingDescriptor.IsStrikeout = false;
					timeFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugDetail:
					timeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(10, 10, 25);
					timeFormattingDescriptor.ForeColor = SimpleColors.DarkGray.Color;
					timeFormattingDescriptor.IsBold = false;
					timeFormattingDescriptor.IsItallic = false;
					timeFormattingDescriptor.IsUnderlined = false;
					timeFormattingDescriptor.IsStrikeout = false;
					timeFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugWarning:
					timeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(25, 20, 10);
					timeFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(240, 200, 85);
					timeFormattingDescriptor.IsBold = false;
					timeFormattingDescriptor.IsItallic = false;
					timeFormattingDescriptor.IsUnderlined = false;
					timeFormattingDescriptor.IsStrikeout = false;
					timeFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugError:
					timeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(50, 25, 10);
					timeFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(200, 200, 200);
					timeFormattingDescriptor.IsBold = true;
					timeFormattingDescriptor.IsItallic = false;
					timeFormattingDescriptor.IsUnderlined = false;
					timeFormattingDescriptor.IsStrikeout = false;
					timeFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugCrash:
					timeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(50, 10, 10);
					timeFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(255, 255, 255);
					timeFormattingDescriptor.IsBold = true;
					timeFormattingDescriptor.IsItallic = false;
					timeFormattingDescriptor.IsUnderlined = false;
					timeFormattingDescriptor.IsStrikeout = false;
					timeFormattingDescriptor.IsObfuscated = false;
					break;
			}

			#endregion

			#region type

			IFormattingDescriptor typeFormattingDescriptor = ObjectFactory.CreateFormattingDescriptor(
				backColor: ObjectFactory.CreateColor(16, 16, 16),
				foreColor: ObjectFactory.CreateColor(240, 240, 240),
				isBold: false,
				isItallic: false,
				isUnderlined: false,
				isStrikeout: false,
				isObfuscated: false);
			switch (thisRichTextMessage.Type)
			{
				case MessageType.Unknown:
					return;
				case MessageType.User:
					typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(16, 16, 16);
					typeFormattingDescriptor.ForeColor = SimpleColors.White.Color;
					typeFormattingDescriptor.IsBold = false;
					typeFormattingDescriptor.IsItallic = false;
					typeFormattingDescriptor.IsUnderlined = false;
					typeFormattingDescriptor.IsStrikeout = false;
					typeFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.ConsoleInformation:
					typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(10, 20, 25);
					typeFormattingDescriptor.ForeColor = SimpleColors.Teal.Color;
					typeFormattingDescriptor.IsBold = false;
					typeFormattingDescriptor.IsItallic = true;
					typeFormattingDescriptor.IsUnderlined = false;
					typeFormattingDescriptor.IsStrikeout = false;
					typeFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugSummary:
					typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(10, 20, 25);
					typeFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(85, 200, 240);
					typeFormattingDescriptor.IsBold = false;
					typeFormattingDescriptor.IsItallic = false;
					typeFormattingDescriptor.IsUnderlined = false;
					typeFormattingDescriptor.IsStrikeout = false;
					typeFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugDetail:
					typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(10, 10, 25);
					typeFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(50, 50, 200);
					typeFormattingDescriptor.IsBold = false;
					typeFormattingDescriptor.IsItallic = false;
					typeFormattingDescriptor.IsUnderlined = false;
					typeFormattingDescriptor.IsStrikeout = false;
					typeFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugWarning:
					typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(25, 20, 10);
					typeFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(240, 200, 85);
					typeFormattingDescriptor.IsBold = false;
					typeFormattingDescriptor.IsItallic = false;
					typeFormattingDescriptor.IsUnderlined = false;
					typeFormattingDescriptor.IsStrikeout = false;
					typeFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugError:
					typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(50, 25, 10);
					typeFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(200, 200, 200);
					typeFormattingDescriptor.IsBold = true;
					typeFormattingDescriptor.IsItallic = false;
					typeFormattingDescriptor.IsUnderlined = false;
					typeFormattingDescriptor.IsStrikeout = false;
					typeFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugCrash:
					typeFormattingDescriptor.BackColor = ObjectFactory.CreateColor(50, 10, 10);
					typeFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(255, 255, 255);
					typeFormattingDescriptor.IsBold = true;
					typeFormattingDescriptor.IsItallic = false;
					typeFormattingDescriptor.IsUnderlined = false;
					typeFormattingDescriptor.IsStrikeout = false;
					typeFormattingDescriptor.IsObfuscated = false;
					break;
			}

			#endregion

			#region message

			IFormattingDescriptor messageFormattingDescriptor = ObjectFactory.CreateFormattingDescriptor(
				backColor: ObjectFactory.CreateColor(16, 16, 16),
				foreColor: ObjectFactory.CreateColor(240, 240, 240),
				isBold: false,
				isItallic: false,
				isUnderlined: false,
				isStrikeout: false,
				isObfuscated: false);
			switch (thisRichTextMessage.Type)
			{
				case MessageType.Unknown:
					return;
				case MessageType.User:
					messageFormattingDescriptor.BackColor = ObjectFactory.CreateColor(16, 16, 16);
					messageFormattingDescriptor.ForeColor = SimpleColors.White.Color;
					messageFormattingDescriptor.IsBold = false;
					messageFormattingDescriptor.IsItallic = false;
					messageFormattingDescriptor.IsUnderlined = false;
					messageFormattingDescriptor.IsStrikeout = false;
					messageFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.ConsoleInformation:
					messageFormattingDescriptor.BackColor = ObjectFactory.CreateColor(10, 20, 25);
					messageFormattingDescriptor.ForeColor = SimpleColors.Teal.Color;
					messageFormattingDescriptor.IsBold = false;
					messageFormattingDescriptor.IsItallic = true;
					messageFormattingDescriptor.IsUnderlined = false;
					messageFormattingDescriptor.IsStrikeout = false;
					messageFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugSummary:
					messageFormattingDescriptor.BackColor = ObjectFactory.CreateColor(10, 20, 25);
					messageFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(85, 200, 240);
					messageFormattingDescriptor.IsBold = false;
					messageFormattingDescriptor.IsItallic = false;
					messageFormattingDescriptor.IsUnderlined = false;
					messageFormattingDescriptor.IsStrikeout = false;
					messageFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugDetail:
					messageFormattingDescriptor.BackColor = ObjectFactory.CreateColor(10, 10, 25);
					messageFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(50, 50, 200);
					messageFormattingDescriptor.IsBold = false;
					messageFormattingDescriptor.IsItallic = false;
					messageFormattingDescriptor.IsUnderlined = false;
					messageFormattingDescriptor.IsStrikeout = false;
					messageFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugWarning:
					messageFormattingDescriptor.BackColor = ObjectFactory.CreateColor(25, 20, 10);
					messageFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(240, 200, 85);
					messageFormattingDescriptor.IsBold = false;
					messageFormattingDescriptor.IsItallic = false;
					messageFormattingDescriptor.IsUnderlined = false;
					messageFormattingDescriptor.IsStrikeout = false;
					messageFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugError:
					messageFormattingDescriptor.BackColor = ObjectFactory.CreateColor(50, 25, 10);
					messageFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(200, 200, 200);
					messageFormattingDescriptor.IsBold = true;
					messageFormattingDescriptor.IsItallic = false;
					messageFormattingDescriptor.IsUnderlined = false;
					messageFormattingDescriptor.IsStrikeout = false;
					messageFormattingDescriptor.IsObfuscated = false;
					break;
				case MessageType.DebugCrash:
					messageFormattingDescriptor.BackColor = ObjectFactory.CreateColor(50, 10, 10);
					messageFormattingDescriptor.ForeColor = ObjectFactory.CreateColor(255, 255, 255);
					messageFormattingDescriptor.IsBold = true;
					messageFormattingDescriptor.IsItallic = false;
					messageFormattingDescriptor.IsUnderlined = false;
					messageFormattingDescriptor.IsStrikeout = false;
					messageFormattingDescriptor.IsObfuscated = false;
					break;
			}

			#endregion

			#endregion
			#region Build String Components

			#region Date

			IRichTextString date = ObjectFactory.CreateRichTextString(dateFormattingDescriptor);
			date.AddFormattedString(thisRichTextMessage.Datestamp.ToSystemString());

			#endregion

			#region Time

			IRichTextString time = ObjectFactory.CreateRichTextString(timeFormattingDescriptor);
			time.AddFormattedString(thisRichTextMessage.Timestamp.ToSystemString());

			#endregion

			#region Type

			IRichTextString type = ObjectFactory.CreateRichTextString(typeFormattingDescriptor);
			switch (thisRichTextMessage.Type)
			{
				default:
				case MessageType.Unknown:
					type.AddFormattedString("Unknown".ResizeOnRight(16, ' '));
					break;
				case MessageType.User:
					type.AddFormattedString("User".ResizeOnRight(16, ' '));
					break;
				case MessageType.ConsoleInformation:
					type.AddFormattedString("Information".ResizeOnRight(16, ' '));
					break;
				case MessageType.DebugSummary:
					type.AddFormattedString("Summary".ResizeOnRight(16, ' '));
					break;
				case MessageType.DebugDetail:
					type.AddFormattedString("Detail".ResizeOnRight(16, ' '));
					break;
				case MessageType.DebugWarning:
					type.AddFormattedString("Warning".ResizeOnRight(16, ' '));
					break;
				case MessageType.DebugError:
					type.AddFormattedString("Error".ResizeOnRight(16, ' '));
					break;
				case MessageType.DebugCrash:
					type.AddFormattedString("Crash".ResizeOnRight(16, ' '));
					break;
			}

			#endregion

			#region Message

			IRichTextString message = ObjectFactory.CreateRichTextString(messageFormattingDescriptor);
			message.AddFormattedString(thisRichTextMessage.String.ToInternallyFormattedSystemString());

			#endregion

			#endregion
			#region Write Contents
			#region Start new line

			if (richTextBox_ConsoleOutput.TextLength > 0) richTextBox_ConsoleOutput.AppendText("\n");

			#endregion

			#region Add Date

			if (false)
			{
				richTextBox_ConsoleOutput.AppendRichTextString(date);
				richTextBox_ConsoleOutput.AppendText(" ");
			}

			#endregion
			#region Add Time

			if (false)
			{
				richTextBox_ConsoleOutput.AppendRichTextString(time);
				richTextBox_ConsoleOutput.AppendText(" ");
			}

			#endregion
			#region Add Type

			if (false)
			{
				int totalMessageSize = 0;
				foreach (var thisElement in type.Elements)
				{
					thisElement.BackColor = typeFormattingDescriptor.BackColor;
				}

				for (int i = 0; i < type.Elements.Count; i++)
				{
					IRichTextElement thisElement = type.Elements[i];
					IRichTextElement currentElement;

					#region Limit Size of total message to 16 Chars

					int thisElementSize = thisElement.Message.Length;
					if (totalMessageSize + thisElementSize > 16)
					{
						currentElement = ObjectFactory.CreateRichTextElement(thisElement.Message.Substring(0, 16 - totalMessageSize));
						currentElement.ForeColor = thisElement.ForeColor;
						currentElement.BackColor = thisElement.BackColor;
						currentElement.IsBold = thisElement.IsBold;
						currentElement.IsItallic = thisElement.IsItallic;
						currentElement.IsUnderlined = thisElement.IsUnderlined;
						currentElement.IsStrikeout = thisElement.IsStrikeout;
						currentElement.IsObfuscated = thisElement.IsObfuscated;

						totalMessageSize += currentElement.Message.Length;
					}
					else
					{
						currentElement = thisElement;
						totalMessageSize += currentElement.Message.Length;
						if (i == type.Elements.Count - 1)
						{
							currentElement =
								ObjectFactory.CreateRichTextElement(thisElement.Message + new string(' ', 16 - totalMessageSize));
							currentElement.ForeColor = thisElement.ForeColor;
							currentElement.BackColor = thisElement.BackColor;
							currentElement.IsBold = thisElement.IsBold;
							currentElement.IsItallic = thisElement.IsItallic;
							currentElement.IsUnderlined = thisElement.IsUnderlined;
							currentElement.IsStrikeout = thisElement.IsStrikeout;
							currentElement.IsObfuscated = thisElement.IsObfuscated;
						}
					}

					#endregion

					richTextBox_ConsoleOutput.AppendRichTextElement(currentElement);
				}
				richTextBox_ConsoleOutput.AppendText(" ");
			}

			#endregion
			#region Add Message

			int messageIndentSize = GetIndentSize();
			if (false)
			{
				int fullMessageSize = message.ToUnformattedSystemString().Length;
				int remainingCharactersToAdd = fullMessageSize;
				int charactersOnThisLine = 0;

				for (int i = 0; i < message.Elements.Count; i++)
				{
					IRichTextElement thisElement = message.Elements[i];
					IRichTextElement workingElement;

					#region Limit Size of total message

					int maxLineSize = MessageSize;

					#region  Break the currrent element across lines if required.

					int sizeOfCurrentElement = thisElement.Message.Length;
					int sizeAlreadyAdded = 0;
					int sizeToAdd = sizeOfCurrentElement - sizeAlreadyAdded;
					if (sizeToAdd > maxLineSize) sizeToAdd = maxLineSize;
					if (sizeToAdd > maxLineSize - charactersOnThisLine) sizeToAdd = maxLineSize - charactersOnThisLine;
					int sizeWillRemain = sizeOfCurrentElement - sizeAlreadyAdded - sizeToAdd;

					#region Keep breaking across lines...

					while (sizeWillRemain > 0)
					{
						workingElement =
							ObjectFactory.CreateRichTextElement(thisElement.Message.Substring(sizeAlreadyAdded, sizeToAdd));
						workingElement.ForeColor = thisElement.ForeColor;
						workingElement.BackColor = thisElement.BackColor;
						workingElement.IsBold = thisElement.IsBold;
						workingElement.IsItallic = thisElement.IsItallic;
						workingElement.IsUnderlined = thisElement.IsUnderlined;
						workingElement.IsStrikeout = thisElement.IsStrikeout;
						workingElement.IsObfuscated = thisElement.IsObfuscated;

						if (workingElement.Message.Contains("\n"))
						{
							workingElement.Message = workingElement.Message.Replace("\n",
								new string(' ', MessageSize - sizeAlreadyAdded + messageIndentSize));
						}
						richTextBox_ConsoleOutput.AppendRichTextElement(workingElement);
						charactersOnThisLine += sizeToAdd;
						richTextBox_ConsoleOutput.AppendText(new string(' ', MessageSize - charactersOnThisLine));
						richTextBox_ConsoleOutput.AppendText(" ");
						richTextBox_ConsoleOutput.AppendText(new string(' ', messageIndentSize));
						charactersOnThisLine = 0;
						sizeAlreadyAdded += sizeToAdd;
						remainingCharactersToAdd -= sizeToAdd;
						sizeWillRemain = sizeOfCurrentElement - sizeAlreadyAdded - sizeToAdd;
						sizeToAdd = sizeOfCurrentElement - sizeAlreadyAdded;
						if (sizeToAdd > maxLineSize) sizeToAdd = maxLineSize;
						if (sizeToAdd > maxLineSize - charactersOnThisLine) sizeToAdd = maxLineSize - charactersOnThisLine;
					}

					#endregion

					#region Last part of the element, no need to breaklines again.

					workingElement =
						ObjectFactory.CreateRichTextElement(thisElement.Message.Substring(sizeAlreadyAdded, sizeToAdd));
					workingElement.ForeColor = thisElement.ForeColor;
					workingElement.BackColor = thisElement.BackColor;
					workingElement.IsBold = thisElement.IsBold;
					workingElement.IsItallic = thisElement.IsItallic;
					workingElement.IsUnderlined = thisElement.IsUnderlined;
					workingElement.IsStrikeout = thisElement.IsStrikeout;
					workingElement.IsObfuscated = thisElement.IsObfuscated;

					if (workingElement.Message.Contains("\n"))
					{
						workingElement.Message =
							workingElement.Message.Split(new[] { '\n' }, 2)[0] +

							new string(' ', MessageSize - workingElement.Message.Split(new[] { '\n' }, 2)[0].Length + 1) +

							"\n" +

							new string(' ', messageIndentSize + 3) +

							workingElement.Message.Split(new[] { '\n' }, 2)[1];

						charactersOnThisLine = thisElement.Message.Split(new[] { '\n' }, 2)[1].Length;
						remainingCharactersToAdd -= sizeToAdd;
						sizeToAdd = 0;
					}
					workingElement.BackColor = thisElement.BackColor;
					//if (OverrideForeColor) workingElement.ForeColor = ForeColor;
					richTextBox_ConsoleOutput.AppendRichTextElement(workingElement);
					charactersOnThisLine += sizeToAdd;
					remainingCharactersToAdd -= sizeToAdd;

					#endregion

					#region Finish the line with spaces.

					workingElement = ObjectFactory.CreateRichTextElement(new string(' ', MessageSize - charactersOnThisLine));
					workingElement.ForeColor = thisElement.ForeColor;
					workingElement.BackColor = thisElement.BackColor;
					workingElement.IsBold = thisElement.IsBold;
					workingElement.IsItallic = thisElement.IsItallic;
					workingElement.IsUnderlined = thisElement.IsUnderlined;
					workingElement.IsStrikeout = thisElement.IsStrikeout;
					workingElement.IsObfuscated = thisElement.IsObfuscated;
					richTextBox_ConsoleOutput.AppendRichTextElement(workingElement);
					charactersOnThisLine += sizeToAdd;
					remainingCharactersToAdd -= sizeToAdd;

					#endregion

					#endregion

					#endregion
				}
			}

			#endregion

			#region Add Overflow if Required.

			IRichTextString overflowElement = ObjectFactory.CreateRichTextString(messageFormattingDescriptor);
			overflowElement.AddFormattedString(new string(' ', OverflowSize));
			richTextBox_ConsoleOutput.AppendRichTextString(overflowElement);

			#endregion
			#endregion
			richTextBox_ConsoleOutput.ScrollToCaret();
		}
		private void AddMessageDirect(IRichTextMessage thisRichTextMessage)
	    {
		    while (richTextMessages.Count >= maximumMessages)
		    {
				#region Cut from text box
			    richTextBox_ConsoleOutput.SelectionStart = 0;
			    richTextBox_ConsoleOutput.SelectionLength = 0;
			    int newLinePos = richTextBox_ConsoleOutput.Text.IndexOf("\n");
			    if (newLinePos > -1)
			    {
				    richTextBox_ConsoleOutput.SelectionStart = 0;
				    richTextBox_ConsoleOutput.SelectionLength = newLinePos+1;
				    richTextBox_ConsoleOutput.SelectedText = "";
			    }
				#endregion
				#region Remove from list
				richTextMessages.RemoveAt(0);
				#endregion
			}
			richTextMessages.Add(new RichTextMessageDictionaryItem(this, thisRichTextMessage));
			AppendRichTextMessageDirect(thisRichTextMessage);
	    }

		private void RichTextBoxUpdaterThread()
	    {
		    while (!IsFormClosing)
		    {
			    //ReEnable when Obfusation Processing Complete.
			    #region Obfuscation (Disabled)
			    //if (performRichTextBoxUpdates)
			    //   {

			    //	try
			    //	{
			    //		foreach (RichTextMessage thisRichTextMessage in richTextMessages)
			    //		{

			    //		}
			    //	}
			    //	catch
			    //	{
			    //		return; //ALL objects on same UI thread, the app is closing...
			    //	}
			    //}
			    #endregion

			    while (notifyIncomingRichTextMessages.WaitOne(0))
			    {
				    IRichTextMessage thisRichTextMessage = null;
				    incomingRichTextMessages.TryDequeue(out thisRichTextMessage);
				    if (IsFormClosing) return;
				    try
				    {
					    if (thisRichTextMessage != null)
						    Invoke(new MethodInvoker(delegate { AddMessageDirect(thisRichTextMessage); }));
				    }
				    catch (InvalidAsynchronousStateException)
				    {
					    //Expected. We've closed the form and we're exiting now.
					    return;
				    }
			    }
			    Thread.Sleep(50);
		    }
	    }
		#endregion
	}
}
