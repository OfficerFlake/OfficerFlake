using System.Collections.Generic;
using System.IO;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.LST
{
    public class Aircraft : ListFile
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

            public AircraftDefinition(IListFileLine thisLine)
            {
	            DataFilePath = thisLine.GetParameter(0);
				VisualModelFilePath = thisLine.GetParameter(1);
				CollisionFilePath = thisLine.GetParameter(2);
				CockpitFilePath = thisLine.GetParameter(3);
				CoarseModelFilePath = thisLine.GetParameter(4);
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
            bool ShowLines = false;
            base.Load();

            List = new List<AircraftDefinition>();
            foreach (var thisLine in Lines)
            {
                if (ShowLines) Debug.AddSummaryMessage(thisLine.ToString());
                if (thisLine.NumberOfParameters < 3) continue;
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
            if (debugMode) Debug.AddDetailMessage("Testing definitions in LST file for validity...");
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
                if (debugMode) Debug.AddDetailMessage("\"" + thisAircraftDefinition.DataFilePath + "\" entry in (" + Filename + ") has files missing - DAT, Model or Collision File. Check the pack and ensure the addon exists in the defined file path address!");
                errors++;
            }
            if (debugMode) Debug.AddDetailMessage("LST file has " + errors + " errors. " + ((errors > 0) ? ":(" : ":D"));
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
                        Debug.AddDetailMessage(thisAircraftDefinition.ToString() + " files missing.");
                }
            }
            return Output.ToArray();
        }
    }
}