using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

using Com.OfficerFlake.Libraries.Color;
using Com.OfficerFlake.Libraries.RichTextMessages;
using Com.OfficerFlake.Libraries.Extensions;

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
	    internal bool FormClosing = false;

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
		    AddMessage(new InformationMessage("&bClicked the \"Test Output\" button!"));
		    AddMessage(new InformationMessage("&bThere are now &e&l" + (richTextMessagesCount+1) + "&r&b messages in the output log!"));
			AddMessage(new InformationMessage("&bSeems fine to me!"));
		}
	    #endregion

		#region RichTextMessages List
		private List<RichTextMessage> richTextMessages = new List<RichTextMessage>();
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
		    foreach (RichTextMessage thisRichTextMessage in richTextMessages)
		    {
			    AppendRichTextMessageDirect(thisRichTextMessage);
		    }
	    }
	    private void AppendRichTextMessageDirect(RichTextMessage thisRichTextMessage)
	    {
			RichTextMessage.MessageElement date = new RichTextMessage.MessageElement();
			date.Message = thisRichTextMessage.Created.InStandardForm().YYYY +
		                   thisRichTextMessage.Created.InStandardForm().MM +
		                   thisRichTextMessage.Created.InStandardForm().DD;
			date.Color = MinecraftColor.White;

			RichTextMessage.MessageElement time = new RichTextMessage.MessageElement();
			time.Message = thisRichTextMessage.Created.InStandardForm().hh +
			               thisRichTextMessage.Created.InStandardForm().mm +
			               thisRichTextMessage.Created.InStandardForm().ss;
			time.Color = MinecraftColor.DarkGray;

		    RichTextMessage.MessageElement username = new RichTextMessage.MessageElement();
		    username.Message = thisRichTextMessage.UserObject.ResizeOnRight(16, ' ');
			username.Color = MinecraftColor.Teal;

		    RichTextMessage.MessageElement[] message = thisRichTextMessage.Elements;

			if (richTextBox_ConsoleOutput.TextLength > 0) richTextBox_ConsoleOutput.AppendText("\n");
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
			    richTextBox_ConsoleOutput.AppendRichTextElement(username);
		    }
		    if (checkBox_ShowMessage.Checked)
		    {
			    foreach (RichTextMessage.MessageElement thisElement in message)
			    {
				    richTextBox_ConsoleOutput.AppendRichTextElement(thisElement);
			    }
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
		    richTextMessages.Add(thisRichTextMessage);
			AppendRichTextMessageDirect(thisRichTextMessage);
	    }

	    private void RichTextBoxUpdaterThread()
	    {
		    while (!FormClosing)
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
				    if (FormClosing) return;
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
