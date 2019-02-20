using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Loggers;

namespace Com.OfficerFlake.Libraries.Networking
{
	public partial class Connection : IConnection
	{
        //General Use
		#region Any Socket
		private bool TCPSend(IPacket thisPacket, Socket _TCPSocket)
		{
		    //lock (_TCPSocket)
		    {
                Logger.AddDebugMessage("Connection " + ConnectionNumber + " entering lock for TCPSend.");
		        try
		        {
		            _TCPSocket.Send(thisPacket.Serialise());
		            if (Loggers.PacketInspector.Client == null | Loggers.PacketInspector.Client == this)
		            {
		                if (Loggers.PacketInspector.DataDirection == DataDirection.ServerToClient)
		                {
		                    if (Loggers.PacketInspector.Type == thisPacket.Type)
		                        Loggers.PacketInspector.UpdatePacket(thisPacket);
		                }
		            }
		            Logger.AddDebugMessage("Connection " + ConnectionNumber + " exiting lock for TCPSend.");
                    return true;
		        }
		        catch (ArgumentNullException e)
		        {
		            //Packet is Null.
		            Debug.AddErrorMessage(e, "Trying to send a Null packet.");
		        }
		        catch (SocketException e)
		        {
                    //WinSock in Error state.
                    //Debug.AddErrorMessage(e, "WinSock is in an error state.");
                    Disconnect("End of Stream.");
                }
		        catch (ObjectDisposedException e)
		        {
                    //Socket closed/disposed.
		            //Debug.AddErrorMessage(e, "Socket has been disposed by the operating system.");
                    Disconnect("End of Stream.");
		        }
		        catch (Exception e)
		        {
		            Debug.AddErrorMessage(e, "Exception in TCPSend.");
		        }
		        Logger.AddDebugMessage("Connection " + ConnectionNumber + " exiting lock for TCPSend.");
                return false;
		    }
		}
		public bool Send(IPacket Input, Socket _TCPSocket)
		{
			return TCPSend(Input, _TCPSocket);
		}
        public bool SendMessage(string Input, Socket _TCPSocket)
		{
			IPacket_32_ServerMessage thisChatMessage = ObjectFactory.CreatePacket32ServerMessage(Input);
			return TCPSend(thisChatMessage, _TCPSocket);
		}
		public bool SendMessage(IPacket_32_ChatMessage Input, Socket _TCPSocket)
		{
			return TCPSend(Input, _TCPSocket);
		}
		public async Task<bool> SendAsync(IPacket thisPacket, Socket _TCPSocket)
		{
			try
			{
				return await Task.Run(() => TCPSend(thisPacket, _TCPSocket));
			}
			catch (ArgumentNullException e)
			{
                Debug.AddErrorMessage(e, "Trying to send a null packet.");
			}
			return false;
		}
		public async Task<bool> SendMessageAsync(string Message, Socket _TCPSocket)
		{
			try
			{
				return await Task.Run(() => SendMessage(Message, _TCPSocket));
			}
			catch (ArgumentNullException e)
			{
			    Debug.AddErrorMessage(e, "Trying to send a null packet.");
			}
            return false;
		}
		#endregion

        //Shortcuts
		#region ToClientStream
		public bool SendToClientStream(IPacket Input)
		{
			return Send(Input, ClientStreamTCPSocket);
		}
		public bool SendToClientStream(string message)
		{
			return SendMessage(message, ClientStreamTCPSocket);
		}
		public async Task<bool> SendToClientStreamAsync(IPacket Input)
		{
			return await SendAsync(Input, ClientStreamTCPSocket);
		}
		public async Task<bool> SendToClientStreamAsync(string message)
		{
			return await SendMessageAsync(message, ClientStreamTCPSocket);
		}
		#endregion
		#region ToHostStream
		public bool SendToHostStream(IPacket Input)
		{
			return Send(Input, HostStreamTCPSocket);
		}
		public bool SendToHostStream(string message)
		{
			return SendMessage(message, HostStreamTCPSocket);
		}
		public async Task<bool> SendToHostStreamAsync(IPacket Input)
		{
			return await SendAsync(Input, HostStreamTCPSocket);
		}
		public async Task<bool> SendToHostStreamAsync(string message)
		{
			return await SendMessageAsync(message, HostStreamTCPSocket);
		}
		#endregion
	}
}
