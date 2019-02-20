using System;
using System.Diagnostics;
using System.IO;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Loggers
{
    internal class DefaultLogger : ILogger
    {
	    public void AddDebugMessage(string message)
	    {
	        StreamWriter debugFile = null;
	        string DebugSubPath = Process.GetCurrentProcess().StartTime.ToString("yyyyMMddHHmmss");
	        string DebugFilePath = "./Logs/Debug_" + DebugSubPath + ".txt";

	        string TimeStamp = (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString("c");


            lock (DebugFilePath)
	        {

	            try
	            {
	                if (!Directory.Exists("./Logs/")) Directory.CreateDirectory("./Logs/");
	            }
	            catch
	            {
	                System.Diagnostics.Debug.WriteLine("Could not verify or create ./Logs/ Directory!");
	                return;
	            }

	            try
	            {
	                debugFile = File.AppendText(DebugFilePath);
	            }
	            catch (UnauthorizedAccessException e)
	            {
	                System.Diagnostics.Debug.WriteLine(
	                    "UnauthorisedAccessException when trying to append to Logs/Debug.txt");
	            }
	            catch (ArgumentNullException e)
	            {
	                System.Diagnostics.Debug.WriteLine("ArgumentNullException when trying to append to Logs/Debug.txt");
	            }
	            catch (ArgumentException e)
	            {
	                System.Diagnostics.Debug.WriteLine("ArgumentException when trying to append to Logs/Debug.txt");
	            }
	            catch (PathTooLongException e)
	            {
	                System.Diagnostics.Debug.WriteLine("PathTooLongException when trying to append to Logs/Debug.txt");
	            }
	            catch (DirectoryNotFoundException e)
	            {
	                System.Diagnostics.Debug.WriteLine(
	                    "DirectoryNotFoundException when trying to append to Logs/Debug.txt");
	            }
	            catch (NotSupportedException e)
	            {
	                System.Diagnostics.Debug.WriteLine("NotSupportedException when trying to append to Logs/Debug.txt");
	            }
	            catch (Exception e)
	            {
	                System.Diagnostics.Debug.WriteLine("Exception when trying to append to Logs/Debug.txt");
                }

	            debugFile?.WriteLine(TimeStamp + ": " + message);
	            debugFile?.Close();
	        }
	    }
    }
	public static class Logger
	{
		private static ILogger _logger = new DefaultLogger();

		public static void LinkLogger(ILogger logger)
		{
			if (logger != null) _logger = logger;
		}

		public static void AddDebugMessage(string message) => _logger.AddDebugMessage(message);
	}
}
