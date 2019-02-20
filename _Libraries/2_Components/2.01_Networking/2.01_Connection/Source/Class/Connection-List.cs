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
		#region Connections List
        /// <summary>
        /// Adds this Connection to the List of Connections.
        /// </summary>
		private void AddToServerList()
	    {
			Connections.AllConnections.Add(this);
	        Logger.AddDebugMessage("Connection " + ConnectionNumber + "  has just been added to the server list.");
        }

        /// <summary>
        /// Removes all Connections with this ConnectionNumber from the List of Connections.
        /// </summary>
	    private void RemoveFromServerList()
	    {
		    int numberRemoved = Connections.AllConnections.RemoveAll(x => x.ConnectionNumber == this.ConnectionNumber);
	        if (numberRemoved > 0)
	        {
	            Logger.AddDebugMessage("All Clients of Connection Number " + ConnectionNumber +
	                                   " have just been removed from the server list. There were " + numberRemoved + " removed in total.");
	        }
	        else
	        {
	            Logger.AddDebugMessage("RemoveFromServerList was called for Connection " + ConnectionNumber + ", however there were no matching clients in the server list to remove!");
	        }
        }
		#endregion
	}
}
