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
		public class Ground
		{
			#region Variables
			public string GroundPath0Dat;
			public string GroundPath1Model;
			public string GroundPath2Collision;
			public string GroundPath3Cockpit;
			public string GroundPath4Coarse;
			#endregion
			#region Cached Information
			public string Identify;
			#endregion

			public static Ground None = new Ground() { Identify = "NULL" };
			public static List<Ground> List = new List<Ground>();
			public static List<RichTextMessage> DebugInformation = new List<RichTextMessage>();

			#region Load All
			/// <summary>
			/// Searches the YSFlightDirectory for the Ground Folder, and loads all Ground Lists from it.
			/// </summary>
			/// <returns></returns>
			public static bool LoadAll()
			{
				//Invalidate the old Ground list!
				List.Clear();
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

							Ground NewMetaGround = new Ground
							{
								GroundPath0Dat = GroundPath0Dat,
								GroundPath1Model = GroundPath1Model,
								GroundPath2Collision = GroundPath2Collision,
								GroundPath3Cockpit = GroundPath3Cockpit,
								GroundPath4Coarse = GroundPath4Coarse
							};

							if (NewMetaGround.GroundPath0Dat.Length < 4)
							{
								//InformationMessage Error = new InformationMessage
								//	(
								//	"Blank line in Ground List: " + GroundList + "."
								//	);
								//DebugInformation.Add(Error);
								continue;
							}

							List.Add(NewMetaGround);
						}
					}

					//AT THIS POINT, ALL YSFLIGHT Ground LST's ARE FULLY LOADED. NOW WE CACHE THE Ground NAMES.

					foreach (Ground ThisMetaGround in List)
					{
						if (!File.Exists(YSFlightDirectory + ThisMetaGround.GroundPath0Dat))
						{
							DebugWarningMessage Warning = new DebugWarningMessage
							(
								"Ground DAT file doesn't exist: " + ThisMetaGround.GroundPath0Dat + "."
							);
							DebugInformation.Add(Warning);
							continue; //Couldn't find the Ground DAT file, we'll leave it blank!
						}
						string[] DatFileContents = File.ReadAllLines(YSFlightDirectory + ThisMetaGround.GroundPath0Dat);
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
										"Ground DAT IDENTIFY Line broken, or string splitter broken: " + ThisMetaGround.GroundPath0Dat + "."
									);
									DebugInformation.Add(Error);
									DebugWarningMessage Error2 = new DebugWarningMessage
									(
										"Ground DAT IDENTIFY Line broken, or string splitter broken: " + DatFileLine + "."
									);
									DebugInformation.Add(Error2);
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
							DebugWarningMessage Error = new DebugWarningMessage
							(
								"Ground DAT file doesn't contain IDENTIFY: " + ThisMetaGround.GroundPath0Dat + "."
							);
							DebugInformation.Add(Error);
						}
					}

					//Cache Complete. All Ground are loaded, ready for use.
					//return false if there are errors. The loading process should investigate the error log.
					return (DebugInformation.Count <= 0);
				}
				catch (Exception e)
				{
					DebugErrorMessage Error = new DebugErrorMessage
					(
						e, "MetaData.Ground.LoadAll Crashed!" + e.ToString()
					);
					DebugInformation.Add(Error);
				}

				return (DebugInformation.Count <= 0);
			}
			#endregion
			#region Find By Name
			/// <summary>
			/// Finds the desired MetaObject by name. If no meta object is found, NoMetaGround is returned.
			/// </summary>
			/// <param name="Name">Ground name to search for.</param>
			/// <returns>
			/// Match: Last Matching MetaGround Object
			/// Else:  "NoMetaGround" Psuedo-Object.
			/// </returns>
			public static Ground FindByName(string Name)
			{
				Ground Output = None;
				if (Name == null) return Output;

				foreach (Ground ThisMetaGround in List)
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
	}
}
