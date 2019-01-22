using System.Windows.Controls;
using System.Windows.Input;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Icons
{
	/// <summary>
	/// Interaction logic for PacketInspector.xaml
	/// </summary>
	public partial class FormationInspector : UserControl
	{
		public FormationInspector()
		{
			InitializeComponent();
		}

		private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (OpenYSFormationInspectorUserInterface.IsVisible) OpenYSFormationInspectorUserInterface.Hide();
			else OpenYSFormationInspectorUserInterface.Show();
		}
	}
}
