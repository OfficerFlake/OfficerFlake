using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface ILSTFile : IListFile
	{
		new List<ILSTFileProperty> Contents { get; set; }
	}

	public interface ILSTFileProperty
	{
		List<string> Parameters { get; set; }

		string ToSystemString();
	}
}
