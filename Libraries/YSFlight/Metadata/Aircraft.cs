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
		public class Aircraft : IO.ListFile.Line, IMetaDataAircraft
		{
			#region Variables
			public string Path_0_PropertiesFile { get; set; }
			public string Path_1_ModelFile { get; set; }
			public string Path_2_CollisionFile { get; set; }
			public string Path_3_CockpitFile { get; set; }
			public string Path_4_CoarseFile { get; set; }

			#endregion
			#region Cached Information
			public string Identify { get; set; }
			#endregion

			public Aircraft(string[] parameters) : base(parameters) { }
			public Aircraft(string identify) : base(new string[] { })
			{
				Identify = identify;
			}
			public static List<IRichTextMessage> DebugInformation = new List<IRichTextMessage>();

			#region Load All
			/// <summary>
			/// Searches the YSFlightDirectory for the Aircraft Folder, and loads all Aircraft Lists from it.
			/// </summary>
			/// <returns></returns>
			public static bool LoadAll()
			{
				//Invalidate the old aircraft list!
				Extensions.YSFlight.MetaData.Aircraft.List.Clear();
				DebugInformation.Clear();

				try
				{
					string YSFlightAircraftDirectory = YSFlightDirectory + @"Aircraft/";

					#region Aircraft Directory Not Found on Disk
					if (!Directory.Exists(YSFlightAircraftDirectory)) return false;
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
						if (!File.Exists(YSFlightAircraftDirectory + thisAircraftListFile)) return false;
						#endregion
						#region Get Lines With .DAT Definitions.
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
							if (NewMetaAircraft.Path_0_PropertiesFile.Length < 4)
							{
								var Warning = ("Blank line in Aircraft List: " + thisAircraftListFile + ".").AsDebugWarningMessage();
								DebugInformation.Add(Warning);
								continue;
							}
							#endregion

							Extensions.YSFlight.MetaData.Aircraft.List.Add(NewMetaAircraft);
						}
						#endregion
					}
					#endregion
					#region Cache MetaAircraft Names
					for (int i = 0; i < Extensions.YSFlight.MetaData.Aircraft.List.Count; i++)
					{
						#region Update Line Number and Contents
						IMetaDataAircraft ThisMetaAircraft = Extensions.YSFlight.MetaData.Aircraft.List[i];
						string[] DatFileContents = File.ReadAllLines(YSFlightDirectory + ThisMetaAircraft.Path_0_PropertiesFile);
						#endregion

						#region .DAT Not Found on Disk
						if (!File.Exists(YSFlightDirectory + ThisMetaAircraft.Path_0_PropertiesFile))
						{
							var Warning =
								("Aircraft DAT file doesn't exist: " + ThisMetaAircraft.Path_0_PropertiesFile + ".").AsDebugWarningMessage();
							DebugInformation.Add(Warning);
							continue; //Couldn't find the aircraft DAT file, we'll leave it blank!
						}
						#endregion

						#region Find IDENTIFY in DAT
						foreach (string DatFileLine in DatFileContents)
						{
							#region Identify

							if (DatFileLine.ToUpperInvariant().Contains(@"IDENTIFY"))
							{
								string[] SplitLine = DatFileLine.SplitPresevingQuotes();
								if (SplitLine.Length <= 1)
								{
									var Warning =("Aircraft DAT IDENTIFY Line broken, or string splitter broken: " + ThisMetaAircraft.Path_0_PropertiesFile + ".").AsDebugWarningMessage();
									DebugInformation.Add(Warning);
									var Warning2 = ("Aircraft DAT IDENTIFY Line broken, or string splitter broken: " + DatFileLine + ".").AsDebugWarningMessage();
									DebugInformation.Add(Warning2);
									continue;
								}
								string AircraftName = SplitLine[1];
								AircraftName = AircraftName.Replace(@" ", @"_");
								ThisMetaAircraft.Identify = AircraftName.ToUpperInvariant();
							}

							#endregion
						}
						#endregion
						#region Couldn't Find IDENTIFY
						if (ThisMetaAircraft.Identify == null)
						{
							var Warning = ("Aircraft DAT file doesn't contain IDENTIFY: " + ThisMetaAircraft.Path_0_PropertiesFile + ".").AsDebugWarningMessage();
							DebugInformation.Add(Warning);
						}
						#endregion
					}
					#endregion

					return (DebugInformation.Count <= 0);
				}
				catch (Exception e)
				{
					var Error = ("MetaData.Aircraft.LoadAll Crashed!").AsDebugErrorMessage(e);
					DebugInformation.Add(Error);
				}

				return (DebugInformation.Count <= 0);
			}
			#endregion
		}
	}
}
