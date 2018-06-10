using System.Collections.Generic;

using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
	public static partial class YSFlight
	{
		public static class MetaData
		{
			public static class Aircraft
			{
				public static List<IMetaDataAircraft> List { get; } = new List<IMetaDataAircraft>();
				public static IMetaDataAircraft None = ObjectFactory.CreateMetaDataAircraft("None");
				#region Find By Name
				/// <summary>
				/// Finds the desired MetaObject by name. If no meta object is found, NoMetaAircraft is returned.
				/// </summary>
				/// <param name="Name">Aircraft name to search for.</param>
				/// <returns>
				/// Match: Last Matching MetaAircraft Object
				/// Else:  "NoMetaAircraft" Psuedo-Object.
				/// </returns>
				public static IMetaDataAircraft FindByName(string Name)
				{
					IMetaDataAircraft Output = None;
					if (Name == null) return Output;

					foreach (IMetaDataAircraft ThisMetaAircraft in List)
					{
						if (ThisMetaAircraft == null) continue;
						if (ThisMetaAircraft.Identify == null) continue;
						if (System.String.Equals(
							ThisMetaAircraft.Identify.ToUpperInvariant().ResizeOnRight(32),
							Name.ToUpperInvariant().ResizeOnRight(32)))
						{
							Output = ThisMetaAircraft;
						}
					}
					if (Output == None)
					{
						//Log.Warning("Failed to find MetaData for aircraft: " + Name + ".");
					}
					return Output;
				}
				#endregion
			}

			public static class Grounds
			{
				public static List<IMetaDataGround> List { get; } = new List<IMetaDataGround>();
				public static IMetaDataGround None = ObjectFactory.CreateMetaDataGround("None");
				#region Find By Name
				/// <summary>
				/// Finds the desired MetaObject by name. If no meta object is found, NoMetaGround is returned.
				/// </summary>
				/// <param name="Name">Ground name to search for.</param>
				/// <returns>
				/// Match: Last Matching MetaGround Object
				/// Else:  "NoMetaGround" Psuedo-Object.
				/// </returns>
				public static IMetaDataGround FindByName(string Name)
				{
					IMetaDataGround Output = None;
					if (Name == null) return Output;

					foreach (IMetaDataGround ThisMetaGround in List)
					{
						if (ThisMetaGround == null) continue;
						if (ThisMetaGround.Identify == null) continue;
						if (System.String.Equals(
							ThisMetaGround.Identify.ToUpperInvariant().ResizeOnRight(31),
							Name.ToUpperInvariant().ResizeOnRight(31)))
						{
							Output = ThisMetaGround;
						}
					}
					if (Output == None)
					{
						//Log.Warning("Failed to find MetaData for Ground: " + Name + ".");
					}
					return Output;
				}
				#endregion
			}

			public static class Scenery
			{
				public static List<IMetaDataScenery> List { get; } = new List<IMetaDataScenery>();
				public static IMetaDataScenery None = ObjectFactory.CreateMetaDataScenery("None");
				#region Find By Name
				/// <summary>
				/// Finds the desired MetaObject by name. If no meta object is found, NoMetaScenery is returned.
				/// </summary>
				/// <param name="Name">Scenery name to search for.</param>
				/// <returns>
				/// Match: Last Matching MetaScenery Object
				/// Else:  "NoMetaScenery" Psuedo-Object.
				/// </returns>
				public static IMetaDataScenery FindByName(string Name)
				{
					IMetaDataScenery Output = None;
					if (Name == null) return Output;

					foreach (IMetaDataScenery ThisMetaScenery in List)
					{
						if (ThisMetaScenery == null) continue;
						if (ThisMetaScenery.Identify == null) continue;
						if (System.String.Equals(
							ThisMetaScenery.Identify.ToUpperInvariant().ResizeOnRight(31),
							Name.ToUpperInvariant().ResizeOnRight(31)))
						{
							Output = ThisMetaScenery;
						}
					}
					if (Output == None)
					{
						//Log.Warning("Failed to find MetaData for Scenery: " + Name + ".");
					}
					return Output;
				}
				#endregion
			}
		}
	}
}
