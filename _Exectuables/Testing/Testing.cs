using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Com.OfficerFlake.Libraries;
using static Com.OfficerFlake.Libraries.RichText.RichTextMessage;
using Com.OfficerFlake.Libraries.UserInterfaces.Windows;
using Com.OfficerFlake.Libraries.Extensions;

using DAT = Com.OfficerFlake.Libraries.YSFlight.Files.DAT;
using LST = Com.OfficerFlake.Libraries.YSFlight.Files.LST;

using Com.OfficerFlake.Libraries.IO.Log;
using static Com.OfficerFlake.Libraries.UserInterfaces.Windows.Extensions;

using Console = Com.OfficerFlake.Libraries.UserInterfaces.Windows.Console;
using Paragraph = Com.OfficerFlake.Libraries.IO.HtmlFile.Dom.Body.Paragraph;
using Com.OfficerFlake.Libraries.Databases;
using Com.OfficerFlake.Libraries.RichText;

namespace Com.OfficerFlake.Executables.Testing
{
    public static class Program
    {
		#region Start Program!
		[STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

	        MainProgram();

        }
		#endregion

	    private static void MainProgram()
	    {
			Console consoleWindow = new Console();
		    NewWindowThread(consoleWindow);

			UserDB.UserObject Flake = new UserDB.UserObject("Flake".AsRichTextString());
		    Flake.YSFHQ.Username = "UsernameGoesHere";
		    Flake.YSFHQ.Password = "PasswordGoesHere";

			//consoleWindow.consoleOutput.AddMessage(new InformationMessage("&bTesting from Root!"));
			//consoleWindow.consoleOutput.AddMessage(new InformationMessage("&aRoot test success!"));
			//consoleWindow.consoleOutput.AddMessage(new InformationMessage("----"));
			//consoleWindow.consoleOutput.AddMessage(new InformationMessage("Testing API Login (unhashed)..."));

		    //if (Flake.YSFHQ.TryAuthenticate())
		    //{
			   // consoleWindow.consoleOutput.AddMessage(new InformationMessage("&aLogin Success!"));
		    //}
		    //else
		    //{
			   // consoleWindow.consoleOutput.AddMessage(new InformationMessage("&cLogin Failure!"));
		    //}
		}

		#region Old Tests
		private static void QuickTest()
        {
            var test = new LogFile("./TestFile.html");

            var crash = new Paragraph(new CrashMessage("Crash Crash Crash"));
            var error = new Paragraph(new ErrorMessage("Error Error Error"));
            var warning = new Paragraph(new WarningMessage("Warning Warning Warning"));
            var debug = new Paragraph(new DebugMessage("Debug Debug Debug"));
            var info = new Paragraph(new InformationMessage("Info Info Info"));
            var user = new Paragraph(new UserMessage(UserDB.TestUser, "User User User"));

            test.Body.Elements.Add(crash);
            test.Body.Elements.Add(error);
            test.Body.Elements.Add(warning);
            test.Body.Elements.Add(debug);
            test.Body.Elements.Add(info);
            test.Body.Elements.Add(user);

            test.Save();

            Process.Start(Directory.GetCurrentDirectory() + test.Filename);
        }

        private const bool useRandom = true;
        private static void DatTest()
        {
            const string targetfile = @"f16.dat";
            var file = useRandom ? GetRandomDatFileFromYsfFolder() : GetDatFileFromYsfFolder(targetfile);
            do
            {
                DatTest2(file);
            } while (useRandom);
        }
        private static bool DatTest2(DAT.File file, bool debug = false)
        {

            var filename = Path.GetFileName(file.Filename) ?? "???";

            var result = file.Load();
            if (result)
            {
                Debug.WriteLine(filename + " reads OK!");
                return true;
            }
            Debug.WriteLine(filename + " reads with ERRORS!");
            if (debug) Debug.WriteLine("NOW PROCESSING : " + filename);
            if (debug) Debug.WriteLine("=================" + new string('=', filename.Length));
            file.Load();
            if (debug) Debug.WriteLine("==============" + new string('=', filename.Length));
            if (debug) Debug.WriteLine("END OF FILE : " + filename);
            return false;
        }
        private static void LstTest()
        {
            Debug.WriteLine("STARTING LST SPIDER TEST");
            Debug.WriteLine("========================");
            Debug.WriteLine("");
            var path = @"C:/Program Files/YSFLIGHT.COM/YSFlight/";
            var installedAircraftLsTs = new [] {path + "Aircraft/aircraft.lst"};
            //var installedAircraftLsTs = LST.Aircraft.GetAllAircraftLSTFilesInYSFlightFolder();
            var count = installedAircraftLsTs.Sum(t => new LST.Aircraft(t).GetAllInstalledAircraftFromLSTFile().Length);
            Debug.WriteLine("There are " + count + " installed aircraft in the YSFlight folder.");
            Debug.WriteLine("");
            for (var j = 0; j < installedAircraftLsTs.Length; j++)
            {
                var thisLstFile = new LST.Aircraft(installedAircraftLsTs[j]);
                var installedAircraft = thisLstFile.GetAllInstalledAircraftFromLSTFile(true);
                Debug.WriteLine("Sequentially testing " + (j + 1) + " of " + installedAircraftLsTs.Length +
                                    " installed aircraft LST files. (" + installedAircraftLsTs[j] + ")");
                for (var i = 0; i < installedAircraft.Length; i++)
                {
                    Debug.WriteLine("----Sequentially testing " + (i + 1) + " of " + installedAircraft.Length +
                                    " defined aircraft...");
                    var thisAircraftDefinition = installedAircraft[i];
                    var filename = thisAircraftDefinition.DataFilePath;
                    if (filename == null) continue;
                    string filepathname;
                    try
                    {
                        filepathname = Path.Combine(path, filename);
                    }
                    catch
                    {
                        continue;
                    }
                    var file = new DAT.File(filepathname);
                    var result = DatTest2(file);
                    var identify = (file.Properties.OfType<DAT.Properties.IDENTIFY>().Any())
                        ? file.Properties.OfType<DAT.Properties.IDENTIFY>().Last().Value
                        : "???";
                    Debug.WriteLine("----====Aircraft: " + identify + " (" + filename + ")");
                    if (!result) continue;
                    var graph = new DAT.Performance.SpiderGraph(file);
                    DAT.Performance.SpiderGraph.Statistics.Update(graph);
                    graph.ShowDebug();
                    Debug.WriteLine("----Done: " + identify);
                }
                Debug.WriteLine("Sequential aircraft testing complete for: " + thisLstFile.Filename);
                Debug.WriteLine("Spider statistics for: " + thisLstFile.Filename);
                DAT.Performance.SpiderGraph.Statistics.ShowDebug();
                Debug.WriteLine("End Spider statistics.");
            }
            Debug.WriteLine("END LST SPIDER TEST");
            Debug.WriteLine("===================");
        }

        private static DAT.File GetRandomDatFileFromYsfFolder()
        {
            const string path = @"C:/Program Files/YSFLIGHT.COM/YSFlight/Aircraft/";
            dynamic[] files = Directory.GetFiles(path, "*.DAT");
            return new DAT.File(GetRandom(files));
        }
        private static DAT.File GetDatFileFromYsfFolder(string filename)
        {
            const string path = @"C:/Program Files/YSFLIGHT.COM/YSFlight/Aircraft/";
            return new DAT.File(Path.Combine(path, filename));
        }

        private static readonly Random Random = new Random();
        private static dynamic GetRandom(dynamic[] objects)
        {
            if (objects == null) throw new ArgumentNullException(nameof(objects));
            var index = Random.Next(0, objects.Length - 1);
            return objects[index];
        }
		#endregion
	}
}
