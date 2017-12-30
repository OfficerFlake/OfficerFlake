using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.YSFlight
{
	public static class World
	{
		public static List<IRichTextMessage> DebugMessages = new List<IRichTextMessage>();

		public static I24BitColor GroundColor { get; set; }
		public static I24BitColor SkyColor { get; set; }
		public static I24BitColor FogColor { get; set; }

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
				public String Identify = "NULL";
				public ISpeed Speed = 0.MetersPerSecond();
				public Single Throttle = 0f;
				public Boolean Gear = true;

				public IPoint3 Position = ObjectFactory.CreatePoint3(0.Meters(), 0.Meters(), 0.Meters());

				public class _Attitude
				{
					public IAngle H = 0.Degrees();
					public IAngle P = 0.Degrees();
					public IAngle B = 0.Degrees();
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
				public IMetaDataGround MetaGroundObject = null;

				public class _Position
				{
					public IDistance X = 0.Meters();
					public IDistance Y = 0.Meters();
					public IDistance Z = 0.Meters();
				}
				public _Position Position = new _Position();

				public class _Attitude
				{
					public IAngle H = 0.Degrees();
					public IAngle P = 0.Degrees();
					public IAngle B = 0.Degrees();
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
					public IDistance X = 0.Meters();
					public IDistance Y = 0.Meters();
					public IDistance Z = 0.Meters();
				}
				public _Position Position = new _Position();

				public class _Point
				{
					public IDistance X = 0.Meters();
					public IDistance Y = 0.Meters();
					public IDistance Z = 0.Meters();
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
						NewPoint.X = ((OriginalList.ToArray()[i].X.ToMeters().RawValue + OriginalList.ToArray()[i + 1].X.ToMeters().RawValue) / 2f).Meters();
						NewPoint.Y = ((OriginalList.ToArray()[i].Y.ToMeters().RawValue + OriginalList.ToArray()[i + 1].Y.ToMeters().RawValue) / 2f).Meters();
						NewPoint.Z = ((OriginalList.ToArray()[i].Z.ToMeters().RawValue + OriginalList.ToArray()[i + 1].Z.ToMeters().RawValue) / 2f).Meters();
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
							NewPoint.X = ((OriginalList.ToArray()[i].X.ToMeters().RawValue + OriginalList.ToArray()[i + 1].X.ToMeters().RawValue) / 2f).Meters();
							NewPoint.Y = ((OriginalList.ToArray()[i].Y.ToMeters().RawValue + OriginalList.ToArray()[i + 1].Y.ToMeters().RawValue) / 2f).Meters();
							NewPoint.Z = ((OriginalList.ToArray()[i].Z.ToMeters().RawValue + OriginalList.ToArray()[i + 1].Z.ToMeters().RawValue) / 2f).Meters();
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
					public IDistance X;
					public IDistance Y;
					public IDistance Z;
				}
				public _Position Position = new _Position();

				public class _Attitude
				{
					public IAngle H;
					public IAngle P;
					public IAngle B;
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

						IDistance PosX = ThisGround.Position.X;
						IDistance PosY = ThisGround.Position.Y;
						IDistance PosZ = ThisGround.Position.Z;
						ThisGround.Position.X =
							(this.Position.X.ToMeters().RawValue +
							(Math.Cos(-this.Attitude.H.ToRadians().RawValue) * PosX.ToMeters().RawValue) +
							(Math.Sin(-this.Attitude.H.ToRadians().RawValue) * PosZ.ToMeters().RawValue)).Meters();
						ThisGround.Position.Y =
							(this.Position.Y.ToMeters().RawValue +
							ThisGround.Position.Y.ToMeters().RawValue).Meters();
						ThisGround.Position.Z =
							(this.Position.X.ToMeters().RawValue +
							(Math.Sin(-this.Attitude.H.ToRadians().RawValue) * -PosX.ToMeters().RawValue) +
							(Math.Cos(-this.Attitude.H.ToRadians().RawValue) * PosZ.ToMeters().RawValue)).Meters();

						ThisGround.Attitude.H = (ThisGround.Attitude.H.ToDegrees().RawValue + this.Attitude.H.ToDegrees().RawValue).Degrees();
						ThisGround.Attitude.P = (ThisGround.Attitude.P.ToDegrees().RawValue + this.Attitude.P.ToDegrees().RawValue).Degrees();
						ThisGround.Attitude.B = (ThisGround.Attitude.B.ToDegrees().RawValue + this.Attitude.B.ToDegrees().RawValue).Degrees();

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
							IDistance _PosX = (ThisPoint.X.ToMeters().RawValue + ThisPath.Position.X.ToMeters().RawValue).Meters();
							IDistance _PosY = (ThisPoint.Y.ToMeters().RawValue + ThisPath.Position.Y.ToMeters().RawValue).Meters();
							IDistance _PosZ = (ThisPoint.Z.ToMeters().RawValue + ThisPath.Position.Z.ToMeters().RawValue).Meters();
							ThisPoint.X =
								(this.Position.X.ToMeters().RawValue + 
								(Math.Cos(-this.Attitude.H.ToRadians().RawValue) * _PosX.ToMeters().RawValue) +
								(Math.Sin(-this.Attitude.H.ToRadians().RawValue) * _PosZ.ToMeters().RawValue)).Meters();
							ThisPoint.Y =
								(this.Position.Y.ToMeters().RawValue +
								ThisPoint.Y.ToMeters().RawValue).Meters();
							ThisPoint.Z =
								(this.Position.Z.ToMeters().RawValue +
								(Math.Sin(-this.Attitude.H.ToRadians().RawValue) * -_PosX.ToMeters().RawValue) +
								(Math.Cos(-this.Attitude.H.ToRadians().RawValue) * _PosZ.ToMeters().RawValue)).Meters();
						}
						IDistance PosX = ThisPath.Position.X;
						IDistance PosY = ThisPath.Position.Y;
						IDistance PosZ = ThisPath.Position.Z;
						ThisPath.Position.X =
							(this.Position.X.ToMeters().RawValue +
							(Math.Cos(-this.Attitude.H.ToRadians().RawValue) * -PosX.ToMeters().RawValue) +
							(Math.Sin(-this.Attitude.H.ToRadians().RawValue) * PosZ.ToMeters().RawValue)).Meters();
						ThisPath.Position.Y =
							(this.Position.Y.ToMeters().RawValue +
							(PosY.ToMeters().RawValue)).Meters();
						ThisPath.Position.Z =
							(this.Position.Z.ToMeters().RawValue +
							(Math.Sin(-this.Attitude.H.ToRadians().RawValue) * -PosX.ToMeters().RawValue) +
							(Math.Cos(-this.Attitude.H.ToRadians().RawValue) * PosZ.ToMeters().RawValue)).Meters();
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
			IMetaDataScenery Target = Extensions.YSFlight.MetaData.Scenery.FindByName(Name);
			if (Target == null)
			{
				var Warning = ("Scenery Not Found: \"" + Name + "\"").AsDebugWarningMessage();
				DebugMessages.Add(Warning);
				Debug.AddWarningMessage("Scenery Not Found: \"" + Name + "\"");
				return false;
			}
			else
			{
				Load(Target);
				return (DebugMessages.Count(x => x is IDebugWarningMessage) > 0);
			}
		}
		public static bool Load(IMetaDataScenery InputScenery)
		{
			#region Start Debug Log
			DebugMessages.Clear();
			DebugMessages.Add((("Starting World.Load")).AsDebugDetailMessage());
			Debug.AddSummaryMessage("Starting World.Load");
			#endregion
			#region Clear Objects
			Objects.GroundList.Clear();
			Objects.PathList.Clear();
			Objects.StartPositionList.Clear();
			#endregion

			DebugMessages.Add(("Loading World: " + InputScenery.Identify).AsDebugDetailMessage());

			#region LoadFLD
			DebugMessages.Add((("Starting World.LoadFLD")).AsDebugDetailMessage());
			LoadFLD(InputScenery);
			DebugMessages.Add((("Ended World.LoadFLD")).AsDebugDetailMessage());
			#endregion

			DebugMessages.Add(("Loaded " + Objects.GroundList.Count + " Ground Objects from FLD.").AsDebugDetailMessage());
			DebugMessages.Add(("Loaded " + Objects.PathList.Count + " Motion Paths from FLD.").AsDebugDetailMessage());

			#region LoadSTP
			DebugMessages.Add((("Starting World.LoadSTP")).AsDebugDetailMessage());
			LoadSTP(InputScenery);
			DebugMessages.Add((("Ended World.LoadSTP")).AsDebugDetailMessage());
			#endregion

			DebugMessages.Add(("Loaded " + Objects.StartPositionList.Count + " Start Positions from STP.").AsDebugDetailMessage());

			#region LoadYFS
			int GroundsLoadedFromFLD = Objects.GroundList.Count;

			DebugMessages.Add((("Starting World.LoadYFS")).AsDebugDetailMessage());
			LoadYFS(InputScenery);
			DebugMessages.Add((("Ended World.LoadYFS")).AsDebugDetailMessage());
			#endregion

			DebugMessages.Add(("Loaded " + (Objects.GroundList.Count - GroundsLoadedFromFLD) + " Ground Objects from YFS.").AsDebugDetailMessage());
			Debug.AddSummaryMessage("Finished World.Load");
			return (DebugMessages.Count(x => x is IDebugWarningMessage) > 0);
		}

		private static bool LoadFLD(IMetaDataScenery InputScenery)
		{
			#region FLD Not Found on Disk
			if (!File.Exists(Settings.YSFlight.Directory + InputScenery.Path_1_FieldFile))
			{
				DebugMessages.Add((("FLD File Not Found: " + InputScenery.Path_1_FieldFile)).AsDebugDetailMessage());
				DebugMessages.Add((("UNFILLED DEBUG MESSAGE IN WORLD!")).AsDebugDetailMessage());
				return false;
			}
			#endregion
			#region Read File Contents
			string[] FLDContents = File.ReadAllLines(Settings.YSFlight.Directory + InputScenery.Path_1_FieldFile);
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
				string ThisLine = FLDContents[i].ToUpperInvariant();
				#endregion

				if (ThisLine == "") continue; //Skip Blank Lines.

				#region Move Back to Root Scenery if Past End Of File.
				while (i > CurrentScenery.EndLine && CurrentScenery != Objects.RootScenery)
				{
					DebugMessages.Add((("Moving back to root scenry")).AsDebugDetailMessage());
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
								DebugMessages.Add(("POS Line (" + CurrentLineNumber + ") in Ground could not be inspected.").AsDebugWarningMessage());
								continue;
							}

							bool failed = false;
							Single temp;
							failed |= !Single.TryParse(Split[1], out temp); CurrentGround.Position.X = temp.Meters();
							failed |= !Single.TryParse(Split[2], out temp); CurrentGround.Position.Y = temp.Meters();
							failed |= !Single.TryParse(Split[3], out temp); CurrentGround.Position.Z = temp.Meters();
							failed |= !Single.TryParse(Split[4], out temp); CurrentGround.Attitude.H = (temp / 65535 * 360).Degrees();
							failed |= !Single.TryParse(Split[5], out temp); CurrentGround.Attitude.P = (temp / 65535 * 360).Degrees();
							failed |= !Single.TryParse(Split[6], out temp); CurrentGround.Attitude.B = (temp / 65535 * 360).Degrees();

							if (failed)
							{
								DebugMessages.Add((("POS Line (" + CurrentLineNumber + ") in Ground could not be converted.")).AsDebugDetailMessage());

								CurrentGround.Position.X = 0.Meters();
								CurrentGround.Position.Y = 0.Meters();
								CurrentGround.Position.Z = 0.Meters();
								CurrentGround.Attitude.H = 0.Degrees();
								CurrentGround.Attitude.P = 0.Degrees();
								CurrentGround.Attitude.B = 0.Degrees();
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
								DebugMessages.Add((("NAM Line (" + CurrentLineNumber + ") in Ground could not be inspected.")).AsDebugDetailMessage());
								continue;
							}

							CurrentGround.Identify = Split[1].Replace(" ","_");

							CurrentGround.MetaGroundObject = Extensions.YSFlight.MetaData.Grounds.FindByName(CurrentGround.Identify);
							if (CurrentGround.MetaGroundObject == Extensions.YSFlight.MetaData.Grounds.None)
							{
								DebugMessages.Add(("Ground Name (" + CurrentLineNumber + ") in Ground could not be found in Metadata.").AsDebugWarningMessage());
								DebugMessages.Add((("Ground NAM Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());}

							continue;
						}
						#endregion
						#region TAG
						if (ThisLine.ToUpperInvariant().StartsWith("TAG"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								DebugMessages.Add(("TAG Line (" + CurrentLineNumber + ") in Ground could not be inspected.").AsDebugWarningMessage());
								DebugMessages.Add((("TAG Ground Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());
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
								DebugMessages.Add(("IFF Line (" + CurrentLineNumber + ") in Ground could not be inspected.").AsDebugWarningMessage());
								DebugMessages.Add((("Ground IFF Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());
								continue;
							}

							bool failed = false;
							failed |= !UInt32.TryParse(Split[1], out CurrentGround.IFF);

							if (failed)
							{
								DebugMessages.Add(("IFF Line (" + CurrentLineNumber + ") in Ground could not be converted.").AsDebugWarningMessage());
								DebugMessages.Add((("Ground IFF Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());

								CurrentGround.IFF = 0;
							}
							continue;
						}
						#endregion

						#region END
						if (ThisLine.ToUpperInvariant().StartsWith("END"))
						{
							CurrentScenery.GroundObjects.Add(CurrentGround);

							DebugMessages.Add((("Added Ground Object (" + CurrentLineNumber + "): " + CurrentGround.Identify + " " + ThisLine)).AsDebugDetailMessage());

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
								DebugMessages.Add(("POS Line (" + CurrentLineNumber + ") in Path could not be inspected.").AsDebugWarningMessage());
								DebugMessages.Add((("Path POS Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());

								continue;
							}
							bool failed = false;
							Single temp;
							failed |= !Single.TryParse(Split[1], out temp); CurrentPath.Position.X = temp.Meters();
							failed |= !Single.TryParse(Split[2], out temp); CurrentPath.Position.Y = temp.Meters();
							failed |= !Single.TryParse(Split[3], out temp); CurrentPath.Position.Z = temp.Meters();


							if (failed)
							{
								DebugMessages.Add(("POS Line (" + CurrentLineNumber + ") in Path could not be converted.").AsDebugWarningMessage());
								DebugMessages.Add((("Path POS Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());

								CurrentPath.Position.X = 0.Meters();
								CurrentPath.Position.Y = 0.Meters();
								CurrentPath.Position.Z = 0.Meters();
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
								DebugMessages.Add(("PNT Line (" + CurrentLineNumber + ") in Path could not be inspected.").AsDebugWarningMessage());
								DebugMessages.Add((("Path PNT Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());

								continue;
							}

							Objects.Path._Point ThisPoint = new Objects.Path._Point();

							bool failed = false;
							Single temp;
							failed |= !Single.TryParse(Split[1], out temp); ThisPoint.X = temp.Meters();
							failed |= !Single.TryParse(Split[2], out temp); ThisPoint.Y = temp.Meters();
							failed |= !Single.TryParse(Split[3], out temp); ThisPoint.Z = temp.Meters();

							if (failed)
							{
								DebugMessages.Add(("PNT Line (" + CurrentLineNumber + ") in Path could not be converted.").AsDebugWarningMessage());
								DebugMessages.Add((("Path PNT Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());

								ThisPoint.X = 0.Meters();
								ThisPoint.Y = 0.Meters();
								ThisPoint.Z = 0.Meters();
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
								DebugMessages.Add(("TAG Line (" + CurrentLineNumber + ") in Path could not be inspected.").AsDebugWarningMessage());
								DebugMessages.Add((("Path TAG Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());

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
								DebugMessages.Add(("AREA Line (" + CurrentLineNumber + ") in Path could not be inspected.").AsDebugWarningMessage());
								DebugMessages.Add((("Path AREA Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());

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
								DebugMessages.Add(("ISLOOP Line (" + CurrentLineNumber + ") in Path could not be inspected.").AsDebugWarningMessage());
								DebugMessages.Add((("Path ISLOOP Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());

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
								DebugMessages.Add(("ID Line (" + CurrentLineNumber + ") in Path could not be inspected.").AsDebugWarningMessage());
								DebugMessages.Add((("Path ID Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());

								continue;
							}

							bool failed = false;
							failed |= !UInt32.TryParse(Split[1], out CurrentPath.Type);

							if (failed)
							{
								DebugMessages.Add(("ID Line (" + CurrentLineNumber + ") in Path could not be converted.").AsDebugWarningMessage());
								DebugMessages.Add((("Path ID Line (" + CurrentLineNumber + "): " + ThisLine)).AsDebugDetailMessage());

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
								ThisPoint.X = (ThisPoint.X.ToMeters().RawValue + CurrentPath.Position.X.ToMeters().RawValue).Meters();
								ThisPoint.Y = (ThisPoint.Y.ToMeters().RawValue + CurrentPath.Position.Y.ToMeters().RawValue).Meters();
								ThisPoint.Z = (ThisPoint.Z.ToMeters().RawValue + CurrentPath.Position.Z.ToMeters().RawValue).Meters();
							}
							CurrentPath.Position.X = 0.Meters();
							CurrentPath.Position.Y = 0.Meters();
							CurrentPath.Position.Z = 0.Meters();
							#endregion

							CurrentScenery.MotionPaths.Add(CurrentPath);

							DebugMessages.Add((("Added Path (" + CurrentLineNumber + "): " + CurrentPath.Identify + " " + ThisLine)).AsDebugDetailMessage());

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
							DebugMessages.Add(("PCK Line (" + CurrentLineNumber + ") in scenery could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("PCK Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugDetailMessage());
							continue;
						}

						#region Skip PC2 and TER
						if (Split[1].ToUpperInvariant().Contains(".PC2")) continue;
						if (Split[1].ToUpperInvariant().Contains(".TER")) continue;
						#endregion

						if (!Split[1].ToUpperInvariant().Contains(".FLD"))
						{
							DebugMessages.Add(("PCK Line (" + CurrentLineNumber + ") in scenery does not specify a FLD.").AsDebugWarningMessage());
							DebugMessages.Add(("PCK Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugDetailMessage());
							continue;
						}

						#region Add a new Child Scenery to Current Scenry
						Objects.Scenery ChildScenery = new Objects.Scenery();
						ChildScenery.Identify = Split[1].ToUpperInvariant();

						ChildScenery.Parent = CurrentScenery;
						CurrentScenery.AddChild(ChildScenery);
						AllSceneries.Add(ChildScenery);
						#endregion

						DebugMessages.Add(("Adding Child Scenry (" + ChildScenery.Identify + ") to (" + CurrentScenery.Identify + ")").AsDebugWarningMessage());

						#region Get Number of Lines in Child Scenery
						int numberOfLinesInChildScenry = 0;
						if (!Int32.TryParse(ThisLine.Split(' ')[2].ToUpperInvariant(), out numberOfLinesInChildScenry))
						{
							DebugMessages.Add(("PCK Line (" + CurrentLineNumber + ") in scenery does not specify number of following lines.").AsDebugWarningMessage());
							DebugMessages.Add(("PCK Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
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

						DebugMessages.Add(("Now Loading Child Scenry (" + CurrentLineNumber + "): " + CurrentScenery.Identify).AsDebugWarningMessage());

						continue;
					}
					#endregion
					#region FIL
					if (ThisLine.ToUpperInvariant().StartsWith("FIL"))
					{
						string[] Split = ThisLine.SplitPresevingQuotes();
						if (Split.Length < 2)
						{
							DebugMessages.Add(("FIL Line (" + CurrentLineNumber + ") in scenery could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("FIL Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
							continue;
						}

						#region Skip PC2 and TER
						if (Split[1].ToUpperInvariant().Contains(".PC2")) continue;
						if (Split[1].ToUpperInvariant().Contains(".TER")) continue;
						#endregion

						if (!Split[1].ToUpperInvariant().Contains(".FLD"))
						{
							DebugMessages.Add(("FIL Line (" + CurrentLineNumber + ") in scenery does not specify a FLD.").AsDebugWarningMessage());
							DebugMessages.Add(("FIL Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
							continue;
						}

						if (AllSceneries.Select(x => x.Identify).Contains(Split[1]))
						{
							DebugMessages.Add(("FIL Line (" + CurrentLineNumber + "): got a FLD.").AsDebugWarningMessage());
							var ArrayOfTargetSceneries = AllSceneries.Where(x => x.Identify == Split[1]).ToArray();
							if (ArrayOfTargetSceneries.Length <= 0)
							{
								DebugMessages.Add(("|FIL Line in Scenery: FLD In Scenery (" + CurrentLineNumber + ") Could not find a target.").AsDebugWarningMessage());
								DebugMessages.Add(("FIL Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
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
							DebugMessages.Add(("POS Line (" + CurrentLineNumber + ") in scenery could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("POS Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
							continue;
						}

						bool failed = false;
						Single temp;
						failed |= !Single.TryParse(Split[1], out temp); TargetScenery.Position.X = temp.Meters();
						failed |= !Single.TryParse(Split[2], out temp); TargetScenery.Position.Y = temp.Meters();
						failed |= !Single.TryParse(Split[3], out temp); TargetScenery.Position.Z = temp.Meters();
						failed |= !Single.TryParse(Split[4], out temp); TargetScenery.Attitude.H = (temp / 65535 * 360).Degrees();
						failed |= !Single.TryParse(Split[5], out temp); TargetScenery.Attitude.P = (temp / 65535 * 360).Degrees();
						failed |= !Single.TryParse(Split[6], out temp); TargetScenery.Attitude.B = (temp / 65535 * 360).Degrees();

						if (failed)
						{
							DebugMessages.Add(("POS Line (" + CurrentLineNumber + ") in scenery could not be converted.").AsDebugWarningMessage());
							DebugMessages.Add(("POS Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());

							TargetScenery.Position.X = 0.Meters();
							TargetScenery.Position.Y = 0.Meters();
							TargetScenery.Position.Z = 0.Meters();
							TargetScenery.Attitude.H = 0.Degrees();
							TargetScenery.Attitude.P = 0.Degrees();
							TargetScenery.Attitude.B = 0.Degrees();
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
							GroundColor = ObjectFactory.CreateColor(colorsAsByte[0], colorsAsByte[1], colorsAsByte[2]).Get24BitColor();
						}
						catch
						{
							DebugMessages.Add(("GND Color Line (" + CurrentLineNumber + ") in scenery could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("GND Color Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
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
							SkyColor = ObjectFactory.CreateColor(colorsAsByte[0], colorsAsByte[1], colorsAsByte[2]).Get24BitColor();
						}
						catch
						{
							DebugMessages.Add(("SKY Color Line (" + CurrentLineNumber + ") in scenery could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("SKY Color Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
						}
					}
					#endregion

					#region GOB
					if (ThisLine.ToUpperInvariant().StartsWith("GOB"))
					{
						DebugMessages.Add(
							CurrentGround == Objects.NULL_Ground
								? ("Grabbing a Ground Object. (" + CurrentLineNumber + ")").AsDebugWarningMessage()
								: ("Finished Current Ground. (" + CurrentLineNumber + "): Grabbing another...").AsDebugWarningMessage());
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
								? ("Grabbing a Path. (" + CurrentLineNumber + ")").AsDebugWarningMessage()
								: ("Finished Current Path. (" + CurrentLineNumber + "): Grabbing another...").AsDebugWarningMessage());
						if (i + 1 < FLDContents.Length)
						{
							string NextLine = FLDContents[i + 1];
							CurrentGround = Objects.NULL_Ground;
							CurrentPath = new Objects.Path();

							//ALWAYS ADD MOTION PATHS, EVEN IF THEY AREN'T LOOPS!
							//if (NextLine.ToUpperInvariant().StartsWith("ISLOOP"))
							//{
							//	DebugMessages.Add((("PST Line Encountered(" + CurrentLineNumber + ") Will be a loop. We will try to inspect for a Race Track."));
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
			DebugMessages.Add(("Converting Child Sceneries To Root.").AsDebugWarningMessage());
			foreach (Objects.Scenery ThisScenery in Objects.RootScenery.Children)
			{
				DebugMessages.Add(("Converting Child Scenery To Root:" + ThisScenery.Identify).AsDebugWarningMessage());
				ThisScenery.ProcessGrounds();
				ThisScenery.ProcessPaths();
				DebugMessages.Add(("Converted Child Scenery To Root:" + ThisScenery.Identify).AsDebugWarningMessage());
			}
			DebugMessages.Add(("Converted Child Sceneries To Root.").AsDebugWarningMessage());

			DebugMessages.Add(("Adding Converted Ground Objects.").AsDebugWarningMessage());
			foreach (Objects.Ground ThisGround in Objects.RootScenery.GroundObjects)
			{
				Objects.GroundList.Add(ThisGround);
			}
			DebugMessages.Add(("Added Converted Ground Objects.").AsDebugWarningMessage());

			DebugMessages.Add(("Adding Converted Paths.").AsDebugWarningMessage());
			foreach (Objects.Path ThisPath in Objects.RootScenery.MotionPaths.ToArray())
			{
				if (ThisPath.Identify != "" & ThisPath.Type == 15) Objects.PathList.Add(ThisPath);
			}
			DebugMessages.Add(("Added Converted Paths.").AsDebugWarningMessage());
			#endregion
			return (DebugMessages.Count(x => x is IDebugWarningMessage) > 0);
		}
		private static bool LoadSTP(IMetaDataScenery InputScenery)
		{
			#region STP Not Found on Disk
			if (!File.Exists(Settings.YSFlight.Directory + InputScenery.Path_2_StartPositionFile)) return false;
			#endregion
			#region Read File Contents
			string[] STPContents = File.ReadAllLines(Settings.YSFlight.Directory + InputScenery.Path_2_StartPositionFile);
			#endregion

			#region Initialise Variables
			Objects.StartPosition CurrentStartPosition = Objects.NULL_StartPosition;
			#endregion

			#region Iterate over STP Contents
			for (int i = 0; i < STPContents.Length; i++)
			{
				#region Update Line Number and Contents
				int CurrentLineNumber = i;
				string ThisLine = STPContents[i].ToUpperInvariant();
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
							DebugMessages.Add(("N Line (" + CurrentLineNumber + ") in STP could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("N STP Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
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
							DebugMessages.Add(("C Line (" + CurrentLineNumber + ") in STP could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("C STP Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
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
									DebugMessages.Add(("C POSITION Line (" + CurrentLineNumber + ") in STP could not be inspected.").AsDebugWarningMessage());
									DebugMessages.Add(("C POSITION Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
									continue;
								}
								failed = false;
								IDistance temp;

								temp = 0.Meters();
								failed |= !ObjectFactory.TryParse(Split[2], out temp);
								Split[2] = temp.ToMeters().ToString();
								CurrentStartPosition.Position.X = temp;

								temp = 0.Meters();
								failed |= !ObjectFactory.TryParse(Split[3], out temp);
								Split[2] = temp.ToMeters().ToString();
								CurrentStartPosition.Position.Y = temp;

								temp = 0.Meters();
								failed |= !ObjectFactory.TryParse(Split[4], out temp);
								Split[3] = temp.ToMeters().ToString();
								CurrentStartPosition.Position.Z = temp;

								if (failed)
								{
									DebugMessages.Add(("C POSITION Line (" + CurrentLineNumber + ") in STP could not be converted.").AsDebugWarningMessage());
									DebugMessages.Add(("C POSITION Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
									CurrentStartPosition.Position.X = 0.Meters();
									CurrentStartPosition.Position.Y = 0.Meters();
									CurrentStartPosition.Position.Z = 0.Meters();
								}
								continue;
							#endregion
							case "ATTITUDE":
								#region ATTITUDE

								if (Split.Length < 5)
								{
									DebugMessages.Add(("C ATTITUDE Line (" + CurrentLineNumber + ") in STP could not be inspected.").AsDebugWarningMessage());
									DebugMessages.Add(("C ATTITUDE Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
									continue;
								}
								failed = false;
								IAngle outx = 0.Degrees();
								IAngle outy = 0.Degrees();
								IAngle outz = 0.Degrees();
								failed |= !ObjectFactory.TryParse(Split[2].ToUpperInvariant(), out outx);
								failed |= !ObjectFactory.TryParse(Split[3].ToUpperInvariant(), out outy);
								failed |= !ObjectFactory.TryParse(Split[4].ToUpperInvariant(), out outz);
								CurrentStartPosition.Attitude.H = (CurrentStartPosition.Attitude.H.ToDegrees().RawValue + outx.ToDegrees().RawValue).Degrees();
								CurrentStartPosition.Attitude.P = (CurrentStartPosition.Attitude.P.ToDegrees().RawValue + outy.ToDegrees().RawValue).Degrees();
								CurrentStartPosition.Attitude.B = (CurrentStartPosition.Attitude.B.ToDegrees().RawValue + outz.ToDegrees().RawValue).Degrees();


								while (CurrentStartPosition.Attitude.H.ToDegrees().RawValue <= -180)
								{
									CurrentStartPosition.Attitude.H = (CurrentStartPosition.Attitude.H.ToDegrees().RawValue + 360).Degrees();
								}
								while (CurrentStartPosition.Attitude.P.ToDegrees().RawValue <= -180)
								{
									CurrentStartPosition.Attitude.P = (CurrentStartPosition.Attitude.P.ToDegrees().RawValue + 360).Degrees();
								}
								while (CurrentStartPosition.Attitude.B.ToDegrees().RawValue <= -180)
								{
									CurrentStartPosition.Attitude.B = (CurrentStartPosition.Attitude.B.ToDegrees().RawValue + 360).Degrees();
								}
								while (CurrentStartPosition.Attitude.H.ToDegrees().RawValue > 180)
								{
									CurrentStartPosition.Attitude.H = (CurrentStartPosition.Attitude.H.ToDegrees().RawValue - 360).Degrees();
								}
								while (CurrentStartPosition.Attitude.P.ToDegrees().RawValue > 180)
								{
									CurrentStartPosition.Attitude.P = (CurrentStartPosition.Attitude.P.ToDegrees().RawValue - 360).Degrees();
								}
								while (CurrentStartPosition.Attitude.B.ToDegrees().RawValue > 180)
								{
									CurrentStartPosition.Attitude.B = (CurrentStartPosition.Attitude.B.ToDegrees().RawValue - 360).Degrees();
								}

								if (failed)
								{
									DebugMessages.Add(("C ATTITUDE Line (" + CurrentLineNumber + ") in STP could not be converted.").AsDebugWarningMessage());
									DebugMessages.Add(("C ATTITUDE Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
									CurrentStartPosition.Attitude.H = 0.Degrees();
									CurrentStartPosition.Attitude.P = 0.Degrees();
									CurrentStartPosition.Attitude.B = 0.Degrees();
								}
								continue;
							#endregion
							case "INITSPED":
								#region INITSPED
								if (Split.Length < 3)
								{
									DebugMessages.Add(("C INITSPED Line (" + CurrentLineNumber + ") in STP could not be inspected.").AsDebugWarningMessage());
									DebugMessages.Add(("C INITSPED Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
									continue;
								}

								failed = false;

								ISpeed output = 0.Knots();
								failed |= !ObjectFactory.TryParse(Split[2].ToUpperInvariant(), out output);
								Split[2] = output.ToString() + "M/S";
								CurrentStartPosition.Speed = output.ToMetersPerSecond();

								if (failed)
								{
									DebugMessages.Add(("C INITSPED Line (" + CurrentLineNumber + ") in STP could not be converted.").AsDebugWarningMessage());
									DebugMessages.Add(("C INITSPED Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
									CurrentStartPosition.Speed = 0.MetersPerSecond();
								}
								continue;
							#endregion
							case "CTLTHROT":
								#region CTLTHROT
								if (Split.Length < 3)
								{
									DebugMessages.Add(("C CTLTHROT Line (" + CurrentLineNumber + ") in STP could not be inspected.").AsDebugWarningMessage());
									DebugMessages.Add(("C CTLTHROT Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
									continue;
								}
								failed = false;
								failed |= !Single.TryParse(Split[2], out CurrentStartPosition.Throttle);

								if (failed)
								{
									DebugMessages.Add(("C CTLTHROT Line (" + CurrentLineNumber + ") in STP could not be converted.").AsDebugWarningMessage());
									DebugMessages.Add(("C CTLTHROT Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
									CurrentStartPosition.Throttle = 0;
								}
								continue;
							#endregion
							case "CTLLDGEA":
								#region CTLLDGEA
								if (Split.Length < 3)
								{
									DebugMessages.Add(("C CTLLDGEA Line (" + CurrentLineNumber + ") in STP could not be inspected.").AsDebugWarningMessage());
									DebugMessages.Add(("C CTLLDGEA Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
									continue;
								}
								failed = false;
								failed |= !Boolean.TryParse(Split[2], out CurrentStartPosition.Gear);

								if (failed)
								{
									DebugMessages.Add(("C CTLLDGEA Line (" + CurrentLineNumber + ") in STP could not be converted.").AsDebugWarningMessage());
									DebugMessages.Add(("C CTLLDGEA Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
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
							DebugMessages.Add(("P Line (" + CurrentLineNumber + ") in STP could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("P STP Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
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
									DebugMessages.Add(("P CARRIER Line (" + CurrentLineNumber + ") in STP could not be inspected.").AsDebugWarningMessage());
									DebugMessages.Add(("P CARRIER Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
									continue;
								}

								IDistance AdjustPosX = 0.Meters();
								IDistance AdjustPosY = 0.Meters();
								IDistance AdjustPosZ = 0.Meters();
								failed |= !ObjectFactory.TryParse(Split[3].ToUpperInvariant(), out AdjustPosX);
								failed |= !ObjectFactory.TryParse(Split[4].ToUpperInvariant(), out AdjustPosY);
								failed |= !ObjectFactory.TryParse(Split[5].ToUpperInvariant(), out AdjustPosZ);

								IAngle AdjustAngleX = 0.Degrees();
								IAngle AdjustAngleY = 0.Degrees();
								IAngle AdjustAngleZ = 0.Degrees();
								failed |= !ObjectFactory.TryParse(Split[6].ToUpperInvariant(), out AdjustAngleX);
								failed |= !ObjectFactory.TryParse(Split[7].ToUpperInvariant(), out AdjustAngleY);
								failed |= !ObjectFactory.TryParse(Split[8].ToUpperInvariant(), out AdjustAngleZ);

								CurrentStartPosition.Position.X = (CurrentStartPosition.Position.X.ToMeters().RawValue - AdjustPosX.ToMeters().RawValue).Meters();
								CurrentStartPosition.Position.Y = (CurrentStartPosition.Position.Y.ToMeters().RawValue - AdjustPosY.ToMeters().RawValue).Meters();
								CurrentStartPosition.Position.Z = (CurrentStartPosition.Position.Z.ToMeters().RawValue - AdjustPosZ.ToMeters().RawValue).Meters();
								CurrentStartPosition.Attitude.H = (CurrentStartPosition.Attitude.H.ToDegrees().RawValue - AdjustAngleX.ToDegrees().RawValue).Degrees();
								CurrentStartPosition.Attitude.P = (CurrentStartPosition.Attitude.P.ToDegrees().RawValue - AdjustAngleY.ToDegrees().RawValue).Degrees();
								CurrentStartPosition.Attitude.B = (CurrentStartPosition.Attitude.B.ToDegrees().RawValue - AdjustAngleZ.ToDegrees().RawValue).Degrees();


								if (failed)
								{
									DebugMessages.Add(("P CARRIER Line (" + CurrentLineNumber + ") in STP could not be converted.").AsDebugWarningMessage());
									DebugMessages.Add(("P CARRIER Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
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
							DebugMessages.Add(("N Line (" + CurrentLineNumber + ") in STP could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("N STP Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
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

			return (DebugMessages.Count(x => x is IDebugWarningMessage) > 0);
		}
		private static bool LoadYFS(IMetaDataScenery InputScenery)
		{
			#region YFS Not Found on Disk
			if (!File.Exists(Settings.YSFlight.Directory + InputScenery.Path_2_StartPositionFile)) return false;
			#endregion
			#region Read File Contents
			string[] YFSContents = File.ReadAllLines(Settings.YSFlight.Directory + InputScenery.Path_3_YFSFile);
			#endregion

			#region Initialise Variables
			Objects.Ground CurrentGround = Objects.NULL_Ground;
			#endregion

			#region Iterate over YFS Contents
			for (int i = 0; i < YFSContents.Length; i++)
			{
				#region Update Line Number and Contents
				int CurrentLineNumber = i;
				string ThisLine = YFSContents[i].ToUpperInvariant();
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
							DebugMessages.Add(("GROUNDOB Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("GROUNDOB YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
							CurrentGround = Objects.NULL_Ground;
							continue;
						}

						CurrentGround = new Objects.Ground();

						CurrentGround.Identify = Split[1];
						CurrentGround.MetaGroundObject = Extensions.YSFlight.MetaData.Grounds.FindByName(Split[1]);
						continue;
					}
					#endregion
					#region GNDPOSIT
					if (ThisLine.ToUpperInvariant().StartsWith("GNDPOSIT"))
					{
						string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
						if (Split.Length < 4)
						{
							DebugMessages.Add(("GNDPOSIT Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("GNDPOSIT YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
							CurrentGround = Objects.NULL_Ground;
							continue;
						}

						bool failed = false;

						IDistance temp;

						temp = 0.Meters();
						failed |= !ObjectFactory.TryParse(Split[1], out temp);
						CurrentGround.Position.X = temp;

						temp = 0.Meters();
						failed |= !ObjectFactory.TryParse(Split[2], out temp);
						CurrentGround.Position.Y = temp;

						temp = 0.Meters();
						failed |= !ObjectFactory.TryParse(Split[3], out temp);
						CurrentGround.Position.Z = temp;

						if (failed)
						{
							DebugMessages.Add(("GNDPOSIT Line (" + CurrentLineNumber + ") in YFS Ground could not be converted.").AsDebugWarningMessage());
							DebugMessages.Add(("GNDPOSIT YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
							CurrentGround.Position.X = 0.Meters();
							CurrentGround.Position.Y = 0.Meters();
							CurrentGround.Position.Z = 0.Meters();
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
							DebugMessages.Add(("GNDATTIT Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("GNDATTIT YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
							CurrentGround = Objects.NULL_Ground;
							continue;
						}

						bool failed = false;

						IAngle temp;

						temp = 0.Degrees();
						failed |= !ObjectFactory.TryParse(Split[1], out temp);
						CurrentGround.Attitude.H = temp;

						temp = 0.Degrees();
						failed |= !ObjectFactory.TryParse(Split[1], out temp);
						CurrentGround.Attitude.P = temp;

						temp = 0.Degrees();
						failed |= !ObjectFactory.TryParse(Split[1], out temp);
						CurrentGround.Attitude.B = temp;

						if (failed)
						{
							DebugMessages.Add(("GNDATTIT Line (" + CurrentLineNumber + ") in YFS Ground could not be converted.").AsDebugWarningMessage());
							DebugMessages.Add(("GNDATTIT YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
							CurrentGround.Attitude.H = 0.Degrees();
							CurrentGround.Attitude.P = 0.Degrees();
							CurrentGround.Attitude.B = 0.Degrees();
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
							DebugMessages.Add(("IDENTIFY Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("IDENTIFY YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
							CurrentGround = Objects.NULL_Ground;
							continue; //couldn't read the name line - error?
						}
						bool failed = false;
						failed |= !UInt32.TryParse(Split[1], out CurrentGround.IFF);
						if (failed)
						{
							DebugMessages.Add(("IDENTIFY Line (" + CurrentLineNumber + ") in YFS Ground could not be converted.").AsDebugWarningMessage());
							DebugMessages.Add(("IDENTIFY YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
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
							DebugMessages.Add(("IDANDTAG Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("IDANDTAG YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
							continue;
						}

						bool failed = false;
						failed |= !UInt32.TryParse(Split[1], out CurrentGround.ID);
						CurrentGround.Tag = Split[2].Replace(" ", "_");


						if (failed)
						{
							DebugMessages.Add(("IDANDTAG Line (" + CurrentLineNumber + ") in YFS Ground could not be converted.").AsDebugWarningMessage());
							DebugMessages.Add(("IDANDTAG YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
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
							DebugMessages.Add(("GROUNDOB Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("GROUNDOB YFS Ground Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugDetailMessage());
							CurrentGround = Objects.NULL_Ground;
							continue;
						}
						CurrentGround = new Objects.Ground();
						CurrentGround.Identify = Split[1];
						CurrentGround.MetaGroundObject = Extensions.YSFlight.MetaData.Grounds.FindByName(Split[1]);
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

			return (DebugMessages.Count(x => x is IDebugWarningMessage) > 0);
		}
	}
}

