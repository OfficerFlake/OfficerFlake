using System;
using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IWorldAircraftObject
	{
		String Identify { get; set; }
		String Tag { get; set; }
		UInt32 Strength { get; set; }
		UInt32 IFF { get; set; }
		UInt32 ID { get; set; }

		IUser Owner { get; set; }
		IMetaDataAircraft MetaData { get; set; }

		IPoint3 Position { get; set; }
		IOrientation3 Attitude { get; set; }
	}

	public interface IWorldStartPosition
	{
		String Identify { get; set; }
		ISpeed Speed { get; set; }
		Single Throttle { get; set; }
		Boolean GearDown { get; set; }

		Boolean AllowIFF1 { get; set; }
		Boolean AllowIFF2 { get; set; }
		Boolean AllowIFF3 { get; set; }
		Boolean AllowIFF4 { get; set; }

		IPoint3 Position { get; set; }
		IOrientation3 Attitude { get; set; }
	}

	public interface IWorldGroundObject
	{
		String Identify { get; set; }
		String Tag { get; set; }
		UInt32 Strength { get; set; }
		UInt32 IFF { get; set; }
		UInt32 ID { get; set; }

		IUser Owner { get; set; }
		IMetaDataGround MetaData { get; set; }
		
		IPoint3 Position { get; set; }
		IOrientation3 Attitude { get; set; }
	}

	public interface IWorldScenery
	{
		String Identify { get; set; }

		IPoint3 Position { get; set; }
		IOrientation3 Attitude { get; set; }
	}

	public interface IWorldMotionPath
	{
		String Identify { get; set; }
		UInt32 Type { get; set; }
		Boolean IsLooping { get; set; }
		WorldMotionPathAreaType AreaType { get; set; }

		List<IPoint3> Points { get; set; }

		IPoint3 Position { get; set; }
		IOrientation3 Attitude { get; set; }

		IWorldMotionPath Interpolate();
		IWorldMotionPath Decimate();
	}
	public enum WorldMotionPathAreaType
	{
		NoArea,
		Land,
		Water
	}
}
