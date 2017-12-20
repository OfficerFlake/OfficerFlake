using System;
using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IDATFile : ICommandFile
	{
		bool LoadAll();
		bool SaveAll();
	}

	public interface IDATFileProperty
	{
		string Command { get; set; }
		object[] Properties { get; set; }

		string ToSystemString();
	}
}
