using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

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

			#region Load All
			/// <summary>
			/// Searches the YSFlightDirectory for the Scenery Folder, and loads all Scenery Lists from it.
			/// </summary>
			/// <returns></returns>
			public static bool LoadAll()
			{
				Debug.AddSummaryMessage("Starting MetaData.Scenery.LoadAll()");
				Extensions.YSFlight.MetaData.Scenery.List.Clear();

				int loadingErrors = 0;

				#region Load All Scenery MetaData
				try
				{
					string YSFlightSceneryDirectory = SettingsLibrary.Settings.YSFlight.Directory + @"Scenery/";

					#region Scenery Directory Not Found on Disk
					if (!Directory.Exists(YSFlightSceneryDirectory))
					{
						Debug.AddErrorMessage(new DirectoryNotFoundException(), "YSFlight Scenery Directory Not Found.");
						return false;
					}
					#endregion
					#region Initialise Variables
					string[] FullFilenames = Directory.GetFiles(YSFlightSceneryDirectory);
					string[] Filenames = FullFilenames.Select(Path.GetFileName).ToArray();
					string[] SceneryLists = Filenames
						.Where(x => x.ToUpperInvariant().StartsWith(@"SCE") && x.ToUpperInvariant().EndsWith(@".LST")).ToArray();
					#endregion

					#region Load Each Scenery List
					foreach (string thisSceneryListFile in SceneryLists)
					{
						#region Aircraft List Not Found on Disk
						if (!File.Exists(YSFlightSceneryDirectory + thisSceneryListFile))
						{
							string message = "Aircraft List defined in directory tree not found.";
							Debug.AddWarningMessage(message);
							loadingErrors++;
							continue;
						}
						#endregion
						#region Get Lines with .FLD Definitions
						string[] SceneryListContents = File.ReadAllLines(YSFlightSceneryDirectory + thisSceneryListFile);
						SceneryListContents = SceneryListContents.Where(x => x.ToUpperInvariant().Contains(@".FLD")).ToArray();
						#endregion
						#region Iterate over LST Contents
						for (int i = 0; i < SceneryListContents.Length; i++)
						{
							#region Update Line Number and Contents
							string thisLine = SceneryListContents[i];
							string ProcessedLine = thisLine.Replace("\\", "/");
							string[] SplitString = ProcessedLine.ToUpperInvariant().SplitPresevingQuotes();
							#endregion

							if (thisLine == "") continue; //skip blank lines.

							#region Initialise Variables
							string SceneryPath1Fld = "";
							string SceneryPath2Stp = "";
							string SceneryPath3Yfs = "";
							string Identify = "";
							#endregion

							#region Assign File Paths for This Scenery
							switch (SplitString.Length - 1)
							{
								default:
									if (SplitString.Length > 3) goto case 3;
									break;
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
							#endregion
							#region Create a New MetaScenery
							Scenery NewMetaScenery = new Scenery(Identify);
							NewMetaScenery.Path_1_FieldFile = SceneryPath1Fld;
							NewMetaScenery.Path_2_StartPositionFile = SceneryPath2Stp;
							NewMetaScenery.Path_3_YFSFile = SceneryPath3Yfs;
							#endregion

							Extensions.YSFlight.MetaData.Scenery.List.Add(NewMetaScenery);
						}
						#endregion
					}
					#endregion
				}
				catch (Exception e)
				{
					string message = "MetaData.Scenery.LoadAll Crashed!";
					Debug.AddErrorMessage(e, message);
					loadingErrors++;
				}
				#endregion

				Debug.AddSummaryMessage("Finished MetaData.Scenery.LoadAll()" + (loadingErrors > 0 ? (" with " + loadingErrors + " errors.") : (".")));
				return (loadingErrors <= 0);
			}
			#endregion
		}
	}
}
