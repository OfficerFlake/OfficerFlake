using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
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
			public class Vehicle : IWorldVehicle
			{
				public Vehicle()
				{
					ID = Extensions.YSFlight.World.GetNextID();
				}

				public void CreateVehicle()
				{
					Extensions.YSFlight.World.Vehicles.Add(this);
					Logger.Debug.AddSummaryMessage("&aAdded Vehicle: [" + this.ID + "]" + this.Identify);
				}
				public void DestroyVehicle()
				{
					Extensions.YSFlight.World.Vehicles.RemoveAll(x=> x == this);
					Logger.Debug.AddSummaryMessage("&cRemoved Vehicle: [" + this.ID + "]" + this.Identify);
				}

				public String Identify { get; set; } = "NULL";
				public String Tag { get; set; } = "";

				public IMetaDataVehicle MetaData { get; set; } = Extensions.YSFlight.MetaData.Aircraft.None;
				public IUser Owner { get; set; } = Users.None;

				public Packet_05VehicleType VehicleType { get; set; } = Packet_05VehicleType.Aircraft;

				public UInt32 ID { get;
					set; } = 0;
				public UInt32 IFF { get; set; } = 0;
				public UInt32 Strength { get; set; } = 10;

				public ICoordinate3 Position { get; set; } = ObjectFactory.CreateCoordinate3(0.Meters(), 0.Meters(), 0.Meters());
				public IOrientation3 Attitude { get; set; } = ObjectFactory.CreateOrientation3(0.Degrees(), 0.Degrees(), 0.Degrees());

				public void Update(IPacket_05_AddVehicle packet)
				{
					Identify = packet.Identify;
					Tag = packet.OwnerName;
					VehicleType = packet.VehicleType;

					ID = packet.ID;
					IFF = packet.IFF;
					Strength = 65535;

					Position = packet.Position;
					Attitude = packet.Attitude;
				}
				public void Update(IPacket_11_FlightData packet)
				{
					Strength = packet.Strength;

					Position = ObjectFactory.CreateCoordinate3(packet.PosX, packet.PosY, packet.PosZ);
					Attitude = ObjectFactory.CreateOrientation3(packet.HdgH, packet.HdgP, packet.HdgB);
				}

				public IPacket_05_AddVehicle GetJoinPacket()
				{
					IPacket_05_AddVehicle joinPacket = ObjectFactory.CreatePacket05AddVehicle();
					joinPacket.ID = ID;
					joinPacket.IFF = IFF;
					joinPacket.Identify = Identify;
					joinPacket.OwnerName = Tag;
					joinPacket.PosX = Position.X;
					joinPacket.PosY = Position.Y;
					joinPacket.PosZ = Position.Z;
					joinPacket.HdgH = Attitude.H;
					joinPacket.HdgP = Attitude.P;
					joinPacket.HdgB = Attitude.B;
					joinPacket.OwnerType = Packet_05OwnerType.Other;
					joinPacket.VehicleType = Packet_05VehicleType.Aircraft;
					return joinPacket;
				}

				public override string ToString()
				{
					return "[" + Tag + "]" + Identify + " (" + Position + ")";
				}
			}

			public class Aircraft : Vehicle, IWorldAircraft
			{
				public Aircraft()
				{
					VehicleType = Packet_05VehicleType.Aircraft;
				}
			}
			public static Aircraft NULL_Aircraft;

			public class Ground : Vehicle, IWorldGround
			{
				public Ground()
				{
					VehicleType = Packet_05VehicleType.Ground;
				}
			}
			public static Ground NULL_Ground;

			public class Scenery
			{
				public Scenery Parent = RootScenery;
				public string Identify = "";
				public int StartLine = 0;
				public int EndLine = 0;

				public ICoordinate3 Position = ObjectFactory.CreateCoordinate3(0.Meters(), 0.Meters(), 0.Meters());
				public IOrientation3 Attitude = ObjectFactory.CreateOrientation3(0.Degrees(), 0.Degrees(), 0.Degrees());

				public I24BitColor GroundColor = ObjectFactory.CreateColor(0, 0, 0).Get24BitColor();
				public I24BitColor SkyColor = ObjectFactory.CreateColor(0, 0, 0).Get24BitColor();
				public WorldMotionPathAreaType DefaultArea = WorldMotionPathAreaType.NoArea;

				public List<Scenery> Children = new List<Scenery>();
				public List<Ground> GroundObjects = new List<Ground>();
				public List<Path> MotionPaths = new List<Path>();

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
							(this.Position.Z.ToMeters().RawValue +
							(Math.Sin(-this.Attitude.H.ToRadians().RawValue) * -PosX.ToMeters().RawValue) +
							(Math.Cos(-this.Attitude.H.ToRadians().RawValue) * PosZ.ToMeters().RawValue)).Meters();

						//ThisGround.Position.X = (ThisGround.Position.X.ToMeters().RawValue  + this.Position.X.ToMeters().RawValue ).Meters();
						//ThisGround.Position.Y = (ThisGround.Position.Y.ToMeters().RawValue  + this.Position.Y.ToMeters().RawValue ).Meters();
						//ThisGround.Position.Z = (ThisGround.Position.Z.ToMeters().RawValue  + this.Position.Z.ToMeters().RawValue ).Meters();
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
						foreach (ICoordinate3 ThisPoint in ThisPath.Points.ToArray())
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

				public override string ToString()
				{
					return Identify;
				}
			}
			public static Scenery RootScenery = new Scenery();

			public class Path : IWorldMotionPath
			{

				public String Identify { get; set; } = "<NULL>";
				public UInt32 Type { get; set; } = 0;
				public Boolean IsLooping { get; set; } = false;
				public WorldMotionPathAreaType AreaType { get; set; } = WorldMotionPathAreaType.Land;

				public List<ICoordinate3> Points { get; set; } = new List<ICoordinate3>();

				public ICoordinate3 Position { get; set; } = ObjectFactory.CreateCoordinate3(0.Meters(), 0.Meters(), 0.Meters());
				public IOrientation3 Attitude { get; set; } = ObjectFactory.CreateOrientation3(0.Degrees(), 0.Degrees(), 0.Degrees());

				public IWorldMotionPath Interpolate()
				{
					List<ICoordinate3> OriginalList = this.Points;
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
						ICoordinate3 NewPoint = ObjectFactory.CreateCoordinate3(0.Meters(), 0.Meters(), 0.Meters());
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
					List<ICoordinate3> OriginalList = this.Points;
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
							ICoordinate3 NewPoint = ObjectFactory.CreateCoordinate3(0.Meters(), 0.Meters(), 0.Meters());
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

				public ICoordinate3 Position { get; set; } = ObjectFactory.CreateCoordinate3(0.Meters(), 0.Meters(), 0.Meters());
				public IOrientation3 Attitude { get; set; } = ObjectFactory.CreateOrientation3(0.Degrees(), 0.Degrees(), 0.Degrees());
			}
			public static StartPosition NULL_StartPosition;
		}

		public static bool Load(string Name)
		{
			int loadingErrors = 0;

			IMetaDataScenery Target = Extensions.YSFlight.MetaData.Scenery.FindByName(Name);
			if (Target == null)
			{
				#region DEBUG: Scenery Not Found: xxxx
				{
					var Message = "Scenery Not Found: \"" + Name + "\"";
					Debug.AddWarningMessage(Message);
				}
				#endregion
				loadingErrors++;
				return false;
			}
			else
			{
				Load(Target);
				return (loadingErrors < 0);
			}
		}
		public static bool Load(IMetaDataScenery InputScenery)
		{
			int loadingErrors = 0;

			#region DEBUG: Starting World.Load
			{
				var Message = "Starting World.Load";
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
				Debug.AddSummaryMessage(Message);
			}
			#endregion

			#region LoadFLD
			#region DEBUG: Starting World.LoadFLD
			{
				var Message = "Starting World.LoadFLD";
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			LoadFLD(InputScenery);
			#region DEBUG: Finished World.LoadFLD
			{
				var Message = "Finished World.LoadFLD";				
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			#endregion
			#region DEBUG: Loaded ??? Ground Objects from FLD.
			int GroundsLoadedFromFLD = Extensions.YSFlight.World.AllGrounds.Count;
			{
				var Message = "Loaded " + GroundsLoadedFromFLD + " Ground Objects from FLD.";
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			#region DEBUG: Loaded ??? Motion Paths from FLD.
			int MotionPathsLoadedFromFLD = Extensions.YSFlight.World.AllMotionPaths.Count;
			{
				var Message = "Loaded " + MotionPathsLoadedFromFLD + " Motion Paths from FLD.";				
				Debug.AddSummaryMessage(Message);
			}
			#endregion

			#region LoadSTP
			#region DEBUG: Starting World.LoadSTP
			{
				var Message = "Starting World.LoadSTP";
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			LoadSTP(InputScenery);
			#region DEBUG: Finished World.LoadSTP
			{
				var Message = "Finished World.LoadSTP";
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			#endregion
			#region DEBUG: Loaded ??? Start Positions from STP.
			int StartPositionsLoadedFromSTP = Extensions.YSFlight.World.AllStartPositions.Count;
			{
				var Message = "Loaded " + StartPositionsLoadedFromSTP + " Start Positions from STP.";
				Debug.AddSummaryMessage(Message);
			}
			#endregion

			#region LoadYFS
			#region DEBUG: Starting World.LoadYFS
			{
				var Message = "Starting World.LoadYFS";
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			LoadYFS(InputScenery);
			#region Finished World.LoadYFS
			{
				var Message = "Finished World.LoadYFS";
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			#endregion
			#region DEBUG: Loaded ??? Ground Objects From YFS
			int GroundObjectsLoadedFromYFS = Extensions.YSFlight.World.AllGrounds.Count - GroundsLoadedFromFLD;
			{
				var Message = "Loaded " + GroundObjectsLoadedFromYFS + " Ground Objects from YFS.";
				Debug.AddSummaryMessage(Message);
			}
			#endregion
			#endregion

			#region DEBUG: Finished World.Load
			{
				var Message = "Finished World.Load";
				Debug.AddSummaryMessage(Message);
			}
			#endregion

			return (loadingErrors <= 0);
		}

		private static bool LoadFLD(IMetaDataScenery InputScenery)
		{
			int loadingErrors = 0;

			#region FLD Not Defined
			if (InputScenery.Path_1_FieldFile == null | InputScenery.Path_1_FieldFile == "")
			{
				string Message = "FLD File Not Defined.";
				Debug.AddWarningMessage(Message);
				loadingErrors++;
				return false;
			}
			#endregion
			#region FLD Not Found on Disk
			if (!File.Exists(Settings.YSFlight.Directory + InputScenery.Path_1_FieldFile))
			{
				string Message = "FLD File Not Found: " + InputScenery.Path_1_FieldFile;
				Debug.AddWarningMessage(Message);
				loadingErrors++;
				return false;
			}
			#endregion
			#region Read File Contents
			string[] FLDContents = File.ReadAllLines(Settings.YSFlight.Directory + InputScenery.Path_1_FieldFile);
			#endregion

			#region Initialise Variables
			Objects.RootScenery = new Objects.Scenery();
			Objects.RootScenery.Parent = Objects.RootScenery;

			List<Objects.Scenery> AllSceneries = new List<Objects.Scenery>() { Objects.RootScenery };
			List<Objects.Scenery> WorkingSceneries = new List<Objects.Scenery>() { Objects.RootScenery };
			Objects.Scenery CurrentScenery = Objects.RootScenery;

			Objects.Ground CurrentGround = Objects.NULL_Ground;
			Objects.Path CurrentPath = Objects.NULL_Path;

			int GOBsHandled = 0;
			int GOBsMissing = 0;
			int PSTsHandled = 0;

			string CurrentMode = "FIELD";

			#endregion
			#region Iterate over FLD Contents
			for (int i = 0; i < FLDContents.Length; i++)
			{
				#region Update Line Number and Contents
				int CurrentLineNumber = i;
				string ThisLine = FLDContents[i].ToUpperInvariant();
				CurrentScenery = WorkingSceneries.Last();
				#endregion
				#region Finish current working scenery if past it's length.
				if (CurrentScenery != Objects.RootScenery)
				{
					if (CurrentLineNumber - 1 == CurrentScenery.EndLine)
					{
						WorkingSceneries.RemoveAll(x => x == CurrentScenery);
						CurrentScenery = WorkingSceneries.Last();
					}
				}
				#endregion

				#region Skip Blank Lines.
				if (ThisLine == "") continue;
				#endregion
				#region Start a new scenery if encounter PCK.
				if (ThisLine.ToUpperInvariant().StartsWith("PCK"))
				{
					#region PCK line undersize!
					string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
					if (Split.Length < 3)
					{
						#region DEBUG: PCK Line xxxx in World.LoadFLD2 is missing required parameters.
						{
							var Message = "PCK Line (" + CurrentLineNumber + ") in World.LoadFLD2 is missing required parameters.";
							Debug.AddWarningMessage(Message);
							Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
						}
						#endregion
						loadingErrors++;
						continue;
					}
					#endregion
					//Potential Error: New scenery ends after current working scenry...

					#region Start new Scenery
					Objects.Scenery newScenery = new Objects.Scenery();
					newScenery.Identify = Split[1];
					newScenery.Parent = CurrentScenery;

					int tempLines = 0;
					Int32.TryParse(Split[2], out tempLines);
					newScenery.StartLine = CurrentLineNumber;
					newScenery.EndLine = CurrentLineNumber + tempLines;
					#endregion
					#region Add Scenery to all Sceneries, and set as current working scenery.
					AllSceneries.Add(newScenery);
					WorkingSceneries.Add(newScenery);
					CurrentScenery = newScenery;
					#endregion
					continue;
				}
				#endregion

				#region Working on current scenery.
				switch (CurrentMode)
				{
					case "FIELD":
						if (ThisLine.ToUpperInvariant().StartsWith("GND"))
						{
							//Update ground color for current scenery
							#region GND
							try
							{
								string[] colorsAsString = ThisLine.Substring(4).SplitPresevingQuotes();
								byte[] colorsAsByte = new byte[3];
								System.Byte.TryParse(colorsAsString[0], out colorsAsByte[0]);
								System.Byte.TryParse(colorsAsString[1], out colorsAsByte[1]);
								System.Byte.TryParse(colorsAsString[2], out colorsAsByte[2]);
								CurrentScenery.GroundColor = ObjectFactory.CreateColor(colorsAsByte[0], colorsAsByte[1], colorsAsByte[2]).Get24BitColor();
							}
							catch
							{
								#region DEBUG: GND Color Line xxxx in World.LoadFLD2 is missing required parameters or failed conversion.
								{
									var Message = "GND Color Line (" + CurrentLineNumber +
												  ") in World.LoadFLD is missing required parameters or failed conversion.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								loadingErrors++;
								continue;
								#endregion
							}
							#endregion
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("SKY"))
						{
							//Update sky color for current scenery
							#region SKY
							try
							{
								string[] colorsAsString = ThisLine.Substring(4).SplitPresevingQuotes();
								byte[] colorsAsByte = new byte[3];
								System.Byte.TryParse(colorsAsString[0], out colorsAsByte[0]);
								System.Byte.TryParse(colorsAsString[1], out colorsAsByte[1]);
								System.Byte.TryParse(colorsAsString[2], out colorsAsByte[2]);
								CurrentScenery.GroundColor = ObjectFactory.CreateColor(colorsAsByte[0], colorsAsByte[1], colorsAsByte[2]).Get24BitColor();
							}
							catch
							{
								#region DEBUG: SKY Color Line xxxx in World.LoadFLD2 is missing required parameters or failed conversion.

								{
									var Message = "SKY Color Line (" + CurrentLineNumber +
												  ") in World.LoadFLD is missing required parameters or failed conversion.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								loadingErrors++;
								continue;
								#endregion
							}
							#endregion
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("DEFAREA"))
						{
							//Update default area for current scenery
							continue;
						}

						if (ThisLine.ToUpperInvariant().StartsWith("PICT2"))
						{
							CurrentMode = "PICT";
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("GOB"))
						{
							CurrentMode = "GOB";
							CurrentGround = new Objects.Ground();
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("FLD"))
						{
							CurrentMode = "FLD";
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("PC2"))
						{
							CurrentMode = "PC2";
							continue;
						}
						break;
					case "PICT":
						if (ThisLine.ToUpperInvariant().StartsWith("PLG"))
						{
							//Stard a new PLG.
							continue;
						}

						if (ThisLine.ToUpperInvariant().StartsWith("ENDPICT"))
						{
							//Done with this PICT.
							CurrentMode = "FIELD";
							continue;
						}
						break;
					case "PICT.PLG":
						if (ThisLine.ToUpperInvariant().StartsWith("COL"))
						{
							//Set Color for Polygon
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("VER"))
						{
							//Add Vertex to Polygon
							continue;
						}

						if (ThisLine.ToUpperInvariant().StartsWith("ENDO"))
						{
							//Done with this PICT.PLG.
							CurrentMode = "PICT";
							continue;
						}
						break;
					case "GOB":
						if (ThisLine.ToUpperInvariant().StartsWith("POS"))
						{
							//Set Ground POS and ATT.
							#region POS
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 7)
							{
								#region DEBUG: POS Line xxxx in GroundObject is missing required parameters.
								{
									var Message = "POS Line (" + CurrentLineNumber + ") in GroundObject is missing required parameters.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								loadingErrors++;
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
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion

								CurrentGround.Position.X = 0.Meters();
								CurrentGround.Position.Y = 0.Meters();
								CurrentGround.Position.Z = 0.Meters();
								CurrentGround.Attitude.H = 0.Degrees();
								CurrentGround.Attitude.P = 0.Degrees();
								CurrentGround.Attitude.B = 0.Degrees();

								loadingErrors++;
								continue;
							}

							#endregion
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("ID"))
						{
							//Set Ground ID
							#region ID
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								#region DEBUG: ID Line xxxx in GroundObject is missing required parameters.
								{
									var Message = "ID Line (" + CurrentLineNumber + ") in GroundObject is missing required parameters.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								loadingErrors++;
								continue;
							}

							bool failed = false;
							failed |= !UInt32.TryParse(Split[1], out var temp);
							//CurrentGround.ID = temp;

							if (failed)
							{
								#region DEBUG: ID Line xxxx in GroundObject failed conversion.
								{
									var Message = "ID Line (" + CurrentLineNumber + ") in GroundObject failed conversion.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								CurrentGround.ID = 0;
								loadingErrors++;
								continue;
							}
							#endregion
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("NAM"))
						{
							//Set Ground Identify
							#region NAM
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								#region DEBUG: NAM Line xxxx in GroundObject is missing required parameters.
								{
									var Message = "NAM Line (" + CurrentLineNumber + ") in GroundObject is missing required parameters.";									
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								loadingErrors++;
								continue;
							}

							CurrentGround.Identify = Split[1].Replace(" ", "_");

							CurrentGround.MetaData = Extensions.YSFlight.MetaData.Grounds.FindByName(CurrentGround.Identify);
							if (CurrentGround.MetaData == Extensions.YSFlight.MetaData.Grounds.None)
							{
								#region DEBUG: NAM Line xxxx in GroundObject Metadata not found. (Addon not installed?)
								{
									var Message = "NAM Line (" + CurrentLineNumber + ") in GroundObject Metadata not found. (Addon \"" + CurrentGround.Identify + "\" not installed?).";
									Debug.AddDetailMessage(Message);
								}
								#endregion
							}
							#endregion
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("TAG"))
						{
							//Set Ground Identify
							#region TAG
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								#region DEBUG: TAG Line xxxx in GroundObject is missing required parameters.
								{
									var Message = "TAG Line (" + CurrentLineNumber + ") in GroundObject is missing required parameters.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								loadingErrors++;
								continue;
							}
							CurrentGround.Tag = Split[1].Replace(" ", "_");
							#endregion
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("IFF"))
						{
							//Set Ground IFF
							#region IFF
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								#region DEBUG: IFF Line xxxx in GroundObject is missing required parameters.
								{
									var Message = "IFF Line (" + CurrentLineNumber + ") in GroundObject is missing required parameters.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								loadingErrors++;
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
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								CurrentGround.IFF = 0;
								loadingErrors++;
								continue;
							}
							#endregion
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("FLG"))
						{
							//Set Ground Flags
							continue;
						}

						if (ThisLine.ToUpperInvariant().StartsWith("END"))
						{
							//Done with this GOB.
							#region END
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
								Debug.AddDetailMessage(Message);
							}
							#endregion
							CurrentGround = Objects.NULL_Ground;
							#endregion
							CurrentMode = "FIELD";
							continue;
						}
						break;
					case "FLD":
						if (ThisLine.ToUpperInvariant().StartsWith("FIL"))
						{
							//Set Scenery FIL
							#region FIL line undersize!
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								#region DEBUG: FIL Line xxxx in World.LoadFLD2 is missing required parameters.
								{
									var Message = "FIL Line (" + CurrentLineNumber + ") in World.LoadFLD2 is missing required parameters.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								loadingErrors++;
								continue;
							}
							#endregion
							WorkingSceneries.Add(AllSceneries.Where(x => x.Identify.ToUpperInvariant() == Split[1].ToUpperInvariant()).First());
							CurrentScenery.Children.Add(WorkingSceneries.Last());
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("POS"))
						{
							//Set Scenery POS
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 7)
							{
								#region DEBUG: POS Line xxxx in World.LoadFLD is missing required parameters.
								{
									var Message = "POS Line (" + CurrentLineNumber + ") in World.LoadFLD is missing required parameters.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								loadingErrors++;
								continue;
							}

							bool failed = false;
							Single temp;
							failed |= !Single.TryParse(Split[1], out temp); CurrentScenery.Position.X = temp.Meters();
							failed |= !Single.TryParse(Split[2], out temp); CurrentScenery.Position.Y = temp.Meters();
							failed |= !Single.TryParse(Split[3], out temp); CurrentScenery.Position.Z = temp.Meters();
							failed |= !Single.TryParse(Split[4], out temp); CurrentScenery.Attitude.H = (temp / 65535 * 360).Degrees();
							failed |= !Single.TryParse(Split[5], out temp); CurrentScenery.Attitude.P = (temp / 65535 * 360).Degrees();
							failed |= !Single.TryParse(Split[6], out temp); CurrentScenery.Attitude.B = (temp / 65535 * 360).Degrees();

							if (failed)
							{
								#region DEBUG: POS Line xxxx in World.LoadFLD2 failed conversion.
								{
									var Message = "POS Line (" + CurrentLineNumber + ") in World.LoadFLD2 failed conversion.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								CurrentScenery.Position.X = 0.Meters();
								CurrentScenery.Position.Y = 0.Meters();
								CurrentScenery.Position.Z = 0.Meters();
								CurrentScenery.Attitude.H = 0.Degrees();
								CurrentScenery.Attitude.P = 0.Degrees();
								CurrentScenery.Attitude.B = 0.Degrees();
								loadingErrors++;
								continue;
							}
							continue;
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("ID"))
						{
							//Set Scenery ID
							continue;
						}

						if (ThisLine.ToUpperInvariant().StartsWith("END"))
						{
							//Done with this FLD.
							CurrentMode = "FIELD";
							WorkingSceneries.RemoveAt(WorkingSceneries.Count - 1);
							continue;
						}
						break;
					case "PC2":
						if (ThisLine.ToUpperInvariant().StartsWith("FIL"))
						{
							//Set Scenery FIL
							#region FIL line undersize!
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 2)
							{
								#region DEBUG: FIL Line xxxx in World.LoadFLD2 is missing required parameters.
								{
									var Message = "FIL Line (" + CurrentLineNumber + ") in World.LoadFLD2 is missing required parameters.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								loadingErrors++;
								continue;
							}
							#endregion
							CurrentScenery.Children.Add(AllSceneries.Where(x => x.Identify.ToUpperInvariant() == Split[1].ToUpperInvariant()).First());
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("POS"))
						{
							//Set Scenery POS
							string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
							if (Split.Length < 7)
							{
								#region DEBUG: POS Line xxxx in World.LoadFLD is missing required parameters.
								{
									var Message = "POS Line (" + CurrentLineNumber + ") in World.LoadFLD is missing required parameters.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								loadingErrors++;
								continue;
							}

							bool failed = false;
							Single temp;
							failed |= !Single.TryParse(Split[1], out temp); CurrentScenery.Position.X = temp.Meters();
							failed |= !Single.TryParse(Split[2], out temp); CurrentScenery.Position.Y = temp.Meters();
							failed |= !Single.TryParse(Split[3], out temp); CurrentScenery.Position.Z = (-temp).Meters();
							failed |= !Single.TryParse(Split[4], out temp); CurrentScenery.Attitude.H = (temp / 65535 * 360).Degrees();
							failed |= !Single.TryParse(Split[5], out temp); CurrentScenery.Attitude.P = (temp / 65535 * 360).Degrees();
							failed |= !Single.TryParse(Split[6], out temp); CurrentScenery.Attitude.B = (temp / 65535 * 360).Degrees();

							if (failed)
							{
								#region DEBUG: POS Line xxxx in World.LoadFLD2 failed conversion.
								{
									var Message = "POS Line (" + CurrentLineNumber + ") in World.LoadFLD2 failed conversion.";
									Debug.AddWarningMessage(Message);
									Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
								}
								#endregion
								CurrentScenery.Position.X = 0.Meters();
								CurrentScenery.Position.Y = 0.Meters();
								CurrentScenery.Position.Z = 0.Meters();
								CurrentScenery.Attitude.H = 0.Degrees();
								CurrentScenery.Attitude.P = 0.Degrees();
								CurrentScenery.Attitude.B = 0.Degrees();
								loadingErrors++;
								continue;
							}
							continue;
						}
						if (ThisLine.ToUpperInvariant().StartsWith("ID"))
						{
							//Set Scenery ID
							continue;
						}

						if (ThisLine.ToUpperInvariant().StartsWith("END"))
						{
							//Done with this PC2.
							CurrentMode = "FIELD";
							continue;
						}
						break;

					default:
						break;
				}
				#endregion
			}
			#region DEBUG: Could not add x GroundObjects as they are not installed. Please see the debug detail for further information!
			if (GOBsMissing > 0)
			{
				var Message = "Could not add " + GOBsMissing + " GroundObjects as they are not installed. Please see the debug detail for further information!";
				Debug.AddWarningMessage(Message);
				loadingErrors++;
			}
			#endregion
			#endregion
			#region Move Objects to Root Scenery
			#region DEBUG: Starting to move Child Sceneries to Root Scenery.
			{
				var Message = "Starting to move Child Sceneries to Root Scenery.";
				Debug.AddDetailMessage(Message);
			}
			#endregion
			foreach (Objects.Scenery ThisScenery in Objects.RootScenery.Children)
			{
				#region DEBUG: Starting to move Child Scenery xxxx to Root Scenery.
				{
					var Message = "Starting to move Child Scenery \"" + ThisScenery.Identify + "\" to Root Scenery.";
					Debug.AddDetailMessage(Message);
				}
				#endregion
				ThisScenery.ProcessGrounds();
				ThisScenery.ProcessPaths();
				#region DEBUG: Finished moving Child Scenery xxxx to Root Scenery.
				{
					var Message = "Finished moving Child Scenery \"" + ThisScenery.Identify + "\" to Root Scenery.";
					Debug.AddDetailMessage(Message);
				}
				#endregion
			}
			#region DEBUG: Finished moving Child Sceneries to Root Scenery.
			{
				var Message = "Finished moving Child Sceneries to Root Scenery.";
				Debug.AddDetailMessage(Message);
			}
			#endregion

			foreach (Objects.Ground ThisGround in Objects.RootScenery.GroundObjects)
			{
				Extensions.YSFlight.World.Vehicles.Add(ThisGround);
			}
			#region DEBUG: Added GroundObjects from RootScenery to World.Ground.AllGrounds
			{
				var Message = "Added GroundObjects from RootScenery to World.Ground.AllGrounds";
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
				Debug.AddDetailMessage(Message);
			}
			#endregion
			#endregion

			return (loadingErrors <= 0);
		}
		private static bool LoadSTP(IMetaDataScenery InputScenery)
		{
			int loadingErrors = 0;

			#region STP Not Defined
			if (InputScenery.Path_2_StartPositionFile == null | InputScenery.Path_2_StartPositionFile == "")
			{
				#region DEBUG: STP File Not Defined.
				{
					var Message = "STP File Not Defined.";
					Debug.AddWarningMessage(Message);
				}
				#endregion
				loadingErrors++;
				return false;
			}
			#endregion
			#region STP Not Found on Disk
			if (!File.Exists(Settings.YSFlight.Directory + InputScenery.Path_2_StartPositionFile))
			{
				#region DEBUG: STP File Not Found: xxxx
				{
					var Message = "STP File Not Found: " + InputScenery.Path_2_StartPositionFile;
					Debug.AddWarningMessage(Message);
				}
				#endregion
				loadingErrors++;
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
							#region DEBUG: N Line xxxx in World.LoadSTP is missing required parameters.
							{
								var Message = "N Line (" + CurrentLineNumber + ") in World.LoadSTP is missing required parameters.";
								Debug.AddWarningMessage(Message);
								Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							}
							#endregion
							CurrentStartPosition = Objects.NULL_StartPosition;
							loadingErrors++;
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
								Debug.AddWarningMessage(Message);
								Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							}
							#endregion
							CurrentStartPosition = Objects.NULL_StartPosition;
							loadingErrors++;
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
										Debug.AddWarningMessage(Message);
										Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									}
									#endregion
									loadingErrors++;
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
										Debug.AddWarningMessage(Message);
										Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									}
									#endregion
									CurrentStartPosition.Position.X = 0.Meters();
									CurrentStartPosition.Position.Y = 0.Meters();
									CurrentStartPosition.Position.Z = 0.Meters();
									loadingErrors++;
									continue;
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
										Debug.AddWarningMessage(Message);
										Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									}
									#endregion
									loadingErrors++;
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
										Debug.AddWarningMessage(Message);
										Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									}
									#endregion
									CurrentStartPosition.Attitude.H = 0.Degrees();
									CurrentStartPosition.Attitude.P = 0.Degrees();
									CurrentStartPosition.Attitude.B = 0.Degrees();
									loadingErrors++;
									continue;
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
										Debug.AddWarningMessage(Message);
										Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									}
									#endregion
									loadingErrors++;
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
										Debug.AddWarningMessage(Message);
										Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									}
									#endregion
									CurrentStartPosition.Speed = 0.MetersPerSecond();
									loadingErrors++;
									continue;
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
										Debug.AddWarningMessage(Message);
										Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									}
									#endregion
									loadingErrors++;
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
										Debug.AddWarningMessage(Message);
										Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									}
									#endregion
									CurrentStartPosition.Throttle = 0;
									loadingErrors++;
									continue;
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
										Debug.AddWarningMessage(Message);
										Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									}
									#endregion
									loadingErrors++;
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
										Debug.AddWarningMessage(Message);
										Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									}
									#endregion
									CurrentStartPosition.GearDown = true;
									loadingErrors++;
									continue;
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
								Debug.AddWarningMessage(Message);
								Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							}
							#endregion
							CurrentStartPosition = Objects.NULL_StartPosition;
							loadingErrors++;
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
										Debug.AddWarningMessage(Message);
										Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									}
									#endregion
									loadingErrors++;
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
										Debug.AddWarningMessage(Message);
										Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
									}
									loadingErrors++;
									break;
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
								Debug.AddWarningMessage(Message);
								Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							}
							#endregion
							CurrentStartPosition = Objects.NULL_StartPosition;
							loadingErrors++;
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

			return (loadingErrors <= 0);
		}
		private static bool LoadYFS(IMetaDataScenery InputScenery)
		{
			int loadingErrors = 0;

			#region YFS Not Defined
			if (InputScenery.Path_3_YFSFile == null | InputScenery.Path_3_YFSFile == "")
			{
				#region DEBUG: YFS File Not Defined.
				{
					var Message = "YFS File Not Defined.";
					Debug.AddDetailMessage(Message);
				}
				#endregion
				loadingErrors++;
				return false;
			}
			#endregion
			#region YFS Not Found on Disk
			if (!File.Exists(Settings.YSFlight.Directory + InputScenery.Path_3_YFSFile))
			{
				#region DEBUG: YFS File Not Found: xxxx
				{
					var Message = "YFS File Not Found: " + InputScenery.Path_3_YFSFile;					
					Debug.AddWarningMessage(Message);
				}
				#endregion
				loadingErrors++;
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
							Debug.AddWarningMessage("GROUNDOB Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected.");
							Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							CurrentGround = Objects.NULL_Ground;
							loadingErrors++;
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
							Debug.AddWarningMessage("GNDPOSIT Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected.");
							Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							CurrentGround = Objects.NULL_Ground;
							loadingErrors++;
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
							Debug.AddWarningMessage("GNDPOSIT Line (" + CurrentLineNumber + ") in YFS Ground could not be converted.");
							Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							CurrentGround.Position.X = 0.Meters();
							CurrentGround.Position.Y = 0.Meters();
							CurrentGround.Position.Z = 0.Meters();
						}
						loadingErrors++;
						continue;
					}
					#endregion
					#region GNDATTIT
					if (ThisLine.ToUpperInvariant().StartsWith("GNDATTIT"))
					{
						string[] Split = ThisLine.RemoveDoubleSpaces().SplitPresevingQuotes();
						if (Split.Length < 4)
						{
							Debug.AddWarningMessage("GNDATTIT Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected.");
							Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							CurrentGround = Objects.NULL_Ground;
							loadingErrors++;
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
							Debug.AddWarningMessage("GNDATTIT Line (" + CurrentLineNumber + ") in YFS Ground could not be converted.");
							Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							CurrentGround.Attitude.H = 0.Degrees();
							CurrentGround.Attitude.P = 0.Degrees();
							CurrentGround.Attitude.B = 0.Degrees();
							loadingErrors++;
							continue;
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
							Debug.AddWarningMessage("IDENTIFY Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected.");
							Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							CurrentGround = Objects.NULL_Ground;
							loadingErrors++;
							continue;
						}
						bool failed = false;
						failed |= !UInt32.TryParse(Split[1], out var temp);
						CurrentGround.IFF = temp;
						if (failed)
						{
							Debug.AddWarningMessage("IDENTIFY Line (" + CurrentLineNumber + ") in YFS Ground could not be converted.");
							Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							CurrentGround.IFF = 0;
							loadingErrors++;
							continue;
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
							Debug.AddWarningMessage("IDANDTAG Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected.");
							Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							loadingErrors++;
							continue;
						}

						bool failed = false;
						failed |= !UInt32.TryParse(Split[1], out var tempID);
						CurrentGround.ID = tempID;
						CurrentGround.Tag = Split[2].Replace(" ", "_");


						if (failed)
						{
							Debug.AddWarningMessage("IDANDTAG Line (" + CurrentLineNumber + ") in YFS Ground could not be converted.");
							Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							CurrentGround.ID = 0;
							CurrentGround.Tag = "<CONVERSION_ERROR>";
							loadingErrors++;
							continue;
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
							Debug.AddWarningMessage("GROUNDOB Line (" + CurrentLineNumber + ") in YFS Ground could not be inspected.");
							Debug.AddDetailMessage("---Line Contents (" + CurrentLineNumber + "): " + ThisLine);
							CurrentGround = Objects.NULL_Ground;
							loadingErrors++;
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

			return (loadingErrors <= 0);
		}
	}
}
