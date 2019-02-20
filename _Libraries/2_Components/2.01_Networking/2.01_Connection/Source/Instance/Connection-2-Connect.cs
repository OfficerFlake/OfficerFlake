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
        // 2) Connect to the Server
        public bool Connect(Socket incomingSocket, bool isProxyMode = false)
		{
            //TODO : Remove this CopyPasta.
		    Logger.AddDebugMessage("Connection " + ConnectionNumber + " .");

            #region DEBUG : Starting Method
            Logger.AddDebugMessage("Connection " + ConnectionNumber + " is starting method Connect(incomingsocket??:"+(incomingSocket==null)+", isProxyMode?:" + isProxyMode + ").");
            #endregion

            #region CreateClientTCPSocket();
            Logger.AddDebugMessage("Connection " + ConnectionNumber + "  is starting a syncronous call to CreateClientTCPSocket(incomingSocket).");
            CreateClientTCPSocket(incomingSocket);
		    Logger.AddDebugMessage("Connection " + ConnectionNumber + "  has just finished the call to CreateClientTCPSocket(incomingSocket).");
            #endregion
            #region if (ProxyMode) CreateHostTCPSocket();
            IsProxyMode = isProxyMode;
		    if (isProxyMode)
		    {
		        Logger.AddDebugMessage("Connection " + ConnectionNumber +
		                               " IS in ProxyMode, so will need to create a host socket and redirect its packets to there.");

		        Logger.AddDebugMessage("Connection " + ConnectionNumber + "  is starting a syncronous call to CreateHostTCPSocket()");
		        CreateHostTCPSocket();
		        Logger.AddDebugMessage("Connection " + ConnectionNumber +
		                               "  has just finished a call to CreateHostTCPSocket().");
		    }
		    else
		    {
		        Logger.AddDebugMessage("Connection " + ConnectionNumber +
		                               "is NOT in Proxy Mode, so does not need to create a Host Socket. All packets will be processed by the OYS Server packet handler");

		    }
            #endregion

            #region AddToServerList();
            Logger.AddDebugMessage("Connection " + ConnectionNumber + "  is starting a syncronous call to AddToServerList.");
            AddToServerList();
		    Logger.AddDebugMessage("Connection " + ConnectionNumber + "  has just finished a call to AddToServerList.");
            #endregion
            #region LoginTime = Now;
            Logger.AddDebugMessage("Connection " + ConnectionNumber + " is about to assign it's LoginTime to Now");
            LoginTime = ObjectFactory.ServerUpTime;
		    IsConnected = true;
		    Logger.AddDebugMessage("Connection " + ConnectionNumber + "  has joined the server at time" + LoginTime.TotalSeconds().ToString() + " seconds.");
            #endregion

            #region StartClientStreamOnTCPSocket();
            Logger.AddDebugMessage("Connection " + ConnectionNumber + "  is starting a syncronous call to StartClientStreamOnTCPSocket.");
            StartClientStreamOnTCPSocket();
		    Logger.AddDebugMessage("Connection " + ConnectionNumber + "  has just finished a call to SetTCPSocketClientStream.");
            #endregion
		    #region StartClientStreamOnTCPSocket();
		    if (IsProxyMode)
		    {
		        Logger.AddDebugMessage("Connection " + ConnectionNumber +
		                               "  is starting a syncronous call to StartHostStreamTCPSocket.");
		        StartHostStreamTCPSocket();
		        Logger.AddDebugMessage("Connection " + ConnectionNumber +
                                       "  has just finished a call to StartHostStreamTCPSocket.");
		    }
            #endregion

		    #region DEBUG : Ending Method
		    Logger.AddDebugMessage("Connection " + ConnectionNumber + " has completed method Connect(incomingsocket??:" + (incomingSocket == null) + ", isProxyMode?:" + isProxyMode + ").");
		    #endregion
            return true;
		}
	}
}
