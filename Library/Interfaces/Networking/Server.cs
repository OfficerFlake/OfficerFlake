namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IServer
	{
		bool Start(uint TCPPort, uint UDPPort, bool IsProxyMode);
		bool Stop();
		bool IsShuttingDown { get; }
	}
}
