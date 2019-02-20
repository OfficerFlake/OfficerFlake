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
		private Socket ClientStreamTCPSocket = BlankTCPSocket;
	    private bool CreateClientTCPSocket(Socket incomingSocket)
	    {
	        if (ClientStreamTCPSocket == BlankTCPSocket)
	        {
                ClientStreamTCPSocket = incomingSocket;
	            Logger.AddDebugMessage("Connection " + ConnectionNumber + "  connected to income ClientSocket");
	            return true;
	        }
	        else
	        {
	            Logger.AddDebugMessage("Connection " + ConnectionNumber + " 's call to CreateHostTCPSocket failed as the host socket is already occupied.");
	            return false;
	        }
	    }
	    private bool StartClientStreamOnTCPSocket()
	    {
	        Logger.AddDebugMessage("Connection " + ConnectionNumber + "  starting ClientStream loop");
	        _ = Task.Run(() => StartTcpGetPacketAsyncLoop(ClientStreamTCPSocket));
	        Logger.AddDebugMessage("Connection " + ConnectionNumber + "  started ClientStream loop");
	        return true;
	    }
	}
}
