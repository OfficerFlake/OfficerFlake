using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.UserInterfaces
{
	public partial class PacketInspectorUserInterface : OYS_Window, IPacketInspector
	{
		public PacketInspectorUserInterface()
		{
			InitializeComponent();
		}

		#region Properties
		private IPacket LastPacket = null;

		private IConnection TargetClient = null;
		public IConnection Client => TargetClient;

		private bool ServerToClient = true;
		private bool ClientToServer
		{
			get => !ServerToClient;
			set => ServerToClient = !value;
		}
		public DataDirection DataDirection => ServerToClient ? DataDirection.ServerToClient : DataDirection.ClientToServer;

		private int TargetPacketType = 0;
		public Int32 Type => TargetPacketType;

		private int TargetStartPosition = 0;
		private int TargetEndPosition = 4;
		#endregion
		#region Methods
		public void LinkPacketInspector()
		{
			Logger.PacketInspector.LinkPacketInspector(this);
		}

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

		public void UpdatePacket(IPacket Input)
		{
			LastPacket = Input;
			if (TargetStartPosition >= TargetEndPosition) return;

			//Binary
			Dispatcher.Invoke(() =>
			{
				try
				{
					BinaryTextBox.Text = Input.Data.Skip(TargetStartPosition).ToArray()[0].ToBinaryString();
				}
				catch
				{
					BinaryTextBox.Text = "ERR";
				}
			});

			//SByte
			Dispatcher.Invoke(() =>
			{
				try
				{
					SByteTextBox.Text = ((sbyte) Input.Data.Skip(TargetStartPosition).ToArray()[0]).ToString();
				}
				catch
				{
					SByteTextBox.Text = "ERR";
				}
			});
			//Byte
			Dispatcher.Invoke(() =>
			{
				try
				{
					ByteTextBox.Text = (Input.Data.Skip(TargetStartPosition).ToArray()[0]).ToString();
				}
				catch
				{
					ByteTextBox.Text = "ERR";
				}
			});

			//Int16
			Dispatcher.Invoke(() =>
			{
				try
				{
					Int16TextBox.Text = (BitConverter.ToInt16(Input.Data.Skip(TargetStartPosition).ToArray(), 0)).ToString();
				}
				catch
				{
					Int16TextBox.Text = "ERR";
				}
			});
			//UInt16
			Dispatcher.Invoke(() =>
			{
				try
				{
					UInt16TextBox.Text = (BitConverter.ToUInt16(Input.Data.Skip(TargetStartPosition).ToArray(), 0)).ToString();
				}
				catch
				{
					UInt16TextBox.Text = "ERR";
				}
			});

			//Int32
			Dispatcher.Invoke(() =>
			{
				try
				{
					Int32TextBox.Text = (BitConverter.ToInt32(Input.Data.Skip(TargetStartPosition).ToArray(), 0)).ToString();
				}
				catch
				{
					Int32TextBox.Text = "ERR";
				}
			});
			//UInt32
			Dispatcher.Invoke(() =>
			{

				try
				{
					UInt32TextBox.Text = (BitConverter.ToUInt32(Input.Data.Skip(TargetStartPosition).ToArray(), 0)).ToString();
				}
				catch
				{
					UInt32TextBox.Text = "ERR";
				}
			});

			//Int64
			Dispatcher.Invoke(() =>
			{
				try
				{
					Int64TextBox.Text = (BitConverter.ToInt64(Input.Data.Skip(TargetStartPosition).ToArray(), 0)).ToString();
				}
				catch
				{
					Int64TextBox.Text = "ERR";
				}
			});
			//UInt64
			Dispatcher.Invoke(() =>
			{

				try
				{
					UInt64TextBox.Text = (BitConverter.ToUInt64(Input.Data.Skip(TargetStartPosition).ToArray(), 0)).ToString();
				}
				catch
				{
					UInt64TextBox.Text = "ERR";
				}
			});

			//Single
			Dispatcher.Invoke(() =>
			{
				try
				{
					SingleTextBox.Text = (BitConverter.ToSingle(Input.Data.Skip(TargetStartPosition).ToArray(), 0)).ToString();
				}
				catch
				{
					SingleTextBox.Text = "ERR";
				}
			});
			//Double
			Dispatcher.Invoke(() =>
			{

				try
				{
					DoubleTextBox.Text = (BitConverter.ToDouble(Input.Data.Skip(TargetStartPosition).ToArray(), 0)).ToString();
				}
				catch
				{
					DoubleTextBox.Text = "ERR";
				}
			});

			//String
			Dispatcher.Invoke(() =>
			{
				try
				{
					StringTextBox.Text = Input.Data.Skip(TargetStartPosition).Take(TargetEndPosition - TargetStartPosition).ToArray().ToSystemString();
				}
				catch
				{
					StringTextBox.Text = "ERR";
				}
			});
			//Raw
			Dispatcher.Invoke(() =>
			{

				try
				{
					RawTextBox.Text = Input.Data.Skip(TargetStartPosition).Take(TargetEndPosition-TargetStartPosition).ToArray().ToHexString();
				}
				catch
				{
					RawTextBox.Text = "ERR";
				}
			});
		}
		private void RecalculatePacket()
		{
			UpdatePacket(LastPacket);
		}
		#endregion

		private void ClientSelector_OnDropDownOpened(object sender, EventArgs e)
		{
			RefreshClientList();
		}
		private void RefreshClientList()
		{
			ClientSelector.Items.Clear();
			foreach (IConnection thisConnection in Connections.AllConnections)
			{
				ClientSelector.Items.Add(thisConnection.User.UserName.ToUnformattedSystemString());
			}
			ClientSelector.Items.Add("All");
		}

		private void ClientSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string text = (sender as ComboBox)?.SelectedItem as string ?? "None";
			try
			{
				TargetClient = Connections.AllConnections?
					.Where(x => string.Equals(x.User.UserName.ToUnformattedSystemString().ToUpperInvariant(),
						text.ToUpperInvariant(), StringComparison.InvariantCultureIgnoreCase))
					.ToArray()[0];
			}
			catch
			{
				TargetClient = null;
			}
		}
		private void DirectionSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ServerToClient = (((sender as ComboBox)?.SelectedItem as string) ?? "Server->Client") == "Server->Client";
		}
		private void TypeTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			Int32.TryParse((sender as TextBox)?.Text ?? "0", out TargetPacketType);
		}
		private void StartTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			Int32.TryParse((sender as TextBox)?.Text ?? "0", out TargetStartPosition);
			if (LastPacket != null) RecalculatePacket();
		}
		private void EndTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			Int32.TryParse((sender as TextBox)?.Text ?? "0", out TargetEndPosition);
			if (LastPacket != null) RecalculatePacket();
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

		public static void LinkPacketInspector() => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.LinkPacketInspector());

		#region ChangeProperties
		public static void UpdateClient(IConnection thisConnection) => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.UpdateClient(thisConnection));
		public static void UpdateDirection(bool serverToClient) => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.UpdateDirection(serverToClient));
		public static void UpdateType(int type) => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.UpdateType(type));
		public static void UpdateStartPosition(int startPosition) => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.UpdateStartPosition(startPosition));
		public static void UpdateEndPosition(int endPosition) => packetInspectorWindow.Dispatcher.Invoke(() => packetInspectorWindow.UpdateEndPosition(endPosition));
		#endregion
	}
}