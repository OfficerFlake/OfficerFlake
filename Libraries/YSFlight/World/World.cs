using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;
using static Com.OfficerFlake.Libraries.SettingsLibrary;

namespace Com.OfficerFlake.Libraries.YSFlight
{
	public static class World
	{
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
			public static Aircraft NULL_Aircraft;

			public class StartPosition : IWorldStartPosition
			{
				public String Identify { get; set; } = "<NULL>";
				public ISpeed Speed { get; set; } = 0.MetersPerSecond();
				public Single Throttle { get; set; } = 0;
				public Boolean GearDown { get; set; } = true;

				public Boolean AllowIFF1 { get; set; } = true;
				public Boolean AllowIFF2 { get; set; } = true;
				public Boolean AllowIFF3 { get; set; } = true;
				public Boolean AllowIFF4 { get; set; } = true;

				public IPoint3 Position { get; set; } = ObjectFactory.CreatePoint3(0.Meters(), 0.Meters(), 0.Meters());
				public IOrientation3 Attitude { get; set; } = ObjectFactory.CreateOrientation3(0.Degrees(), 0.Degrees(), 0.Degrees());
			}
			public static StartPosition NULL_StartPosition;

			public class Ground : IWorldGround
			{
				public String Identify { get; set; } = "<NULL>";
				public String Tag { get; set; } = "<NULL>";
				public UInt32 Strength { get; set; } = 255;
				public UInt32 IFF { get; set; } = 0;
				public UInt32 ID { get; set; } = 0;

				public IUser Owner { get; set; } = Users.None;
				public IMetaDataGround MetaData { get; set; } = Extensions.YSFlight.MetaData.Grounds.None;

				public IPoint3 Position { get; set; } = ObjectFactory.CreatePoint3(0.Meters(), 0.Meters(), 0.Meters());
				public IOrientation3 Attitude { get; set; } = ObjectFactory.CreateOrientation3(0.Degrees(), 0.Degrees(), 0.Degrees());
			}
			public static Ground NULL_Ground;

			public class Path : IWorldMotionPath
			{

				public String Identify { get; set; } = "<NULL>";
				public UInt32 Type { get; set; } = 0;
				public Boolean IsLooping { get; set; } = false;
				public WorldMotionPathAreaType AreaType { get; set; } = WorldMotionPathAreaType.Land;

				public List<IPoint3> Points { get; set; } = new List<IPoint3>();

				public IPoint3 Position { get; set; } = ObjectFactory.CreatePoint3(0.Meters(), 0.Meters(), 0.Meters());
				public IOrientation3 Attitude { get; set; } = ObjectFactory.CreateOrientation3(0.Degrees(), 0.Degrees(), 0.Degrees());

				public IWorldMotionPath Interpolate()
				{
					List<IPoint3> OriginalList = this.Points;
					IWorldMotionPath NewPath = new Path();

					NewPath.Identify = this.Identify;
					NewPath.Type = this.Type;
					NewPath.IsLooping = this.IsLooping;
					NewPath.AreaType = this.AreaType;
					NewPath.Position = this.Position;
					NewPath.Attitude = this.Attitude;

					for (int i = 0; i < OriginalList.Count - 1; i++)
					{
						NewPath.Points.Add(OriginalList.ToArray()[i]);
						IPoint3 NewPoint = ObjectFactory.CreatePoint3(0.Meters(), 0.Meters(), 0.Meters());
						NewPoint.X = ((OriginalList.ToArray()[i].X.ToMeters().RawValue + OriginalList.ToArray()[i + 1].X.ToMeters().RawValue) / 2f).Meters();
						NewPoint.Y = ((OriginalList.ToArray()[i].Y.ToMeters().RawValue + OriginalList.ToArray()[i + 1].Y.ToMeters().RawValue) / 2f).Meters();
						NewPoint.Z = ((OriginalList.ToArray()[i].Z.ToMeters().RawValue + OriginalList.ToArray()[i + 1].Z.ToMeters().RawValue) / 2f).Meters();
						NewPath.Points.Add(NewPoint);
					}
					NewPath.Points.Add(OriginalList.ToArray()[OriginalList.Count - 1]);
					return NewPath;
				}
				public IWorldMotionPath Decimate()
				{
					List<IPoint3> OriginalList = this.Points;
					IWorldMotionPath NewPath = new Path();

					NewPath.Identify = this.Identify;
					NewPath.Type = this.Type;
					NewPath.IsLooping = this.IsLooping;
					NewPath.AreaType = this.AreaType;
					NewPath.Position = this.Position;
					NewPath.Attitude = this.Attitude;

					for (int i = 0; i < OriginalList.Count - 1; i++)
					{
						if (i == 0)
						{
							//add the start of the path.
							NewPath.Points.Add(OriginalList.ToArray()[0]);
							continue;
						}
						if ((OriginalList.Count - 2) % 2 == 0)
						{
							//even no.
							IPoint3 NewPoint = ObjectFactory.CreatePoint3(0.Meters(), 0.Meters(), 0.Meters());
							NewPoint.X = ((OriginalList.ToArray()[i].X.ToMeters().RawValue + OriginalList.ToArray()[i + 1].X.ToMeters().RawValue) / 2f).Meters();
							NewPoint.Y = ((OriginalList.ToArray()[i].Y.ToMeters().RawValue + OriginalList.ToArray()[i + 1].Y.ToMeters().RawValue) / 2f).Meters();
							NewPoint.Z = ((OriginalList.ToArray()[i].Z.ToMeters().RawValue + OriginalList.ToArray()[i + 1].Z.ToMeters().RawValue) / 2f).Meters();
							NewPath.Points.Add(NewPoint);
							i++; //skip the next point!
						}
						else
						{
							//odd no.
							i++;
							if (i < OriginalList.Count - 1) NewPath.Points.Add(OriginalList.ToArray()[i]);
						}
					}
					NewPath.Points.Add(OriginalList.ToArray()[OriginalList.Count - 1]);
					return NewPath;
				}
			}
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
						foreach (IPoint3 ThisPoint in ThisPath.Points.ToArray())
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
			List<IRichTextMessage> DebugMessages = new List<IRichTextMessage>();

			DebugMessages.Clear();
			IMetaDataScenery Target = Extensions.YSFlight.MetaData.Scenery.FindByName(Name);
			if (Target == null)
			{
				#region DEBUG: Scenery Not Found: xxxx
				{
					var Message = "Scenery Not Found: \"" + Name + "\"";
					DebugMessages.Add(Message.AsDebugWarningMessage());
					Debug.AddWarningMessage(Message);
				}
				#endregion
				return false;
			}
			else
			{
				Load(Target);
				return (DebugMessages.Count(x => x is IDebugWarningMessage | x is IDebugErrorMessage | x is IDebugCrashMessage) > 0);
			}
		}
		public static bool Load(IMetaDataScenery InputScenery)
		{
			List<IRichTextMessage> DebugMessages = new List<IRichTextMessage>();

			#region DEBUG: Starting World.Load
			{
				var Message = "Starting World.Load";
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			
			#region World.Load...
			#region Clear Objects
			Extensions.YSFlight.World.AllAircraft.Clear();
			Extensions.YSFlight.World.AllGrounds.Clear();

			Extensions.YSFlight.World.AllScenerys.Clear();
			Extensions.YSFlight.World.AllMotionPaths.Clear();
			Extensions.YSFlight.World.AllStartPositions.Clear();
			#endregion
			#region DEBUG: Loading Word: xxxx
			{
				var Message = "Loading World: " + InputScenery.Identify;
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion

			#region LoadFLD
			#region DEBUG: Starting World.LoadFLD
			{
				var Message = "Starting World.LoadFLD";
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			LoadFLD(InputScenery);
			#region DEBUG: Finished World.LoadFLD
			{
				var Message = "Finished World.LoadFLD";
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			#endregion
			#region DEBUG: Loaded ??? Ground Objects from FLD.
			int GroundsLoadedFromFLD = Extensions.YSFlight.World.AllGrounds.Count;
			{
				var Message = "Loaded " + GroundsLoadedFromFLD + " Ground Objects from FLD.";
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			#region DEBUG: Loaded ??? Motion Paths from FLD.
			int MotionPathsLoadedFromFLD = Extensions.YSFlight.World.AllMotionPaths.Count;
			{
				var Message = "Loaded " + MotionPathsLoadedFromFLD + " Motion Paths from FLD.";
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion

			#region LoadSTP
			#region DEBUG: Starting World.LoadSTP
			{
				var Message = "Starting World.LoadSTP";
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			LoadSTP(InputScenery);
			#region DEBUG: Finished World.LoadSTP
			{
				var Message = "Finished World.LoadSTP";
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			#endregion
			#region DEBUG: Loaded ??? Start Positions from STP.
			int StartPositionsLoadedFromSTP = Extensions.YSFlight.World.AllStartPositions.Count;
			{
				var Message = "Loaded " + StartPositionsLoadedFromSTP + " Start Positions from STP.";
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion

			#region LoadYFS
			#region DEBUG: Starting World.LoadYFS
			{
				var Message = "Starting World.LoadYFS";
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			LoadYFS(InputScenery);
			#region Finished World.LoadYFS
			{
				var Message = "Finished World.LoadYFS";
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			#endregion
			#region DEBUG: Loaded ??? Ground Objects From YFS
			int GroundObjectsLoadedFromYFS = Extensions.YSFlight.World.AllGrounds.Count - GroundsLoadedFromFLD;
			{
				var Message = "Loaded " + GroundObjectsLoadedFromYFS + " Ground Objects from YFS.";
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			#endregion

			#region DEBUG: Finished World.Load
			{
				var Message = "Finished World.Load";
				DebugMessages.Add(Message.AsDebugSummaryMessage());
				Debug.AddSummaryMessage(Message);
			}
			#endregion

			return (DebugMessages.Count(x => x is IDebugWarningMessage | x is IDebugErrorMessage | x is IDebugCrashMessage) <= 0);
		}

		private static bool LoadFLD(IMetaDataScenery InputScenery)
		{
			List<IRichTextMessage> DebugMessages = new List<IRichTextMessage>();
			#region FLD Not Defined
			if (InputScenery.Path_1_FieldFile == null | InputScenery.Path_1_FieldFile == "")
			{
				#region DEBUG: FLD File Not Defined.
				{
					var Message = "FLD File Not Defined.";
					DebugMessages.Add(Message.AsDebugWarningMessage());
					Debug.AddWarningMessage(Message);
				}
				#endregion
				return false;
			}
			#endregion
			#region FLD Not Found on Disk
			if (!File.Exists(Settings.YSFlight.Directory + InputScenery.Path_1_FieldFile))
			{
				#region DEBUG: FLD File Not Found: xxxx
				{
					var Message = "FLD File Not Found: " + InputScenery.Path_1_FieldFile;
					DebugMessages.Add(Message.AsDebugWarningMessage());
					Debug.AddWarningMessage(Message);
				}
				#endregion
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
			int GOBsMissing = 0;
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
								#region DEBUG: POS Line xxxx in GroundObject is missing required parameters.
								{
									var Message = "POS Line (" + CurrentLineNumber + ") in GroundObject is missing required parameters.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
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
								#region DEBUG: POS Line xxxx in GroundObject failed conversion.
								{
									var Message = "POS Line (" + CurrentLineNumber + ") in GroundObject failed conversion.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
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
								#region DEBUG: NAM Line xxxx in GroundObject is missing required parameters.
								{
									var Message = "NAM Line (" + CurrentLineNumber + ") in GroundObject is missing required parameters.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
								continue;
							}

							CurrentGround.Identify = Split[1].Replace(" ","_");

							CurrentGround.MetaData = Extensions.YSFlight.MetaData.Grounds.FindByName(CurrentGround.Identify);
							if (CurrentGround.MetaData == Extensions.YSFlight.MetaData.Grounds.None)
							{
								#region DEBUG: NAM Line xxxx in GroundObject Metadata not found. (Addon not installed?)
								{
									var Message = "NAM Line (" + CurrentLineNumber + ") in GroundObject Metadata not found. (Addon \"" + CurrentGround.Identify + "\" not installed?).";
									DebugMessages.Add(Message.AsDebugDetailMessage());
									Debug.AddDetailMessage(Message);
								}
								#endregion
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
								#region DEBUG: TAG Line xxxx in GroundObject is missing required parameters.
								{
									var Message = "TAG Line (" + CurrentLineNumber + ") in GroundObject is missing required parameters.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
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
								#region DEBUG: IFF Line xxxx in GroundObject is missing required parameters.
								{
									var Message = "IFF Line (" + CurrentLineNumber + ") in GroundObject is missing required parameters.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
								continue;
							}

							bool failed = false;
							failed |= !UInt32.TryParse(Split[1], out var temp);
							CurrentGround.IFF = temp;

							if (failed)
							{
								#region DEBUG: IFF Line xxxx in GroundObject failed conversion.
								{
									var Message = "IFF Line (" + CurrentLineNumber + ") in GroundObject failed conversion.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
								CurrentGround.IFF = 0;
							}
							continue;
						}
						#endregion

						#region END
						if (ThisLine.ToUpperInvariant().StartsWith("END"))
						{
							if (CurrentGround.MetaData != Extensions.YSFlight.MetaData.Grounds.None)
							{
								CurrentScenery.GroundObjects.Add(CurrentGround);
								GOBsHandled++;
							}
							else
							{
								GOBsMissing++;
							}
							#region DEBUG: GroundObject xxxx Added Successfully.
							{
								var Message = "GroundObject \"" + CurrentGround.Identify + "\" Added Successfully.";
								DebugMessages.Add(Message.AsDebugDetailMessage());
								Debug.AddDetailMessage(Message);
							}
							#endregion
							CurrentGround = Objects.NULL_Ground;
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
								#region DEBUG: POS Line xxxx in MotionPath is missing required parameters.
								{
									var Message = "POS Line (" + CurrentLineNumber + ") in MotionPath is missing required parameters.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
								continue;
							}
							bool failed = false;
							Single temp;
							failed |= !Single.TryParse(Split[1], out temp); CurrentPath.Position.X = temp.Meters();
							failed |= !Single.TryParse(Split[2], out temp); CurrentPath.Position.Y = temp.Meters();
							failed |= !Single.TryParse(Split[3], out temp); CurrentPath.Position.Z = temp.Meters();


							if (failed)
							{
								#region DEBUG: POS Line xxxx in MotionPath failed conversion.
								{
									var Message = "POS Line (" + CurrentLineNumber + ") in MotionPath failed conversion.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
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
								#region DEBUG: PNT Line xxxx in MotionPath is missing required parameters.
								{
									var Message = "PNT Line (" + CurrentLineNumber + ") in MotionPath is missing required parameters.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
								continue;
							}

							IPoint3 ThisPoint = ObjectFactory.CreatePoint3(0.Meters(), 0.Meters(), 0.Meters());

							bool failed = false;
							Single temp;
							failed |= !Single.TryParse(Split[1], out temp); ThisPoint.X = temp.Meters();
							failed |= !Single.TryParse(Split[2], out temp); ThisPoint.Y = temp.Meters();
							failed |= !Single.TryParse(Split[3], out temp); ThisPoint.Z = temp.Meters();

							if (failed)
							{
								#region DEBUG: PNT Line xxxx in MotionPath failed conversion.
								{
									var Message = "PNT Line (" + CurrentLineNumber + ") in MotionPath failed conversion.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
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
								#region DEBUG: TAG Line xxxx in MotionPath is missing required parameters.
								{
									var Message = "TAG Line (" + CurrentLineNumber + ") in MotionPath is missing required parameters.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
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
								#region DEBUG: AREA Line xxxx in MotionPath is missing required parameters.
								{
									var Message = "AREA Line (" + CurrentLineNumber + ") in MotionPath is missing required parameters.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
								continue;
							}
							switch (Split[1].ToUpperInvariant())
							{
								default:
									#region DEBUG: AREA Line xxxx in MotionPath failed conversion.
									{
										var Message = "AREA Line (" + CurrentLineNumber + ") in MotionPath failed conversion.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
									goto case "NOAREA" ;
								case "NOAREA":
									CurrentPath.AreaType = WorldMotionPathAreaType.NoArea;
									break;
								case "LAND":
									CurrentPath.AreaType = WorldMotionPathAreaType.Land;
									break;
								case "WATER":
									CurrentPath.AreaType = WorldMotionPathAreaType.Water;
									break;
							}
							continue;
						}
						#endregion
						#region ISLOOP
						if (ThisLine.ToUpperInvariant().StartsWith("ISLOOP"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								#region DEBUG: ISLOOP Line xxxx in MotionPath is missing required parameters.
								{
									var Message = "ISLOOP Line (" + CurrentLineNumber + ") in MotionPath is missing required parameters.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
								continue;
							}
							string option = Split[1].Replace(" ", "_");
							Boolean.TryParse(option, out var tempIsLooping);
							CurrentPath.IsLooping = tempIsLooping;
							continue;
						}
						#endregion
						#region ID
						if (ThisLine.ToUpperInvariant().StartsWith("ID"))
						{
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								#region DEBUG: ID Line xxxx in MotionPath is missing required parameters.
								{
									var Message = "ID Line (" + CurrentLineNumber + ") in MotionPath is missing required parameters.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
								continue;
							}

							bool failed = false;
							failed |= !UInt32.TryParse(Split[1], out var tempType);
							CurrentPath.Type = tempType;

							if (failed)
							{
								#region DEBUG: ID Line xxxx in MotionPath failed conversion.
								{
									var Message = "ID Line (" + CurrentLineNumber + ") in MotionPath failed conversion.";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
								CurrentPath.Type = 0;
							}
							continue;
						}
						#endregion
						#region FIL
						if (ThisLine.ToUpperInvariant().StartsWith("FIL"))
						{
							continue;
							//TODO: [0] World.LoadFLD.FIL NotImplmented
						}
						#endregion

						#region END
						if (ThisLine.ToUpperInvariant().StartsWith("END"))
						{
							#region Convert Path Points to Path Root
							foreach (IPoint3 ThisPoint in CurrentPath.Points.ToArray())
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

							#region DEBUG: MotionPath xxxx Added Successfully.
							{
								var Message = "MotionPath \"" + CurrentPath.Identify + "\" Added Successfully.";
								DebugMessages.Add(Message.AsDebugDetailMessage());
								Debug.AddDetailMessage(Message);
							}
							#endregion

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
							#region DEBUG: PCK Line xxxx in World.LoadFLD is missing required parameters.
							{
								var Message = "PCK Line (" + CurrentLineNumber + ") in World.LoadFLD is missing required parameters.";
								DebugMessages.Add(Message.AsDebugWarningMessage());
								Debug.AddWarningMessage(Message);
							}
							#endregion
							continue;
						}

						#region Skip PC2 and TER
						if (Split[1].ToUpperInvariant().Contains(".PC2")) continue;
						if (Split[1].ToUpperInvariant().Contains(".TER")) continue;
						#endregion

						if (!Split[1].ToUpperInvariant().Contains(".FLD"))
						{
							#region DEBUG: PCK Line xxxx in World.LoadFLD is missing required parameters.
							{
								var Message = "PCK Line (" + CurrentLineNumber + ") in World.LoadFLD does not specify a FLD.";
								DebugMessages.Add(Message.AsDebugDetailMessage());
								Debug.AddDetailMessage(Message);
							}
							#endregion
							continue;
						}

						#region Add a new Child Scenery to Current Scenry
						Objects.Scenery ChildScenery = new Objects.Scenery();
						ChildScenery.Identify = Split[1].ToUpperInvariant();

						ChildScenery.Parent = CurrentScenery;
						CurrentScenery.AddChild(ChildScenery);
						AllSceneries.Add(ChildScenery);
						#endregion

						#region DEBUG: ChildScenery xxxx Added to yyyy Successfully.
						{
							var Message = "ChildScenery \"" + ChildScenery.Identify + "\" Added To \"" + CurrentScenery.Identify + "\" Successfully.";
							DebugMessages.Add(Message.AsDebugDetailMessage());
							Debug.AddDetailMessage(Message);
						}
						#endregion

						#region Get Number of Lines in Child Scenery
						int numberOfLinesInChildScenry = 0;
						if (!Int32.TryParse(ThisLine.Split(' ')[2].ToUpperInvariant(), out numberOfLinesInChildScenry))
						{
							#region DEBUG: PCK Line xxxx in World.LoadFLD does not specify number of following lines.
							{
								var Message = "PCK Line (" + CurrentLineNumber + ") in World.LoadFLD does not specify number of following lines";
								DebugMessages.Add(Message.AsDebugWarningMessage());
								Debug.AddWarningMessage(Message);
							}
							#endregion
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

						#region DEBUG: Now Loaing ChildScenery xxxx In yyyy.
						{
							var Message = "Now Loaing ChildScenery  \"" + ChildScenery.Identify + "\" In \"" + CurrentScenery.Identify + "\".";
							DebugMessages.Add(Message.AsDebugDetailMessage());
							Debug.AddDetailMessage(Message);
						}
						#endregion

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
							#region DEBUG: FIL Line xxxx in World.LoadFLD is missing required parameters.
							{
								var Message = "FIL Line (" + CurrentLineNumber + ") in World.LoadFLD is missing required parameters.";
								DebugMessages.Add(Message.AsDebugWarningMessage());
								Debug.AddWarningMessage(Message);
							}
							#endregion
							continue;
						}

						#region Skip PC2 and TER
						if (Split[1].ToUpperInvariant().Contains(".PC2")) continue;
						if (Split[1].ToUpperInvariant().Contains(".TER")) continue;
						#endregion

						if (!Split[1].ToUpperInvariant().Contains(".FLD"))
						{
							#region DEBUG: FIL Line xxxx in World.LoadFLD is does not specify a FLD.
							{
								var Message = "FIL Line (" + CurrentLineNumber + ") in World.LoadFLD does not specify a FLD.";
								DebugMessages.Add(Message.AsDebugDetailMessage());
								Debug.AddDetailMessage(Message);
							}
							#endregion
							continue;
						}

						if (AllSceneries.Select(x => x.Identify).Contains(Split[1]))
						{
							DebugMessages.Add(("FIL Line (" + CurrentLineNumber + "): got a FLD.").AsDebugWarningMessage());
							var ArrayOfTargetSceneries = AllSceneries.Where(x => x.Identify == Split[1]).ToArray();
							if (ArrayOfTargetSceneries.Length <= 0)
							{
								#region DEBUG: FIL Line xxxx in World.LoadFLD references a FLD that was not declared!
								{
									var Message = "FIL Line (" + CurrentLineNumber + ") in World.LoadFLD references a FLD that was not declared!";
									DebugMessages.Add(Message.AsDebugWarningMessage());
									Debug.AddWarningMessage(Message);
								}
								#endregion
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
							#region DEBUG: POS Line xxxx in World.LoadFLD is missing required parameters.
							{
								var Message = "POS Line (" + CurrentLineNumber + ") in World.LoadFLD is missing required parameters.";
								DebugMessages.Add(Message.AsDebugWarningMessage());
								Debug.AddWarningMessage(Message);
							}
							#endregion
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
							#region DEBUG: POS Line xxxx in World.LoadFLD failed conversion.
							{
								var Message = "POS Line (" + CurrentLineNumber + ") in World.LoadFLD failed conversion.";
								DebugMessages.Add(Message.AsDebugWarningMessage());
								Debug.AddWarningMessage(Message);
							}
							#endregion
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
							Extensions.YSFlight.World.FLDGroundColor = ObjectFactory.CreateColor(colorsAsByte[0], colorsAsByte[1], colorsAsByte[2]).Get24BitColor();
						}
						catch
						{
							#region DEBUG: GND Color Line xxxx in World.LoadFLD is missing required parameters or failed conversion.
							{
								var Message = "GND Color Line (" + CurrentLineNumber + ") in World.LoadFLD is missing required parameters or failed conversion.";
								DebugMessages.Add(Message.AsDebugWarningMessage());
								Debug.AddWarningMessage(Message);
							}
							#endregion
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
							Extensions.YSFlight.World.FLDSkyColor = ObjectFactory.CreateColor(colorsAsByte[0], colorsAsByte[1], colorsAsByte[2]).Get24BitColor();
						}
						catch
						{
							#region DEBUG: SKY Color Line xxxx in World.LoadFLD is missing required parameters or failed conversion.
							{
								var Message = "SKY Color Line (" + CurrentLineNumber + ") in World.LoadFLD is missing required parameters or failed conversion.";
								DebugMessages.Add(Message.AsDebugWarningMessage());
								Debug.AddWarningMessage(Message);
							}
							#endregion
						}
					}
					#endregion

					#region GOB
					if (ThisLine.ToUpperInvariant().StartsWith("GOB"))
					{
						#region DEBUG: Now loading a new GroundObject.
						{
							var Message = "Now loading a new GroundObject.";
							DebugMessages.Add(Message.AsDebugDetailMessage());
							Debug.AddDetailMessage(Message);
						}
						#endregion
						CurrentGround = new Objects.Ground();
						CurrentPath = Objects.NULL_Path;
						continue;
					}
					#endregion
					#region PST
					if (ThisLine.ToUpperInvariant().StartsWith("PST"))
					{
						#region DEBUG: Now loading a new MotionPath.
						{
							var Message = "Now loading a new MotionPath.";
							DebugMessages.Add(Message.AsDebugDetailMessage());
							Debug.AddDetailMessage(Message);
						}
						#endregion
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
			#region DEBUG: Could not add x GroundObjects as they are not installed. Please see the debug detail for further information!
			if (GOBsMissing > 0)
			{
				var Message = "Could not add " + GOBsMissing + " GroundObjects as they are not installed. Please see the debug detail for further information!";
				DebugMessages.Add(Message.AsDebugWarningMessage());
				Debug.AddWarningMessage(Message);
			}
			#endregion
			#endregion
			#region Move Objects to Root Scenery
			#region DEBUG: Starting to move Child Sceneries to Root Scenery.
			{
				var Message = "Starting to move Child Sceneries to Root Scenery.";
				DebugMessages.Add(Message.AsDebugDetailMessage());
				Debug.AddDetailMessage(Message);
			}
			#endregion
			foreach (Objects.Scenery ThisScenery in Objects.RootScenery.Children)
			{
				#region DEBUG: Starting to move Child Scenery xxxx to Root Scenery.
				{
					var Message = "Starting to move Child Scenery \"" + ThisScenery.Identify + "\" to Root Scenery.";
					DebugMessages.Add(Message.AsDebugDetailMessage());
					Debug.AddDetailMessage(Message);
				}
				#endregion
				ThisScenery.ProcessGrounds();
				ThisScenery.ProcessPaths();
				#region DEBUG: Finished moving Child Scenery xxxx to Root Scenery.
				{
					var Message = "Finished moving Child Scenery \"" + ThisScenery.Identify + "\" to Root Scenery.";
					DebugMessages.Add(Message.AsDebugDetailMessage());
					Debug.AddDetailMessage(Message);
				}
				#endregion
			}
			#region DEBUG: Finished moving Child Sceneries to Root Scenery.
			{
				var Message = "Finished moving Child Sceneries to Root Scenery.";
				DebugMessages.Add(Message.AsDebugDetailMessage());
				Debug.AddDetailMessage(Message);
			}
			#endregion

			foreach (Objects.Ground ThisGround in Objects.RootScenery.GroundObjects)
			{
				Extensions.YSFlight.World.AllGrounds.Add(ThisGround);
			}
			#region DEBUG: Added GroundObjects from RootScenery to World.Ground.AllGrounds
			{
				var Message = "Added GroundObjects from RootScenery to World.Ground.AllGrounds";
				DebugMessages.Add(Message.AsDebugDetailMessage());
				Debug.AddDetailMessage(Message);
			}
			#endregion

			foreach (Objects.Path ThisPath in Objects.RootScenery.MotionPaths.ToArray())
			{
				if (ThisPath.Identify != "" & ThisPath.Type == 15) Extensions.YSFlight.World.AllMotionPaths.Add(ThisPath);
			}
			#region DEBUG: Added MotionPaths from RootScenery to World.Ground.AllMotionPaths
			{
				var Message = "Added MotionPaths from RootScenery to World.Ground.AllMotionPaths";
				DebugMessages.Add(Message.AsDebugDetailMessage());
				Debug.AddDetailMessage(Message);
			}
			#endregion
			#endregion

			return (DebugMessages.Count(x => x is IDebugWarningMessage | x is IDebugErrorMessage | x is IDebugCrashMessage) <= 0);
		}
		private static bool LoadSTP(IMetaDataScenery InputScenery)
		{
			List<IRichTextMessage> DebugMessages = new List<IRichTextMessage>();
			#region STP Not Defined
			if (InputScenery.Path_2_StartPositionFile == null | InputScenery.Path_2_StartPositionFile == "")
			{
				#region DEBUG: STP File Not Defined.
				{
					var Message = "STP File Not Defined.";
					DebugMessages.Add(Message.AsDebugWarningMessage());
					Debug.AddWarningMessage(Message);
				}
				#endregion
				return false;
			}
			#endregion
			#region STP Not Found on Disk
			if (!File.Exists(Settings.YSFlight.Directory + InputScenery.Path_2_StartPositionFile))
			{
				#region DEBUG: STP File Not Found: xxxx
				{
					var Message = "STP File Not Found: " + InputScenery.Path_2_StartPositionFile;
					DebugMessages.Add(Message.AsDebugWarningMessage());
					Debug.AddWarningMessage(Message);
				}
				#endregion
				return false;
			}
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
							Extensions.YSFlight.World.AllStartPositions.Add(CurrentStartPosition);
						}
						#endregion


						string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
						if (Split.Length < 2)
						{
							DebugMessages.Add(("N Line (" + CurrentLineNumber + ") in STP could not be inspected.").AsDebugWarningMessage());
							DebugMessages.Add(("N STP Line (" + CurrentLineNumber + "): " + ThisLine).AsDebugWarningMessage());
							#region DEBUG: N Line xxxx in World.LoadSTP is missing required parameters.
							{
								var Message = "N Line (" + CurrentLineNumber + ") in World.LoadSTP is missing required parameters.";
								DebugMessages.Add(Message.AsDebugWarningMessage());
								Debug.AddWarningMessage(Message);
							}
							#endregion
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
							#region DEBUG: C Line xxxx in World.LoadSTP is missing required parameters.
							{
								var Message = "C Line (" + CurrentLineNumber + ") in World.LoadSTP is missing required parameters.";
								DebugMessages.Add(Message.AsDebugWarningMessage());
								Debug.AddWarningMessage(Message);
							}
							#endregion
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
									#region DEBUG: C POSITION Line xxxx in World.LoadSTP is missing required parameters.
									{
										var Message = "C POSITION Line (" + CurrentLineNumber + ") in World.LoadSTP is missing required parameters.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
									continue;
								}
								failed = false;
								IDistance tempDistance;

								tempDistance = 0.Meters();
								failed |= !ObjectFactory.TryParse(Split[2], out tempDistance);
								Split[2] = tempDistance.ToMeters().ToString();
								CurrentStartPosition.Position.X = tempDistance;

								tempDistance = 0.Meters();
								failed |= !ObjectFactory.TryParse(Split[3], out tempDistance);
								Split[2] = tempDistance.ToMeters().ToString();
								CurrentStartPosition.Position.Y = tempDistance;

								tempDistance = 0.Meters();
								failed |= !ObjectFactory.TryParse(Split[4], out tempDistance);
								Split[3] = tempDistance.ToMeters().ToString();
								CurrentStartPosition.Position.Z = tempDistance;

								if (failed)
								{
									#region DEBUG: C POSITION Line xxxx in World.LoadSTP failed conversion.
									{
										var Message = "C POSITION Line (" + CurrentLineNumber + ") in World.LoadSTP failed conversion.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
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
									#region DEBUG: C ATTITUDE Line xxxx in World.LoadSTP is missing required parameters.
									{
										var Message = "C ATTITUDE Line (" + CurrentLineNumber + ") in World.LoadSTP is missing required parameters.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
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
									#region DEBUG: C ATTITUDE Line xxxx in World.LoadSTP failed conversion.
									{
										var Message = "C ATTITUDE Line (" + CurrentLineNumber + ") in World.LoadSTP failed conversion.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
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
									#region DEBUG: C INITSPED Line xxxx in World.LoadSTP is missing required parameters.
									{
										var Message = "C INITSPED Line (" + CurrentLineNumber + ") in World.LoadSTP is missing required parameters.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
									continue;
								}

								failed = false;

								ISpeed output = 0.Knots();
								failed |= !ObjectFactory.TryParse(Split[2].ToUpperInvariant(), out output);
								Split[2] = output.ToString() + "M/S";
								CurrentStartPosition.Speed = output.ToMetersPerSecond();

								if (failed)
								{
									#region DEBUG: C INITSPED Line xxxx in World.LoadSTP failed conversion.
									{
										var Message = "C INITSPED Line (" + CurrentLineNumber + ") in World.LoadSTP failed conversion.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
									CurrentStartPosition.Speed = 0.MetersPerSecond();
								}
								continue;
							#endregion
							case "CTLTHROT":
								#region CTLTHROT
								if (Split.Length < 3)
								{
									#region DEBUG: C CTLTHROT Line xxxx in World.LoadSTP is missing required parameters.
									{
										var Message = "C CTLTHROT Line (" + CurrentLineNumber + ") in World.LoadSTP is missing required parameters.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
									continue;
								}
								failed = false;
								failed |= !Single.TryParse(Split[2], out var throttle);
								CurrentStartPosition.Throttle = throttle;

								if (failed)
								{
									#region DEBUG: C CTLTHROT Line xxxx in World.LoadSTP failed conversion.
									{
										var Message = "C CTLTHROT Line (" + CurrentLineNumber + ") in World.LoadSTP failed conversion.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
									CurrentStartPosition.Throttle = 0;
								}
								continue;
							#endregion
							case "CTLLDGEA":
								#region CTLLDGEA
								if (Split.Length < 3)
								{
									#region DEBUG: C CTLLDGEA Line xxxx in World.LoadSTP is missing required parameters.
									{
										var Message = "C CTLLDGEA Line (" + CurrentLineNumber + ") in World.LoadSTP is missing required parameters.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
									continue;
								}
								failed = false;
								failed |= !Boolean.TryParse(Split[2], out var tempGear);
								CurrentStartPosition.GearDown = tempGear;

								if (failed)
								{
									#region DEBUG: C CTLLDGEA Line xxxx in World.LoadSTP failed conversion.
									{
										var Message = "C CTLLDGEA Line (" + CurrentLineNumber + ") in World.LoadSTP failed conversion.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
									CurrentStartPosition.GearDown = true;
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
							#region DEBUG: P Line xxxx in World.LoadSTP is missing required parameters.
							{
								var Message = "P Line (" + CurrentLineNumber + ") in World.LoadSTP is missing required parameters.";
								DebugMessages.Add(Message.AsDebugWarningMessage());
								Debug.AddWarningMessage(Message);
							}
							#endregion
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
									#region DEBUG: P CARRIER Line xxxx in World.LoadSTP is missing required parameters.
									{
										var Message = "P CARRIER Line (" + CurrentLineNumber + ") in World.LoadSTP is missing required parameters.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
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
									#region DEBUG: P CARRIER Line xxxx in World.LoadSTP failed conversion.
									{
										var Message = "P CARRIER Line (" + CurrentLineNumber + ") in World.LoadSTP failed conversion.";
										DebugMessages.Add(Message.AsDebugWarningMessage());
										Debug.AddWarningMessage(Message);
									}
									#endregion
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
							#region DEBUG: N Line xxxx in World.LoadSTP is missing required parameters.
							{
								var Message = "N Line (" + CurrentLineNumber + ") in World.LoadSTP is missing required parameters.";
								DebugMessages.Add(Message.AsDebugWarningMessage());
								Debug.AddWarningMessage(Message);
							}
							#endregion
							CurrentStartPosition = Objects.NULL_StartPosition;
							continue;
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
				Extensions.YSFlight.World.AllStartPositions.Add(CurrentStartPosition);
				//Since the declarations do not terminate, we need to add the last one at the end of the file.
			}
			#endregion

			return (DebugMessages.Count(x => x is IDebugWarningMessage | x is IDebugErrorMessage | x is IDebugCrashMessage) <= 0);
		}
		private static bool LoadYFS(IMetaDataScenery InputScenery)
		{
			List<IRichTextMessage> DebugMessages = new List<IRichTextMessage>();
			#region YFS Not Defined
			if (InputScenery.Path_3_YFSFile == null | InputScenery.Path_3_YFSFile == "")
			{
				#region DEBUG: YFS File Not Defined.
				{
					var Message = "YFS File Not Defined.";
					DebugMessages.Add(Message.AsDebugDetailMessage());
					Debug.AddDetailMessage(Message);
				}
				#endregion
				return false;
			}
			#endregion
			#region YFS Not Found on Disk
			if (!File.Exists(Settings.YSFlight.Directory + InputScenery.Path_3_YFSFile))
			{
				#region DEBUG: YFS File Not Found: xxxx
				{
					var Message = "YFS File Not Found: " + InputScenery.Path_3_YFSFile;
					DebugMessages.Add(Message.AsDebugWarningMessage());
					Debug.AddWarningMessage(Message);
				}
				#endregion
				return false;
			}
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
						if (CurrentGround != Objects.NULL_Ground) Extensions.YSFlight.World.AllGrounds.Add(CurrentGround);
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
						CurrentGround.MetaData = Extensions.YSFlight.MetaData.Grounds.FindByName(Split[1]);
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
						failed |= !ObjectFactory.TryParse(Split[2], out temp);
						CurrentGround.Attitude.P = temp;

						temp = 0.Degrees();
						failed |= !ObjectFactory.TryParse(Split[3], out temp);
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
						failed |= !UInt32.TryParse(Split[1], out var temp);
						CurrentGround.IFF = temp;
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
						failed |= !UInt32.TryParse(Split[1], out var tempID);
						CurrentGround.ID = tempID;
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
						CurrentGround.MetaData = Extensions.YSFlight.MetaData.Grounds.FindByName(Split[1]);
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
				Extensions.YSFlight.World.AllGrounds.Add(CurrentGround);
				//Since the declarations do not terminate, we need to add the last one at the end of the file.
			}
			#endregion

			return (DebugMessages.Count(x => x is IDebugWarningMessage | x is IDebugErrorMessage | x is IDebugCrashMessage) <= 0);
		}
	}
}

