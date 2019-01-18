namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IServer
	{
		bool Start(bool IsProxyMode);
		bool Stop();
		ITimeSpan UpTime { get; }
		bool IsShuttingDown { get; }
	}
}
