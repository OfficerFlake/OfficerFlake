using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Com.OfficerFlake.Libraries;
using static Com.OfficerFlake.Libraries.RichText.RichTextMessage;
using Com.OfficerFlake.Libraries.Extensions;

using DAT = Com.OfficerFlake.Libraries.YSFlight.Files.DAT;
using LST = Com.OfficerFlake.Libraries.YSFlight.Files.LST;

using Com.OfficerFlake.Libraries.IO.Log;
using Com.OfficerFlake.Libraries.Networking;
using Com.OfficerFlake.Libraries.Networking.Packets;
using static Com.OfficerFlake.Libraries.UserInterfaces.Windows.Extensions;

using Console = Com.OfficerFlake.Libraries.UserInterfaces.Windows.Console;
using Paragraph = Com.OfficerFlake.Libraries.IO.HtmlFile.Dom.Body.Paragraph;

using static Com.OfficerFlake.Libraries.Database;
using Com.OfficerFlake.Libraries.RichText;
using Com.OfficerFlake.Libraries.YSFHQ;
using Com.OfficerFlake.Libraries.YSFlight;
using Debug = Com.OfficerFlake.Libraries.UserInterfaces.Windows.Debug;

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

	        AppDomain currentDomain = AppDomain.CurrentDomain;
	        currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromLibrariesFolder);

			MainProgram();

        }
		#endregion
		#region LoadFromLibrariesFolder
		private static Assembly LoadFromLibrariesFolder(object sender, ResolveEventArgs args)
		{
			#region Unblock Files
			string[] FileNames = Directory.GetFiles("./Libraries/");
			foreach (string ThisFileName in FileNames)
			{
				try
				{
					Unblock(ThisFileName);
				}
				catch
				{
				}
			}
			#endregion
			#region Initialise Variables
			Assembly AssemblyToLoad;
			Assembly RequestingAssembly;
			string assemblyFileameWithoutExtension = "";
			#endregion

			#region Find and Load the Assembly
			try
			{
				#region Get Requesting Assembly
				RequestingAssembly = Assembly.GetExecutingAssembly();
				if (args.RequestingAssembly != null) RequestingAssembly = args.RequestingAssembly;
				#endregion
				#region Get List of Referenced Assembly Names
				AssemblyName[] ReferencedAssemblymNames = RequestingAssembly.GetReferencedAssemblies();
				#endregion

				#region Iterate over Referenced Assembly Names
				foreach (AssemblyName thisAssemblyName in ReferencedAssemblymNames)
				{
					#region Initialise Variables
					string currentIterationAssemblyName =
						thisAssemblyName.FullName.Substring(0, thisAssemblyName.FullName.IndexOf(","));
					string desiredAssemblyName = args.Name.Substring(0, args.Name.IndexOf(","));
					#endregion
					#region Found it!
					if (currentIterationAssemblyName == desiredAssemblyName)
					{             
						assemblyFileameWithoutExtension = args.Name.Substring(0, args.Name.IndexOf(","));
						break;
					}
					#endregion
				}
				#endregion
				#region Not Found!
				if (assemblyFileameWithoutExtension == "")
				{
					return null;
				}
				#endregion

				#region Load DLL and PDB 
				byte[] DLLBytes = File.ReadAllBytes("./Libraries/" + assemblyFileameWithoutExtension + ".DLL");
				byte[] PDBBytes = File.ReadAllBytes("./ProgramDebugSymbols/" + assemblyFileameWithoutExtension + ".PDB");
				AssemblyToLoad = Assembly.Load(DLLBytes, PDBBytes);
				#endregion
			}
			catch (Exception e)
			{
				System.Console.ForegroundColor = ConsoleColor.White;
				System.Console.Clear();
				System.Console.WriteLine("Failed to Launch OYS!");
				System.Console.WriteLine();
				System.Console.WriteLine("Specifically, Failed to load DLL: " + args.Name.Substring(0, args.Name.IndexOf(",")));
				System.Console.WriteLine("Are you sure ALL the .DLL's are in the ./Libraries/ Folder?");
				System.Console.WriteLine("");
				System.Console.WriteLine("(Exception Info Follows)");
				System.Console.WriteLine(e.ToString());
				System.Console.WriteLine("");
				System.Console.ForegroundColor = ConsoleColor.Red;
				System.Console.WriteLine("[SCROLL UP TO SEE FULL DETAILS!]");
				while (true)
				{
					System.Console.ReadKey(true);
				}
			}
			#endregion

			return AssemblyToLoad;
		}

		#region Unblock File
		[DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool DeleteFile(string name);

		private static bool Unblock(string fileName)
		{
			return DeleteFile(fileName + ":Zone.Identifier");
		}
		#endregion
		#endregion

		private static void MainProgram()
		{
			#region Link Objects Together
			Connection.SetPacketProcessor(PacketProcessor.Server.Process);
			#endregion

			Console.Show();
			Debug.Show();

			Debug.AddCrashMessage("TEST");

			#region Load World
			Console.AddInformationMessage("Loading World");

			Metadata.LoadAll();

			//World.Load("OPENYS_TEST_FIELD");
			World.Load("HAWAII");

			Console.AddInformationMessage("World Loading Complete!");
			#endregion

			#region Start Server
			Console.AddInformationMessage("Starting Server...");
			Server.Start();
			Console.AddInformationMessage("Now Listening on Port 7915!");
			#endregion

			Console.WaitForClose();
			Debug.WaitForClose();

			Server.ShutDown();
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
            var user = new Paragraph(new UserMessage(Users.TestUser, "User User User"));

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
                Debug.AddInformationMessage(filename + " reads OK!");
                return true;
            }
            Debug.AddWarningMessage(filename + " reads with ERRORS!");
            if (debug) Debug.AddInformationMessage("NOW PROCESSING : " + filename);
            if (debug) Debug.AddInformationMessage("=================" + new string('=', filename.Length));
            file.Load();
            if (debug) Debug.AddInformationMessage("==============" + new string('=', filename.Length));
            if (debug) Debug.AddInformationMessage("END OF FILE : " + filename);
            return false;
        }
        private static void LstTest()
        {
            Debug.AddInformationMessage("STARTING LST SPIDER TEST");
            Debug.AddInformationMessage("========================");
            Debug.AddInformationMessage("");
            var path = @"C:/Program Files/YSFLIGHT.COM/YSFlight/";
            var installedAircraftLsTs = new [] {path + "Aircraft/aircraft.lst"};
            //var installedAircraftLsTs = LST.Aircraft.GetAllAircraftLSTFilesInYSFlightFolder();
            var count = installedAircraftLsTs.Sum(t => new LST.Aircraft(t).GetAllInstalledAircraftFromLSTFile().Length);
            Debug.AddInformationMessage("There are " + count + " installed aircraft in the YSFlight folder.");
            Debug.AddInformationMessage("");
            for (var j = 0; j < installedAircraftLsTs.Length; j++)
            {
                var thisLstFile = new LST.Aircraft(installedAircraftLsTs[j]);
                var installedAircraft = thisLstFile.GetAllInstalledAircraftFromLSTFile(true);
                Debug.AddInformationMessage("Sequentially testing " + (j + 1) + " of " + installedAircraftLsTs.Length +
                                    " installed aircraft LST files. (" + installedAircraftLsTs[j] + ")");
                for (var i = 0; i < installedAircraft.Length; i++)
                {
                    Debug.AddInformationMessage("----Sequentially testing " + (i + 1) + " of " + installedAircraft.Length +
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
                    Debug.AddInformationMessage("----====Aircraft: " + identify + " (" + filename + ")");
                    if (!result) continue;
                    var graph = new DAT.Performance.SpiderGraph(file);
                    DAT.Performance.SpiderGraph.Statistics.Update(graph);
                    graph.ShowDebug();
                    Debug.AddInformationMessage("----Done: " + identify);
                }
                Debug.AddInformationMessage("Sequential aircraft testing complete for: " + thisLstFile.Filename);
                Debug.AddInformationMessage("Spider statistics for: " + thisLstFile.Filename);
                DAT.Performance.SpiderGraph.Statistics.ShowDebug();
                Debug.AddInformationMessage("End Spider statistics.");
            }
            Debug.AddInformationMessage("END LST SPIDER TEST");
            Debug.AddInformationMessage("===================");
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
