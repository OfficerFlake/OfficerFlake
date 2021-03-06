﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
	public static partial class YSFlight
	{
		public static class World
		{
			private static UInt32 CurrentID = 0;
			public static UInt32 GetNextID() => ++CurrentID;

			public static List<IWorldVehicle> Vehicles { get; } = new List<IWorldVehicle>();
			public static List<IWorldVehicle> AllAircraft => Vehicles.Where(x=>x.VehicleType == Packet_05VehicleType.Aircraft).ToList();
			public static List<IWorldVehicle> AllGrounds => Vehicles.Where(x => x.VehicleType == Packet_05VehicleType.Ground).ToList();
			public static IWorldVehicle NoVehicle { get; } = ObjectFactory.CreateVehicle();

			public static IWorldVehicle GetClosestVehicle(IWorldVehicle TargetVehicle, double WithinDistance = Double.MaxValue, IWorldVehicle[] WithinVehicles = null)
			{
			    if (WithinVehicles == null) WithinVehicles = AllAircraft.Where(x => x.ID != TargetVehicle.ID).ToArray();
                IWorldVehicle ClosestVehicle = null;
				Double Distance = Double.MaxValue;
				foreach (IWorldVehicle thisVehicle in WithinVehicles)
				{
					double newDistance =
						Math.Sqrt(
							Math.Pow(TargetVehicle.Position.X.ToMeters().RawValue - thisVehicle.Position.X.ToMeters().RawValue, 2) +
							Math.Pow(TargetVehicle.Position.Y.ToMeters().RawValue - thisVehicle.Position.Y.ToMeters().RawValue, 2) +
							Math.Pow(TargetVehicle.Position.Z.ToMeters().RawValue - thisVehicle.Position.Z.ToMeters().RawValue, 2)
						);
					if (newDistance < Distance & newDistance <= WithinDistance)
					{
						ClosestVehicle = thisVehicle;
						Distance = newDistance;
					}
                }
				return ClosestVehicle;
			}
			public static Double GetClosestVehicleDistance(IWorldVehicle TargetVehicle, double WithinDistance = Double.MaxValue)
			{
			    Double Distance = Double.MaxValue;
                IWorldVehicle ClosestVehicle = GetClosestVehicle(TargetVehicle, WithinDistance);
			    if (ClosestVehicle == null) return Distance;
			    Distance = Math.Sqrt
                (
			        Math.Pow(TargetVehicle.Position.X.ToMeters().RawValue - ClosestVehicle.Position.X.ToMeters().RawValue, 2) +
			        Math.Pow(TargetVehicle.Position.Y.ToMeters().RawValue - ClosestVehicle.Position.Y.ToMeters().RawValue, 2) +
			        Math.Pow(TargetVehicle.Position.Z.ToMeters().RawValue - ClosestVehicle.Position.Z.ToMeters().RawValue, 2)
			    );
                return Distance;
			}

			public static List<IWorldScenery> AllScenerys { get; } = new List<IWorldScenery>();
			public static List<IWorldMotionPath> AllMotionPaths { get; } = new List<IWorldMotionPath>();
			public static List<IWorldStartPosition> AllStartPositions { get; } = new List<IWorldStartPosition>();

			public static I24BitColor FLDGroundColor { get; set; } = ObjectFactory.CreateColor(0, 0, 0).Get24BitColor();
			public static I24BitColor FLDSkyColor { get; set; } = ObjectFactory.CreateColor(0, 100, 200).Get24BitColor();
			public static I24BitColor FLDFogColor { get; set; } = ObjectFactory.CreateColor(120, 140, 160).Get24BitColor();
		}
	}
}
