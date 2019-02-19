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
        // 2) Connect to the Server
        public bool Connect(Socket incomingSocket, bool isProxyMode = false)
		{
            //TODO : Remove this CopyPasta.
		    Debug.AddDetailMessage("Connection " + ConnectionNumber + " .");

            #region DEBUG : Starting Method
            Debug.AddDetailMessage("Connection " + ConnectionNumber + " is starting method Connect(incomingsocket??:"+(incomingSocket==null)+", isProxyMode?:" + isProxyMode + ").");
            #endregion

            #region CreateClientTCPSocket();
            Debug.AddDetailMessage("Connection " + ConnectionNumber + "  is starting a syncronous call to CreateClientTCPSocket(incomingSocket).");
            CreateClientTCPSocket(incomingSocket);
		    Debug.AddDetailMessage("Connection " + ConnectionNumber + "  has just finished the call to CreateClientTCPSocket(incomingSocket).");
            #endregion
            #region if (ProxyMode) CreateHostTCPSocket();
            IsProxyMode = isProxyMode;
		    if (isProxyMode)
		    {
		        Debug.AddDetailMessage("Connection " + ConnectionNumber +
		                               " IS in ProxyMode, so will need to create a host socket and redirect its packets to there.");

		        Debug.AddDetailMessage("Connection " + ConnectionNumber + "  is starting a syncronous call to CreateHostTCPSocket()");
		        CreateHostTCPSocket();
		        Debug.AddDetailMessage("Connection " + ConnectionNumber +
		                               "  has just finished a call to CreateHostTCPSocket().");
		    }
		    else
		    {
		        Debug.AddDetailMessage("Connection " + ConnectionNumber +
		                               "is NOT in Proxy Mode, so does not need to create a Host Socket. All packets will be processed by the OYS Server packet handler");

		    }
            #endregion

            #region AddToServerList();
            Debug.AddDetailMessage("Connection " + ConnectionNumber + "  is starting a syncronous call to AddToServerList.");
            AddToServerList();
		    Debug.AddDetailMessage("Connection " + ConnectionNumber + "  has just finished a call to AddToServerList.");
            #endregion
            #region LoginTime = Now;
            Debug.AddDetailMessage("Connection " + ConnectionNumber + " is about to assign it's LoginTime to Now");
            LoginTime = ObjectFactory.ServerUpTime;
		    IsConnected = true;
		    Debug.AddDetailMessage("Connection " + ConnectionNumber + "  has joined the server at time" + LoginTime.TotalSeconds().ToString() + " seconds.");
            #endregion

            #region StartClientStreamOnTCPSocket();
            Debug.AddDetailMessage("Connection " + ConnectionNumber + "  is starting a syncronous call to StartClientStreamOnTCPSocket.");
            StartClientStreamOnTCPSocket();
		    Debug.AddDetailMessage("Connection " + ConnectionNumber + "  has just finished a call to SetTCPSocketClientStream.");
            #endregion
		    #region StartClientStreamOnTCPSocket();
		    if (IsProxyMode)
		    {
		        Debug.AddDetailMessage("Connection " + ConnectionNumber +
		                               "  is starting a syncronous call to StartHostStreamTCPSocket.");
		        StartHostStreamTCPSocket();
		        Debug.AddDetailMessage("Connection " + ConnectionNumber +
                                       "  has just finished a call to StartHostStreamTCPSocket.");
		    }
            #endregion

		    #region DEBUG : Ending Method
		    Debug.AddDetailMessage("Connection " + ConnectionNumber + " has completed method Connect(incomingsocket??:" + (incomingSocket == null) + ", isProxyMode?:" + isProxyMode + ").");
		    #endregion
            return true;
		}
	}
}
