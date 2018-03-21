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
		IMass WeightOfFuel { get; }
		UInt16 AmmoGun { get; }
		UInt16 Strength { get; }
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
