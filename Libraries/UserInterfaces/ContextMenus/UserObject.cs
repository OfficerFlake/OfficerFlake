using System;
using System.Windows.Forms;

namespace Com.OfficerFlake.Libraries.UserInterfaces.ContextMenus
{
	public partial class UserObject : UserControl
	{
		public UserObject()
		{
			InitializeComponent();
		}

		private void freezeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"User would be frozen if this was linked to a user object.\n\nBreak here to implement this feature!",
				"NOT IMPLEMENTED",
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation);
		}
		private void kickToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"User would be kicked from the server if this was linked to a user object.\n\nBreak here to implement this feature!",
				"NOT IMPLEMENTED",
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation);
		}
		private void banToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"User would be banned from the server if this was linked to a user object.\n\nBreak here to implement this feature!",
				"NOT IMPLEMENTED",
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation);
		}
		private void infoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"User info dialogue wouild be shown if this was linked to a user object.\n\nBreak here to implement this feature!",
				"NOT IMPLEMENTED",
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation);
		}
	}
}
