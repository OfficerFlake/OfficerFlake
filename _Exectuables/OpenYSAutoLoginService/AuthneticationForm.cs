using System;
using System.Drawing;
using System.Windows.Forms;
using Com.OfficerFlake.Libraries.YSFHQ;

namespace OpenYSAutoLoginService
{
	public partial class AuthenticationForm : Form
	{
		private string UsernameWatermark = "Username";
		private string PasswordWatermark = "Password";

		private bool buttonDisabled = false; //if we actually disable the button, it is ugly!

		public int UserID = -1;

		public AuthenticationForm()
		{
			InitializeComponent();
			textBox_Username.ForeColor = SystemColors.GrayText;
			textBox_Username.Text = UsernameWatermark;
			this.textBox_Username.Leave += new System.EventHandler(this.textBox_Username_Leave);
			this.textBox_Username.Enter += new System.EventHandler(this.textBox_Username_Enter);
			textBox_Password.ForeColor = SystemColors.GrayText;
			textBox_Password.Text = PasswordWatermark;
			this.textBox_Password.Leave += new System.EventHandler(this.textBox_Password_Leave);
			this.textBox_Password.Enter += new System.EventHandler(this.textBox_Password_Enter);
		}

		private void textBox_Username_Leave(object sender, EventArgs e)
		{
			if (textBox_Username.Text.Length == 0)
			{
				textBox_Username.Text = UsernameWatermark;
				textBox_Username.ForeColor = SystemColors.GrayText;
			}
		}
		private void textBox_Username_Enter(object sender, EventArgs e)
		{
			if (textBox_Username.Text == UsernameWatermark)
			{
				textBox_Username.Text = "";
				textBox_Username.ForeColor = SystemColors.WindowText;
			}
		}

		private void textBox_Password_Leave(object sender, EventArgs e)
		{
			if (textBox_Password.Text.Length == 0)
			{
				textBox_Password.Text = PasswordWatermark;
				textBox_Password.ForeColor = SystemColors.GrayText;
			}
		}
		private void textBox_Password_Enter(object sender, EventArgs e)
		{
			if (textBox_Password.Text == PasswordWatermark)
			{
				textBox_Password.Text = "";
				textBox_Password.ForeColor = SystemColors.WindowText;
			}
		}

		private bool ValidateForm()
		{
			if (textBox_Username.Text == UsernameWatermark | textBox_Username.Text == "") return false;
			if (textBox_Password.Text == UsernameWatermark | textBox_Password.Text == "") return false;
			return true;

		}

		private void button_Authenticate_Click(object sender, EventArgs e)
		{
			if (buttonDisabled) return;
			buttonDisabled = true;
			button_Authenticate.ImageKey = imageList_Authenticate.Images.Keys[0];
			button_Authenticate.Text = @"    Authenticating...";			
			Button_Authenticate_Process();
			button_Authenticate.Text = @"    " + button_Authenticate.Text;
			buttonDisabled = false;
			return;

			
		}

		private void Button_Authenticate_Process()
		{
			if (!ValidateForm())
			{
				label_Result.Text = @"Error: No Username Given!";
				goto Error;
			}
			var AuthenticationResult = YSFHQ.TryAuthenticate(textBox_Username.Text, textBox_Password.Text);
			switch (AuthenticationResult)
			{
				case -503: //Program Broken.
					label_Result.Text = @"Error: This Program is broken!";
					button_Authenticate.Text = @"Program Error!";
					goto Alert;
				case -500: //Service Error
					label_Result.Text = @"Error: Couldn't Reach YSFHQ.";
					button_Authenticate.Text = @"Re-Authenticate?";
					goto Alert;
				case -403: //Bad Username/Password
					label_Result.Text = @"Error: Username/Password Invalid.";
					button_Authenticate.Text = @"Re-Authenticate?";
					goto Error;
				case -401: //API Key Rejected
					label_Result.Text = @"Error: This Program doesn't have a Valid API Key.";
					button_Authenticate.Text = @"Program Error!";
					goto Alert;
				case -400: //No Username/Password or HTTPS not used.
					label_Result.Text = @"Error: Didn't Use HTTPS or no Username/Password.";
					button_Authenticate.Text = @"Re-Authenticate?";
					goto Alert;
				default:
					label_Result.Text = @"Success: Authenticated as User: " + AuthenticationResult.ToString();
					button_Authenticate.Text = @"Re-Authenticate?";
					goto Success;
			}

			Error:
			button_Authenticate.ImageKey = imageList_Authenticate.Images.Keys[2];
			return;

			Alert:
			button_Authenticate.ImageKey = imageList_Authenticate.Images.Keys[3];
			return;

			Success:
			UserID = AuthenticationResult;
			button_Authenticate.ImageKey = imageList_Authenticate.Images.Keys[1];
			return;
		}
	}
}