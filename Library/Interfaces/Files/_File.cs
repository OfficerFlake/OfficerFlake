using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IFile
	{
		string Filename { get; }
		string[] Contents { get; set; }

		bool Load();
		bool Save();
	}
}
