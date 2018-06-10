using System;
using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
	public static partial class YSFlight
	{
		public static class World
		{
			private static UInt32 CurrentID = 0;
			public static UInt32 GetNextID() => ++CurrentID;

			public static List<IWorldVehicle> Vehicles { get; } = new List<IWorldVehicle>();
			public static List<IWorldAircraft> AllAircraft => Vehicles.OfType<IWorldAircraft>().ToList();
			public static List<IWorldGround> AllGrounds => Vehicles.OfType<IWorldGround>().ToList();
			public static IWorldVehicle NoVehicle { get; } = ObjectFactory.CreateVehicle();

			public static List<IWorldScenery> AllScenerys { get; } = new List<IWorldScenery>();
			public static List<IWorldMotionPath> AllMotionPaths { get; } = new List<IWorldMotionPath>();
			public static List<IWorldStartPosition> AllStartPositions { get; } = new List<IWorldStartPosition>();

			public static I24BitColor FLDGroundColor { get; set; } = ObjectFactory.CreateColor(0, 0, 0).Get24BitColor();
			public static I24BitColor FLDSkyColor { get; set; } = ObjectFactory.CreateColor(0, 100, 200).Get24BitColor();
			public static I24BitColor FLDFogColor { get; set; } = ObjectFactory.CreateColor(120, 140, 160).Get24BitColor();
		}
	}
}
