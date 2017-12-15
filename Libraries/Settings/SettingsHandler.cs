using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Com.OfficerFlake.Libraries.Color;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.IO.CommandFile;

namespace Com.OfficerFlake.Libraries
{
	public static class SettingsHandler
	{
		#region Settings File Monitoring
		public static FileSystemWatcher SettingsFileWatcher = new FileSystemWatcher();

		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		public static bool Monitor()
		{
			SettingsFileWatcher.Path = Directory.GetCurrentDirectory();
			SettingsFileWatcher.NotifyFilter = NotifyFilters.LastWrite;
			SettingsFileWatcher.Filter = "Settings.xlsx";
			SettingsFileWatcher.Changed += new FileSystemEventHandler(SettingsFileChanged);
			SettingsFileWatcher.EnableRaisingEvents = true;
			//Console.WriteLine("Monitoring: " + Directory.GetCurrentDirectory() + "\\Settings.Dat");
			return true;
		}

		private static void SettingsFileChanged(object source, FileSystemEventArgs e)
		{
			// Specify what is done when a file is changed, created, or deleted.
			System.Console.ForegroundColor = ConsoleColor.Yellow;
			System.Console.WriteLine("Settings file updated manually. To Reload, type \"&a/ReloadSettings&e\".");
			System.Console.ForegroundColor = ConsoleColor.White;
			SettingsFileWatcher.EnableRaisingEvents = false;
			//LoadAll();
			SettingsFileWatcher.EnableRaisingEvents = true;
		}
		#endregion

		#region Save/Load
		internal static object ConvertParameterStringToObject(Type desiredType, string parameters, object defaultObject)
		{
			try
			{
				//DO NOT ADD CUTSOM CLASSES TO CONVERT TYPE! USE A DATABASE PRIMARY KEY INSTEAD!


				//System Objects
				#region Boolean
				if (desiredType == typeof(Boolean))
					return Convert.ChangeType(Boolean.Parse(parameters), desiredType);
				#endregion
				#region Byte
				if (desiredType == typeof(Byte))
					return Convert.ChangeType(Byte.Parse(parameters), desiredType);
				#endregion
				#region SByte
				if (desiredType == typeof(SByte))
					return Convert.ChangeType(SByte.Parse(parameters), desiredType);
				#endregion

				#region Int16
				if (desiredType == typeof(Int16))
					return Convert.ChangeType(Int16.Parse(parameters), desiredType);
				#endregion
				#region Int32
				if (desiredType == typeof(Int32))
					return Convert.ChangeType(Int32.Parse(parameters), desiredType);
				#endregion
				#region Int64
				if (desiredType == typeof(Int64))
					return Convert.ChangeType(Int64.Parse(parameters), desiredType);
				#endregion
				#region UInt16
				if (desiredType == typeof(UInt16))
					return Convert.ChangeType(UInt16.Parse(parameters), desiredType);
				#endregion
				#region UInt32
				if (desiredType == typeof(UInt32))
					return Convert.ChangeType(UInt32.Parse(parameters), desiredType);
				#endregion
				#region UInt64
				if (desiredType == typeof(UInt64))
					return Convert.ChangeType(UInt64.Parse(parameters), desiredType);
				#endregion

				#region Single
				if (desiredType == typeof(Single))
					return Convert.ChangeType(Single.Parse(parameters), desiredType);
				#endregion
				#region Double
				if (desiredType == typeof(Double))
					return Convert.ChangeType(Double.Parse(parameters), desiredType);
				#endregion

				#region IPAddress
				if (desiredType == typeof(IPAddress))
				{
					IPAddress matchingIPAddress = IPAddress.Parse("127.0.0.1");
					try
					{
						matchingIPAddress = Dns.GetHostAddresses(parameters)[0];
					}
					catch
					{
					}
					try
					{
						matchingIPAddress = IPAddress.Parse(parameters);
					}
					catch
					{
					}
					return Convert.ChangeType(matchingIPAddress, desiredType);
				}
				#endregion
				#region String
				if (desiredType == typeof(String))
					return Convert.ChangeType(Double.Parse(parameters), desiredType);
				#endregion

				//Units Of Measurement
				#region Angle				
				if (desiredType == typeof(Angle))
				{
					Angle thisAngle;
					Angle.TryParse(parameters, out thisAngle);
					return Convert.ChangeType(thisAngle, desiredType);
				}
				#endregion
				#region Area
				if (desiredType == typeof(Area))
				{
					Area thisArea;
					Area.TryParse(parameters, out thisArea);
					return Convert.ChangeType(thisArea, desiredType);
				}
				#endregion
				#region Energy				
				if (desiredType == typeof(Energy))
				{
					Energy thisEnergy;
					Energy.TryParse(parameters, out thisEnergy);
					return Convert.ChangeType(thisEnergy, desiredType);
				}

				#endregion
				#region Length				
				if (desiredType == typeof(Length))
				{
					Length thisLength;
					Length.TryParse(parameters, out thisLength);
					return Convert.ChangeType(thisLength, desiredType);
				}

				#endregion
				#region Mass				
				if (desiredType == typeof(Mass))
				{
					Mass thisMass;
					Mass.TryParse(parameters, out thisMass);
					return Convert.ChangeType(thisMass, desiredType);
				}

				#endregion
				#region Power				
				if (desiredType == typeof(Power))
				{
					Power thisPower;
					Power.TryParse(parameters, out thisPower);
					return Convert.ChangeType(thisPower, desiredType);
				}
				#endregion
				#region Pressure				
				if (desiredType == typeof(Pressure))
				{
					Pressure thisPressure;
					Pressure.TryParse(parameters, out thisPressure);
					return Convert.ChangeType(thisPressure, desiredType);
				}
				#endregion
				#region Speed				
				if (desiredType == typeof(Speed))
				{
					Speed thisSpeed;
					Speed.TryParse(parameters, out thisSpeed);
					return Convert.ChangeType(thisSpeed, desiredType);
				}
				#endregion
				#region Temperature				
				if (desiredType == typeof(Temperature))
				{
					Temperature thisTemperature;
					Temperature.TryParse(parameters, out thisTemperature);
					return Convert.ChangeType(thisTemperature, desiredType);
				}
				#endregion
				#region Volume				
				if (desiredType == typeof(Volume))
				{
					Volume thisVolume;
					Volume.TryParse(parameters, out thisVolume);
					return Convert.ChangeType(thisVolume, desiredType);
				}
				#endregion

				//Colors
				#region XRGBColor
				if (desiredType == typeof(XRGBColor))
				{
					string[] split = parameters.Split(' ');

					byte red = 255;
					byte green = 255;
					byte blue = 255;

					XRGBColor White = new XRGBColor(255, 255, 255);

					if (split.Length < 3)
					{
						return Convert.ChangeType(White, desiredType);
					}

					try
					{
						red = Convert.ToByte(split[0]);
						green = Convert.ToByte(split[1]);
						blue = Convert.ToByte(split[2]);
					}
					catch (OverflowException)
					{
						//Debug
						return Convert.ChangeType(White, desiredType);
					}
					catch (FormatException)
					{
						//Debug
						return Convert.ChangeType(White, desiredType);
					}
					return Convert.ChangeType(new XRGBColor(red, green, blue), desiredType);
				}
				#endregion

			}
			catch
			{
			}
			return defaultObject;
		}
		internal static bool FindAndUpdateSetting(string command, string parameters)
		{
			try
			{
				#region Split Command
				string[] commandSplit = parameters.Split('.');
				#endregion
				#region Find and Modify the Setting.
				Type TargetClass = typeof(Settings);
				for (int i = 0; i < commandSplit.Length; i++)
				{
					#region Found a Matching Sub-Class, Move into it.
					if (i < commandSplit.Length - 1)
					{
						TargetClass = TargetClass.GetNestedType(commandSplit[i]);
						continue;
					}
					#endregion
					#region Convert the Paramters to an Object
					FieldInfo thisField = TargetClass.GetField(commandSplit[i]);
					object valueToSet = ConvertParameterStringToObject(thisField.FieldType, parameters, thisField.GetValue(null));
					#endregion
					#region Set the Field to the Converted Value
					thisField.SetValue(null, valueToSet);
					return true;
					#endregion
				}
				#endregion
				#region Couldn't Find the Correct Setting.
				return false;
				#endregion
			}
			catch
			{
				return false;
			}
		}


		public static bool LoadAll()
		{
			#region Settings Not Found on Disk
			if (!File.Exists(@"./Settings.Dat")) return false;
			#endregion
			#region Load Settings File Contents
			Settings.SettingsFile.Load();
			#endregion
			#region Iterate over Contents, Update Settings
			try
			{
				for (int i = 0; i < Settings.SettingsFile.Lines.Count; i++)
				{
					CommandFile.Line thisLine = Settings.SettingsFile.Lines[i];

					string command = thisLine.Command;
					string parameters = string.Join(" ", thisLine.Parameters);

					FindAndUpdateSetting(command, parameters);
				}
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
			#endregion
		}
		public static bool SaveAll()
		{
			//TODO: REWRITE SAVEALL TO USE TXT FILE

			SettingsFileWatcher.EnableRaisingEvents = false;
			FileInfo File = new FileInfo("./Settings.xlsx");
			//This framework is a real pain in the ARSE!
			//It uses non zero based indexes!
			//using (ExcelPackage xlPackage = new ExcelPackage(File))
			//{
			//	// get the first worksheet in the workbook
			//	ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
			//	for (int i = 4; i < 1024; i++)
			//	{
			//		object _Key = worksheet.Cells[i, 1].Value;
			//		string Key = _Key == null ? "" : _Key.ToString();
			//		if (Key == "")
			//		{
			//			continue;
			//		}
			//		object _Val = worksheet.Cells[i, 2].Value;
			//		string Val = _Val == null ? "" : _Val.ToString();
			//		object NewVal = SettingsHandler._GetDirect(Key);
			//		if (NewVal == null)
			//		{
			//			Log.Warning(("&3Save Fail: " + Key).Resize(System.Console.WindowWidth));
			//			NewVal = Val;
			//		}
			//		if (NewVal.GetType() == typeof(IPAddress))
			//		{
			//			IPAddress _IP = (IPAddress)NewVal;
			//			IPAddress[] _Matches = new IPAddress[0];
			//			bool NetIsUp = false;
			//			try
			//			{
			//				Ping ping = new Ping();

			//				//ping googles dns server to determine if the net connection is available!
			//				PingReply pingStatus = ping.Send(IPAddress.Parse("8.8.8.8"));

			//				if (pingStatus.Status == IPStatus.Success)
			//				{
			//					NetIsUp = true;
			//				}
			//			}
			//			catch
			//			{
			//			}

			//			try
			//			{
			//				if (NetIsUp) _Matches = Dns.GetHostAddresses(Val);
			//			}
			//			catch
			//			{
			//				//No net connection, can't resolve...
			//			}
			//			if (!NetIsUp) continue; //can't verify the IP Address, let's leave it the way it is for now...
			//			if (_Matches.Select(x => x.ToString()).Contains(_IP.ToString())) continue; //no change required!
			//			else worksheet.Cells[i, 2].Value = NewVal;
			//			continue;
			//		}
			//		if (NewVal.ToString() == Val) continue;
			//		worksheet.Cells[i, 2].Value = NewVal;
			//	}
			//	xlPackage.Save();

			//} // the using statement calls Dispose() which closes the package.
			//try
			//{
			//	SettingsFileWatcher.EnableRaisingEvents = true;
			//}
			//catch
			//{
			//	//Path not of legal form? Stop watching...
			//}
			return true;
		}
		#endregion

		public static bool DumpSettingsFileTemplate(string Output)
		{
			try
			{
				//var resourceName = "OpenYS.SettingsTemplate.xlsx";
				//string[] Names = System.Reflection.Assembly.GetAssembly(typeof(Settings)).GetManifestResourceNames();

				//using (Stream stream = System.Reflection.Assembly.GetAssembly(typeof(Settings)).GetManifestResourceStream(resourceName))
				//{
				//	using (System.IO.FileStream fileStream = new System.IO.FileStream(Output, System.IO.FileMode.Create))
				//	{
				//		for (int i = 0; i < stream.Length; i++)
				//		{
				//			fileStream.WriteByte((byte)stream.ReadByte());
				//		}
				//		fileStream.Close();
				//	}
				//}
				return true;
			}
			catch
			{
				return false;
			}
		}
		
	}
}
