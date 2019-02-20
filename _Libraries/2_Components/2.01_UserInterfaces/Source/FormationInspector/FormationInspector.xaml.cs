using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using Com.OfficerFlake.Libraries.Loggers;

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
            Loggers.FormationInspector.LinkFormationInspector(this);
        }
        #endregion

        public void UpdateClientFormationHost(int formationPositionNumber, string username, int? flightId)
        {
            Dispatcher.Invoke(() =>
            {
                SolidColorBrush HasFlightID_Foreground = new SolidColorBrush(Color.FromRgb(22, 22, 22));
                SolidColorBrush HasFlightID_Background = new SolidColorBrush(Color.FromRgb(170, 170, 170));
                
                SolidColorBrush NoFlightID_Foreground = new SolidColorBrush(Color.FromRgb(170, 170, 170));
                SolidColorBrush NoFlightID_Background = new SolidColorBrush(Color.FromRgb(22, 22, 22));

                SolidColorBrush Error_Foreground = new SolidColorBrush(Color.FromRgb(240, 0, 0));
                SolidColorBrush Error_Background = new SolidColorBrush(Color.FromRgb(22, 22, 00));

                Border Border_Position = null;
                Border Border_Username = null;
                Border Border_ID = null;
                Border Border_Target = null;
                Border Border_X = null;
                Border Border_Y = null;
                Border Border_Z = null;

                Label Label_Position = null;
                Label Label_Username = null;
                Label Label_ID = null;
                Label Label_Target = null;
                Label Label_X = null;
                Label Label_Y = null;
                Label Label_Z = null;

                switch (formationPositionNumber)
                {
                    case 1:
                        Border_Position = Border_Client1_Position;
                        Border_Username = Border_Client1_Username;
                        Border_ID = Border_Client1_ID;
                        Border_Target = Border_Client1_Target;
                        Border_X = Border_Client1_X;
                        Border_Y = Border_Client1_Y;
                        Border_Z = Border_Client1_Z;

                        Label_Position = Label_Client1_Position;
                        Label_Username = Label_Client1_Username;
                        Label_ID = Label_Client1_ID;
                        Label_Target = Label_Client1_Target;
                        Label_X = Label_Client1_X;
                        Label_Y = Label_Client1_Y;
                        Label_Z = Label_Client1_Z;

                        goto updatedetails;
                    case 2:
                        Border_Position = Border_Client2_Position;
                        Border_Username = Border_Client2_Username;
                        Border_ID = Border_Client2_ID;
                        Border_Target = Border_Client2_Target;
                        Border_X = Border_Client2_X;
                        Border_Y = Border_Client2_Y;
                        Border_Z = Border_Client2_Z;

                        Label_Position = Label_Client2_Position;
                        Label_Username = Label_Client2_Username;
                        Label_ID = Label_Client2_ID;
                        Label_Target = Label_Client2_Target;
                        Label_X = Label_Client2_X;
                        Label_Y = Label_Client2_Y;
                        Label_Z = Label_Client2_Z;

                        goto updatedetails;
                    case 3:
                        Border_Position = Border_Client3_Position;
                        Border_Username = Border_Client3_Username;
                        Border_ID = Border_Client3_ID;
                        Border_Target = Border_Client3_Target;
                        Border_X = Border_Client3_X;
                        Border_Y = Border_Client3_Y;
                        Border_Z = Border_Client3_Z;

                        Label_Position = Label_Client3_Position;
                        Label_Username = Label_Client3_Username;
                        Label_ID = Label_Client3_ID;
                        Label_Target = Label_Client3_Target;
                        Label_X = Label_Client3_X;
                        Label_Y = Label_Client3_Y;
                        Label_Z = Label_Client3_Z;

                        goto updatedetails;
                    case 4:
                        Border_Position = Border_Client4_Position;
                        Border_Username = Border_Client4_Username;
                        Border_ID = Border_Client4_ID;
                        Border_Target = Border_Client4_Target;
                        Border_X = Border_Client4_X;
                        Border_Y = Border_Client4_Y;
                        Border_Z = Border_Client4_Z;

                        Label_Position = Label_Client4_Position;
                        Label_Username = Label_Client4_Username;
                        Label_ID = Label_Client4_ID;
                        Label_Target = Label_Client4_Target;
                        Label_X = Label_Client4_X;
                        Label_Y = Label_Client4_Y;
                        Label_Z = Label_Client4_Z;

                        goto updatedetails;
                    case 5:
                        Border_Position = Border_Client5_Position;
                        Border_Username = Border_Client5_Username;
                        Border_ID = Border_Client5_ID;
                        Border_Target = Border_Client5_Target;
                        Border_X = Border_Client5_X;
                        Border_Y = Border_Client5_Y;
                        Border_Z = Border_Client5_Z;

                        Label_Position = Label_Client5_Position;
                        Label_Username = Label_Client5_Username;
                        Label_ID = Label_Client5_ID;
                        Label_Target = Label_Client5_Target;
                        Label_X = Label_Client5_X;
                        Label_Y = Label_Client5_Y;
                        Label_Z = Label_Client5_Z;

                        goto updatedetails;
                    case 6:
                        Border_Position = Border_Client6_Position;
                        Border_Username = Border_Client6_Username;
                        Border_ID = Border_Client6_ID;
                        Border_Target = Border_Client6_Target;
                        Border_X = Border_Client6_X;
                        Border_Y = Border_Client6_Y;
                        Border_Z = Border_Client6_Z;

                        Label_Position = Label_Client6_Position;
                        Label_Username = Label_Client6_Username;
                        Label_ID = Label_Client6_ID;
                        Label_Target = Label_Client6_Target;
                        Label_X = Label_Client6_X;
                        Label_Y = Label_Client6_Y;
                        Label_Z = Label_Client6_Z;

                        goto updatedetails;
                    case 7:
                        Border_Position = Border_Client7_Position;
                        Border_Username = Border_Client7_Username;
                        Border_ID = Border_Client7_ID;
                        Border_Target = Border_Client7_Target;
                        Border_X = Border_Client7_X;
                        Border_Y = Border_Client7_Y;
                        Border_Z = Border_Client7_Z;

                        Label_Position = Label_Client7_Position;
                        Label_Username = Label_Client7_Username;
                        Label_ID = Label_Client7_ID;
                        Label_Target = Label_Client7_Target;
                        Label_X = Label_Client7_X;
                        Label_Y = Label_Client7_Y;
                        Label_Z = Label_Client7_Z;

                        goto updatedetails;
                    case 8:
                        Border_Position = Border_Client8_Position;
                        Border_Username = Border_Client8_Username;
                        Border_ID = Border_Client8_ID;
                        Border_Target = Border_Client8_Target;
                        Border_X = Border_Client8_X;
                        Border_Y = Border_Client8_Y;
                        Border_Z = Border_Client8_Z;

                        Label_Position = Label_Client8_Position;
                        Label_Username = Label_Client8_Username;
                        Label_ID = Label_Client8_ID;
                        Label_Target = Label_Client8_Target;
                        Label_X = Label_Client8_X;
                        Label_Y = Label_Client8_Y;
                        Label_Z = Label_Client8_Z;

                        goto updatedetails;
                    case 9:
                        Border_Position = Border_Client9_Position;
                        Border_Username = Border_Client9_Username;
                        Border_ID = Border_Client9_ID;
                        Border_Target = Border_Client9_Target;
                        Border_X = Border_Client9_X;
                        Border_Y = Border_Client9_Y;
                        Border_Z = Border_Client9_Z;

                        Label_Position = Label_Client9_Position;
                        Label_Username = Label_Client9_Username;
                        Label_ID = Label_Client9_ID;
                        Label_Target = Label_Client9_Target;
                        Label_X = Label_Client9_X;
                        Label_Y = Label_Client9_Y;
                        Label_Z = Label_Client9_Z;

                        goto updatedetails;
                        updatedetails:
                        if (flightId.HasValue)
                        {
                            Border_Position.Background = HasFlightID_Background;
                            Border_Username.Background = HasFlightID_Background;
                            Border_ID.Background = HasFlightID_Background;
                            Border_Target.Background = HasFlightID_Background;
                            Border_X.Background = HasFlightID_Background;
                            Border_Y.Background = HasFlightID_Background;
                            Border_Z.Background = HasFlightID_Background;

                            Label_Position.Foreground = HasFlightID_Foreground;
                            Label_Username.Foreground = HasFlightID_Foreground;
                            Label_ID.Foreground = HasFlightID_Foreground;
                            Label_Target.Foreground = HasFlightID_Foreground;
                            Label_X.Foreground = HasFlightID_Foreground;
                            Label_Y.Foreground = HasFlightID_Foreground;
                            Label_Z.Foreground = HasFlightID_Foreground;

                            Label_Username.Content = username ?? "<Error>";
                            Label_ID.Content = flightId.ToString() ?? "?????";
                            Label_Target.Content = "--";
                            Label_X.Content = "-----";
                            Label_Y.Content = "-----";
                            Label_Z.Content = "-----";
                        }
                        else
                        {
                            Border_Position.Background = NoFlightID_Background;
                            Border_Username.Background = Error_Background;
                            Border_ID.Background = NoFlightID_Background;
                            Border_Target.Background = NoFlightID_Background;
                            Border_X.Background = NoFlightID_Background;
                            Border_Y.Background = NoFlightID_Background;
                            Border_Z.Background = NoFlightID_Background;

                            Label_Position.Foreground = NoFlightID_Foreground;
                            Label_Username.Foreground = Error_Foreground;
                            Label_ID.Foreground = NoFlightID_Foreground;
                            Label_Target.Foreground = NoFlightID_Foreground;
                            Label_X.Foreground = NoFlightID_Foreground;
                            Label_Y.Foreground = NoFlightID_Foreground;
                            Label_Z.Foreground = NoFlightID_Foreground;

                            Label_Username.Content = username ?? "<Not Connected>";
                            Label_ID.Content = "-----";
                            Label_Target.Content = "--";
                            Label_X.Content = "-----";
                            Label_Y.Content = "-----";
                            Label_Z.Content = "-----";
                        }
                        break;
                    default:
                    {
                        Debug.AddWarningMessage(
                            "Attempted to update a formation position with invalid formation position number!");
                        break;
                    }
                }
            });
        }
        public void UpdateClientFormationPosition(int formationPositionNumber, int? targetPositionNumber, double? xPosition, double? yPosition, double? zPosition)
        {
            Dispatcher.Invoke(() =>
            {
                SolidColorBrush InFormation_Foreground = new SolidColorBrush(Color.FromRgb(240, 240, 240));
                SolidColorBrush InFormation_Background = new SolidColorBrush(Color.FromRgb(0, 240, 0));

                SolidColorBrush NoFormation_Foreground = new SolidColorBrush(Color.FromRgb(170, 170, 170));
                SolidColorBrush NoFormation_Background = new SolidColorBrush(Color.FromRgb(22, 22, 22));
                
                SolidColorBrush Error_Foreground = new SolidColorBrush(Color.FromRgb(240, 0, 0));
                SolidColorBrush Error_Background = new SolidColorBrush(Color.FromRgb(22, 22, 00));

                Border Border_Position = null;
                Border Border_Username = null;
                Border Border_ID = null;
                Border Border_Target = null;
                Border Border_X = null;
                Border Border_Y = null;
                Border Border_Z = null;

                Label Label_Position = null;
                Label Label_Username = null;
                Label Label_ID = null;
                Label Label_Target = null;
                Label Label_X = null;
                Label Label_Y = null;
                Label Label_Z = null;

                switch (formationPositionNumber)
                {
                    case 1:
                        Border_Position = Border_Client1_Position;
                        Border_Username = Border_Client1_Username;
                        Border_ID = Border_Client1_ID;
                        Border_Target = Border_Client1_Target;
                        Border_X = Border_Client1_X;
                        Border_Y = Border_Client1_Y;
                        Border_Z = Border_Client1_Z;

                        Label_Position = Label_Client1_Position;
                        Label_Username = Label_Client1_Username;
                        Label_ID = Label_Client1_ID;
                        Label_Target = Label_Client1_Target;
                        Label_X = Label_Client1_X;
                        Label_Y = Label_Client1_Y;
                        Label_Z = Label_Client1_Z;

                        goto updatedetails;
                    case 2:
                        Border_Position = Border_Client2_Position;
                        Border_Username = Border_Client2_Username;
                        Border_ID = Border_Client2_ID;
                        Border_Target = Border_Client2_Target;
                        Border_X = Border_Client2_X;
                        Border_Y = Border_Client2_Y;
                        Border_Z = Border_Client2_Z;

                        Label_Position = Label_Client2_Position;
                        Label_Username = Label_Client2_Username;
                        Label_ID = Label_Client2_ID;
                        Label_Target = Label_Client2_Target;
                        Label_X = Label_Client2_X;
                        Label_Y = Label_Client2_Y;
                        Label_Z = Label_Client2_Z;

                        goto updatedetails;
                    case 3:
                        Border_Position = Border_Client3_Position;
                        Border_Username = Border_Client3_Username;
                        Border_ID = Border_Client3_ID;
                        Border_Target = Border_Client3_Target;
                        Border_X = Border_Client3_X;
                        Border_Y = Border_Client3_Y;
                        Border_Z = Border_Client3_Z;

                        Label_Position = Label_Client3_Position;
                        Label_Username = Label_Client3_Username;
                        Label_ID = Label_Client3_ID;
                        Label_Target = Label_Client3_Target;
                        Label_X = Label_Client3_X;
                        Label_Y = Label_Client3_Y;
                        Label_Z = Label_Client3_Z;

                        goto updatedetails;
                    case 4:
                        Border_Position = Border_Client4_Position;
                        Border_Username = Border_Client4_Username;
                        Border_ID = Border_Client4_ID;
                        Border_Target = Border_Client4_Target;
                        Border_X = Border_Client4_X;
                        Border_Y = Border_Client4_Y;
                        Border_Z = Border_Client4_Z;

                        Label_Position = Label_Client4_Position;
                        Label_Username = Label_Client4_Username;
                        Label_ID = Label_Client4_ID;
                        Label_Target = Label_Client4_Target;
                        Label_X = Label_Client4_X;
                        Label_Y = Label_Client4_Y;
                        Label_Z = Label_Client4_Z;

                        goto updatedetails;
                    case 5:
                        Border_Position = Border_Client5_Position;
                        Border_Username = Border_Client5_Username;
                        Border_ID = Border_Client5_ID;
                        Border_Target = Border_Client5_Target;
                        Border_X = Border_Client5_X;
                        Border_Y = Border_Client5_Y;
                        Border_Z = Border_Client5_Z;

                        Label_Position = Label_Client5_Position;
                        Label_Username = Label_Client5_Username;
                        Label_ID = Label_Client5_ID;
                        Label_Target = Label_Client5_Target;
                        Label_X = Label_Client5_X;
                        Label_Y = Label_Client5_Y;
                        Label_Z = Label_Client5_Z;

                        goto updatedetails;
                    case 6:
                        Border_Position = Border_Client6_Position;
                        Border_Username = Border_Client6_Username;
                        Border_ID = Border_Client6_ID;
                        Border_Target = Border_Client6_Target;
                        Border_X = Border_Client6_X;
                        Border_Y = Border_Client6_Y;
                        Border_Z = Border_Client6_Z;

                        Label_Position = Label_Client6_Position;
                        Label_Username = Label_Client6_Username;
                        Label_ID = Label_Client6_ID;
                        Label_Target = Label_Client6_Target;
                        Label_X = Label_Client6_X;
                        Label_Y = Label_Client6_Y;
                        Label_Z = Label_Client6_Z;

                        goto updatedetails;
                    case 7:
                        Border_Position = Border_Client7_Position;
                        Border_Username = Border_Client7_Username;
                        Border_ID = Border_Client7_ID;
                        Border_Target = Border_Client7_Target;
                        Border_X = Border_Client7_X;
                        Border_Y = Border_Client7_Y;
                        Border_Z = Border_Client7_Z;

                        Label_Position = Label_Client7_Position;
                        Label_Username = Label_Client7_Username;
                        Label_ID = Label_Client7_ID;
                        Label_Target = Label_Client7_Target;
                        Label_X = Label_Client7_X;
                        Label_Y = Label_Client7_Y;
                        Label_Z = Label_Client7_Z;

                        goto updatedetails;
                    case 8:
                        Border_Position = Border_Client8_Position;
                        Border_Username = Border_Client8_Username;
                        Border_ID = Border_Client8_ID;
                        Border_Target = Border_Client8_Target;
                        Border_X = Border_Client8_X;
                        Border_Y = Border_Client8_Y;
                        Border_Z = Border_Client8_Z;

                        Label_Position = Label_Client8_Position;
                        Label_Username = Label_Client8_Username;
                        Label_ID = Label_Client8_ID;
                        Label_Target = Label_Client8_Target;
                        Label_X = Label_Client8_X;
                        Label_Y = Label_Client8_Y;
                        Label_Z = Label_Client8_Z;

                        goto updatedetails;
                    case 9:
                        Border_Position = Border_Client9_Position;
                        Border_Username = Border_Client9_Username;
                        Border_ID = Border_Client9_ID;
                        Border_Target = Border_Client9_Target;
                        Border_X = Border_Client9_X;
                        Border_Y = Border_Client9_Y;
                        Border_Z = Border_Client9_Z;

                        Label_Position = Label_Client9_Position;
                        Label_Username = Label_Client9_Username;
                        Label_ID = Label_Client9_ID;
                        Label_Target = Label_Client9_Target;
                        Label_X = Label_Client9_X;
                        Label_Y = Label_Client9_Y;
                        Label_Z = Label_Client9_Z;

                        goto updatedetails;
                        updatedetails:
                        if (targetPositionNumber.HasValue)
                        {
                            Border_Position.Background = InFormation_Background;
                            Border_Username.Background = InFormation_Background;
                            Border_ID.Background = InFormation_Background;
                            Border_Target.Background = InFormation_Background;
                            Border_X.Background = InFormation_Background;
                            Border_Y.Background = InFormation_Background;
                            Border_Z.Background = InFormation_Background;

                            Label_Position.Foreground = InFormation_Foreground;
                            Label_Username.Foreground = InFormation_Foreground;
                            Label_ID.Foreground = InFormation_Foreground;
                            Label_Target.Foreground = InFormation_Foreground;
                            Label_X.Foreground = InFormation_Foreground;
                            Label_Y.Foreground = InFormation_Foreground;
                            Label_Z.Foreground = InFormation_Foreground;

                            Label_Target.Content = "#" + targetPositionNumber;
                            Label_X.Content = xPosition.HasValue
                                ? Math.Round(xPosition.Value, 0).ToString(CultureInfo.InvariantCulture)
                                : "-----";
                            Label_Y.Content = yPosition.HasValue
                                ? Math.Round(yPosition.Value, 0).ToString(CultureInfo.InvariantCulture)
                                : "-----";
                            Label_Z.Content = zPosition.HasValue
                                ? Math.Round(zPosition.Value, 0).ToString(CultureInfo.InvariantCulture)
                                : "-----";
                        }
                        else
                        {
                            Border_Position.Background = NoFormation_Background;
                            Border_Username.Background = NoFormation_Background;
                            Border_ID.Background = NoFormation_Background;
                            Border_Target.Background = NoFormation_Background;
                            Border_X.Background = NoFormation_Background;
                            Border_Y.Background = NoFormation_Background;
                            Border_Z.Background = NoFormation_Background;

                            Label_Position.Foreground = NoFormation_Foreground;
                            Label_Username.Foreground = NoFormation_Foreground;
                            Label_ID.Foreground = NoFormation_Foreground;
                            Label_Target.Foreground = NoFormation_Foreground;
                            Label_X.Foreground = NoFormation_Foreground;
                            Label_Y.Foreground = NoFormation_Foreground;
                            Label_Z.Foreground = NoFormation_Foreground;

                            Label_Target.Content = "--";
                            Label_X.Content = xPosition.HasValue
                                ? Math.Round(xPosition.Value, 0).ToString(CultureInfo.InvariantCulture)
                                : "-----";
                            Label_Y.Content = yPosition.HasValue
                                ? Math.Round(yPosition.Value, 0).ToString(CultureInfo.InvariantCulture)
                                : "-----";
                            Label_Z.Content = zPosition.HasValue
                                ? Math.Round(zPosition.Value, 0).ToString(CultureInfo.InvariantCulture)
                                : "-----";
                        }
                        break;
                    default:
                    {
                        Debug.AddWarningMessage(
                            "Attempted to update a formation position with invalid formation position number!");
                        break;
                    }
                }
            });
        }

        public void UpdateHostAddressFromSettings()
        {
            Dispatcher.Invoke(() =>
            {
                TextBox_HostAddress.Text =
                    (SettingsLibrary.Settings.Server.ProxyServer.DestinationAddress?.ToString() ?? "255.255.255.255") +
                    ":" + SettingsLibrary.Settings.Server.ProxyServer.DestinationPort.ToString();
                TextBox_HostAddress.IsReadOnly = true;
                TextBox_HostAddress.IsReadOnlyCaretVisible = false;
            });
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
        public static void ChangeTitle(string newTitle) => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.ChangeTitle(newTitle));
        public static Boolean IsVisible => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.IsVisible);
        #endregion
        #region Wait Load/Close
        public static bool WaitForCreation(int timeout = Int32.MaxValue) => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.WaitForCreation(timeout));
        public static bool WaitForClose(int timeout = Int32.MaxValue) => formationInspectorWindow.WaitForClose(timeout);
        #endregion

        public static void LinkFormationInspector() => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.LinkFormationInspector());

        #region ChangeProperties
        public static void UpdateClientFormationHost(int formationPositionNumber, string username, int? flightId) => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.UpdateClientFormationHost(formationPositionNumber, username, flightId));
        public static void UpdateClientFormationPosition(int formationPositionNumber, int? targetPositionNumber, double? xPosition, double? yPosition, double? zPosition) => formationInspectorWindow.Dispatcher.Invoke(() => formationInspectorWindow.UpdateClientFormationPosition(formationPositionNumber, targetPositionNumber, xPosition, yPosition, zPosition));
        #endregion
    }
}
