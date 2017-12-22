using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IListFile : IFile
	{
		List<IListFileLine> Lines { get; set; }

		new bool Load();
		new bool Save();
	}
	public interface IListFileLine
	{
		int NumberOfParameters { get; }
		string GetParameter(int index);
		void SetParameter(int index, string value);

		string ToString();
	}
}
