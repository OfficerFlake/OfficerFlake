using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

using Com.OfficerFlake.Libraries.RichText;

namespace Com.OfficerFlake.Libraries.YSFlight
{
	public static class World
	{
		public static List<RichTextMessage> DebugMessages = new List<RichTextMessage>();

		public static Color.XRGBColor GroundColor = null;
		public static Color.XRGBColor SkyColor = null;
		public static Color.XRGBColor FogColor = null;

		public static class Objects
		{
			private static volatile uint NextID = 1;
			public static uint GetNextID()
			{
				return NextID++;
			}

			public class Aircraft
			{
				public string Identify;
				public uint IFF;

				public class _Position
				{
					public double X;
					public double Y;
					public double Z;
				}
				public _Position Position = new _Position();

				public class _Attitude
				{
					public double X;
					public double Y;
					public double Z;
				}
				public _Attitude Attitude = new _Attitude();
			}
			public static List<Aircraft> AircraftList = new List<Aircraft>();
			public static Aircraft NULL_Aircraft;

			public class StartPosition
			{
				public string Identify = "NULL";
				public double Speed = 0.00;
				public double Throttle = 0.00;
				public bool Gear = true;

				public class _Position
				{
					public double X = 0.00;
					public double Y = 0.00;
					public double Z = 0.00;
				}
				public _Position Position = new _Position();

				public class _Attitude
				{
					public double X = 0.00;
					public double Y = 0.00;
					public double Z = 0.00;
				}
				public _Attitude Attitude = new _Attitude();
			}
			public static List<StartPosition> StartPositionList = new List<StartPosition>();
			public static StartPosition NULL_StartPosition;

			public class Ground
			{
				public string Identify = "<NULL>";
				public string Tag = "<NULL>";
				public uint Strength = 240;
				public uint IFF = 0;
				public uint ID = World.Objects.GetNextID();
				public Metadata.Ground MetaGroundObject = Metadata.Ground.None;

				public class _Position
				{
					public float X = 0;
					public float Y = 0;
					public float Z = 0;
				}
				public _Position Position = new _Position();

				public class _Attitude
				{
					public float X = 0;
					public float Y = 0;
					public float Z = 0;
				}
				public _Attitude Attitude = new _Attitude();
			}
			public static List<Ground> GroundList = new List<Ground>();
			public static Ground NULL_Ground;

			public class Path
			{
				public string Identify = "<NULL>";
				public uint Type = 0;
				public bool IsLooping = false;

				public string AreaType = "<NULL>";

				public class _Position
				{
					public float X = 0;
					public float Y = 0;
					public float Z = 0;
				}
				public _Position Position = new _Position();

				public class _Point
				{
					public float X = 0;
					public float Y = 0;
					public float Z = 0;
				}
				public List<_Point> Points = new List<_Point>();

				public List<_Point> Interpolate()
				{
					List<Objects.Path._Point> OriginalList = this.Points;
					List<Objects.Path._Point> NewPath = new List<Objects.Path._Point>();
					for (int i = 0; i < OriginalList.Count - 1; i++)
					{
						NewPath.Add(OriginalList.ToArray()[i]);
						Objects.Path._Point NewPoint = new Objects.Path._Point();
						NewPoint.X = (OriginalList.ToArray()[i].X + OriginalList.ToArray()[i + 1].X) / 2f;
						NewPoint.Y = (OriginalList.ToArray()[i].Y + OriginalList.ToArray()[i + 1].Y) / 2f;
						NewPoint.Z = (OriginalList.ToArray()[i].Z + OriginalList.ToArray()[i + 1].Z) / 2f;
						NewPath.Add(NewPoint);
						//if (i == OriginalList.Count - 2) NewPath.Add(OriginalList.ToArray()[i + 1]);

						/*
                        if (i == OriginalList.Count - 2 & this.IsLooping)
                        {
                            NewPoint = new Objects.Path._Point();
                            NewPoint.X = (OriginalList.ToArray()[i+1].X + OriginalList.ToArray()[0].X) / 2f;
                            NewPoint.Y = (OriginalList.ToArray()[i+1].Y + OriginalList.ToArray()[0].Y) / 2f;
                            NewPoint.Z = (OriginalList.ToArray()[i+1].Z + OriginalList.ToArray()[0].Z) / 2f;
                            NewPath.Add(NewPoint);
                        }
                        */

					}
					NewPath.Add(OriginalList.ToArray()[OriginalList.Count - 1]);
					return NewPath;
				}

				public List<_Point> Decimate()
				{
					List<Objects.Path._Point> OriginalList = this.Points;
					List<Objects.Path._Point> NewPath = new List<Objects.Path._Point>();
					for (int i = 0; i < OriginalList.Count - 1; i++)
					{
						if (i == 0)
						{
							//add the start of the path.
							NewPath.Add(OriginalList.ToArray()[0]);
							continue;
						}
						if ((OriginalList.Count - 2) % 2 == 0)
						{
							//even no.
							Objects.Path._Point NewPoint = new Objects.Path._Point();
							NewPoint.X = (OriginalList.ToArray()[i].X + OriginalList.ToArray()[i + 1].X) / 2;
							NewPoint.Y = (OriginalList.ToArray()[i].Y + OriginalList.ToArray()[i + 1].Y) / 2;
							NewPoint.Z = (OriginalList.ToArray()[i].Z + OriginalList.ToArray()[i + 1].Z) / 2;
							NewPath.Add(NewPoint);
							i++; //skip the next point!
						}
						else
						{
							//odd no.
							i++;
							if (i < OriginalList.Count - 1) NewPath.Add(OriginalList.ToArray()[i]);
						}
					}
					NewPath.Add(OriginalList.ToArray()[OriginalList.Count - 1]);
					return NewPath;
				}

			}
			public static List<Path> PathList = new List<Path>();
			public static Path._Point NULL_Point = new Path._Point();
			public static Path NULL_Path = new Path();

			public class Scenery
			{
				public Scenery Parent = RootScenery;
				public string Identify = "";
				public int EndLine = 0;
				public List<Scenery> Children = new List<Scenery>();
				public List<Ground> GroundObjects = new List<Ground>();
				public List<Path> MotionPaths = new List<Path>();

				public class _Position
				{
					public float X;
					public float Y;
					public float Z;
				}
				public _Position Position = new _Position();

				public class _Attitude
				{
					public float X;
					public float Y;
					public float Z;
				}
				public _Attitude Attitude = new _Attitude();

				public bool AddChild(Scenery ThisChild)
				{
					if (ThisChild == this) return false;
					Children.Add(ThisChild);
					return true;
				}

				public bool ProcessGrounds()
				{
					int Indent = 0;
					Scenery Target = this;
					while (Target.Parent != RootScenery)
					{
						Indent++;
						Target = Target.Parent;
					}
					foreach (Scenery ThisScenery in this.Children)
					{
						//Console.WriteLine("SUBSCENERY: " + Identify);
						ThisScenery.ProcessGrounds();
					}
					//Console.WriteLine("END SUBSCENERY: " + Identify);
					foreach (Ground ThisGround in this.GroundObjects)
					{

						float PosX = ThisGround.Position.X;
						float PosY = ThisGround.Position.Y;
						float PosZ = ThisGround.Position.Z;
						ThisGround.Position.X = (float)(this.Position.X + (Math.Cos(-this.Attitude.X / 180 * Math.PI) * PosX) + (Math.Sin(-this.Attitude.X / 180 * Math.PI) * PosZ));
						ThisGround.Position.Y = (float)(this.Position.Y + ThisGround.Position.Y);
						ThisGround.Position.Z = (float)(this.Position.Z + (Math.Sin(-this.Attitude.X / 180 * Math.PI) * -PosX) + (Math.Cos(-this.Attitude.X / 180 * Math.PI) * PosZ));
						ThisGround.Attitude.X += this.Attitude.X;
						ThisGround.Attitude.Y += this.Attitude.Y;
						ThisGround.Attitude.Z += this.Attitude.Z;
						Parent.GroundObjects.Add(ThisGround);
					}
					GroundObjects.Clear();
					return true;
				}

				public bool ProcessPaths()
				{
					int Indent = 0;
					Scenery Target = this;
					while (Target.Parent != RootScenery)
					{
						Indent++;
						Target = Target.Parent;
					}
					foreach (Scenery ThisScenery in this.Children)
					{
						//Console.WriteLine("SUBSCENERY: " + Identify);
						ThisScenery.ProcessPaths();
					}
					//Console.WriteLine("END SUBSCENERY: " + Identify);
					foreach (Path ThisPath in this.MotionPaths)
					{
						foreach (Path._Point ThisPoint in ThisPath.Points.ToArray())
						{
							float _PosX = ThisPoint.X + ThisPath.Position.X;
							float _PosY = ThisPoint.Y + ThisPath.Position.Y;
							float _PosZ = ThisPoint.Z + ThisPath.Position.Z;
							ThisPoint.X = (float)(this.Position.X + (Math.Cos(-this.Attitude.X / 180 * Math.PI) * _PosX) + (Math.Sin(-this.Attitude.X / 180 * Math.PI) * _PosZ));
							ThisPoint.Y = (float)(this.Position.Y + ThisPoint.Y);
							ThisPoint.Z = (float)(this.Position.Z + (Math.Sin(-this.Attitude.X / 180 * Math.PI) * -_PosX) + (Math.Cos(-this.Attitude.X / 180 * Math.PI) * _PosZ));
						}
						float PosX = ThisPath.Position.X;
						float PosY = ThisPath.Position.Y;
						float PosZ = ThisPath.Position.Z;
						ThisPath.Position.X = (float)(this.Position.X + (Math.Cos(-this.Attitude.X / 180 * Math.PI) * PosX) + (Math.Sin(-this.Attitude.X / 180 * Math.PI) * PosZ));
						ThisPath.Position.Y = (float)(this.Position.Y + ThisPath.Position.Y);
						ThisPath.Position.Z = (float)(this.Position.Z + (Math.Sin(-this.Attitude.X / 180 * Math.PI) * -PosX) + (Math.Cos(-this.Attitude.X / 180 * Math.PI) * PosZ));
						Parent.MotionPaths.Add(ThisPath);
					}
					MotionPaths.Clear();
					return true;
				}
			}

			public static Scenery RootScenery = new Scenery();
		}

		public static bool Load(string Name)
		{
			DebugMessages.Clear();
			Metadata.Scenery Target = Metadata.Scenery.FindByName(Name);
			if (Target == Metadata.Scenery.None)
			{
				DebugMessages.Add(new WarningMessage("Scenery Not Found: \"" + Name + "\""));
				return false;
			}
			else
			{
				Load(Target);
				return (DebugMessages.Count(x => x is WarningMessage) > 0);
			}
		}
		public static bool Load(Metadata.Scenery InputScenery)
		{
			#region Start Debug Log
			DebugMessages.Clear();
			DebugMessages.Add(new InformationMessage("Starting World.Load"));
			#endregion
			#region Clear Objects
			Objects.GroundList.Clear();
			Objects.PathList.Clear();
			Objects.StartPositionList.Clear();
			#endregion

			DebugMessages.Add(new InformationMessage("Loading World: " + InputScenery.Identify));

			#region LoadFLD
			DebugMessages.Add(new InformationMessage("Starting World.LoadFLD"));
			LoadFLD(InputScenery);
			DebugMessages.Add(new InformationMessage("Ended World.LoadFLD"));
			#endregion

			DebugMessages.Add(new InformationMessage("Loaded " + Objects.GroundList.Count + " Ground Objects from FLD."));
			DebugMessages.Add(new InformationMessage("Loaded " + Objects.PathList.Count + " Motion Paths from FLD."));

			#region LoadSTP
			DebugMessages.Add(new InformationMessage("Starting World.LoadSTP"));
			LoadSTP(InputScenery);
			DebugMessages.Add(new InformationMessage("Ended World.LoadSTP"));
			#endregion

			DebugMessages.Add(new InformationMessage("Loaded " + Objects.StartPositionList.Count + " Start Positions from STP."));

			#region LoadYFS
			int GroundsLoadedFromFLD = Objects.GroundList.Count;

			DebugMessages.Add(new InformationMessage("Starting World.LoadYFS"));
			LoadYFS(InputScenery);
			DebugMessages.Add(new InformationMessage("Ended World.LoadYFS"));
			#endregion

			DebugMessages.Add(new InformationMessage("Loaded " + (Objects.GroundList.Count - GroundsLoadedFromFLD) + " Ground Objects from YFS."));

			return (DebugMessages.Count(x => x is WarningMessage) > 0);
		}

		private static bool LoadFLD(Metadata.Scenery InputScenery)
		{
			#region FLD Not Found on Disk
			if (!File.Exists(Metadata.YSFlightDirectory + InputScenery.SceneryPath1Fld))
			{
				DebugMessages.Add(new WarningMessage("FLD File Not Found: " + InputScenery.SceneryPath1Fld));
				return false;
			}
			#endregion
			#region Read File Contents
			string[] FLDContents = File.ReadAllLines(Metadata.YSFlightDirectory + InputScenery.SceneryPath1Fld);
			#endregion

			#region Initialise Variables
			Objects.RootScenery = new Objects.Scenery();
			Objects.Ground CurrentGround = Objects.NULL_Ground;
			Objects.Path CurrentPath = Objects.NULL_Path;
			Objects.RootScenery.Parent = Objects.RootScenery;
			Objects.Scenery CurrentScenery = Objects.RootScenery;
			Objects.Scenery TargetScenery = Objects.RootScenery;
			int ExpectPos = 0;
			int Indent = 0;
			int GOBsHandled = 0;
			int PSTsHandled = 0;
			List<Objects.Scenery> AllSceneries = new List<Objects.Scenery>();
			#endregion

			#region Iterate over FLD Contents
			for (int i = 0; i < FLDContents.Length; i++)
			{
				#region Update Line Number and Contents
				int CurrentLineNumber = i;
				string ThisLine = FLDContents[i];
				#endregion

				if (ThisLine == "") continue; //Skip Blank Lines.

				#region Move Back to Root Scenery if Past End Of File.
				while (i > CurrentScenery.EndLine && CurrentScenery != Objects.RootScenery)
				{
					DebugMessages.Add(new InformationMessage("Moving back to root scenry"));
					Indent--;
					CurrentScenery = CurrentScenery.Parent;
					if (Indent < 0) Indent = 0;
				}
				#endregion

				#region Editing a Ground Object or Path.
				if (CurrentGround != Objects.NULL_Ground | CurrentPath != Objects.NULL_Path)
				{
					if (CurrentGround != Objects.NULL_Ground)
					{
						#region POS
						if (ThisLine.ToUpperInvariant().StartsWith("POS"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 7)
							{
								DebugMessages.Add(new WarningMessage("POS Line (" + CurrentLineNumber + ") in Ground could not be inspected."));
								DebugMessages.Add(new InformationMessage("Ground POS Line (" + CurrentLineNumber + "): " + ThisLine));
								continue;
							}

							bool failed = false;
							failed |= !Single.TryParse(Split[1], out CurrentGround.Position.X);
							failed |= !Single.TryParse(Split[2], out CurrentGround.Position.Y);
							failed |= !Single.TryParse(Split[3], out CurrentGround.Position.Z);
							failed |= !Single.TryParse(Split[4], out CurrentGround.Attitude.X);
							failed |= !Single.TryParse(Split[5], out CurrentGround.Attitude.Y);
							failed |= !Single.TryParse(Split[6], out CurrentGround.Attitude.Z);
							CurrentGround.Attitude.X = (CurrentGround.Attitude.X / 65535 * 360);
							CurrentGround.Attitude.Y = (CurrentGround.Attitude.Y / 65535 * 360);
							CurrentGround.Attitude.Z = (CurrentGround.Attitude.Z / 65535 * 360);

							if (failed)
							{
								DebugMessages.Add(new WarningMessage("POS Line (" + CurrentLineNumber + ") in Ground could not be converted."));
								DebugMessages.Add(new InformationMessage("Ground POS Line (" + CurrentLineNumber + "): " + ThisLine));

								CurrentGround.Position.X = 0;
								CurrentGround.Position.Y = 0;
								CurrentGround.Position.Z = 0;
								CurrentGround.Attitude.X = 0;
								CurrentGround.Position.Y = 0;
								CurrentGround.Position.Z = 0;
							}
							continue;
						}
						#endregion
						#region NAM
						if (ThisLine.ToUpperInvariant().StartsWith("NAM"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								DebugMessages.Add(new WarningMessage("NAM Line (" + CurrentLineNumber + ") in Ground could not be inspected."));
								DebugMessages.Add(new InformationMessage("Ground NAM Line (" + CurrentLineNumber + "): " + ThisLine));
								continue;
							}

							CurrentGround.Identify = Split[1].Replace(" ","_");

							CurrentGround.MetaGroundObject = Metadata.Ground.FindByName(CurrentGround.Identify);
							if (CurrentGround.MetaGroundObject == Metadata.Ground.None)
							{
								DebugMessages.Add(new WarningMessage("Ground Name (" + CurrentLineNumber + ") in Ground could not be found in Metadata."));
								DebugMessages.Add(new InformationMessage("Ground NAM Line (" + CurrentLineNumber + "): " + ThisLine));
							}

							continue;
						}
						#endregion
						#region TAG
						if (ThisLine.ToUpperInvariant().StartsWith("TAG"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								DebugMessages.Add(new WarningMessage("TAG Line (" + CurrentLineNumber + ") in Ground could not be inspected."));
								DebugMessages.Add(new InformationMessage("TAG Ground Line (" + CurrentLineNumber + "): " + ThisLine));
								continue;
							}

							CurrentGround.Tag = Split[1].Replace(" ", "_");

							continue;
						}
						#endregion
						#region IFF
						if (ThisLine.ToUpperInvariant().StartsWith("IFF"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								DebugMessages.Add(new WarningMessage("IFF Line (" + CurrentLineNumber + ") in Ground could not be inspected."));
								DebugMessages.Add(new InformationMessage("Ground IFF Line (" + CurrentLineNumber + "): " + ThisLine));
								continue;
							}

							bool failed = false;
							failed |= !UInt32.TryParse(Split[1], out CurrentGround.IFF);

							if (failed)
							{
								DebugMessages.Add(new WarningMessage("IFF Line (" + CurrentLineNumber + ") in Ground could not be converted."));
								DebugMessages.Add(new InformationMessage("Ground IFF Line (" + CurrentLineNumber + "): " + ThisLine));

								CurrentGround.IFF = 0;
							}
							continue;
						}
						#endregion

						#region END
						if (ThisLine.ToUpperInvariant().StartsWith("END"))
						{
							CurrentScenery.GroundObjects.Add(CurrentGround);

							DebugMessages.Add(new InformationMessage("Added Ground Object (" + CurrentLineNumber + "): " + CurrentGround.Identify + " " + ThisLine));

							CurrentGround = Objects.NULL_Ground;
							GOBsHandled++;

							continue;
						}
						#endregion
					}
					if (CurrentPath != Objects.NULL_Path)
					{
						#region POS
						if (ThisLine.ToUpperInvariant().StartsWith("POS"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 4)
							{
								DebugMessages.Add(new WarningMessage("POS Line (" + CurrentLineNumber + ") in Path could not be inspected."));
								DebugMessages.Add(new InformationMessage("Path POS Line (" + CurrentLineNumber + "): " + ThisLine));

								continue;
							}
							bool failed = false;
							failed |= !Single.TryParse(Split[1], out CurrentPath.Position.X);
							failed |= !Single.TryParse(Split[2], out CurrentPath.Position.Y);
							failed |= !Single.TryParse(Split[3], out CurrentPath.Position.Z);


							if (failed)
							{
								DebugMessages.Add(new WarningMessage("POS Line (" + CurrentLineNumber + ") in Path could not be converted."));
								DebugMessages.Add(new InformationMessage("Path POS Line (" + CurrentLineNumber + "): " + ThisLine));

								CurrentPath.Position.X = 0;
								CurrentPath.Position.Y = 0;
								CurrentPath.Position.Z = 0;
							}
							continue;
						}
						#endregion
						#region PNT
						if (ThisLine.ToUpperInvariant().StartsWith("PNT"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 4)
							{
								DebugMessages.Add(new WarningMessage("PNT Line (" + CurrentLineNumber + ") in Path could not be inspected."));
								DebugMessages.Add(new InformationMessage("Path PNT Line (" + CurrentLineNumber + "): " + ThisLine));

								continue;
							}

							Objects.Path._Point ThisPoint = new Objects.Path._Point();

							bool failed = false;
							failed |= !Single.TryParse(Split[1], out ThisPoint.X);
							failed |= !Single.TryParse(Split[2], out ThisPoint.Y);
							failed |= !Single.TryParse(Split[3], out ThisPoint.Z);

							if (failed)
							{
								DebugMessages.Add(new WarningMessage("PNT Line (" + CurrentLineNumber + ") in Path could not be converted."));
								DebugMessages.Add(new InformationMessage("Path PNT Line (" + CurrentLineNumber + "): " + ThisLine));

								ThisPoint.X = 0;
								ThisPoint.Y = 0;
								ThisPoint.Z = 0;
							}
							CurrentPath.Points.Add(ThisPoint);
							continue;
						}
						#endregion
						#region TAG
						if (ThisLine.ToUpperInvariant().StartsWith("TAG"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								DebugMessages.Add(new WarningMessage("TAG Line (" + CurrentLineNumber + ") in Path could not be inspected."));
								DebugMessages.Add(new InformationMessage("Path TAG Line (" + CurrentLineNumber + "): " + ThisLine));

								continue;
							}

							CurrentPath.Identify = Split[1].Replace(" ", "_");

							continue;
						}
						#endregion
						#region AREA
						if (ThisLine.ToUpperInvariant().StartsWith("AREA"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								DebugMessages.Add(new WarningMessage("AREA Line (" + CurrentLineNumber + ") in Path could not be inspected."));
								DebugMessages.Add(new InformationMessage("Path AREA Line (" + CurrentLineNumber + "): " + ThisLine));

								continue;
							}
							CurrentPath.AreaType = Split[1].Replace(" ", "_");
							continue;
						}
						#endregion
						#region ISLOOP
						if (ThisLine.ToUpperInvariant().StartsWith("ISLOOP"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								DebugMessages.Add(new WarningMessage("ISLOOP Line (" + CurrentLineNumber + ") in Path could not be inspected."));
								DebugMessages.Add(new InformationMessage("Path ISLOOP Line (" + CurrentLineNumber + "): " + ThisLine));

								continue;
							}

							string option = Split[1].Replace(" ", "_");
							Boolean.TryParse(option, out CurrentPath.IsLooping);

							continue;
						}
						#endregion
						#region ID
						if (ThisLine.ToUpperInvariant().StartsWith("ID"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								DebugMessages.Add(new WarningMessage("ID Line (" + CurrentLineNumber + ") in Path could not be inspected."));
								DebugMessages.Add(new InformationMessage("Path ID Line (" + CurrentLineNumber + "): " + ThisLine));

								continue;
							}

							bool failed = false;
							failed |= !UInt32.TryParse(Split[1], out CurrentPath.Type);

							if (failed)
							{
								DebugMessages.Add(new WarningMessage("ID Line (" + CurrentLineNumber + ") in Path could not be converted."));
								DebugMessages.Add(new InformationMessage("Path ID Line (" + CurrentLineNumber + "): " + ThisLine));

								CurrentPath.Type = 0;
							}
							continue;
						}
						#endregion
						#region FIL
						if (ThisLine.ToUpperInvariant().StartsWith("FIL"))
						{
							//Dont even know WHAT to do here...
							continue;
							/*
                            string[] Split = Utilities.StringCompress(ThisLine).Split(new char[] { ' ' }, 2);
                            if (Split.Length < 2) continue; //couldn't read the name line - error?
                            CurrentPath.Identify = Split[1].ReplaceAll("\"", "").ReplaceAll(" ", "_");
                            //Console.WriteLine("TAG: " + CurrentGround.Tag);
                            continue;
                            */
						}
						#endregion

						#region END
						if (ThisLine.ToUpperInvariant().StartsWith("END"))
						{
							#region Convert Path Points to Path Root
							foreach (Objects.Path._Point ThisPoint in CurrentPath.Points.ToArray())
							{
								ThisPoint.X += CurrentPath.Position.X;
								ThisPoint.Y += CurrentPath.Position.Y;
								ThisPoint.Z += CurrentPath.Position.Z;
							}
							CurrentPath.Position.X = 0;
							CurrentPath.Position.Y = 0;
							CurrentPath.Position.Z = 0;
							#endregion

							CurrentScenery.MotionPaths.Add(CurrentPath);

							DebugMessages.Add(new InformationMessage("Added Path (" + CurrentLineNumber + "): " + CurrentPath.Identify + " " + ThisLine));

							CurrentPath = Objects.NULL_Path;
							PSTsHandled++;
							continue;
						}
						#endregion
					}
				}
				#endregion
				#region Look for another Ground Object or Path
				else
				{
					#region PCK
					if (ThisLine.ToUpperInvariant().StartsWith("PCK"))
					{
						string[] Split = ThisLine.SplitPresevingQuotes();
						if (Split.Length < 2)
						{
							DebugMessages.Add(new WarningMessage("PCK Line (" + CurrentLineNumber + ") in scenery could not be inspected."));
							DebugMessages.Add(new InformationMessage("PCK Line (" + CurrentLineNumber + "): " + ThisLine));
							continue;
						}

						#region Skip PC2 and TER
						if (Split[1].ToUpperInvariant().Contains(".PC2")) continue;
						if (Split[1].ToUpperInvariant().Contains(".TER")) continue;
						#endregion

						if (!Split[1].ToUpperInvariant().Contains(".FLD"))
						{
							DebugMessages.Add(new WarningMessage("PCK Line (" + CurrentLineNumber + ") in scenery does not specify a FLD."));
							DebugMessages.Add(new InformationMessage("PCK Line (" + CurrentLineNumber + "): " + ThisLine));
							continue;
						}

						#region Add a new Child Scenery to Current Scenry
						Objects.Scenery ChildScenery = new Objects.Scenery();
						ChildScenery.Identify = Split[1].ToUpperInvariant();

						ChildScenery.Parent = CurrentScenery;
						CurrentScenery.AddChild(ChildScenery);
						AllSceneries.Add(ChildScenery);
						#endregion

						DebugMessages.Add(new InformationMessage("Adding Child Scenry (" + ChildScenery.Identify + ") to (" + CurrentScenery.Identify + ")"));

						#region Get Number of Lines in Child Scenery
						int numberOfLinesInChildScenry = 0;
						if (!Int32.TryParse(ThisLine.Split(' ')[2].ToUpperInvariant(), out numberOfLinesInChildScenry))
						{
							DebugMessages.Add(new WarningMessage("PCK Line (" + CurrentLineNumber + ") in scenery does not specify number of following lines."));
							DebugMessages.Add(new InformationMessage("PCK Line (" + CurrentLineNumber + "): " + ThisLine));
							continue;
						}
						#endregion
						#region Initialise Child Scenery
						ChildScenery.EndLine = i + numberOfLinesInChildScenry;
						Indent++;
						GOBsHandled = 0;
						PSTsHandled = 0;
						#endregion
						#region Move into Child Scenery
						CurrentScenery = ChildScenery;
						#endregion

						DebugMessages.Add(new InformationMessage("Now Loading Child Scenry (" + CurrentLineNumber + "): " + CurrentScenery.Identify));

						continue;
					}
					#endregion
					#region FIL
					if (ThisLine.ToUpperInvariant().StartsWith("FIL"))
					{
						string[] Split = ThisLine.SplitPresevingQuotes();
						if (Split.Length < 2)
						{
							DebugMessages.Add(new WarningMessage("FIL Line (" + CurrentLineNumber + ") in scenery could not be inspected."));
							DebugMessages.Add(new InformationMessage("FIL Line (" + CurrentLineNumber + "): " + ThisLine));
							continue;
						}

						#region Skip PC2 and TER
						if (Split[1].ToUpperInvariant().Contains(".PC2")) continue;
						if (Split[1].ToUpperInvariant().Contains(".TER")) continue;
						#endregion

						if (!Split[1].ToUpperInvariant().Contains(".FLD"))
						{
							DebugMessages.Add(new WarningMessage("FIL Line (" + CurrentLineNumber + ") in scenery does not specify a FLD."));
							DebugMessages.Add(new InformationMessage("FIL Line (" + CurrentLineNumber + "): " + ThisLine));
							continue;
						}

						if (AllSceneries.Select(x => x.Identify).Contains(Split[1]))
						{
							DebugMessages.Add(new InformationMessage("FIL Line (" + CurrentLineNumber + "): got a FLD."));
							var ArrayOfTargetSceneries = AllSceneries.Where(x => x.Identify == Split[1]).ToArray();
							if (ArrayOfTargetSceneries.Length <= 0)
							{
								DebugMessages.Add(new WarningMessage("|FIL Line in Scenery: FLD In Scenery (" + CurrentLineNumber + ") Could not find a target."));
								DebugMessages.Add(new InformationMessage("FIL Line (" + CurrentLineNumber + "): " + ThisLine));
								continue;
							}
							TargetScenery = ArrayOfTargetSceneries[0];
							ExpectPos = i + 1;
						}

						continue;
					}
					#endregion
					#region POS
					if (ThisLine.ToUpperInvariant().StartsWith("POS") && ExpectPos == i)
					{
						//Console.WriteLine("POS SCE: " + ThisLine);
						string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
						if (Split.Length < 7)
						{
							DebugMessages.Add(new WarningMessage("POS Line (" + CurrentLineNumber + ") in scenery could not be inspected."));
							DebugMessages.Add(new InformationMessage("POS Line (" + CurrentLineNumber + "): " + ThisLine));
							continue;
						}

						bool failed = false;
						failed |= !Single.TryParse(Split[1], out TargetScenery.Position.X);
						failed |= !Single.TryParse(Split[2], out TargetScenery.Position.Y);
						failed |= !Single.TryParse(Split[3], out TargetScenery.Position.Z);
						failed |= !Single.TryParse(Split[4], out TargetScenery.Attitude.X);
						failed |= !Single.TryParse(Split[5], out TargetScenery.Attitude.Y);
						failed |= !Single.TryParse(Split[6], out TargetScenery.Attitude.Z);
						TargetScenery.Attitude.X = (TargetScenery.Attitude.X / 65535 * 360);
						TargetScenery.Attitude.Y = (TargetScenery.Attitude.Y / 65535 * 360);
						TargetScenery.Attitude.Z = (TargetScenery.Attitude.Z / 65535 * 360);


						if (failed)
						{
							DebugMessages.Add(new WarningMessage("POS Line (" + CurrentLineNumber + ") in scenery could not be converted."));
							DebugMessages.Add(new InformationMessage("POS Line (" + CurrentLineNumber + "): " + ThisLine));

							TargetScenery.Position.X = 0;
							TargetScenery.Position.Y = 0;
							TargetScenery.Position.Z = 0;
							TargetScenery.Attitude.X = 0;
							TargetScenery.Position.Y = 0;
							TargetScenery.Position.Z = 0;
						}
						continue;
					}
					#endregion

					#region GND
					if (ThisLine.ToUpperInvariant().StartsWith("GND") & CurrentScenery == Objects.RootScenery)
					{
						try
						{
							string[] colorsAsString = ThisLine.Substring(4).SplitPresevingQuotes();
							byte[] colorsAsByte = new byte[3];
							System.Byte.TryParse(colorsAsString[0], out colorsAsByte[0]);
							System.Byte.TryParse(colorsAsString[1], out colorsAsByte[1]);
							System.Byte.TryParse(colorsAsString[2], out colorsAsByte[2]);
							GroundColor = new Color.XRGBColor(colorsAsByte[0], colorsAsByte[1], colorsAsByte[2]);
						}
						catch
						{
							DebugMessages.Add(new WarningMessage("GND Color Line (" + CurrentLineNumber + ") in scenery could not be inspected."));
							DebugMessages.Add(new InformationMessage("GND Color Line (" + CurrentLineNumber + "): " + ThisLine));
						}
					}
					#endregion
					#region SKY
					if (ThisLine.ToUpperInvariant().StartsWith("SKY") & CurrentScenery == Objects.RootScenery)
					{
						try
						{
							string[] colorsAsString = ThisLine.Substring(4).Split(' ');
							byte[] colorsAsByte = new byte[3];
							System.Byte.TryParse(colorsAsString[0], out colorsAsByte[0]);
							System.Byte.TryParse(colorsAsString[1], out colorsAsByte[1]);
							System.Byte.TryParse(colorsAsString[2], out colorsAsByte[2]);
							SkyColor = new Color.XRGBColor(colorsAsByte[0], colorsAsByte[1], colorsAsByte[2]);
						}
						catch
						{
							DebugMessages.Add(new WarningMessage("SKY Color Line (" + CurrentLineNumber + ") in scenery could not be inspected."));
							DebugMessages.Add(new InformationMessage("SKY Color Line (" + CurrentLineNumber + "): " + ThisLine));
						}
					}
					#endregion

					#region GOB
					if (ThisLine.ToUpperInvariant().StartsWith("GOB"))
					{
						DebugMessages.Add(
							CurrentGround == Objects.NULL_Ground
								? new InformationMessage("Grabbing a Ground Object. (" + CurrentLineNumber + ")")
								: new InformationMessage("Finished Current Ground. (" + CurrentLineNumber + "): Grabbing another..."));
						CurrentGround = new Objects.Ground();
						CurrentPath = Objects.NULL_Path;
						continue;
					}
					#endregion
					#region PST
					if (ThisLine.ToUpperInvariant().StartsWith("PST"))
					{
						DebugMessages.Add(
							CurrentPath == Objects.NULL_Path
								? new InformationMessage("Grabbing a Path. (" + CurrentLineNumber + ")")
								: new InformationMessage("Finished Current Path. (" + CurrentLineNumber + "): Grabbing another..."));
						if (i + 1 < FLDContents.Length)
						{
							string NextLine = FLDContents[i + 1];
							CurrentGround = Objects.NULL_Ground;
							CurrentPath = new Objects.Path();

							//ALWAYS ADD MOTION PATHS, EVEN IF THEY AREN'T LOOPS!
							//if (NextLine.ToUpperInvariant().StartsWith("ISLOOP"))
							//{
							//	DebugMessages.Add(new InformationMessage("PST Line Encountered(" + CurrentLineNumber + ") Will be a loop. We will try to inspect for a Race Track."));
							//}
						}
						continue;
					}
					#endregion
				}
				#endregion
			}
			#endregion

			#region Move Objects to Root Scenery
			DebugMessages.Add(new InformationMessage("Converting Child Sceneries To Root."));
			foreach (Objects.Scenery ThisScenery in Objects.RootScenery.Children)
			{
				DebugMessages.Add(new InformationMessage("Converting Child Scenery To Root:" + ThisScenery.Identify));
				ThisScenery.ProcessGrounds();
				ThisScenery.ProcessPaths();
				DebugMessages.Add(new InformationMessage("Converted Child Scenery To Root:" + ThisScenery.Identify));
			}
			DebugMessages.Add(new InformationMessage("Converted Child Sceneries To Root."));

			DebugMessages.Add(new InformationMessage("Adding Converted Ground Objects."));
			foreach (Objects.Ground ThisGround in Objects.RootScenery.GroundObjects)
			{
				Objects.GroundList.Add(ThisGround);
			}
			DebugMessages.Add(new InformationMessage("Added Converted Ground Objects."));

			DebugMessages.Add(new InformationMessage("Adding Converted Paths."));
			foreach (Objects.Path ThisPath in Objects.RootScenery.MotionPaths.ToArray())
			{
				if (ThisPath.Identify != "" & ThisPath.Type == 15) Objects.PathList.Add(ThisPath);
			}
			DebugMessages.Add(new InformationMessage("Added Converted Paths."));
			#endregion
			return (DebugMessages.Count(x => x is WarningMessage) > 0);
		}
		private static bool LoadSTP(Metadata.Scenery InputScenery)
		{
			#region STP Not Found on Disk
			if (!File.Exists(Metadata.YSFlightDirectory + InputScenery.SceneryPath2Stp)) return false;
			#endregion
			#region Read File Contents
			string[] STPContents = File.ReadAllLines(Metadata.YSFlightDirectory + InputScenery.SceneryPath2Stp);
			#endregion

			#region Initialise Variables
			Objects.StartPosition CurrentStartPosition = Objects.NULL_StartPosition;
			#endregion

			#region Iterate over STP Contents
			for (int i = 0; i < STPContents.Length; i++)
			{
				#region Update Line Number and Contents
				int CurrentLineNumber = i;
				string ThisLine = STPContents[i];
				#endregion

				if (ThisLine == "") continue; //Skip Blank Lines.

				#region Editing a Start Position
				if (CurrentStartPosition != Objects.NULL_StartPosition)
				{
					#region N
					if (ThisLine.ToUpperInvariant().StartsWith("N"))
					{
						#region Finish Current Ground and Start a New One
						if (CurrentStartPosition != Objects.NULL_StartPosition)
						{
							Objects.StartPositionList.Add(CurrentStartPosition);
						}
						#endregion


						string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
						if (Split.Length < 2)
						{
							DebugMessages.Add(new WarningMessage("N Line (" + CurrentLineNumber + ") in STP could not be inspected."));
							DebugMessages.Add(new InformationMessage("N STP Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentStartPosition = Objects.NULL_StartPosition;
							continue; //couldn't read the name line - error?
						}
						CurrentStartPosition = new Objects.StartPosition();
						CurrentStartPosition.Identify = Split[1];
						continue;
					}
					#endregion
					#region C
					if (ThisLine.ToUpperInvariant().StartsWith("C"))
					{
						string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
						if (Split.Length < 2)
						{
							DebugMessages.Add(new WarningMessage("C Line (" + CurrentLineNumber + ") in STP could not be inspected."));
							DebugMessages.Add(new InformationMessage("C STP Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentStartPosition = Objects.NULL_StartPosition;
							continue;
						}
						bool failed = false;
						switch (Split[1].ToUpperInvariant())
						{

							case "POSITION":
								#region POSITION
								if (Split.Length < 5)
								{
									DebugMessages.Add(new WarningMessage("C POSITION Line (" + CurrentLineNumber + ") in STP could not be inspected."));
									DebugMessages.Add(new InformationMessage("C POSITION Line (" + CurrentLineNumber + "): " + ThisLine));
									continue;
								}
								failed = false;
								Length temp;

								temp = 0.Meters();
								failed |= !Length.TryParse(Split[2], out temp);
								Split[2] = temp.ToMeters().ToString();
								CurrentStartPosition.Position.X = (float)temp.ConvertToBase;

								temp = 0.Meters();
								failed |= !Length.TryParse(Split[3], out temp);
								Split[2] = temp.ToMeters().ToString();
								CurrentStartPosition.Position.Y = (float)temp.ConvertToBase;

								temp = 0.Meters();
								failed |= !Length.TryParse(Split[4], out temp);
								Split[3] = temp.ToMeters().ToString();
								CurrentStartPosition.Position.Z = (float)temp.ConvertToBase;

								if (failed)
								{
									DebugMessages.Add(new WarningMessage("C POSITION Line (" + CurrentLineNumber + ") in STP could not be converted."));
									DebugMessages.Add(new InformationMessage("C POSITION Line (" + CurrentLineNumber + "): " + ThisLine));
									CurrentStartPosition.Position.X = 0;
									CurrentStartPosition.Position.Y = 0;
									CurrentStartPosition.Position.Z = 0;
								}
								continue;
							#endregion
							case "ATTITUDE":
								#region ATTITUDE

								if (Split.Length < 5)
								{
									DebugMessages.Add(new WarningMessage("C ATTITUDE Line (" + CurrentLineNumber + ") in STP could not be inspected."));
									DebugMessages.Add(new InformationMessage("C ATTITUDE Line (" + CurrentLineNumber + "): " + ThisLine));
									continue;
								}
								failed = false;
								Angle outx = 0.Degrees();
								Angle outy = 0.Degrees();
								Angle outz = 0.Degrees();
								failed |= !Angle.TryParse(Split[2].ToUpperInvariant(), out outx);
								failed |= !Angle.TryParse(Split[3].ToUpperInvariant(), out outy);
								failed |= !Angle.TryParse(Split[4].ToUpperInvariant(), out outz);
								CurrentStartPosition.Attitude.X += (double)outx.ToDegrees().ConvertToBase;
								CurrentStartPosition.Attitude.Y += (double)outy.ToDegrees().ConvertToBase;
								CurrentStartPosition.Attitude.Z += (double)outz.ToDegrees().ConvertToBase;

								while (CurrentStartPosition.Attitude.X <= -180)
								{
									CurrentStartPosition.Attitude.X += 360;
								}
								while (CurrentStartPosition.Attitude.Y <= -180)
								{
									CurrentStartPosition.Attitude.Y += 360;
								}
								while (CurrentStartPosition.Attitude.Z <= -180)
								{
									CurrentStartPosition.Attitude.Z += 360;
								}

								while (CurrentStartPosition.Attitude.X > 180)
								{
									CurrentStartPosition.Attitude.X -= 360;
								}
								while (CurrentStartPosition.Attitude.Y > 180)
								{
									CurrentStartPosition.Attitude.Y -= 360;
								}
								while (CurrentStartPosition.Attitude.Z > 180)
								{
									CurrentStartPosition.Attitude.Z -= 360;
								}

								if (failed)
								{
									DebugMessages.Add(new WarningMessage("C ATTITUDE Line (" + CurrentLineNumber + ") in STP could not be converted."));
									DebugMessages.Add(new InformationMessage("C ATTITUDE Line (" + CurrentLineNumber + "): " + ThisLine));
									CurrentStartPosition.Attitude.X = 0;
									CurrentStartPosition.Attitude.Y = 0;
									CurrentStartPosition.Attitude.Z = 0;
								}
								continue;
							#endregion
							case "INITSPED":
								#region INITSPED
								if (Split.Length < 3)
								{
									DebugMessages.Add(new WarningMessage("C INITSPED Line (" + CurrentLineNumber + ") in STP could not be inspected."));
									DebugMessages.Add(new InformationMessage("C INITSPED Line (" + CurrentLineNumber + "): " + ThisLine));
									continue;
								}

								failed = false;

								Speed output = 0.Knots();
								failed |= !Speed.TryParse(Split[2].ToUpperInvariant(), out output);
								Split[2] = output.ToString() + "M/S";
								CurrentStartPosition.Speed = (double)output.ToMetersPerSeconds().ConvertToBase;

								if (failed)
								{
									DebugMessages.Add(new WarningMessage("C INITSPED Line (" + CurrentLineNumber + ") in STP could not be converted."));
									DebugMessages.Add(new InformationMessage("C INITSPED Line (" + CurrentLineNumber + "): " + ThisLine));
									CurrentStartPosition.Speed = 0;
								}
								continue;
							#endregion
							case "CTLTHROT":
								#region CTLTHROT
								if (Split.Length < 3)
								{
									DebugMessages.Add(new WarningMessage("C CTLTHROT Line (" + CurrentLineNumber + ") in STP could not be inspected."));
									DebugMessages.Add(new InformationMessage("C CTLTHROT Line (" + CurrentLineNumber + "): " + ThisLine));
									continue;
								}
								failed = false;
								failed |= !Double.TryParse(Split[2], out CurrentStartPosition.Throttle);

								if (failed)
								{
									DebugMessages.Add(new WarningMessage("C CTLTHROT Line (" + CurrentLineNumber + ") in STP could not be converted."));
									DebugMessages.Add(new InformationMessage("C CTLTHROT Line (" + CurrentLineNumber + "): " + ThisLine));
									CurrentStartPosition.Throttle = 0;
								}
								continue;
							#endregion
							case "CTLLDGEA":
								#region CTLLDGEA
								if (Split.Length < 3)
								{
									DebugMessages.Add(new WarningMessage("C CTLLDGEA Line (" + CurrentLineNumber + ") in STP could not be inspected."));
									DebugMessages.Add(new InformationMessage("C CTLLDGEA Line (" + CurrentLineNumber + "): " + ThisLine));
									continue;
								}
								failed = false;
								failed |= !Boolean.TryParse(Split[2], out CurrentStartPosition.Gear);

								if (failed)
								{
									DebugMessages.Add(new WarningMessage("C CTLLDGEA Line (" + CurrentLineNumber + ") in STP could not be converted."));
									DebugMessages.Add(new InformationMessage("C CTLLDGEA Line (" + CurrentLineNumber + "): " + ThisLine));
									CurrentStartPosition.Gear = true;
								}
								continue;
								#endregion
						}
					}
					#endregion
					#region P
					if (ThisLine.ToUpperInvariant().StartsWith("P"))
					{

						string[] Split = ThisLine.RemoveDoubleSpaces().Split(' ');
						if (Split.Length < 2)
						{
							DebugMessages.Add(new WarningMessage("P Line (" + CurrentLineNumber + ") in STP could not be inspected."));
							DebugMessages.Add(new InformationMessage("P STP Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentStartPosition = Objects.NULL_StartPosition;
							continue; //couldn't read the name line - error?
						}

						bool failed = false;

						switch (Split[1].ToUpperInvariant())
						{
							case "CARRIER":
								#region CARRIER
								if (Split.Length < 9)
								{
									DebugMessages.Add(new WarningMessage("P CARRIER Line (" + CurrentLineNumber + ") in STP could not be inspected."));
									DebugMessages.Add(new InformationMessage("P CARRIER Line (" + CurrentLineNumber + "): " + ThisLine));
									continue;
								}

								Length AdjustPosX = 0.Meters();
								Length AdjustPosY = 0.Meters();
								Length AdjustPosZ = 0.Meters();
								failed |= !Length.TryParse(Split[3].ToUpperInvariant(), out AdjustPosX);
								failed |= !Length.TryParse(Split[4].ToUpperInvariant(), out AdjustPosY);
								failed |= !Length.TryParse(Split[5].ToUpperInvariant(), out AdjustPosZ);

								Angle AdjustAngleX = 0.Degrees();
								Angle AdjustAngleY = 0.Degrees();
								Angle AdjustAngleZ = 0.Degrees();
								failed |= !Angle.TryParse(Split[6].ToUpperInvariant(), out AdjustAngleX);
								failed |= !Angle.TryParse(Split[7].ToUpperInvariant(), out AdjustAngleY);
								failed |= !Angle.TryParse(Split[8].ToUpperInvariant(), out AdjustAngleZ);

								CurrentStartPosition.Position.X -= (double)AdjustPosX.ConvertToBase;
								CurrentStartPosition.Position.Y -= (double)AdjustPosY.ConvertToBase;
								CurrentStartPosition.Position.Z -= (double)AdjustPosZ.ConvertToBase;
								CurrentStartPosition.Attitude.X -= (double)AdjustAngleX.ConvertToBase;
								CurrentStartPosition.Attitude.Y -= (double)AdjustAngleY.ConvertToBase;
								CurrentStartPosition.Attitude.Z -= (double)AdjustAngleZ.ConvertToBase;


								if (failed)
								{
									DebugMessages.Add(new WarningMessage("P CARRIER Line (" + CurrentLineNumber + ") in STP could not be converted."));
									DebugMessages.Add(new InformationMessage("P CARRIER Line (" + CurrentLineNumber + "): " + ThisLine));
								}
								break;
								#endregion
						}
					}
					#endregion
				}
				#endregion
				#region Look for another Start Position
				else
				{
					#region N
					if (ThisLine.ToUpperInvariant().StartsWith("N"))
					{
						string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
						if (Split.Length < 2)
						{
							DebugMessages.Add(new WarningMessage("N Line (" + CurrentLineNumber + ") in STP could not be inspected."));
							DebugMessages.Add(new InformationMessage("N STP Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentStartPosition = Objects.NULL_StartPosition;
							continue; //couldn't read the name line - error?
						}
						CurrentStartPosition = new Objects.StartPosition();
						CurrentStartPosition.Identify = Split[1];
						continue;
					}
					#endregion
				}
				#endregion
			}
			#endregion
			#region Finish the Last Start Position
			if (CurrentStartPosition != Objects.NULL_StartPosition)
			{
				Objects.StartPositionList.Add(CurrentStartPosition);
				//Since the declarations do not terminate, we need to add the last one at the end of the file.
			}
			#endregion

			return (DebugMessages.Count(x => x is WarningMessage) > 0);
		}
		private static bool LoadYFS(Metadata.Scenery InputScenery)
		{
			#region YFS Not Found on Disk
			if (!File.Exists(Metadata.YSFlightDirectory + InputScenery.SceneryPath3Yfs)) return false;
			#endregion
			#region Read File Contents
			string[] YFSContents = File.ReadAllLines(Metadata.YSFlightDirectory + InputScenery.SceneryPath3Yfs);
			#endregion

			#region Initialise Variables
			Objects.Ground CurrentGround = Objects.NULL_Ground;
			#endregion

			#region Iterate over YFS Contents
			for (int i = 0; i < YFSContents.Length; i++)
			{
				#region Update Line Number and Contents
				int CurrentLineNumber = i;
				string ThisLine = YFSContents[i];
				#endregion

				if (ThisLine == "") continue; //Skip Blank Lines.

				#region Editing a Ground Object
				if (CurrentGround != Objects.NULL_Ground)
				{
					#region GROUNDOB
					if (ThisLine.ToUpperInvariant().StartsWith("GROUNDOB"))
					{
						if (CurrentGround != Objects.NULL_Ground) Objects.GroundList.Add(CurrentGround);
						string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
						if (Split.Length < 2)
						{
							DebugMessages.Add(new WarningMessage("GROUNDOB Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected."));
							DebugMessages.Add(new InformationMessage("GROUNDOB YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentGround = Objects.NULL_Ground;
							continue;
						}

						CurrentGround = new Objects.Ground();

						CurrentGround.Identify = Split[1];
						CurrentGround.MetaGroundObject = Metadata.Ground.FindByName(Split[1]);
						continue;
					}
					#endregion
					#region GNDPOSIT
					if (ThisLine.ToUpperInvariant().StartsWith("GNDPOSIT"))
					{
						string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
						if (Split.Length < 4)
						{
							DebugMessages.Add(new WarningMessage("GNDPOSIT Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected."));
							DebugMessages.Add(new InformationMessage("GNDPOSIT YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentGround = Objects.NULL_Ground;
							continue;
						}

						bool failed = false;

						Length temp;

						temp = 0.Meters();
						failed |= !Length.TryParse(Split[1], out temp);
						CurrentGround.Position.X = (float)temp.ConvertToBase;

						temp = 0.Meters();
						failed |= !Length.TryParse(Split[2], out temp);
						CurrentGround.Position.Y = (float)temp.ConvertToBase;

						temp = 0.Meters();
						failed |= !Length.TryParse(Split[3], out temp);
						CurrentGround.Position.Z = (float)temp.ConvertToBase;

						if (failed)
						{
							DebugMessages.Add(new WarningMessage("GNDPOSIT Line (" + CurrentLineNumber + ") in YFS Ground could not be converted."));
							DebugMessages.Add(new InformationMessage("GNDPOSIT YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentGround.Position.X = 0;
							CurrentGround.Position.Y = 0;
							CurrentGround.Position.Z = 0;
						}
						continue;
					}
					#endregion
					#region GNDATTIT
					if (ThisLine.ToUpperInvariant().StartsWith("GNDATTIT"))
					{
						string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
						if (Split.Length < 4)
						{
							DebugMessages.Add(new WarningMessage("GNDATTIT Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected."));
							DebugMessages.Add(new InformationMessage("GNDATTIT YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentGround = Objects.NULL_Ground;
							continue;
						}

						bool failed = false;

						Angle temp;

						temp = 0.Degrees();
						failed |= !Angle.TryParse(Split[1], out temp);
						CurrentGround.Position.X = (float)temp.ConvertToBase;

						temp = 0.Degrees();
						failed |= !Angle.TryParse(Split[1], out temp);
						CurrentGround.Position.Y = (float)temp.ConvertToBase;

						temp = 0.Degrees();
						failed |= !Angle.TryParse(Split[1], out temp);
						CurrentGround.Position.Z = (float)temp.ConvertToBase;

						if (failed)
						{
							DebugMessages.Add(new WarningMessage("GNDATTIT Line (" + CurrentLineNumber + ") in YFS Ground could not be converted."));
							DebugMessages.Add(new InformationMessage("GNDATTIT YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentGround.Attitude.X = 0;
							CurrentGround.Attitude.Y = 0;
							CurrentGround.Attitude.Z = 0;
						}
						continue;
					}
					#endregion
					#region IDENTIFY
					if (ThisLine.ToUpperInvariant().StartsWith("IDENTIFY"))
					{
						string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
						if (Split.Length < 2)
						{
							DebugMessages.Add(new WarningMessage("IDENTIFY Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected."));
							DebugMessages.Add(new InformationMessage("IDENTIFY YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentGround = Objects.NULL_Ground;
							continue; //couldn't read the name line - error?
						}
						bool failed = false;
						failed |= !UInt32.TryParse(Split[1], out CurrentGround.IFF);
						if (failed)
						{
							DebugMessages.Add(new WarningMessage("IDENTIFY Line (" + CurrentLineNumber + ") in YFS Ground could not be converted."));
							DebugMessages.Add(new InformationMessage("IDENTIFY YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentGround.IFF = 0;
						}
						continue;
					}
					#endregion
					#region IDANDTAG
					if (ThisLine.ToUpperInvariant().StartsWith("IDANDTAG"))
					{
						string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
						if (Split.Length < 3)
						{
							DebugMessages.Add(new WarningMessage("IDANDTAG Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected."));
							DebugMessages.Add(new InformationMessage("IDANDTAG YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine));
							continue;
						}

						bool failed = false;
						failed |= !UInt32.TryParse(Split[1], out CurrentGround.ID);
						CurrentGround.Tag = Split[2].Replace(" ", "_");


						if (failed)
						{
							DebugMessages.Add(new WarningMessage("IDANDTAG Line (" + CurrentLineNumber + ") in YFS Ground could not be converted."));
							DebugMessages.Add(new InformationMessage("IDANDTAG YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentGround.ID = 0;
							CurrentGround.Tag = "<CONVERSION_ERROR>";
						}
						continue;
					}
					#endregion
					
				}
				#endregion
				#region Look for another Ground Object
				else
				{
					#region GROUNDOB
					if (ThisLine.ToUpperInvariant().StartsWith("GROUNDOB"))
					{
						string[] Split = ThisLine.RemoveDoubleSpaces().Split(' ');
						if (Split.Length < 2)
						{
							DebugMessages.Add(new WarningMessage("GROUNDOB Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected."));
							DebugMessages.Add(new InformationMessage("GROUNDOB YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine));
							CurrentGround = Objects.NULL_Ground;
							continue;
						}
						CurrentGround = new Objects.Ground();
						CurrentGround.Identify = Split[1];
						CurrentGround.MetaGroundObject = Metadata.Ground.FindByName(Split[1]);
						continue;
					}
					#endregion
				}
				#endregion
			}
			#endregion
			#region Finish the Last Ground Object
			if (CurrentGround != Objects.NULL_Ground)
			{
				Objects.GroundList.Add(CurrentGround);
				//Since the declarations do not terminate, we need to add the last one at the end of the file.
			}
			#endregion

			return (DebugMessages.Count(x => x is WarningMessage) > 0);
		}
	}
}

