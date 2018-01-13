using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Com.OfficerFlake.Libraries;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Logger;

using Com.OfficerFlake.Libraries.Networking;
using Com.OfficerFlake.Libraries.UserInterfaces.Windows;
using Com.OfficerFlake.Libraries.UserInterfacesWPF;
using Com.OfficerFlake.Libraries.YSFlight;

using Console = Com.OfficerFlake.Libraries.Logger.Console;
using Debug = Com.OfficerFlake.Libraries.Logger.Debug;

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
			MasterObjectFactory.LinkMasterFactory();
			//DebugUI.LinkDebug();
			ConsoleUI.CreateWindow();
			ConsoleUI.LinkConsole();
			Connection.SetPacketProcessor(PacketProcessor.Server.Process);
			#endregion

			//ConsoleUI.Show();
			//DebugUI.Show();

			Console.AddInformationMessage("TEST");
			Debug.AddCrashMessage(new NotImplementedException("CRASH TEST"), "TEST");
			Debug.AddErrorMessage(new NotImplementedException("ERROR TEST"), "TEST");
			Debug.AddWarningMessage("TEST");
			Debug.AddDetailMessage("TEST");
			Debug.AddSummaryMessage("TEST");

			#region Load World
			Console.AddInformationMessage("Loading World");
			Console.AddUserMessage(Users.Console, "TEST");

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

			ConsoleUI.WaitForClose();
			//DebugUI.WaitForClose();

			Server.Stop();
		}
	}
}
