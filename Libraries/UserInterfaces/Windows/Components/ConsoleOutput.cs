using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using Com.OfficerFlake.Libraries.Color;
using static Com.OfficerFlake.Libraries.Database;
using static Com.OfficerFlake.Libraries.RichText.RichTextMessage;
using static Com.OfficerFlake.Libraries.RichText.RichTextString;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.RichText;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
	/// <summary>
	/// A RichTextBox built to accept RichTextMessages through the AddMessage method.
	/// </summary>
	/// 
	/// Sealed and completed. Please do not add any new public methods without reviewing the architecture first!
	public sealed partial class ConsoleOutput : UserControl
    {
		#region Constructor
		internal ConsoleOutput()
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
	    private const int MessageSize = 56;


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

	    private void Button_TestOutput_Click(object sender, EventArgs e)
	    {
		    //AddMessage(new UserMessage(UserDB.TestUser, "&bClicked the \"Test Output\" button!"));
		    //AddMessage(new UserMessage(UserDB.TestUser, "&bThere are now &e&l" + (richTextMessagesCount+1) + "&r&b messages in the output log!"));
			//AddMessage(new UserMessage(UserDB.TestUser, "&bSeems fine to me!"));

		    AddMessage(new UserMessage(Users.TestUser, "&eLONG MESSAGE TEST----------------------------------------------------------------------------------------------------------------------------------------------"));
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
			    "Message: " + GetMessageFromPosition(GetMouseRow(currentTextIndex)).String.ToUnformattedString());
	    }
		#endregion

		#region RichTextMessages List

		private class RichTextMessageDictionaryItem
	    {
		    private static ConsoleOutput Parent;
		    public int StartIndex;
			public RichTextMessage Message;

		    public RichTextMessageDictionaryItem(ConsoleOutput _Parent, RichTextMessage _Message)
		    {
			    Parent = _Parent;
				StartIndex = Parent.richTextBox_ConsoleOutput.Lines.Length;
			    Message = _Message;
		    }
	    }

		private List<RichTextMessageDictionaryItem> richTextMessages = new List<RichTextMessageDictionaryItem>();
	    private int maximumMessages = 1000; //Stress tested okay to ~25,000 objects.
	    private int richTextMessagesCount => richTextMessages.Count + incomingRichTextMessages.Count;

		private ConcurrentQueue<RichTextMessage> incomingRichTextMessages = new ConcurrentQueue<RichTextMessage>();
		private ManualResetEvent notifyIncomingRichTextMessages = new ManualResetEvent(false);

		/// <summary>
		/// Thread safe method of adding a RichTextMessage to the Output Console.
		/// </summary>
		/// <param name="thisRichTextMessage"></param>
	    public void AddMessage(RichTextMessage thisRichTextMessage)
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
	    private RichTextMessage GetMessageFromPosition(int Row)
	    {
		    RichTextMessage output = null;
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
	    private void AppendRichTextMessageDirect(RichTextMessage thisRichTextMessage)
	    {
			RichTextString.MessageElement date = new RichTextString.MessageElement();
			date.Message = thisRichTextMessage.Created.InStandardForm().YYYY +
		                   thisRichTextMessage.Created.InStandardForm().MM +
		                   thisRichTextMessage.Created.InStandardForm().DD;
			date.Color = SimpleColors.ColorF;

		    RichTextString.MessageElement time = new RichTextString.MessageElement();
			time.Message = thisRichTextMessage.Created.InStandardForm().hh +
			               thisRichTextMessage.Created.InStandardForm().mm +
			               thisRichTextMessage.Created.InStandardForm().ss;
			time.Color = SimpleColors.ColorE;

			RichTextString.MessageElement[] username = thisRichTextMessage.UserObject.Username.Elements;

			RichTextString.MessageElement[] message = thisRichTextMessage.String.Elements;

			if (richTextBox_ConsoleOutput.TextLength > 0) richTextBox_ConsoleOutput.AppendText("\n");
		    int messageIndentSize = GetIndentSize();
			if (checkBox_ShowDate.Checked)
		    {
			    richTextBox_ConsoleOutput.AppendRichTextElement(date);
			    richTextBox_ConsoleOutput.AppendText(" ");
		    }
		    if (checkBox_ShowTime.Checked)
		    {
			    richTextBox_ConsoleOutput.AppendRichTextElement(time);
			    richTextBox_ConsoleOutput.AppendText(" ");
			}
		    if (checkBox_ShowUsername.Checked)
		    {
			    int totalMessageSize = 0;
				for (int i=0; i<username.Length; i++)
				{
					MessageElement thisElement = username[i];
					MessageElement currentElement;
					#region Limit Size of total message to 16 Chars
					int thisElementSize = thisElement.Message.Length;
					if (totalMessageSize + thisElementSize > 16)
					{
						currentElement = new MessageElement(thisElement.Message.Substring(0, 16 - totalMessageSize), thisElement.Color,
							thisElement.IsBold, thisElement.IsItalic, thisElement.IsUnderlined, thisElement.IsObfuscated);
						totalMessageSize += currentElement.Message.Length;
					}
					else
					{
						currentElement = thisElement;
						totalMessageSize += currentElement.Message.Length;
						if (i == username.Length - 1)
						{
							currentElement = new MessageElement(thisElement.Message + new string(' ', 16-totalMessageSize), thisElement.Color,
								thisElement.IsBold, thisElement.IsItalic, thisElement.IsUnderlined, thisElement.IsObfuscated);
						}
					}
					#endregion
					richTextBox_ConsoleOutput.AppendRichTextElement(currentElement);
				}
			    richTextBox_ConsoleOutput.AppendText(" ");
			}
		    if (checkBox_ShowMessage.Checked)
		    {
				int fullMessageSize = message.Sum(x => x.Message.Length);
			    int remainingCharactersToAdd = fullMessageSize;
			    int charactersOnThisLine = 0;

			    for (int i = 0; i < message.Length; i++)
			    {
				    MessageElement thisElement = message[i];
				    MessageElement workingElement;
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
						workingElement = new MessageElement
					    (
						    thisElement.Message.Substring(sizeAlreadyAdded, sizeToAdd),
							thisElement.Color,
						    thisElement.IsBold,
							thisElement.IsItalic,
							thisElement.IsUnderlined,
							thisElement.IsObfuscated
							);
					    richTextBox_ConsoleOutput.AppendRichTextElement(workingElement);
					    charactersOnThisLine += sizeToAdd;
						richTextBox_ConsoleOutput.AppendText("\n ");
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
				    workingElement = new MessageElement
				    (
					    thisElement.Message.Substring(sizeAlreadyAdded, sizeToAdd),
					    thisElement.Color,
					    thisElement.IsBold,
					    thisElement.IsItalic,
					    thisElement.IsUnderlined,
					    thisElement.IsObfuscated
				    );
				    richTextBox_ConsoleOutput.AppendRichTextElement(workingElement);
				    charactersOnThisLine += sizeToAdd;
					remainingCharactersToAdd -= sizeToAdd;
					#endregion
					#endregion
					#endregion
				}
			    //richTextBox_ConsoleOutput.AppendText(" ");
			}
		    richTextBox_ConsoleOutput.ScrollToCaret();
		}
	    private void AddMessageDirect(RichTextMessage thisRichTextMessage)
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
				    RichTextMessage thisRichTextMessage = null;
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
