using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.UserInterfaces
{
	public partial class PacketInspectorUserInterface : OYS_Window
	{
		public PacketInspectorUserInterface()
		{
			InitializeComponent();
		}

		#region Properties
		private IPacket LastPacket = null;

		private IConnection TargetClient = null;
		private bool ServerToClient = true;
		private bool ClientToServer
		{
			get => !ServerToClient;
			set => ServerToClient = !value;
		}
		private int TargetPacketType = 0;
		private int TargetStartPosition = 0;
		private int TargetEndPosition = 4;
		#endregion
		#region Methods
		public void UpdateClient(IConnection thisConnection)
		{
			if (thisConnection != null) TargetClient = thisConnection;
		}
		public void UpdateDirection(bool serverToClient)
		{
			ServerToClient = serverToClient;
		}
		public void UpdateType(int type)
		{
			if (TargetPacketType > 0) TargetPacketType = type;
		}
		public void UpdateStartPosition(int startPosition)
		{
			if (startPosition >= 0) TargetStartPosition = startPosition;
		}
		public void UpdateEndPosition(int endPosition)
		{
			if (endPosition >= 0) TargetEndPosition = endPosition;
		}
		#endregion

		private void ClientSelector_OnDropDownOpened(object sender, EventArgs e)
		{
			RefreshClientList();
		}
		public void RefreshClientList()
		{
			ClientSelector.Items.Clear();
			ClientSelector.Items.Add("None");
			foreach (IConnection thisConnection in Connections.AllConnections)
			{
				ClientSelector.Items.Add(thisConnection.User.UserName.ToUnformattedSystemString());
			}
			ClientSelector.Items.Add("All");
		}
	}

	/// <summary>
	/// UI Window for the Server Program. All Console/Debug Messages come through here.
	/// </summary>
	public static class OpenYSPacketInspectorUserInterface
	{
		private static PacketInspectorUserInterface packetInspectorWindow;

		#region Create/Close
		public static void CreateWindow() => packetInspectorWindow = UserInterface.CreateWindow<PacketInspectorUserInterface>();
		public static void CloseWindow() => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.Close());
		#endregion
		#region Show/Hide
		public static void Show() => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.Show());
		public static void Hide() => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.Hide());
		#endregion
		#region Wait Load/Close
		public static bool WaitForCreation(int timeout = Int32.MaxValue) => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.WaitForCreation(timeout));
		public static bool WaitForClose(int timeout = Int32.MaxValue) => packetInspectorWindow.WaitForClose(timeout);
		#endregion

		#region ChangeProperties
		public static void UpdateClient(IConnection thisConnection) => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.UpdateClient(thisConnection));
		public static void UpdateDirection(bool serverToClient) => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.UpdateDirection(serverToClient));
		public static void UpdateType(int type) => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.UpdateType(type));
		public static void UpdateStartPosition(int startPosition) => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.UpdateStartPosition(startPosition));
		public static void UpdateEndPosition(int endPosition) => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.UpdateEndPosition(endPosition));
		#endregion
	}
}