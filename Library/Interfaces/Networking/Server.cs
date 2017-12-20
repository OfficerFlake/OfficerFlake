using System;
using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IServer
	{
		bool Start();
		bool Stop();
		bool IsShuttingDown { get; set; }

		bool UDPRecieveDatagram();
		bool TCPAcceptNewConnection();
	}
}
