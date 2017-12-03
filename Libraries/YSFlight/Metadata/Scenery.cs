using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.RichText;

namespace Com.OfficerFlake.Libraries.YSFlight
{
    public static partial class Metadata
    {
		#region Scenery
		public class Scenery
		{
			public string SceneryPath1Fld;
			public string SceneryPath2Stp;
			public string SceneryPath3Yfs;

			public string Identify;
			//DO NOT ADD MORE INFO! METADATA IS A CACHE ONLY!

			public static List<Scenery> List = new List<Scenery>();
			public static List<RichTextMessage> DebugInformation = new List<RichTextMessage>();

			/// <summary>
			/// Psuedo-Object to represent Null.
			/// </summary>
			public static Scenery None = new Scenery() { Identify = "NULL" };

			#region Load All
			/// <summary>
			/// Searches the YSFlightDirectory for the Scenery Folder, and loads all Scenery Lists from it.
			/// </summary>
			/// <returns></returns>
			public static bool LoadAll()
			{
				//Invalidate the old Scenery list!
				List.Clear();
				DebugInformation.Clear();

				try
				{
					string YSFlightSceneryDirectory = YSFlightDirectory + @"Scenery/";
					if (!Directory.Exists(YSFlightSceneryDirectory)) return false;
					string[] FullFilenames = Directory.GetFiles(YSFlightSceneryDirectory);
					string[] Filenames = FullFilenames.Select(Path.GetFileName).ToArray();
					string[] SceneryLists = Filenames
						.Where(x => x.ToUpperInvariant().StartsWith(@"SCE") && x.ToUpperInvariant().EndsWith(@".LST")).ToArray();
					foreach (string SceneryList in SceneryLists)
					{
						if (!File.Exists(YSFlightSceneryDirectory + SceneryList)) return false;
						string[] SceneryListContents = File.ReadAllLines(YSFlightSceneryDirectory + SceneryList);
						SceneryListContents = SceneryListContents.Where(x => x.ToUpperInvariant().Contains(@".FLD")).ToArray();
						foreach (string Line in SceneryListContents)
						{
							string ProcessedLine = Line.Replace("\\", "/");
							string[] SplitString = ProcessedLine.SplitPresevingQuotes();
							string SceneryPath1Fld = "";
							string SceneryPath2Stp = "";
							string SceneryPath3Yfs = "";
							string Identify = "";

							switch (SplitString.Length - 1)
							{
								case 3:
									SceneryPath3Yfs = SplitString[3];
									goto case 2;
								case 2:
									SceneryPath2Stp = SplitString[2];
									goto case 1;
								case 1:
									SceneryPath1Fld = SplitString[1];
									goto case 0;
								case 0:
									Identify = SplitString[0];
									break;
							}

							Scenery NewMetaScenery = new Scenery
							{
								Identify = Identify,
								SceneryPath1Fld = SceneryPath1Fld,
								SceneryPath2Stp = SceneryPath2Stp,
								SceneryPath3Yfs = SceneryPath3Yfs
							};

							List.Add(NewMetaScenery);
						}
					}

					//AT THIS POINT, ALL YSFLIGHT Scenery LST's ARE FULLY LOADED.
					return (DebugInformation.Count <= 0);
				}
				catch (Exception e)
				{
					WarningMessage Error = new WarningMessage
					(
						"MetaData.Scenery.LoadAll Crashed!" + e.ToString()
					);
					DebugInformation.Add(Error);
				}

				return (DebugInformation.Count <= 0);
			}
			#endregion
			#region Find By Name
			/// <summary>
			/// Finds the desired MetaObject by name. If no meta object is found, NoMetaScenery is returned.
			/// </summary>
			/// <param name="Name">Scenery name to search for.</param>
			/// <returns>
			/// Match: Last Matching MetaScenery Object
			/// Else:  "NoMetaScenery" Psuedo-Object.
			/// </returns>
			public static Scenery FindByName(string Name)
			{
				Scenery Output = None;
				if (Name == null) return Output;

				foreach (Scenery ThisMetaScenery in List)
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
		#endregion
	}
}
