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
        private Socket HostStreamTCPSocket = BlankTCPSocket;
        private bool CreateHostTCPSocket()
	    {
	        if (HostStreamTCPSocket == BlankTCPSocket)
	        {
	            HostStreamTCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                HostStreamTCPSocket.Connect(SettingsLibrary.Settings.Server.ProxyServer.DestinationAddress.IpAddress,
	                (int)SettingsLibrary.Settings.Server.ProxyServer.DestinationPort);
                Logger.AddDebugMessage("Connection " + ConnectionNumber + "  connected to HostAddress");
	            return true;
	        }
	        else
	        {
	            Logger.AddDebugMessage("Connection " + ConnectionNumber + " 's call to CreateHostTCPSocket failed as the host socket is already occupied.");
	            return false;
            }
	    }
	    private bool StartHostStreamTCPSocket()
	    {
	        Logger.AddDebugMessage("Connection " + ConnectionNumber + "  starting HostStream loop");
	        _ = Task.Run(() => StartTcpGetPacketAsyncLoop(HostStreamTCPSocket));
	        Logger.AddDebugMessage("Connection " + ConnectionNumber + "  started HostStream loop");
	        return true;
	    }
	}
}
