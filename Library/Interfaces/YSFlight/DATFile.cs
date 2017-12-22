using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IDATFIle : ICommandFile
	{
		new List<IDATFileProperty> Contents { get; set; }

		new bool Load();
		new bool Save();
	}
	public interface IDATProperty : ICommandFileLine
	{
		object GetParameter<T>(int index);
		void SetParameter<T>(int index, T parameter);
	}
}
