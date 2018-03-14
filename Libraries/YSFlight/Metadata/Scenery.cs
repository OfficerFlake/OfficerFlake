using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight
{
    public static partial class Metadata
    {
		public class Scenery : IO.ListFile.Line, IMetaDataScenery
		{
			#region Variables
			public string Path_1_FieldFile { get; set; }
			public string Path_2_StartPositionFile { get; set; }
			public string Path_3_YFSFile { get; set; }
			#endregion
			#region Cached Information
			public string Identify { get; set; }
			#endregion

			public Scenery(string[] parameters) : base(parameters) { }
			public Scenery(string identify) : base(new string[] { })
			{
				Identify = identify;
			}
			public static List<IRichTextMessage> DebugInformation = new List<IRichTextMessage>();

			#region Load All
			/// <summary>
			/// Searches the YSFlightDirectory for the Scenery Folder, and loads all Scenery Lists from it.
			/// </summary>
			/// <returns></returns>
			public static bool LoadAll()
			{
				//Invalidate the old Scenery list!
				Extensions.YSFlight.MetaData.Scenery.List.Clear();
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
						if (!File.Exists(YSFlightSceneryDirectory + SceneryList)) continue;
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

							Scenery NewMetaScenery = new Scenery(Identify);
							NewMetaScenery.Path_1_FieldFile = SceneryPath1Fld;
							NewMetaScenery.Path_2_StartPositionFile = SceneryPath2Stp;
							NewMetaScenery.Path_3_YFSFile = SceneryPath3Yfs;

							Extensions.YSFlight.MetaData.Scenery.List.Add(NewMetaScenery);
						}
					}

					//AT THIS POINT, ALL YSFLIGHT Scenery LST's ARE FULLY LOADED.
					return (DebugInformation.Count <= 0);
				}
				catch (Exception e)
				{
					var Error = ("MetaData.Scenery.LoadAll Crashed!").AsDebugErrorMessage(e);
					DebugInformation.Add(Error);
				}

				return (DebugInformation.Count(x=>x is IDebugWarningMessage | x is IDebugErrorMessage | x is IDebugCrashMessage) <= 0);
			}
			#endregion
		}
	}
}
