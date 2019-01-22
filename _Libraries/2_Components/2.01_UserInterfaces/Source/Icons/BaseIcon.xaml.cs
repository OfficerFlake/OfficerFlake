using System.Windows.Controls;
using System.Windows.Media;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Icons
{
	/// <summary>
	/// Interaction logic for BaseIcon.xaml
	/// </summary>
	public partial class BaseIcon : UserControl
	{
		public BaseIcon()
		{
			InitializeComponent();
		}

	    public void Enable()
	    {
	        BaseIconImage.Source = new ImageSourceConverter().ConvertFromString("pack://application:,,,/2.01_UserInterfaces;component/IconBaseEnabled.png") as ImageSource;
	    }

	    public void Disable()
	    {
	        BaseIconImage.Source = new ImageSourceConverter().ConvertFromString("pack://application:,,,/2.01_UserInterfaces;component/IconBaseDisabled.png") as ImageSource;
	    }
    }
}
