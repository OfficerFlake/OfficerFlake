using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.UserInterfaces
{
    /// <summary>
    /// Interaction logic for FormationInspector.xaml
    /// </summary>
    public partial class FormationInspectorUserInterface : OYS_Window, IFormationInspector
    {
        public FormationInspectorUserInterface()
        {
            InitializeComponent();
        }

        #region Methods
        public void LinkFormationInspector()
        {
            Logger.FormationInspector.LinkFormationInspector(this);
        }
        #endregion

        public void UpdateClientFormationHost(int formationPositionNumber, string username, int? flightId)
        {
            throw new NotImplementedException();
        }
        public void UpdateClientFormationPosition(int formationPositionNumber, int? targetPositionNumber, double? xPosition, double? yPosition, double? zPosition)
        {
            throw new NotImplementedException();
        }

        private void FormationInspectorUserInterface_OnClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Visibility = Visibility.Hidden;
        }
    }

    public static class OpenYSFormationInspectorUserInterface
    {
        private static FormationInspectorUserInterface formationInspectorWindow;

        #region Create/Close
        public static void CreateWindow() => formationInspectorWindow = UserInterface.CreateWindow<FormationInspectorUserInterface>();
        public static void CloseWindow() => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.Close());
        #endregion
        #region Show/Hide
        public static void Show() => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.Show());
        public static void Hide() => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.Hide());
        public static Boolean IsVisible => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.IsVisible);
        #endregion
        #region Wait Load/Close
        public static bool WaitForCreation(int timeout = Int32.MaxValue) => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.WaitForCreation(timeout));
        public static bool WaitForClose(int timeout = Int32.MaxValue) => formationInspectorWindow.WaitForClose(timeout);
        #endregion

        public static void LinkPacketInspector() => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.LinkFormationInspector());

        #region ChangeProperties
        public static void UpdateClientFormationHost(int formationPositionNumber, string username, int? flightId) => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.UpdateClientFormationHost(formationPositionNumber, username, flightId));
        public static void UpdateClientFormationPosition(int formationPositionNumber, int? targetPositionNumber, double? xPosition, double? yPosition, double? zPosition) => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.UpdateClientFormationPosition(formationPositionNumber, targetPositionNumber, xPosition, yPosition, zPosition));
        #endregion
    }
}
