using System;
using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IDATFile : ICommandFile
	{
		new List<IDATFileProperty> Contents { get; set; }

		IDATFileCached CachedData { get; set; }
	}

	public interface IDATFileCached
	{
		IMass WEIGFUEL { get; }
        IDistance HTRADIUS { get; }
		UInt16 INITIGUN { get; }
		UInt16 STRENGTH { get; }
	}

	public interface IDATFileProperty
	{
		string Command { get; set; }
		object[] Properties { get; set; }

		T GetParameter<T>(int index);
		void SetParameter(int index, object parameter);

		string ToSystemString();
	}
}
