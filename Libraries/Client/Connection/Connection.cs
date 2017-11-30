using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Com.OfficerFlake.Libraries.Networking
{
    public class Connection
    {
	    #region ConnectionNumber
	    private static int ConnectionIDIncrementer = 0;
	    public int ConnectionNumber
	    {
		    get;
	    }
	    #endregion

		public Connection()
	    {
		    ConnectionNumber = ConnectionIDIncrementer++;
		}

		#region Sockets
		#region TCP/IP
		private Socket TCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	    private delegate void TCPPacketReceivedEvent(Connection thisConnection, GenericPacket thisPacket);
	    private event TCPPacketReceivedEvent TCPPacketReceived = TCPPacketReceivedEventSignalled;
		#region Reciever
		private class TCPSocketReadObject
	    {
		    // Size
		    public byte[] sizebuffer = new byte[4];
		    public int size = 0;

		    // Data
		    public byte[] databuffer = null;

		    // Operating...
		    public int bytesreceivedsofar = 0;
	    }
	    private void TCPStartToRecieveNewPacket()
	    {
		    TCPReceiveHeader();
	    }
		private void TCPReceiveHeader()
		{
			lock (TCPSocket)
			{
				try
				{
					//Debug.WriteLine("Test Async");
					// Create the state object.
					TCPSocketReadObject state = new TCPSocketReadObject();

					// Begin receiving the data from the remote device.
					//Debug.WriteLine("Start Receiving");
					TCPSocket.BeginReceive(state.sizebuffer, 0, 4, 0,
						new AsyncCallback(TCPReceiveHeaderCallback), state);
				}
				catch (SocketException)
				{
					//Client.Disconnect("Remote client forcibly closed the connection.");
					return;
				}
				catch (Exception)
				{
					//Debug.WriteLine(e.ToString());
					//Client.Disconnect("Failed to receive packet header.");
					return;
				}
			}
		}
		private void TCPReceiveHeaderCallback(IAsyncResult ar)
		{
			lock (TCPSocket)
			{
				try
				{
					// Retrieve the state object and the client socket 
					// from the asynchronous state object.
					TCPSocketReadObject state = (TCPSocketReadObject)ar.AsyncState;
					// Read data from the remote device.
					int bytesRead = TCPSocket.EndReceive(ar);
					if (bytesRead == 0)
					{
						//End Of Stream
						//Debug.WriteLine("End of DataStrem");
						//Client.Disconnect("Recv'd 0 data when trying to receive packet header.");
					}
					state.bytesreceivedsofar += bytesRead;
					if (state.bytesreceivedsofar < 4)
					{
						// need more data, so store the data received so far.
						//state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
						//  Get the rest of the data.
						//client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
						//new AsyncCallback(ReceiveHeaderCallback), state);
						TCPSocket.BeginReceive(state.sizebuffer, state.bytesreceivedsofar, 4 - state.bytesreceivedsofar, SocketFlags.None,
						new AsyncCallback(TCPReceiveHeaderCallback), state);
						return;
					}
					else
					{
						// All bytes have been received.
						TCPReceivePayload(state);
					}
				}
				catch (SocketException)
				{
					//Client.Disconnect("Remote client forcibly closed the connection.");
					return;
				}
				catch (Exception)
				{
					//Debug.WriteLine(e.ToString());
					//Client.Disconnect("Generic Error when trying to receive packet header.");
					return;
				}
			}
		}
		private void TCPReceivePayload(TCPSocketReadObject state)
		{
			lock (TCPSocket)
			{
				try
				{
					// Get Size...
					state.size = (int)(BitConverter.ToUInt32(state.sizebuffer, 0));
					state.bytesreceivedsofar = 0;
					state.databuffer = new byte[state.size];

					// Begin receiving the data from the remote device.
					TCPSocket.BeginReceive(state.databuffer, state.bytesreceivedsofar, state.size - state.bytesreceivedsofar, SocketFlags.None,
						new AsyncCallback(TCPReceivePayloadCallback), state);
				}
				catch (SocketException)
				{
					//Client.Disconnect("Remote client forcibly closed the connection.");
					return;
				}
				catch (Exception)
				{
					//Debug.WriteLine(e.ToString());
					//Client.Disconnect("Failed to receive packet body.");
					return;
				}
			}
		}
		private void TCPReceivePayloadCallback(IAsyncResult ar)
		{
			GenericPacket NewPacket = null;
			lock (TCPSocket)
			{
				try
				{
					// Retrieve the state object and the client socket 
					// from the asynchronous state object.
					TCPSocketReadObject state = (TCPSocketReadObject)ar.AsyncState;
					// Read data from the remote device.
					int bytesRead = TCPSocket.EndReceive(ar);
					if (bytesRead == 0)
					{
						//End Of Stream
						//Debug.WriteLine("End of DataStream");
						//Client.Disconnect("Recv'd 0 data when trying to receive packet body.");
					}
					state.bytesreceivedsofar += bytesRead;
					if (state.bytesreceivedsofar < state.size)
					{
						TCPSocket.BeginReceive(state.databuffer, state.bytesreceivedsofar, state.size - state.bytesreceivedsofar, SocketFlags.None,
							new AsyncCallback(TCPReceivePayloadCallback), state);
						return;
					}
					else
					{
						//Debug.WriteLine(state.sizebuffer.ToDebugHexString() + state.databuffer.ToDebugHexString());
						//Debug.TestPoint();

						// All bytes have been received.
						if (state.databuffer.Length > 4)
						{
							byte[] typedata = new byte[4];
							Array.Copy(state.databuffer, 0, typedata, 0, 4);
							int type = BitConverter.ToInt32(typedata, 0);

							byte[] data = new byte[state.databuffer.Length - 4];
							Array.Copy(state.databuffer, 4, typedata, 0, state.databuffer.Length - 4);

							NewPacket = new GenericPacket(0, state.databuffer);
						}
						//Debug.WriteLine("End Receiving");
					}
				}
				catch (SocketException)
				{
					//Client.Disconnect("Remote client forcibly closed the connection.");
					return;
				}
				catch (Exception)
				{
					//Console.WriteLine(e.ToString());
					//Client.Disconnect("Generic Error when trying to receive packet body.");
					return;
				}
			}
			TCPPacketReceived(this, NewPacket);
		}
	    private static void TCPPacketReceivedEventSignalled(Connection thisConnection, GenericPacket thisPacket)
	    {
		    thisConnection.InformPacketReceived(thisConnection, thisPacket);
			thisConnection.TCPStartToRecieveNewPacket();
	    }
		#endregion
		#endregion
		#region UDP
		private Socket UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		private static UdpClient UDPReciever = new UdpClient();

	    private static void UDPStartRecieve()
	    {
		    try
		    {
			    UDPReciever.BeginReceive(new AsyncCallback(UDPEndRecieve), null);
		    }
		    catch
		    {
		    }
	    }
	    private static void UDPEndRecieve(IAsyncResult res)
	    {
		    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 7916);
		    byte[] received = UDPReciever.EndReceive(res, ref RemoteIpEndPoint);

		    UDPStartRecieve();
	    }
		#endregion
		#endregion

		#region PacketReceived Signalling
		private delegate void PacketReceivedEvent(Connection thisConnection, GenericPacket thisPacket);
	    private event PacketReceivedEvent InformPacketReceived = PacketRecievedEventSignalled;
	    private static void PacketRecievedEventSignalled(Connection thisConncetion, GenericPacket thisPacket)
	    {
		    //Action Packet.
			thisConncetion.ProcessPacket(thisPacket);
	    }

	    private void ProcessPacket(GenericPacket thisPacket)
	    {
		    return;
	    }
		#endregion
    }
}
