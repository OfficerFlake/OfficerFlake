using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IExceptionHandler
	{
		bool Handle<T>(T e) where T : Exception;
	}
}
