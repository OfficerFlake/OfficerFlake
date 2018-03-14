﻿using System.Collections.Generic;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
	public static partial class YSFlight
	{
		public static class World
		{
			public static List<IWorldAircraft> AllAircraft { get; } = new List<IWorldAircraft>();
			public static List<IWorldGround> AllGrounds { get; } = new List<IWorldGround>();

			public static List<IWorldScenery> AllScenerys { get; } = new List<IWorldScenery>();
			public static List<IWorldMotionPath> AllMotionPaths { get; } = new List<IWorldMotionPath>();
			public static List<IWorldStartPosition> AllStartPositions { get; } = new List<IWorldStartPosition>();

			public static I24BitColor FLDGroundColor { get; set; } = ObjectFactory.CreateColor(0, 0, 0).Get24BitColor();
			public static I24BitColor FLDSkyColor { get; set; } = ObjectFactory.CreateColor(0, 100, 200).Get24BitColor();
			public static I24BitColor FLDFogColor { get; set; } = ObjectFactory.CreateColor(120, 140, 160).Get24BitColor();
		}
	}
}
