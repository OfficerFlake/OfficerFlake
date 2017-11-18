using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Com.OfficerFlake.UserInterfaces.Windows
{
    public partial class IOForm : Form
    {
        public delegate void BtnRunClickEventHandler(object sender, EventArgs e);
        public event BtnRunClickEventHandler _eventBtnRunClicked;

        public IOForm()
        {
            InitializeComponent();
        }

        public void InvokeIfRequired(Control _invokeTarget, MethodInvoker _methodinvoker)
        {
            if (_invokeTarget.InvokeRequired)
            {
                _invokeTarget.Invoke(_methodinvoker);
            }
            else
            {
                _methodinvoker();
            }
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (_eventBtnRunClicked == null)
            {
                Debug.WriteLine("No subscribers for " + nameof(_eventBtnRunClicked) + ".");
                return;
            }
            _eventBtnRunClicked(this, e);
        }

        public void SubscribeToRunButtonClicked(BtnRunClickEventHandler subscribingEventHandler)
        {
            InvokeIfRequired(this, () => _eventBtnRunClicked += subscribingEventHandler);

        }

        private void IOForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Do Nothing here...
        }

        private void IOForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
