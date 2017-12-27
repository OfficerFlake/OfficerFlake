using System;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IExceptionHandler
	{
		bool Handle<T>(T e) where T : Exception;
	}
}
