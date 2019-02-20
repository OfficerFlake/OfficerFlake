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
        // 1) Create the Connection Instance.
	    public Connection()
	    {
	        ConnectionNumber = ++ConnectionIDIncrementer;
	        Logger.AddDebugMessage("New client object has been created, is has been assigned ID: " + ConnectionNumber);
	    }
	}
}
