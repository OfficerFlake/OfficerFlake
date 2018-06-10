using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

using Com.OfficerFlake.Libraries.Extensions;

namespace OpenYSAuthenticatorExecutable
{
	static class Program
	{

		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			AppDomain currentDomain = AppDomain.CurrentDomain;

			YSFHQAuthenticationService testform = new YSFHQAuthenticationService();

			int[] PIDs = DetectYSFlightProcesses();
			IPEndPoint[] Endpoints = GetTCPIPConnectionFromProcessIDs(PIDs);

			Application.Run();
		}

		private static string RunCMDGetOutput(string args = "")
		{
			Process process = new Process
			{
				StartInfo =
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true,
					FileName = "cmd.exe",
					Arguments = "/C " + args
				}
			};
			process.Start();
			process.WaitForExit();
			string output = "";
			if (process.HasExited)
			{
				output = process.StandardOutput.ReadToEnd();
			}
			return output;
		}

		public static int[] DetectYSFlightProcesses()
		{
			List<int> PIDs = new List<int>();
			string fsmaino = RunCMDGetOutput("tasklist | findstr fsmaino");
			if (fsmaino.Length > 0)
			{
				string[] lines = fsmaino.Split('\n');
				foreach (string thisline in lines)
				{
					if (thisline.Length <= 0) continue;
					string thisPID = thisline.RemoveDoubleSpaces().Split(' ')[1];
					int convertedPID = 0;
					Int32.TryParse(thisPID, out convertedPID);
					if (convertedPID > 0) PIDs.Add(convertedPID);
				}
			}

			string fsmaindx = RunCMDGetOutput("tasklist | findstr fsmaindx");
			if (fsmaindx.Length > 0)
			{
				string[] lines = fsmaindx.Split('\n');
				foreach (string thisline in lines)
				{
					if (thisline.Length <= 0) continue;
					string thisPID = thisline.RemoveDoubleSpaces().Split(' ')[1];
					int convertedPID = 0;
					Int32.TryParse(thisPID, out convertedPID);
					if (convertedPID > 0) PIDs.Add(convertedPID);
				}
			}

			string ysflight32_gl1 = RunCMDGetOutput("tasklist | findstr ysflight32_gl1");
			if (ysflight32_gl1.Length > 0)
			{
				string[] lines = ysflight32_gl1.Split('\n');
				foreach (string thisline in lines)
				{
					if (thisline.Length <= 0) continue;
					string thisPID = thisline.RemoveDoubleSpaces().Split(' ')[1];
					int convertedPID = 0;
					Int32.TryParse(thisPID, out convertedPID);
					if (convertedPID > 0) PIDs.Add(convertedPID);
				}
			}

			string ysflight32_gl2 = RunCMDGetOutput("tasklist | findstr ysflight32_gl2");
			if (ysflight32_gl2.Length > 0)
			{
				string[] lines = ysflight32_gl2.Split('\n');
				foreach (string thisline in lines)
				{
					if (thisline.Length <= 0) continue;
					string thisPID = thisline.RemoveDoubleSpaces().Split(' ')[1];
					int convertedPID = 0;
					Int32.TryParse(thisPID, out convertedPID);
					if (convertedPID > 0) PIDs.Add(convertedPID);
				}
			}

			string ysflight32_d3d9 = RunCMDGetOutput("tasklist | findstr ysflight32_d3d9");
			if (ysflight32_d3d9.Length > 0)
			{
				string[] lines = ysflight32_d3d9.Split('\n');
				foreach (string thisline in lines)
				{
					if (thisline.Length <= 0) continue;
					string thisPID = thisline.RemoveDoubleSpaces().Split(' ')[1];
					int convertedPID = 0;
					Int32.TryParse(thisPID, out convertedPID);
					if (convertedPID > 0) PIDs.Add(convertedPID);
				}
			}

			return PIDs.ToArray();
		}
		public static IPEndPoint[] GetTCPIPConnectionFromProcessIDs(int[] PIDs)
		{
			List<IPEndPoint> endPoints = new List<IPEndPoint>();
			foreach (int thisPID in PIDs)
			{
				string response = RunCMDGetOutput("netstat -aon | findstr " + thisPID.ToString());
				string[] lines = response.Split('\n');
				foreach (string thisline in lines)
				{
					if (thisline.Length <= 0) continue;
					string thisEndPoint = thisline.RemoveDoubleSpaces().Split(' ')[3];
					string thisIP = thisEndPoint.Split(':')[0];
					string thisPort = thisEndPoint.Split(':')[1];
					IPAddress convertedIP = IPAddress.Any;
					IPAddress.TryParse(thisIP, out convertedIP);
					int convertedPort = -1;
					int.TryParse(thisPort, out convertedPort);
					if (convertedPort > 0) endPoints.Add(new IPEndPoint(convertedIP, convertedPort));
				}
			}
			return endPoints.ToArray();
		}
	}
}
