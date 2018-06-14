namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IServer
	{
		bool Start(bool IsProxyMode);
		bool Stop();
		bool IsShuttingDown { get; }
	}
}
