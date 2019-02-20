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
        /// <summary>
        /// Database User Object associated with the Connection.
        /// </summary>
		public IUser User { get; set; } = ObjectFactory.CreateUser(ObjectFactory.CreateRichTextString("<Unknown User>"));

        /// <summary>
        /// YSFlight Netcode Version of the Connection
        /// </summary>
		public UInt32 Version { get; set; } = 0;

        /// <summary>
        /// The Network Latency of the Connection.
        /// </summary>
		public double Ping { get; set; } = 300;

        /// <summary>
        /// Progressive counter that is to be incremented every time a new Connection is made.
        /// </summary>
		private static uint ConnectionIDIncrementer = 0;

        /// <summary>
        /// The unique number of this Connection.
        /// </summary>
		public UInt32 ConnectionNumber { get; private set; }

        /// <summary>
        /// What type of Connection is this? YSFlight? Virtual? Other?
        /// </summary>
		public ConnectionType ConnectionType { get; set; } = ConnectionType.YSFlight;

        /// <summary>
        /// Is the Connection currently connected to the server?
        /// </summary>
		public bool IsConnected { get; set; } = false;

        /// <summary>
        /// Is this Connection a part of the OYS Proxy or OYS Server? That is, should it pass packets to the host socket, or process itself?
        /// </summary>
		public bool IsProxyMode { get; private set; } = false;

        /// <summary>
        /// What is the state of this Connections login?
        /// </summary>
        public LoginStatus LoginState { get; set; } = LoginStatus.Disconnected;

        /// <summary>
        /// Returns a true value if this Connection is connected and still logging in.
        /// </summary>
		public bool IsLoggingIn => LoginState == LoginStatus.LoggingIn;

        /// <summary>
        /// Returns a true value if the Connection is connected and finished logging in.
        /// </summary>
		public bool IsLoggedIn => LoginState == LoginStatus.LoggedIn;

	    /// <summary>
	    /// Returns a true value if the Connection is connected and NOT logged in.
	    /// </summary>
	    public bool IsNotLoggedIn => LoginState != LoginStatus.LoggedIn;

        /// <summary>
        /// How long since the server started was this Connection created?
        /// </summary>
		public ITimeSpan LoginTime { get; private set; }

        /// <summary>
        /// What is the current Flight status of the Connection?
        /// </summary>
		public FlightStatus FlightStatus { get; set; } = FlightStatus.Idle;

        /// <summary>
        /// Returns true if this connection is currently in flight.
        /// </summary>
		public bool IsFlying => FlightStatus == FlightStatus.Flying;

	    /// <summary>
	    /// Returns true if this connection is currently NOT in flight.
	    /// </summary>
	    public bool IsNotFlying => FlightStatus == FlightStatus.Idle;

        /// <summary>
        /// The vehicle that has been created and associated with this Connection.
        /// </summary>
		public IWorldVehicle Vehicle { get; set; } = Extensions.YSFlight.World.NoVehicle;

        /// <summary>
        /// Returns True if this Connection has issued a join request and it is currently pending.
        /// </summary>
		public bool JoinRequestPending { get; set; } = false;

        /// <summary>
        /// A list of the last 5 packets that this Connection has received.
        /// </summary>
        public List<IPacket> Last5PacketsReceived { get; } = new List<IPacket>();
	}
}
