using System.Windows.Controls;
using System.Windows.Input;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Icons
{
    /// <summary>
    /// Interaction logic for FormationClientMinimise.xaml
    /// </summary>
    public partial class FormationClientMinimise : UserControl
	{
		public FormationClientMinimise()
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
