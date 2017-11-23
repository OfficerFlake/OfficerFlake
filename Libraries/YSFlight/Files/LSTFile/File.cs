using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.LST
{
    public class Aircraft : CommandFile
    {
        private const bool DebugMode = false;
        public class AircraftDefinition
        {
            public string DataFilePath;
            public string VisualModelFilePath;
            public string CollisionFilePath;
            public string CockpitFilePath;
            public string CoarseModelFilePath;

            public AircraftDefinition(string dataFilePath = null, string visualModelFilePath = null,
                string collisionFilePath = null, string cockpitFilePath = null, string coarseModelFilePath = null)
            {
                DataFilePath = dataFilePath;
                VisualModelFilePath = visualModelFilePath;
                CollisionFilePath = collisionFilePath;
                CockpitFilePath = cockpitFilePath;
                CoarseModelFilePath = coarseModelFilePath;
            }

            public AircraftDefinition(Line thisLine)
            {
                DataFilePath = thisLine.GetElementOrNull(0);
                VisualModelFilePath = thisLine.GetElementOrNull(1);
                CollisionFilePath = thisLine.GetElementOrNull(2);
                CockpitFilePath = thisLine.GetElementOrNull(3);
                CoarseModelFilePath = thisLine.GetElementOrNull(4);
            }

            public AircraftDefinition(string[] input)
            {
                DataFilePath =
                    (input.Length > 0 && input[0] != null) ? input[0].CleanString() : null;
                VisualModelFilePath =
                    (input.Length > 1 && input[1] != null) ? input[1].CleanString() : null;
                CollisionFilePath =
                    (input.Length > 2 && input[2] != null) ? input[2].CleanString() : null;
                CockpitFilePath =
                    (input.Length > 3 && input[3] != null) ? input[3].CleanString() : null;
                CoarseModelFilePath =
                    (input.Length > 4 && input[4] != null) ? input[4].CleanString() : null;
            }

            public override string ToString()
            {
                return DataFilePath;
            }
        }
        public List<AircraftDefinition> List;

        public Aircraft(string filename) : base(filename)
        {
        }

        public new void Load()
        {
            const bool ShowLines = false;
            base.Load();

            List = new List<AircraftDefinition>();
            foreach (var thisLine in Lines)
            {
                if (ShowLines) Debug.WriteLine(thisLine);
                if (thisLine.isBlank) continue;
                if (thisLine.NumberOfElements < 3) continue;
                var seperatedLine =
                    thisLine.ToString()
                        .SplitPresevingQuotes()
                        .Select(x => x.CleanString())
                        .ToArray();

                AircraftDefinition thisAircraftDefinition = new AircraftDefinition(seperatedLine);
                List.Add(thisAircraftDefinition);
            }
        }

        public AircraftDefinition[] GetAllInstalledAircraftFromLSTFile(bool debugMode = false)
        {
            List<AircraftDefinition> Output = new List<AircraftDefinition>();
            var ysflightDirectory = @"C:/Program Files/YSFLIGHT.COM/YSFlight/";
            Load();
            if (debugMode) Debug.WriteLine("Testing definitions in LST file for validity...");
            var errors = 0;
            foreach (AircraftDefinition thisAircraftDefinition in List)
            {
                if (!System.IO.File.Exists(Path.Combine(ysflightDirectory, thisAircraftDefinition.DataFilePath)))
                    goto Error;
                if (!System.IO.File.Exists(Path.Combine(ysflightDirectory, thisAircraftDefinition.VisualModelFilePath)))
                    goto Error;
                if (!System.IO.File.Exists(Path.Combine(ysflightDirectory, thisAircraftDefinition.CollisionFilePath)))
                    goto Error;
                Output.Add(thisAircraftDefinition);
                continue;
                Error:
                if (debugMode) Debug.WriteLine("\"" + thisAircraftDefinition.DataFilePath + "\" entry in (" + Filename + ") has files missing - DAT, Model or Collision File. Check the pack and ensure the addon exists in the defined file path address!");
                errors++;
            }
            if (debugMode) Debug.WriteLine("LST file has " + errors + " errors. " + ((errors > 0) ? ":(" : ":D"));
            return Output.ToArray();
        }

        public static string[] GetAllAircraftLSTFilesInYSFlightFolder()
        {
            var ysflightDirectory = @"C:/Program Files/YSFLIGHT.COM/YSFlight/";
            var files = Directory.GetFiles(ysflightDirectory + "Aircraft/", "Air*.LST");
            return files;
        }

        public static AircraftDefinition[] GetAllInstalledAircraftInYSFlightFolder()
        {
            List<AircraftDefinition> Output = new List<AircraftDefinition>();
            var ysflightDirectory = @"C:/Program Files/YSFLIGHT.COM/YSFlight/";
            var files = GetAllAircraftLSTFilesInYSFlightFolder();
            foreach (string thisLSTFileName in files)
            {
                Aircraft thisFile = new Aircraft(thisLSTFileName);
                thisFile.Load();
                foreach (AircraftDefinition thisAircraftDefinition in thisFile.List)
                {
                    if (!System.IO.File.Exists(Path.Combine(ysflightDirectory, thisAircraftDefinition.DataFilePath)))
                        goto Error;
                    if (!System.IO.File.Exists(Path.Combine(ysflightDirectory, thisAircraftDefinition.VisualModelFilePath)))
                        goto Error;
                    if (!System.IO.File.Exists(Path.Combine(ysflightDirectory, thisAircraftDefinition.CollisionFilePath)))
                        goto Error;
                    Output.Add(thisAircraftDefinition);
                    continue;
                    Error:
                        Debug.WriteLine(thisAircraftDefinition.ToString() + " files missing.");
                }
            }
            return Output.ToArray();
        }
    }
}