using System;
using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IWorldVehicle
	{
		void CreateVehicle();
		void DestroyVehicle();

		String Identify { get; set; }
		String Tag { get; set; }
		UInt32 Strength { get; set; }
		UInt32 IFF { get; set; }
		UInt32 ID { get; set; }

		Packet_05VehicleType VehicleType { get; set; }

		IUser Owner { get; set; }
		IMetaDataVehicle MetaData { get; set; }

		ICoordinate3 Position { get; set; }
		IOrientation3 Attitude { get; set; }

		IPacket_05_AddVehicle GetJoinPacket();

		void Update(IPacket_05_AddVehicle packet);
		void Update(IPacket_11_FlightData packet);
	}
	public interface IWorldAircraft : IWorldVehicle
	{
	}
	public interface IWorldGround : IWorldVehicle
	{
	}

	public interface IWorldScenery
	{
		String Identify { get; set; }

		ICoordinate3 Position { get; set; }
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

		ICoordinate3 Position { get; set; }
		IOrientation3 Attitude { get; set; }
	}
	
	public interface IWorldMotionPath
	{
		String Identify { get; set; }
		UInt32 Type { get; set; }
		Boolean IsLooping { get; set; }
		WorldMotionPathAreaType AreaType { get; set; }

		List<ICoordinate3> Points { get; set; }

		ICoordinate3 Position { get; set; }
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
