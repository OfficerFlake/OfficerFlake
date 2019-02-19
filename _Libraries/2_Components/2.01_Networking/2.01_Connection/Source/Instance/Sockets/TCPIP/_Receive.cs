using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Debug = Com.OfficerFlake.Libraries.Logger.Debug;

namespace Com.OfficerFlake.Libraries.Networking
{
    public partial class Connection : IConnection
	{
        private UInt32 TcpGetPacketHeader(Socket _TCPSocket)
		{
			byte[] sizeBuffer = new byte[4];
			goto Receive;

			//Get Data.
			Receive:
			try
			{
				_TCPSocket.Receive(sizeBuffer, 4, SocketFlags.None);
				goto Convert;
			}
			catch (ArgumentNullException e)
			{
                Debug.AddErrorMessage(e, "Buffer is Null.");
			}
			catch (ArgumentOutOfRangeException e)
			{
			    Debug.AddErrorMessage(e, "Size of Data is larger than size of Buffer.");
                //size exceeds buffer.
            }
			catch (SocketException e)
			{
			    Debug.AddErrorMessage(e, "Winsock is in an error state.");
                //WinSock Error.
            }
			catch (ObjectDisposedException e)
			{
			    Debug.AddErrorMessage(e, "Socket has been closed by the operating system.");
                //Socket Closed.
            }
			catch (System.Security.SecurityException e)
			{
			    Debug.AddErrorMessage(e, "Security Exception.");
                //Caller in Stack doesn't have permissions.
            }
			return 0;

			//Convert Data.
			Convert:
			try
			{
                uint SizeOutput = BitConverter.ToUInt32(sizeBuffer, 0);
                Debug.AddDetailMessage("Size of Incoming Packet is: \"" + (int)SizeOutput + "\".");
			    return SizeOutput;
			}
			catch (ArgumentNullException e)
			{
                Debug.AddErrorMessage(e, "sizeBuffer is Null.");
			}
			catch (ArgumentOutOfRangeException e)
			{
			    Debug.AddErrorMessage(e, "Buffer index is out of range.");
            }
			catch (ArgumentException e)
			{
			    Debug.AddErrorMessage(e, "The buffer contents cannot be represented as UInt32.");
            }
			return 0;
		}
        private byte[] TcpGetPacketBody(UInt32 size, Socket _TCPSocket)
		{
			byte[] bodyBuffer = new byte[size];

			//Get Data.
			try
			{
				_TCPSocket.Receive(bodyBuffer, (int) size, SocketFlags.None);
			}
			catch (ArgumentNullException e)
			{
			    Debug.AddErrorMessage(e, "Buffer is Null.");
			}
			catch (ArgumentOutOfRangeException e)
			{
			    Debug.AddErrorMessage(e, "Size of Data is larger than size of Buffer.");
			    //size exceeds buffer.
			}
			catch (SocketException e)
			{
			    Debug.AddErrorMessage(e, "Winsock is in an error state.");
			    //WinSock Error.
			}
			catch (ObjectDisposedException e)
			{
			    Debug.AddErrorMessage(e, "Socket has been closed by the operating system.");
			    //Socket Closed.
			}
			catch (System.Security.SecurityException e)
			{
			    Debug.AddErrorMessage(e, "Security Exception.");
			    //Caller in Stack doesn't have permissions.
			}
		    Debug.AddDetailMessage("Recieved \"" + bodyBuffer.Length + "\" bytes of data to complete a packet.");
            return bodyBuffer;
		}

        private IPacket TcpGetPacket(Socket _TCPSocket)
		{
		    lock (_TCPSocket) //Must ensure only one task can recieve a packet at a time!
		    {
		        Debug.AddDetailMessage("Connection " + ConnectionNumber + " has entered the lock in TCPGetPacket");

                #region Init

                IPacket output = null;

		        UInt32 size;
		        byte[] body;

		        #endregion

		        #region GetData

		        try
		        {
		            size = TcpGetPacketHeader(_TCPSocket);
		            goto Body;
		        }
		        catch (ArgumentNullException e)
		        {
                    Debug.AddWarningMessage("Null Packet returned from TCPGetPacketHeader()");
		            //thisPacket is Null.
		        }
		        Debug.AddDetailMessage("Connection " + ConnectionNumber + " is leaving the lock in TCPGetPacket");
                return output;

		        Body:
		        try
		        {
		            body = TcpGetPacketBody(size, _TCPSocket);
		            goto PrepareType;
		        }
		        catch (ArgumentNullException)
		        {
		            Debug.AddWarningMessage("Null Packet returned from TCPGetPacketBody()");
                    //thisPacket is Null.
                }
		        Debug.AddDetailMessage("Connection " + ConnectionNumber + " is leaving the lock in TCPGetPacket");
                return output;

		        #endregion

		        #region Type

		        PrepareType:
		        byte[] typeBuffer;
		        try
		        {
		            typeBuffer = body.Take(4).ToArray();
		            goto ConvertType;
		        }
		        catch (ArgumentNullException e)
		        {
		            Debug.AddErrorMessage(e, "body is Null when trying to identify data Type.");
                    //body is null.
                }
		        Debug.AddDetailMessage("Connection " + ConnectionNumber + " is leaving the lock in TCPGetPacket");
                return output;

		        ConvertType:
		        UInt32 type;
		        try
		        {
		            type = BitConverter.ToUInt32(typeBuffer, 0);
		            goto PrepareData;
		        }
		        catch (ArgumentNullException e)
		        {
                    Debug.AddErrorMessage(e, "typeBuffer is Null.");
		        }
		        catch (ArgumentOutOfRangeException e)
		        {
		            Debug.AddErrorMessage(e, "startIndex is out of range of the array.");
                }
		        catch (ArgumentException e)
		        {
                    Debug.AddErrorMessage(e, "Type cannot be represented as a UInt32.");
		        }
		        return output;

		        #endregion

		        #region Data

		        PrepareData:
		        byte[] data;
		        try
		        {
		            data = body.Skip(4).ToArray();
		            goto Combine;
		        }
		        catch (ArgumentNullException e)
		        {
		            Debug.AddErrorMessage(e, "body is null");
		        }
		        Debug.AddDetailMessage("Connection " + ConnectionNumber + " is leaving the lock in TCPGetPacket");
                return output;

		        #endregion

		        #region BuildPacket

		        Combine:
		        try
		        {
		            output = ObjectFactory.CreateGenericPacket();
		            output.ResizeData((int) size);
		            output.Type = type;
		            output.Data = data;
		            if (Logger.PacketInspector.Client == null | Logger.PacketInspector.Client == this)
		            {
		                if (Logger.PacketInspector.DataDirection == DataDirection.ClientToServer)
		                {
		                    if (Logger.PacketInspector.Type == output.Type) Logger.PacketInspector.UpdatePacket(output);
		                }
		            }
		        }
		        catch (ArgumentNullException e)
		        {
                    Debug.AddWarningMessage("Output packet from TCPGetPacket is null.");
		            output = null;
		        }
		        Debug.AddDetailMessage("Connection " + ConnectionNumber + " is leaving the lock in TCPGetPacket");
		        return output;
                #endregion
            }
		}
        private async Task<IPacket> TcpGetPacketAsync(Socket _TCPSocket)
		{
            //Get the Packet
		    if (_TCPSocket == ClientStreamTCPSocket) Debug.AddDetailMessage("Client "+ConnectionNumber+" is starting the TCPGetPacket Phase from the ClientStream");
		    if (_TCPSocket == HostStreamTCPSocket) Debug.AddDetailMessage("Connection " + ConnectionNumber + "  is starting the TCPGetPacket Phase from the HostStream");
		    if (_TCPSocket != HostStreamTCPSocket & _TCPSocket != ClientStreamTCPSocket) Debug.AddWarningMessage("Connection " + ConnectionNumber + "  made a call to TCPGetPacket with a non-assigned socket!?!?!?");
            IPacket receivedPacket = null;
		    Debug.AddDetailMessage("Connection " + ConnectionNumber + " is making a call to TCPGetPacketAsync");
            receivedPacket = await Task.Run(() => TcpGetPacket(_TCPSocket));
		    Debug.AddDetailMessage("Connection " + ConnectionNumber + " has finished its call to TCPGetPacketAsync");
		    return receivedPacket;
		}

	    private Boolean TcpSendToProcessor(Socket _TCPSocket, IPacket receivedPacket)
	    {
	        if (receivedPacket == null)
	        {
	            Debug.AddWarningMessage("Disconnect() is about to be called from TCPSendToProcessor because the packet received is null.");
	            Disconnect("End of datastream.");
	            return false;
	        }
	        if (receivedPacket.Type == 01)
	        {
	            IPacket_01_Login loginPacket = ObjectFactory.CreatePacket01Login();
	            loginPacket.Data = receivedPacket.Data;
	            User.UserName = (loginPacket.Username ?? ("nameless_" + DateTime.Now.InStandardForm().hhmmss)).AsRichTextString();
	        }
	        if (_TCPSocket == ClientStreamTCPSocket)
	        {
	            _ = ProcessPacketClientStream(receivedPacket);
	            return true;
            }
	        if (_TCPSocket == HostStreamTCPSocket)
	        {
	            _ = ProcessPacketHostStream(receivedPacket);
	            return true;
	        }
	        // _TCPSocket != HostStreamTCPSocket & _TCPSocket != ClientStreamTCPSocket
	        {
	            Debug.AddWarningMessage("Connection " + ConnectionNumber + " got a packet from a socket, but it's not assigned as the client or as the host, so don't know what to do with it!");
	            return false;
            }
	    }

	    private async Task<Boolean> StartTcpGetPacketAsyncLoop(Socket _TCPSocket)
	    {
	        while (IsConnected)
	        {
	            IPacket receivedPacket = TcpGetPacket(_TCPSocket);
	            if (receivedPacket == null)
	            {
                    Debug.AddWarningMessage("TcpGetPacketAsyncLoop is being terminated as received a null packet!");
	                return false;
	            }
	            TcpSendToProcessor(_TCPSocket, receivedPacket);
	        }
	        Debug.AddWarningMessage("TcpGetPacketAsyncLoop is being terminated as connection is no longer connected.");
	        return false;
        }
	}
}
