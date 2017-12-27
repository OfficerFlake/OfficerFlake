using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface ICommandFile : IFile
	{
		List<ICommandFileLine> Lines { get; set; }

		new bool Load();
		new bool Save();
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
