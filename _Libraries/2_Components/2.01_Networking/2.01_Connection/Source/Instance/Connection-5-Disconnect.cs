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
        // 5) Disconnect from the Server.
		#region Disconnect
		public bool Disconnect(string reason)
	    {
	        if (IsConnected)
	        {
	            RemoveFromServerList();
	            IsConnected = false;
	            LoginState = LoginStatus.Disconnected;
	            Loggers.Console.AddInformationMessage(
	                "&c" + User.UserName.ToUnformattedSystemString() + " left the server.");
	            foreach (IConnection otherConnection in Connections.AllConnections.Exclude(this))
	            {
	                if (Vehicle != null & Vehicle != YSFlight.World.NoVehicle)
	                {
	                    if (Vehicle is IWorldAircraft)
	                    {
	                        IPacket_13_RemoveAircraft RemoveAircraft = ObjectFactory.CreatePacket13RemoveAircraft();
	                        RemoveAircraft.ID = Vehicle.ID;
	                        otherConnection.SendToClientStreamAsync(RemoveAircraft);
	                    }
	                    if (Vehicle is IWorldGround)
	                    {
	                        IPacket_19_RemoveGround RemoveGround = ObjectFactory.CreatePacket19RemoveGround();
	                        RemoveGround.ID = Vehicle.ID;
	                        otherConnection.SendToClientStreamAsync(RemoveGround);
	                    }
	                }
	                _ = otherConnection.SendToClientStreamAsync(
	                    this.User.UserName.ToUnformattedSystemString() + " left the server.");
	            }
	            if (Vehicle != null & Vehicle != YSFlight.World.NoVehicle)
	            {
	                Vehicle.DestroyVehicle();
	                Vehicle = YSFlight.World.NoVehicle;
	                FlightStatus = FlightStatus.Idle;
	            }
	            _ = SendToClientStreamAsync("Disconnected from the server.");
	            _ = SendToClientStreamAsync("Disconnection reason: " + reason);
	            if (ClientStreamTCPSocket.Connected)
	            {
	                try
	                {
	                    ClientStreamTCPSocket.Disconnect(false);
	                }
	                catch
	                {
	                }
	            }
	            if (IsProxyMode & HostStreamTCPSocket.Connected)
	            {
	                try
	                {
	                    HostStreamTCPSocket.Disconnect(false);
	                }
	                catch
	                {
	                }
	            }
	            try
	            {
	                ClientStreamTCPSocket.Dispose();
	                HostStreamTCPSocket.Dispose();
	            }
	            catch
	            {
	            }
	            return true;
	        }
	        else
	        {
	            return false;
	        }
	    }
		#endregion
	}
}
