using System.Collections.Generic;
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
		}
	}
}
