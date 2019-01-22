using System.Windows.Controls;
using System.Windows.Input;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Icons
{
    /// <summary>
    /// Interaction logic for FormationClientMaximise.xaml
    /// </summary>
    public partial class FormationClientMaximise : UserControl
	{
		public FormationClientMaximise()
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
