using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.RichText;

namespace Com.OfficerFlake.Libraries.YSFlight
{
    public static partial class Metadata
    {
		public class Aircraft
		{
			#region Variables
			private string AircraftPath0Dat;
			#pragma warning disable 414
			private string AircraftPath1Model;
			private string AircraftPath2Collision;
			private string AircraftPath3Cockpit;
			private string AircraftPath4Coarse;
			#pragma warning restore 414
			#endregion
			#region Cached Information
			public string Identify;
			#endregion

			public static Aircraft None = new Aircraft() { Identify = "NULL" };
			public static List<Aircraft> List = new List<Aircraft>();
			public static List<RichTextMessage> DebugInformation = new List<RichTextMessage>();

			#region Load All
			/// <summary>
			/// Searches the YSFlightDirectory for the Aircraft Folder, and loads all Aircraft Lists from it.
			/// </summary>
			/// <returns></returns>
			public static bool LoadAll()
			{
				//Invalidate the old aircraft list!
				List.Clear();
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
							Aircraft NewMetaAircraft = new Aircraft
							{
								AircraftPath0Dat = AircraftPath0Dat,
								AircraftPath1Model = AircraftPath1Model,
								AircraftPath2Collision = AircraftPath2Collision,
								AircraftPath3Cockpit = AircraftPath3Cockpit,
								AircraftPath4Coarse = AircraftPath4Coarse
							};
							#endregion
							#region Ensure .DAT is defined.
							if (NewMetaAircraft.AircraftPath0Dat.Length < 4)
							{
								DebugWarningMessage Warning = new DebugWarningMessage
									(
									"Blank line in Aircraft List: " + thisAircraftListFile + "."
									);
								DebugInformation.Add(Warning);
								continue;
							}
							#endregion

							List.Add(NewMetaAircraft);
						}
						#endregion
					}
					#endregion
					#region Cache MetaAircraft Names
					for (int i = 0; i < List.Count; i++)
					{
						#region Update Line Number and Contents
						Aircraft ThisMetaAircraft = List[i];
						string[] DatFileContents = File.ReadAllLines(YSFlightDirectory + ThisMetaAircraft.AircraftPath0Dat);
						#endregion

						#region .DAT Not Found on Disk
						if (!File.Exists(YSFlightDirectory + ThisMetaAircraft.AircraftPath0Dat))
						{
							DebugWarningMessage Warning = new DebugWarningMessage
							(
								"Aircraft DAT file doesn't exist: " + ThisMetaAircraft.AircraftPath0Dat + "."
							);
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
									DebugWarningMessage Error = new DebugWarningMessage
									(
										"Aircraft DAT IDENTIFY Line broken, or string splitter broken: " + ThisMetaAircraft.AircraftPath0Dat + "."
									);
									DebugInformation.Add(Error);
									DebugWarningMessage Error2 = new DebugWarningMessage
									(
										"Aircraft DAT IDENTIFY Line broken, or string splitter broken: " + DatFileLine + "."
									);
									DebugInformation.Add(Error2);
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
							DebugWarningMessage Warning = new DebugWarningMessage
							(
								"Aircraft DAT file doesn't contain IDENTIFY: " + ThisMetaAircraft.AircraftPath0Dat + "."
							);
							DebugInformation.Add(Warning);
						}
						#endregion
					}
					#endregion

					return (DebugInformation.Count <= 0);
				}
				catch (Exception e)
				{
					DebugErrorMessage Error = new DebugErrorMessage
					(
						e, "MetaData.Aircraft.LoadAll Crashed!" + e.ToString()
					);
					DebugInformation.Add(Error);
				}

				return (DebugInformation.Count <= 0);
			}
			#endregion
			#region Find By Name
			/// <summary>
			/// Finds the desired MetaObject by name. If no meta object is found, NoMetaAircraft is returned.
			/// </summary>
			/// <param name="Name">Aircraft name to search for.</param>
			/// <returns>
			/// Match: Last Matching MetaAircraft Object
			/// Else:  "NoMetaAircraft" Psuedo-Object.
			/// </returns>
			public static Aircraft FindByName(string Name)
			{
				Aircraft Output = None;
				if (Name == null) return Output;
				
				foreach (Aircraft ThisMetaAircraft in List)
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
	}
}
