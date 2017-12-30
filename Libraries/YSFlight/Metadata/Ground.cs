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
		public class Ground : IO.ListFile.Line, IMetaDataGround
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

			public Ground(string[] parameters) : base(parameters) { }
			public Ground(string identify) : base(new string[] { })
			{
				Identify = identify;
			}
			public static List<IRichTextMessage> DebugInformation = new List<IRichTextMessage>();

			#region Load All
			/// <summary>
			/// Searches the YSFlightDirectory for the Ground Folder, and loads all Ground Lists from it.
			/// </summary>
			/// <returns></returns>
			public static bool LoadAll()
			{
				//Invalidate the old Ground list!
				Extensions.YSFlight.MetaData.Grounds.List.Clear();
				DebugInformation.Clear();

				try
				{
					string YSFlightGroundDirectory = YSFlightDirectory + @"Ground/";
					if (!Directory.Exists(YSFlightGroundDirectory)) return false;
					string[] FullFilenames = Directory.GetFiles(YSFlightGroundDirectory);
					string[] Filenames = FullFilenames.Select(Path.GetFileName).ToArray();
					string[] GroundLists = Filenames
						.Where(x => x.ToUpperInvariant().StartsWith(@"GRO") && x.ToUpperInvariant().EndsWith(@".LST")).ToArray();
					foreach (string GroundList in GroundLists)
					{
						if (!File.Exists(YSFlightGroundDirectory + GroundList)) return false;
						string[] GroundListContents = File.ReadAllLines(YSFlightGroundDirectory + GroundList);
						GroundListContents = GroundListContents.Where(x => x.ToUpperInvariant().Contains(@".DAT")).ToArray();
						foreach (string Line in GroundListContents)
						{
							string ProcessedLine = Line.Replace("\\", "/");
							string[] SplitString = ProcessedLine.SplitPresevingQuotes();
							string GroundPath0Dat = "";
							string GroundPath1Model = "";
							string GroundPath2Collision = "";
							string GroundPath3Cockpit = "";
							string GroundPath4Coarse = "";

							switch (SplitString.Length - 1)
							{
								case 4:
									GroundPath4Coarse = SplitString[4];
									goto case 3;
								case 3:
									GroundPath3Cockpit = SplitString[3];
									goto case 2;
								case 2:
									GroundPath2Collision = SplitString[2];
									goto case 1;
								case 1:
									GroundPath1Model = SplitString[1];
									goto case 0;
								case 0:
									GroundPath0Dat = SplitString[0];
									break;
							}

							Ground NewMetaGround = new Ground(
								new[]
								{
									GroundPath0Dat,
									GroundPath1Model,
									GroundPath3Cockpit,
									GroundPath4Coarse,
								});

							if (NewMetaGround.Path_0_PropertiesFile.Length < 4)
							{
								//InformationMessage Error = new InformationMessage
								//	(
								//	"Blank line in Ground List: " + GroundList + "."
								//	);
								//DebugInformation.Add(Error);
								continue;
							}

							Extensions.YSFlight.MetaData.Grounds.List.Add(NewMetaGround);
						}
					}

					//AT THIS POINT, ALL YSFLIGHT Ground LST's ARE FULLY LOADED. NOW WE CACHE THE Ground NAMES.

					foreach (Ground ThisMetaGround in Extensions.YSFlight.MetaData.Scenery.List)
					{
						if (!File.Exists(YSFlightDirectory + ThisMetaGround.Path_0_PropertiesFile))
						{
							var Warning = ("Ground DAT file doesn't exist: " + ThisMetaGround.Path_0_PropertiesFile + ".").AsDebugWarningMessage();
							DebugInformation.Add(Warning);
							continue; //Couldn't find the Ground DAT file, we'll leave it blank!
						}
						string[] DatFileContents = File.ReadAllLines(YSFlightDirectory + ThisMetaGround.Path_0_PropertiesFile);
						foreach (string DatFileLine in DatFileContents)
						{
							#region Identify

							if (DatFileLine.ToUpperInvariant().Contains(@"IDENTIFY"))
							{
								string[] SplitLine = DatFileLine.SplitPresevingQuotes();
								if (SplitLine.Length <= 1)
								{
									var Warning = ("Ground DAT IDENTIFY Line broken, or string splitter broken: " + ThisMetaGround.Path_0_PropertiesFile + ".").AsDebugWarningMessage();
									DebugInformation.Add(Warning);
									var Warning2 = ("Ground DAT IDENTIFY Line broken, or string splitter broken: " + DatFileLine + ".").AsDebugWarningMessage();
									DebugInformation.Add(Warning2);
									continue;
								}
								string GroundName = SplitLine[1];
								GroundName = GroundName.Replace(@" ", @"_");
								ThisMetaGround.Identify = GroundName.ToUpperInvariant();
							}

							#endregion
						}
						if (ThisMetaGround.Identify == null)
						{
							var Warning = ("Ground DAT file doesn't contain IDENTIFY: " + ThisMetaGround.Path_0_PropertiesFile + ".").AsDebugWarningMessage();
							DebugInformation.Add(Warning);
						}
					}

					//Cache Complete. All Ground are loaded, ready for use.
					//return false if there are errors. The loading process should investigate the error log.
					return (DebugInformation.Count <= 0);
				}
				catch (Exception e)
				{
					var Error = ("MetaData.Ground.LoadAll Crashed!").AsDebugErrorMessage(e);
					DebugInformation.Add(Error);
				}

				return (DebugInformation.Count <= 0);
			}
			#endregion
		}
	}
}
