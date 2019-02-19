using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Com.OfficerFlake.Libraries;
using Com.OfficerFlake.Libraries.Logger;
using Com.OfficerFlake.Libraries.Networking;
using Com.OfficerFlake.Libraries.UserInterfaces;
using Com.OfficerFlake.Libraries.YSFlight;

using Console = Com.OfficerFlake.Libraries.Logger.Console;
using static Com.OfficerFlake.Libraries.SettingsLibrary;

namespace Com.OfficerFlake.Executables.ProxyMode
{
	public static class Program
	{
		#region Start Program!
		[STAThread]
		public static void Main()
		{
			//LoadAllDLLs();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromLibrariesFolder);

			LinkObjects();
			MainProgram();

		}
		#endregion

		public static void LoadAllDLLs()
		{
			string[] files = Directory.GetFiles("./Libraries/", "*.dll").Select(Path.GetFileNameWithoutExtension).ToArray();
			foreach (string thisfile in files)
			{
				try
				{
					byte[] DLLBytes = File.ReadAllBytes("./Libraries/" + thisfile + ".DLL");
					byte[] PDBBytes = File.ReadAllBytes("./ProgramDebugSymbols/" + thisfile + ".PDB");
					Assembly.Load(DLLBytes, PDBBytes);
				}
				catch
				{
				}
			}
		}
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
		#region Link Objects
		private static void LinkObjects()
		{
			#region Link Objects Together
			#region LINK FACTORY FIRST!
			MasterObjectFactory.LinkMasterFactory();
			#endregion
			#region Link Interacting Components
			Connection.SetPacketProcessorClientStream(PacketProcessor.ServerClientStream.Process);
			#endregion
			#region LINK UI LAST!
			UserInterface.Initialise();
			OpenYSServerModeUserInterface.CreateWindow();
		    OpenYSServerModeUserInterface.ChangeTitle("OpenYS - Server Mode");
            OpenYSPacketInspectorUserInterface.CreateWindow();
			OpenYSPacketInspectorUserInterface.LinkPacketInspector();
		    OpenYSFormationInspectorUserInterface.CreateWindow();
		    OpenYSFormationInspectorUserInterface.LinkFormationInspector();
            OpenYSServerModeUserInterface.LinkDebug();
			OpenYSServerModeUserInterface.LinkConsole();
			#endregion
			OpenYSServerModeUserInterface.Show();
			#endregion
		}
		#endregion
		#region Run Server
		private static void MainProgram()
		{
			Console.AddInformationMessage("Starting OpenYS Version: " + DeveloperAttributes.DeveloperInfo.BuildVersion);

			#region Load Settings
			Console.AddInformationMessage("Loading Settings...");
			SettingsHandler.LoadAll();
			Console.AddInformationMessage("Settings Loading Complete.");
		    FormationInspector.UpdateHostAddressFromSettings();
            #endregion
            #region Load MetaData
            Console.AddInformationMessage("Loading YSFlight MetaData from \"" + Settings.YSFlight.Directory + "\".");
			Metadata.LoadAll();
			Console.AddInformationMessage("YSFlight Metadata Loading Complete.");
			#endregion
			#region Load World
			Console.AddInformationMessage("Loading World from Field: \"" + Settings.Options.FieldName + "\".");
			World.Load(Settings.Options.FieldName);
			Console.AddInformationMessage("World Loading Complete!");
			#endregion
			#region Start Server
			Console.AddInformationMessage("Starting OpenYS Server...");
			Server.Start();
			Console.AddInformationMessage("OpenYS Server Startup Complete.");
			Console.AddInformationMessage("Now listening for TCP Traffic on Port: " + Settings.Server.ListeningPorts.TCP + "!");
			Console.AddInformationMessage("Now Listening for UDP Traffic on Port: " + Settings.Server.ListeningPorts.UDP + "!");
			#endregion

			Console.AddInformationMessage("--------");

			OpenYSServerModeUserInterface.WaitForClose();
			OpenYSPacketInspectorUserInterface.CloseWindow();

			Server.Stop();
			UserInterface.Shutdown();
		}
		#endregion
	}
}
