using System.Windows.Controls;
using System.Windows.Input;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Icons
{
	/// <summary>
	/// Interaction logic for PacketInspector.xaml
	/// </summary>
	public partial class PacketInspector : UserControl
	{
		public PacketInspector()
		{
			InitializeComponent();
		}

		private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (OpenYSPacketInspectorUserInterface.IsVisible) OpenYSPacketInspectorUserInterface.Hide();
			else OpenYSPacketInspectorUserInterface.Show();
		}
	}
}
