using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.YSFlight
{
    public static partial class Metadata
    {
		public class Ground : IO.ListFile.Line, IMetaDataGround
		{
			#region Variables
			public string Path_0_PropertiesFile {
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
			public string Path_1_ModelFile {
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
			public string Path_2_CollisionFile {
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
			public string Path_3_CockpitFile {
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
				Debug.AddSummaryMessage("Starting MetaData.Ground.LoadAll()");
				Extensions.YSFlight.MetaData.Grounds.List.Clear();
				DebugInformation.Clear();

				try
				{
					string YSFlightGroundDirectory = YSFlightDirectory + @"Ground/";
					#region Ground Directory Not Found on Disk
					if (!Directory.Exists(YSFlightGroundDirectory))
					{
						Debug.AddWarningMessage("YSFlight Ground Directory Not Found.");
						return false;
					}
					#endregion
					#region Initialise Variables
					string[] FullFilenames = Directory.GetFiles(YSFlightGroundDirectory);
					string[] Filenames = FullFilenames.Select(Path.GetFileName).ToArray();
					string[] GroundLists = Filenames
						.Where(x => x.ToUpperInvariant().StartsWith(@"GRO") && x.ToUpperInvariant().EndsWith(@".LST")).ToArray();
					#endregion

					#region Load Each Ground List.
					foreach (string thisGroundListFile in GroundLists)
					{
						#region Ground List Not Found on Disk
						if (!File.Exists(YSFlightGroundDirectory + thisGroundListFile))
						{
							string message = "Ground List defined in directory tree not found.";
							IRichTextMessage debugmessage = message.AsDebugWarningMessage();

							Debug.AddWarningMessage(message);
							DebugInformation.Add(debugmessage);
							return false;
						}
						#endregion
						#region Get Lines With .DAT Definitions.
						string[] groundListContents = File.ReadAllLines(YSFlightGroundDirectory + thisGroundListFile);
						groundListContents = groundListContents.Where(x => x.ToUpperInvariant().Contains(@".DAT")).ToArray();
						#endregion

						#region Iterate Over LST Contents
						for (int i = 0; i < groundListContents.Length; i++)
						{
							#region Update Line Number and Contents
							string thisLine = groundListContents[i];
							string ProcessedLine = thisLine.Replace("\\", "/");
							string[] SplitString = ProcessedLine.SplitPresevingQuotes();
							#endregion

							if (thisLine == "") continue; //skip blank lines.

							#region Initalise Variables
							string GroundPath0Dat = "";
							string GroundPath1Model = "";
							string GroundPath2Collision = "";
							string GroundPath3Cockpit = "";
							string GroundPath4Coarse = "";
							#endregion

							#region Assign File Paths for This Ground
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
							#endregion
							#region Create a New MetaGround
							Ground NewMetaGround = new Ground(
								new[]
								{
									GroundPath0Dat,
									GroundPath1Model,
									GroundPath3Cockpit,
									GroundPath4Coarse,
								});
							#endregion
							#region Ensure .DAT is defined.
							if (NewMetaGround.Path_0_PropertiesFile.Length < 4)
							{
								string message = "Blank line in Ground List: " + thisGroundListFile + ".";
								IRichTextMessage debugmessage = message.AsDebugDetailMessage();

								Debug.AddDetailMessage(message);
								Debug.AddDetailMessage("----" + thisLine);
								DebugInformation.Add(debugmessage);
								continue;
							}
							#endregion

							Extensions.YSFlight.MetaData.Grounds.List.Add(NewMetaGround);
						}
						#endregion
					}
					#endregion
					#region Cache MetaGround Names
					for (int i = 0; i < Extensions.YSFlight.MetaData.Grounds.List.Count; i++)
					{
						#region Update Line Number and Contents
						IMetaDataGround ThisMetaGround = Extensions.YSFlight.MetaData.Grounds.List[i];
						string[] DatFileContents = File.ReadAllLines(YSFlightDirectory + ThisMetaGround.Path_0_PropertiesFile);
						#endregion

						#region .DAT Not Found on Disk
						if (!File.Exists(YSFlightDirectory + ThisMetaGround.Path_0_PropertiesFile))
						{
							string message = "Ground DAT file doesn't exist: " + ThisMetaGround.Path_0_PropertiesFile + ".";
							IRichTextMessage debugmessage = message.AsDebugWarningMessage();

							Debug.AddWarningMessage(message);
							DebugInformation.Add(debugmessage);
							continue;
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
									string message = "Ground DAT IDENTIFY Line broken, or string splitter broken: " + ThisMetaGround.Path_0_PropertiesFile + ".";
									IRichTextMessage debugmessage = message.AsDebugWarningMessage();

									Debug.AddWarningMessage(message);
									Debug.AddWarningMessage("----" + DatFileLine);
									DebugInformation.Add(debugmessage);
									continue;
								}
								string GroundName = SplitLine[1];
								GroundName = GroundName.Replace(@" ", @"_");
								ThisMetaGround.Identify = GroundName.ToUpperInvariant();
							}
							#endregion
						}
						#endregion
						#region Couldn't Find IDENTIFY
						if (ThisMetaGround.Identify == null)
						{
							string message = "Ground DAT file doesn't contain IDENTIFY: " + ThisMetaGround.Path_0_PropertiesFile + ".";
							IRichTextMessage debugmessage = message.AsDebugWarningMessage();

							Debug.AddWarningMessage(message);
							DebugInformation.Add(debugmessage);
							continue;
						}
						#endregion
					}
					#endregion
				}
				catch (Exception e)
				{
					string message = "MetaData.Ground.LoadAll Crashed!";
					IRichTextMessage debugmessage = message.AsDebugErrorMessage(e);

					Debug.AddErrorMessage(e, message);
					DebugInformation.Add(debugmessage);
				}

				Debug.AddSummaryMessage("Finished MetaData.Ground.LoadAll()");
				return (DebugInformation.Count <= 0);
			}
			#endregion
		}
	}
}
