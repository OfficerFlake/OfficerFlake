using System;
using System.Windows.Forms;

namespace OpenYSAuthenticatorExecutable
{
	public partial class YSFHQAuthenticationService : Form
	{
		private NotifyIcon trayIcon;

		public YSFHQAuthenticationService()
		{
			//InitializeComponent();

			//Initialize Tray Icon
			trayIcon = new NotifyIcon()
			{
				Icon = Resources.OpenYS,
				ContextMenu = new ContextMenu(new MenuItem[] {
					new MenuItem("Edit Authentication", EditAuthentication),
					new MenuItem("Stop Service", AskToStopService),
				}),
				Visible = true
			};
		}

		private void EditAuthentication(object sender, EventArgs e)
		{
			AuthenticationForm authForm = new AuthenticationForm();
			authForm.Show();
		}

		private void AskToStopService(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Stop Service?", "YSFHQ Authentication", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
			{
				StopService();
			}
		}
		private void StopService()
		{
			trayIcon.Visible = false;
			trayIcon.Dispose();
			Application.Exit();
		}

		private void YSFHQAuthenticationService_FormClosing(object sender, FormClosingEventArgs e)
		{
			StopService();
		}
	}
}
