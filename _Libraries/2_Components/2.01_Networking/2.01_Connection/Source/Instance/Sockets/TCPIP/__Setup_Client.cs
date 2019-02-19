using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.Networking
{
	public partial class Connection : IConnection
	{
		private Socket ClientStreamTCPSocket = BlankTCPSocket;
	    private bool CreateClientTCPSocket(Socket incomingSocket)
	    {
	        if (ClientStreamTCPSocket == BlankTCPSocket)
	        {
                ClientStreamTCPSocket = incomingSocket;
	            Debug.AddDetailMessage("Connection " + ConnectionNumber + "  connected to income ClientSocket");
	            return true;
	        }
	        else
	        {
	            Debug.AddDetailMessage("Connection " + ConnectionNumber + " 's call to CreateHostTCPSocket failed as the host socket is already occupied.");
	            return false;
	        }
	    }
	    private bool StartClientStreamOnTCPSocket()
	    {
	        Debug.AddDetailMessage("Connection " + ConnectionNumber + "  starting ClientStream loop");
	        _ = Task.Run(() => StartTcpGetPacketAsyncLoop(ClientStreamTCPSocket));
	        Debug.AddDetailMessage("Connection " + ConnectionNumber + "  started ClientStream loop");
	        return true;
	    }
	}
}
