using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IDATFile : ICommandFile
	{
		new List<IDATFileProperty> Contents { get; set; }
	}

	public interface IDATFileProperty
	{
		string Command { get; set; }
		object[] Properties { get; set; }
		T GetParameter<T>(int index);
		void SetParameter<T>(int index, T parameter);

		string ToSystemString();
	}
}
