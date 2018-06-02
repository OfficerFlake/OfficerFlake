using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfSandbox
{
	public partial class Testing : Window
	{
		public Testing()
		{
			InitializeComponent();
			this.DataContext = this;
		}
	}
}