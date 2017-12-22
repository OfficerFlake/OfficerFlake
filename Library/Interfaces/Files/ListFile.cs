using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IListFile : IFile
	{
		List<string> Lines { get; set; }

		string GetParameter(int index);
		string SetParameter(int index, string value);

		new bool Load();
		new bool Save();
	}
}
