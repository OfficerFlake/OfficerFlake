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
        // 6) Garbage Collector removes the client from the list.
	    ~Connection()
	    {
	        Logger.AddDebugMessage("Client object has been discarded by the runtime garbage collector.");
            //This is currently being called!
        }
	}
}
