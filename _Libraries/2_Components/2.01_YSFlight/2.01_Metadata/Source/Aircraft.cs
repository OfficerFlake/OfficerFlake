﻿using System;
using System.IO;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Loggers;

namespace Com.OfficerFlake.Libraries.YSFlight
{
    public static partial class Metadata
    {
		public class Aircraft : IO.ListFile.Line, IMetaDataAircraft
		{
			#region Properties
			public string Path_0_PropertiesFile
			{
				get => (Contents.Count > 0) ? Contents[0] : "";
				set
				{
					while (Contents.Count <= 0) 
					{
						Contents.Add("");
					}
					Contents[0] = value;
				}
			}
			public string Path_1_ModelFile
			{
				get => (Contents.Count > 1) ? Contents[1] : "";
				set
				{
					while (Contents.Count <= 1)
					{
						Contents.Add("");
					}
					Contents[1] = value;
				}
			}
			public string Path_2_CollisionFile
			{
				get => (Contents.Count > 2) ? Contents[2] : "";
				set
				{
					while (Contents.Count <= 2)
					{
						Contents.Add("");
					}
					Contents[2] = value;
				}
			}
			public string Path_3_CockpitFile
			{
				get => (Contents.Count > 3) ? Contents[3] : "";
				set
				{
					while (Contents.Count <= 3)
					{
						Contents.Add("");
					}
					Contents[3] = value;
				}
			}
			public string Path_4_CoarseFile {
				get => (Contents.Count > 4) ? Contents[4] : "";
				set
				{
					while (Contents.Count <= 4)
					{
						Contents.Add("");
					}
					Contents[4] = value;
				}
			}
			#endregion
			#region Cached Information
			public string Identify { get; set; } = "NULL";
			#endregion

			public Aircraft(string[] parameters) : base(parameters) { }
			public Aircraft(string identify) : base(new string[] { })
			{
				Identify = identify;
			}

		    public IDATFile LoadDATFile()
		    {
		        IDATFile DatFile = ObjectFactory.CreateDATFileReference(SettingsLibrary.Settings.YSFlight.Directory + Path_0_PropertiesFile);
		        return DatFile;
		    }

			#region Load All
			/// <summary>
			/// Searches the YSFlightDirectory for the Aircraft Folder, and loads all Aircraft Lists from it.
			/// </summary>
			/// <returns></returns>
			public static bool LoadAll()
			{
				Debug.AddSummaryMessage("Starting MetaData.Aircraft.LoadAll()");
				Extensions.YSFlight.MetaData.Aircraft.List.Clear();

				int loadingErrors = 0;

				#region Load All Aircraft MetaData
				try
				{
					string YSFlightAircraftDirectory = SettingsLibrary.Settings.YSFlight.Directory + @"Aircraft/";

					#region Aircraft Directory Not Found on Disk
					if (!Directory.Exists(YSFlightAircraftDirectory))
					{
						Debug.AddErrorMessage(new DirectoryNotFoundException(), "YSFlight Aircraft Directory Not Found.");
						return false;
					}
					#endregion
					#region Initialise Variables
					string[] allFilesInDirectory = Directory.GetFiles(YSFlightAircraftDirectory);
					string[] allLSTFilesInDirectory = allFilesInDirectory.Select(Path.GetFileName).ToArray();
					string[] aircraftLists = allLSTFilesInDirectory
						.Where(x => x.ToUpperInvariant().StartsWith(@"AIR") && x.ToUpperInvariant().EndsWith(@".LST")).ToArray();
					#endregion

					#region Load Each Aircraft List.
					foreach (string thisAircraftListFile in aircraftLists)
					{
						#region Aircraft List Not Found on Disk
						if (!File.Exists(YSFlightAircraftDirectory + thisAircraftListFile))
						{
							string message = "Aircraft List defined in directory tree not found.";
							Debug.AddWarningMessage(message);
							loadingErrors++;
							continue;
						}
						#endregion
						#region Get Lines With .DAT Definitions
						string[] aircraftListContents = File.ReadAllLines(YSFlightAircraftDirectory + thisAircraftListFile);
						aircraftListContents = aircraftListContents.Where(x => x.ToUpperInvariant().Contains(@".DAT")).ToArray();
						#endregion
						#region Iterate Over LST Contents
						for (int i =0; i < aircraftListContents.Length; i++)
						{
							#region Update Line Number and Contents
							string thisLine = aircraftListContents[i];
							string ProcessedLine = thisLine.Replace("\\", "/");
							string[] SplitString = ProcessedLine.ToUpperInvariant().SplitPresevingQuotes();
							#endregion

							if (thisLine == "") continue; //skip blank lines.

							#region Initialise Variables
							string AircraftPath0Dat = "";
							string AircraftPath1Model = "";
							string AircraftPath2Collision = "";
							string AircraftPath3Cockpit = "";
							string AircraftPath4Coarse = "";
							#endregion

							#region Assign File Paths for This Aircraft
							switch (SplitString.Length - 1)
							{
								default:
									if (SplitString.Length > 4) goto case 4;
									break;
								case 4:
									AircraftPath4Coarse = SplitString[4];
									goto case 3;
								case 3:
									AircraftPath3Cockpit = SplitString[3];
									goto case 2;
								case 2:
									AircraftPath2Collision = SplitString[2];
									goto case 1;
								case 1:
									AircraftPath1Model = SplitString[1];
									goto case 0;
								case 0:
									AircraftPath0Dat = SplitString[0];
									break;
							}
							#endregion
							#region Create a New MetaAircraft
							Aircraft NewMetaAircraft = new Aircraft(
								new[]
								{
									AircraftPath0Dat,
									AircraftPath1Model,
									AircraftPath2Collision,
									AircraftPath3Cockpit,
									AircraftPath4Coarse
								});
							#endregion
							#region Ensure .DAT is defined.
							if (NewMetaAircraft.Path_0_PropertiesFile.Length < 3)
							{
								string message = "Incomplete line in Aircraft List: " + thisAircraftListFile + ".";
								Logger.AddDebugMessage(message);
								Logger.AddDebugMessage("----" + thisLine);
								loadingErrors++;
								continue;
							}
							#endregion

							Extensions.YSFlight.MetaData.Aircraft.List.Add(NewMetaAircraft);
						}
						Logger.AddDebugMessage("Loaded AircraftLST: " + thisAircraftListFile);
						#endregion
					}
					#endregion
					#region Cache MetaAircraft Names
					for (int i = 0; i < Extensions.YSFlight.MetaData.Aircraft.List.Count; i++)
					{
						#region .DAT Not Found on Disk
						IMetaDataAircraft ThisMetaAircraft = Extensions.YSFlight.MetaData.Aircraft.List[i];
						if (!File.Exists(SettingsLibrary.Settings.YSFlight.Directory + ThisMetaAircraft.Path_0_PropertiesFile))
						{
							string message = "Aircraft DAT file doesn't exist: " + ThisMetaAircraft.Path_0_PropertiesFile + ".";
							Debug.AddWarningMessage(message);
							loadingErrors++;
							continue;
						}
						#endregion
						#region Update Line Number and Contents
						string[] DatFileContents = File.ReadAllLines(SettingsLibrary.Settings.YSFlight.Directory + ThisMetaAircraft.Path_0_PropertiesFile);
						#endregion
						#region Find IDENTIFY in DAT
						for (int j = 0; j < DatFileContents.Length; j++)
						{
							string ThisLine = DatFileContents[j];
							int CurrentLineNumber = j;

							#region Identify
							if (ThisLine.ToUpperInvariant().Contains(@"IDENTIFY"))
							{
								string[] SplitLine = ThisLine.SplitPresevingQuotes();
								if (SplitLine.Length <= 1)
								{
									string message = "Aircraft DAT IDENTIFY Line broken, or string splitter broken: " + ThisMetaAircraft.Path_0_PropertiesFile + ".";
									Debug.AddWarningMessage(message);
									Logger.AddDebugMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									loadingErrors++;
									continue;
								}
								string AircraftName = SplitLine[1];
								AircraftName = AircraftName.Replace(@" ", @"_");
								ThisMetaAircraft.Identify = AircraftName.ToUpperInvariant();
								Logger.AddDebugMessage("Cached Aircraft Name: " + ThisMetaAircraft.Identify);
							}
							#endregion
						}
						#endregion
						#region Couldn't Find IDENTIFY
						if (ThisMetaAircraft.Identify == null)
						{
							string message = "Aircraft DAT file doesn't contain IDENTIFY: " + ThisMetaAircraft.Path_0_PropertiesFile + ".";
							Debug.AddWarningMessage(message);
							loadingErrors++;
							continue;
						}
						#endregion
					}
					#endregion
				}
				catch (Exception e)
				{
					string message = "MetaData.Aircraft.LoadAll Crashed!";
					Debug.AddErrorMessage(e, message);
					loadingErrors++;
				}
				#endregion

				Debug.AddSummaryMessage("Finished MetaData.Aircraft.LoadAll()" + (loadingErrors > 0 ? (" with " + loadingErrors + " errors.") : (".")));
				return (loadingErrors <= 0);
			}
			#endregion
		}
	}
}
