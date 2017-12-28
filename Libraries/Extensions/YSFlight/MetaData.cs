using System.Collections.Generic;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
	public static partial class YSFlight
	{
		public static class MetaData
		{
			public static List<IMetaDataAircraft> AllAircraft { get; } = new List<IMetaDataAircraft>();
			public static List<IMetaDataGround> AllGrounds { get; } = new List<IMetaDataGround>();
			public static List<IMetaDataScenery> AllScenerys { get; } = new List<IMetaDataScenery>();
		}
	}
}
