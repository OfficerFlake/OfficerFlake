using System;
using System.Windows.Forms;

namespace Com.OfficerFlake.Libraries.UserInterfaces.ContextMenus
{
	public interface IClickableMenu
	{
		ContextMenuStrip MenuToShow { get; set; }
		void Show();
		void Subscribe(EventHandler eventHandler);
	}

	public partial class ClickableMenu : UserControl, IClickableMenu
	{
		public ClickableMenu()
		{
			InitializeComponent();
		}

		public ContextMenuStrip MenuToShow
		{
			get => contextMenuStrip_ClickableMenu;
			set => contextMenuStrip_ClickableMenu = value;
		} 
		public new void Show()
		{
			base.Show();
			contextMenuStrip_ClickableMenu.Show(MousePosition);
		}
		public void Subscribe(EventHandler eventHandler)
		{
			UpdateRequired += eventHandler;
		}

		private event EventHandler UpdateRequired;
		protected void MenuItemChanged(object sender, EventArgs e)
		{
			UpdateRequired?.Invoke(this, e);
		}
	}
}
