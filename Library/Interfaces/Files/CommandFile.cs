using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface ICommandFile : IFile
	{
		new List<ICommandFileLine> Contents { get; set; }
	}
	public interface ICommandFileLine
	{
		string Command { get; set; }

		int NumberOfParameters { get; }
		string GetParameter(int index);
		bool SetParameter(int index, string value);

		string ToString();
	}
}
