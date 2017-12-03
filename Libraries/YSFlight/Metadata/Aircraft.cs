using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.RichText;

namespace Com.OfficerFlake.Libraries.YSFlight
{
    public static partial class Metadata
    {
	    const string YSFlightDirectory = "C:/Program Files/YSFLIGHT.COM/YSFLIGHT/";

		#region Aircraft
		public class Aircraft
		{
			public string AircraftPath0Dat;
			public string AircraftPath1Model;
			public string AircraftPath2Collision;
			public string AircraftPath3Cockpit;
			public string AircraftPath4Coarse;

			public string Identify;
			//DO NOT ADD MORE INFO! METADATA IS A CACHE ONLY!

			public static List<Aircraft> List = new List<Aircraft>();
			public static List<RichTextMessage> DebugInformation = new List<RichTextMessage>();

			/// <summary>
			/// Psuedo-Object to represent Null.
			/// </summary>
			public static Aircraft None = new Aircraft() { Identify = "NULL" };

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

				//If the YSFlight Aircraft directory doesn't exist, return false.

				string YSFlightAircraftDirectory = YSFlightDirectory + @"Aircraft/";
				if (!Directory.Exists(YSFlightAircraftDirectory)) return false;
				string[] FullFilenames = Directory.GetFiles(YSFlightAircraftDirectory);
				string[] Filenames = FullFilenames.Select(Path.GetFileName).ToArray();
				string[] AircraftLists = Filenames.Where(x => x.ToUpperInvariant().StartsWith(@"AIR") && x.ToUpperInvariant().EndsWith(@".LST")).ToArray();
				foreach (string AircraftList in AircraftLists)
				{
					if (!File.Exists(YSFlightAircraftDirectory + AircraftList)) return false;
					string[] AircraftListContents = File.ReadAllLines(YSFlightAircraftDirectory + AircraftList);
					AircraftListContents = AircraftListContents.Where(x => x.ToUpperInvariant().Contains(@".DAT")).ToArray();
					foreach (string Line in AircraftListContents)
					{
						string ProcessedLine = Line.Replace("\\", "/");
						string[] SplitString = ProcessedLine.SplitPresevingQuotes();
						string AircraftPath0Dat = "";
						string AircraftPath1Model = "";
						string AircraftPath2Collision = "";
						string AircraftPath3Cockpit = "";
						string AircraftPath4Coarse = "";

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

						Aircraft NewMetaAircraft = new Aircraft
						{
							AircraftPath0Dat = AircraftPath0Dat,
							AircraftPath1Model = AircraftPath1Model,
							AircraftPath2Collision = AircraftPath2Collision,
							AircraftPath3Cockpit = AircraftPath3Cockpit,
							AircraftPath4Coarse = AircraftPath4Coarse
						};

						if (NewMetaAircraft.AircraftPath0Dat.Length < 4)
						{
							//InformationMessage Error = new InformationMessage
							//	(
							//	"Blank line in Aircraft List: " + AircraftList + "."
							//	);
							//DebugInformation.Add(Error);
							continue;
						}

						List.Add(NewMetaAircraft);
					}
				}

				//AT THIS POINT, ALL YSFLIGHT AIRCRAFT LST's ARE FULLY LOADED. NOW WE CACHE THE AIRCRAFT NAMES.

				foreach (Aircraft ThisMetaAircraft in List)
				{
					if (!File.Exists(YSFlightDirectory + ThisMetaAircraft.AircraftPath0Dat))
					{
						InformationMessage Error = new InformationMessage
						(
							"Aircraft DAT file doesn't exist: " + ThisMetaAircraft.AircraftPath0Dat + "."
						);
						DebugInformation.Add(Error);
						continue; //Couldn't find the aircraft DAT file, we'll leave it blank!
					}
					string[] DatFileContents = File.ReadAllLines(YSFlightDirectory + ThisMetaAircraft.AircraftPath0Dat);
					foreach (string DatFileLine in DatFileContents)
					{
						#region Identify

						if (DatFileLine.ToUpperInvariant().Contains(@"IDENTIFY"))
						{
							string[] SplitLine = DatFileLine.SplitPresevingQuotes();
							if (SplitLine.Length <= 1)
							{
								InformationMessage Error = new InformationMessage
								(
									"Aircraft DAT IDENTIFY Line broken, or string splitter broken: " + ThisMetaAircraft.AircraftPath0Dat + "."
								);
								DebugInformation.Add(Error);
								InformationMessage Error2 = new InformationMessage
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
					if (ThisMetaAircraft.Identify == null)
					{
						InformationMessage Error = new InformationMessage
						(
							"Aircraft DAT file doesn't contain IDENTIFY: " + ThisMetaAircraft.AircraftPath0Dat + "."
						);
						DebugInformation.Add(Error);
					}
				}

				//Cache Complete. All aircraft are loaded, ready for use.
				//return false if there are errors. The loading process should investigate the error log.
				return (DebugInformation.Count <= 0);
			}
			#endregion
			#region Find By Name
			/// <summary>
			/// Finds the desired MetaObject by name. If no meta object is found, NULL is returned.
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
						ThisMetaAircraft.Identify.ToUpperInvariant().ResizeOnRight(31),
						Name.ToUpperInvariant().ResizeOnRight(31)))
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
		#endregion
	}
}
