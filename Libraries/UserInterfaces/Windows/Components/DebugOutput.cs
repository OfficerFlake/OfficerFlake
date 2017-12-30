using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.UserInterfaces.ContextMenus;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
	/// <summary>
	/// A RichTextBox built to accept RichTextMessages through the AddMessage method.
	/// </summary>
	/// 
	/// Sealed and completed. Please do not add any new public methods without reviewing the architecture first!
	public sealed partial class DebugOutput : UserControl
    {
		#region Constructor
		internal DebugOutput()
	    {
		    InitializeComponent();
		    if (DesignMode) return;
		    DebugMenu.UpdateRequired += OnUpdateRequired;
		    new Thread(() => RichTextBoxUpdaterThread()).Start();
		}
		#endregion

		#region Variables
		//private bool performRichTextBoxUpdates = true;
	    internal ManualResetEvent FormClosing = new ManualResetEvent(false);
	    internal bool IsFormClosing => FormClosing.WaitOne(0);

	    private const int DateSize = 8;
	    private const int TimeSize = 6;
	    private const int TypeSize = 16;

		private int MessageSize =>
			91 -
			(DebugMenu.showDateToolStripMenuItem.Checked ? DateSize+1 : 0) -
			(DebugMenu.showTimeToolStripMenuItem.Checked ? TimeSize+1 : 0) -
			(DebugMenu.showTypeToolStripMenuItem.Checked ? TypeSize+1 : 0);

		private int OverflowSize =>
			91 -
			(DebugMenu.showDateToolStripMenuItem.Checked ? DateSize + 1 : 0) -
			(DebugMenu.showTimeToolStripMenuItem.Checked ? TimeSize + 1 : 0) -
			(DebugMenu.showTypeToolStripMenuItem.Checked ? TypeSize + 1 : 0) -
			(DebugMenu.showMessageToolStripMenuItem.Checked ? MessageSize : 0);



		public DebugMenu DebugMenu = new DebugMenu();
		#endregion
		#region Control Events
	    private void OnUpdateRequired(object sender, EventArgs e)
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
		    private static DebugOutput Parent;
		    public int StartIndex;
			public IRichTextMessage Message;

		    public RichTextMessageDictionaryItem(DebugOutput _Parent, IRichTextMessage _Message)
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
		    if (DebugMenu.showDateToolStripMenuItem.Checked) output += (DateSize+1);
		    if (DebugMenu.showTimeToolStripMenuItem.Checked) output += (TimeSize+1);
		    if (DebugMenu.showTypeToolStripMenuItem.Checked) output += (TypeSize+1);
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
			#region Color Override
			IColor BackColor = ObjectFactory.CreateColor(16,16,16);
		    bool OverrideBackColor = false;
		    IColor ForeColor = ObjectFactory.CreateColor(240, 240, 240);
		    bool OverrideForeColor = false;
			switch (thisRichTextMessage.Type)
		    {
			    case MessageType.Unknown:
					return;
			    case MessageType.User:
				    return;
			    case MessageType.ConsoleInformation:
				    return;
				case MessageType.DebugSummary:
				    if (!DebugMenu.showDebugSummaryToolStripMenuItem.Checked) return;
					BackColor = ObjectFactory.CreateColor(10, 20, 25);
					OverrideBackColor = true;
					ForeColor = ObjectFactory.CreateColor(85, 240, 240);
					OverrideForeColor = true;
					break;
				case MessageType.DebugDetail:
				    if (!DebugMenu.showDebugDetailToolStripMenuItem.Checked) return;
					BackColor = ObjectFactory.CreateColor(10, 10, 25);
					OverrideBackColor = true;
					ForeColor = ObjectFactory.CreateColor(50, 200, 200);
					OverrideForeColor = true;
					break;
				case MessageType.DebugWarning:
				    if (!DebugMenu.showDebugWarningToolStripMenuItem.Checked) return;
					BackColor = ObjectFactory.CreateColor(25, 25, 10);
					OverrideBackColor = true;
					ForeColor = ObjectFactory.CreateColor(240, 240, 85);
					OverrideForeColor = true;
					break;
				case MessageType.DebugError:
				    if (!DebugMenu.showDebugErrorToolStripMenuItem.Checked) return;
					BackColor = ObjectFactory.CreateColor(50, 25, 10);
					OverrideBackColor = true;
					ForeColor = ObjectFactory.CreateColor(200, 200, 200);
					OverrideForeColor = true;
					break;
				case MessageType.DebugCrash:
				    if (!DebugMenu.showDebugCrashToolStripMenuItem.Checked) return;
					BackColor = ObjectFactory.CreateColor(50, 10, 10);
					OverrideBackColor = true;
					ForeColor = ObjectFactory.CreateColor(255, 255, 255);
					OverrideForeColor = true;
					break;
			}
			#endregion

			#region Date
			IRichTextElement date = ObjectFactory.CreateRichTextElement(thisRichTextMessage.Datestamp.ToSystemString());
			date.ForeColor = SimpleColors.White.Color;
		    if (OverrideBackColor) date.BackColor = BackColor;
		    if (OverrideForeColor) date.ForeColor = ForeColor;
			#endregion
			#region Time
		    IRichTextElement time = ObjectFactory.CreateRichTextElement(thisRichTextMessage.Timestamp.ToSystemString());
			time.ForeColor = SimpleColors.DarkGray.Color;
		    if (OverrideBackColor) time.BackColor = BackColor;
		    if (OverrideForeColor) time.ForeColor = ForeColor;
			#endregion
			#region Type
			MessageType type = thisRichTextMessage.Type;
			#endregion
			#region Message
			List<IRichTextElement> message = thisRichTextMessage.String.Elements;
			#endregion

			#region Start new line
			if (richTextBox_ConsoleOutput.TextLength > 0) richTextBox_ConsoleOutput.AppendText("\n");
			#endregion
			#region Add Date
			if (DebugMenu.showDateToolStripMenuItem.Checked)
		    {
			    richTextBox_ConsoleOutput.AppendRichTextElement(date);
			    richTextBox_ConsoleOutput.AppendText(" ");
		    }
			#endregion
			#region Add Time
			if (DebugMenu.showTimeToolStripMenuItem.Checked)
		    {
			    richTextBox_ConsoleOutput.AppendRichTextElement(time);
			    richTextBox_ConsoleOutput.AppendText(" ");
			}
			#endregion
			#region Add Type
			if (DebugMenu.showTypeToolStripMenuItem.Checked)
		    {
			    int totalMessageSize = 0;
			    IRichTextString messageTypeString = ("&d" + "???").AsRichTextString();
			    switch (thisRichTextMessage.Type)
			    {
					default:
						goto case MessageType.Unknown;
					case MessageType.Unknown:
						messageTypeString = ("&d" + "???").AsRichTextString();
						return;
				    case MessageType.User:
					    messageTypeString = ("&d" + "User").AsRichTextString();
						return;
				    case MessageType.ConsoleInformation:
					    messageTypeString = ("&d" + "Console").AsRichTextString();
						return;
				    case MessageType.DebugSummary:
						messageTypeString = ("&b" + "Summary").AsRichTextString();
						break;
				    case MessageType.DebugDetail:
						messageTypeString = ("&9" + "Detail").AsRichTextString();
						break;
				    case MessageType.DebugWarning:
						messageTypeString = ("&e" + "Warning").AsRichTextString();
						break;
				    case MessageType.DebugError:
						messageTypeString = ("&c" + "Error").AsRichTextString();
						break;
				    case MessageType.DebugCrash:
						messageTypeString = ("&c" + "Crash").AsRichTextString();
						break;
				}
			    foreach (var thisElement in messageTypeString.Elements)
			    {
				    thisElement.BackColor = BackColor;
			    }

				for (int i=0; i < messageTypeString.Elements.Count; i++)
				{
					IRichTextElement thisElement = messageTypeString.Elements[i];
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

					}
					else
					{
						currentElement = thisElement;
						totalMessageSize += currentElement.Message.Length;
						if (i == messageTypeString.Elements.Count - 1)
						{
							currentElement = ObjectFactory.CreateRichTextElement(thisElement.Message + new string(' ', 16 - totalMessageSize));
							currentElement.ForeColor = thisElement.ForeColor;
							currentElement.BackColor = thisElement.BackColor;
							currentElement.IsBold = thisElement.IsBold;
							currentElement.IsItallic = thisElement.IsItallic;
							currentElement.IsUnderlined = thisElement.IsUnderlined;
							currentElement.IsStrikeout = thisElement.IsStrikeout;
							currentElement.IsObfuscated = thisElement.IsObfuscated;
							if (OverrideBackColor) currentElement.BackColor = BackColor;
							if (OverrideForeColor) currentElement.ForeColor = ForeColor;
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
			if (DebugMenu.showMessageToolStripMenuItem.Checked)
		    {
				int fullMessageSize = message.Sum(x => x.Message.Length);
			    int remainingCharactersToAdd = fullMessageSize;
			    int charactersOnThisLine = 0;

			    for (int i = 0; i < message.Count; i++)
			    {
				    IRichTextElement thisElement = message[i];
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
					    workingElement = ObjectFactory.CreateRichTextElement(thisElement.Message.Substring(sizeAlreadyAdded, sizeToAdd));
					    workingElement.ForeColor = thisElement.ForeColor;
					    workingElement.BackColor = thisElement.BackColor;
					    workingElement.IsBold = thisElement.IsBold;
					    workingElement.IsItallic = thisElement.IsItallic;
					    workingElement.IsUnderlined = thisElement.IsUnderlined;
					    workingElement.IsStrikeout = thisElement.IsStrikeout;
					    workingElement.IsObfuscated = thisElement.IsObfuscated;

						if (workingElement.Message.Contains("\n"))
						{
							workingElement.Message = workingElement.Message.Replace("\n", new string(' ', MessageSize - sizeAlreadyAdded + messageIndentSize));
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
				    workingElement = ObjectFactory.CreateRichTextElement(thisElement.Message.Substring(sizeAlreadyAdded, sizeToAdd));
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
						    workingElement.Message.Split(new[] {'\n'}, 2)[0] +

						    new string(' ', MessageSize - workingElement.Message.Split(new[] {'\n'}, 2)[0].Length + 1) +

						    "\n" +

						    new string(' ', messageIndentSize + 1) +

						    workingElement.Message.Split(new[] {'\n'}, 2)[1];

						charactersOnThisLine = thisElement.Message.Split(new[] { '\n' }, 2)[1].Length;
					    remainingCharactersToAdd -= sizeToAdd;
						sizeToAdd = 0;
				    }
					workingElement.BackColor = thisElement.BackColor;
				    if (OverrideBackColor) workingElement.BackColor = BackColor;
				    if (OverrideForeColor) workingElement.ForeColor = ForeColor;
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

				    if (OverrideBackColor) workingElement.BackColor = BackColor;
				    if (OverrideForeColor) workingElement.ForeColor = ForeColor;
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
		    IRichTextElement overflowElement = ObjectFactory.CreateRichTextElement(new string(' ', OverflowSize));
		    overflowElement.ForeColor = ForeColor;
		    overflowElement.BackColor = BackColor;

		    richTextBox_ConsoleOutput.AppendRichTextElement(overflowElement);
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

		private void ShowDebugMenu(object sender, EventArgs e)
		{
			DebugMenu.Show();
			DebugMenu.Visible = true;
		}
	}
}
