using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Permissions;

using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries
{
	public static partial class SettingsLibrary
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
					//DO NOT ADD CUSTOM CLASSES TO CONVERT TYPE! USE A DATABASE PRIMARY KEY INSTEAD!

					//System Objects

					#region Boolean

					if (desiredType == typeof(Boolean))
					{
						Boolean output;
						return Boolean.TryParse(parameters, out output) ? output : defaultObject;
					}

					#endregion

					#region Byte

					if (desiredType == typeof(Byte))
					{
						Byte output;
						return Byte.TryParse(parameters, out output) ? output : defaultObject;
					}

					#endregion
					#region SByte

					if (desiredType == typeof(SByte))
					{
						SByte output;
						return SByte.TryParse(parameters, out output) ? output : defaultObject;
					}

					#endregion

					#region Int16

					if (desiredType == typeof(Int16))
					{
						Int16 output;
						return Int16.TryParse(parameters, out output) ? output : defaultObject;
					}

					#endregion
					#region UInt16

					if (desiredType == typeof(UInt16))
					{
						UInt16 output;
						return UInt16.TryParse(parameters, out output) ? output : defaultObject;
					}

					#endregion

					#region Int32

					if (desiredType == typeof(Int32))
					{
						Int32 output;
						return Int32.TryParse(parameters, out output) ? output : defaultObject;
					}

					#endregion
					#region UInt32

					if (desiredType == typeof(UInt32))
					{
						UInt32 output;
						return UInt32.TryParse(parameters, out output) ? output : defaultObject;
					}

					#endregion

					#region Int64

					if (desiredType == typeof(Int64))
					{
						Int64 output;
						return Int64.TryParse(parameters, out output) ? output : defaultObject;
					}

					#endregion
					#region UInt64

					if (desiredType == typeof(UInt64))
					{
						UInt64 output;
						return UInt64.TryParse(parameters, out output) ? output : defaultObject;
					}

					#endregion

					#region Single

					if (desiredType == typeof(Single))
					{
						Single output;
						return Single.TryParse(parameters, out output) ? output : defaultObject;
					}

					#endregion
					#region Double

					if (desiredType == typeof(Double))
					{
						Double output;
						return Double.TryParse(parameters, out output) ? output : defaultObject;
					}

					#endregion

					#region IPAddress

					if (desiredType == typeof(IHostAddress))
					{
						IHostAddress Default = defaultObject as IHostAddress;
						try
						{
							IHostAddress HostAddress = ObjectFactory.CreateHostAddress(parameters);
							return (Default.IpAddress.ToString() == HostAddress.IpAddress.ToString()) ? Default : HostAddress;
						}
						catch
						{
						}
						return defaultObject;
					}

					#endregion

					#region String

					if (desiredType == typeof(String))
						return parameters;

					#endregion

					//Units Of Measurement

					#region Angle				

					if (desiredType == typeof(IAngle))
					{
						IAngle nullConversion; ObjectFactory.TryParse("0DEGREES", out nullConversion);
						IAngle converted; ObjectFactory.TryParse(parameters, out converted);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}

					#endregion
					#region Area

					if (desiredType == typeof(IArea))
					{
						IArea nullConversion; ObjectFactory.TryParse("0SQUAREMETERS", out nullConversion);
						IArea converted; ObjectFactory.TryParse(parameters, out converted);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}

					#endregion
					#region Distance				

					if (desiredType == typeof(IDistance))
					{
						IDistance nullConversion; ObjectFactory.TryParse("0METERS", out nullConversion);
						IDistance converted; ObjectFactory.TryParse(parameters, out converted);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}

					#endregion
					#region Durations				

					if (desiredType == typeof(IDate))
					{
						IDate nullConversion = ObjectFactory.CreateDate("");
						IDate converted = ObjectFactory.CreateDate(parameters);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}
					if (desiredType == typeof(IDateTime))
					{
						IDateTime nullConversion = ObjectFactory.CreateDateTime("");
						IDateTime converted = ObjectFactory.CreateDateTime(parameters);
						return (converted.ToString() == nullConversion.ToSystemString()) ? defaultObject : converted;
					}
					if (desiredType == typeof(ITime))
					{
						ITime nullConversion = ObjectFactory.CreateTime("");
						ITime converted = ObjectFactory.CreateTime(parameters);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}
					if (desiredType == typeof(ITimeSpan))
					{
						ITimeSpan nullConversion = ObjectFactory.CreateTimeSpan("");
						ITimeSpan converted = ObjectFactory.CreateTimeSpan(parameters);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}

					#endregion
					#region Energy				

					if (desiredType == typeof(IEnergy))
					{
						IEnergy nullConversion; ObjectFactory.TryParse("0KILOJOULES", out nullConversion);
						IEnergy converted; ObjectFactory.TryParse(parameters, out converted);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}

					#endregion
					#region Mass				

					if (desiredType == typeof(IMass))
					{
						IMass nullConversion; ObjectFactory.TryParse("0KILOGRAMS", out nullConversion);
						IMass converted; ObjectFactory.TryParse(parameters, out converted);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}

					#endregion
					#region Power				

					if (desiredType == typeof(IPower))
					{
						IPower nullConversion; ObjectFactory.TryParse("0KILOWATTS", out nullConversion);
						IPower converted; ObjectFactory.TryParse(parameters, out converted);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}

					#endregion
					#region Pressure				

					if (desiredType == typeof(IPressure))
					{
						IPressure nullConversion; ObjectFactory.TryParse("0PASCALS", out nullConversion);
						IPressure converted; ObjectFactory.TryParse(parameters, out converted);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}

					#endregion
					#region Speed				

					if (desiredType == typeof(ISpeed))
					{
						ISpeed nullConversion; ObjectFactory.TryParse("0M/SEC", out nullConversion);
						ISpeed converted; ObjectFactory.TryParse(parameters, out converted);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}

					#endregion
					#region Temperature				

					if (desiredType == typeof(ITemperature))
					{
						ITemperature nullConversion; ObjectFactory.TryParse("0CELCIUS", out nullConversion);
						ITemperature converted; ObjectFactory.TryParse(parameters, out converted);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}

					#endregion
					#region Volume				

					if (desiredType == typeof(IVolume))
					{
						IVolume nullConversion; ObjectFactory.TryParse("0LITRES", out nullConversion);
						IVolume converted; ObjectFactory.TryParse(parameters, out converted);
						return (converted.ToString() == nullConversion.ToString()) ? defaultObject : converted;
					}

					#endregion

					//Colors

					#region XRGBColor

					if (desiredType == typeof(I24BitColor))
					{
						string[] split = parameters.Split(' ');

						byte red = 255;
						byte green = 255;
						byte blue = 255;

						I24BitColor Default = defaultObject as I24BitColor;

						if (split.Length < 3)
						{
							return Default;
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
							return Default;
						}
						catch (FormatException)
						{
							//Debug
							return Default;
						}
						I24BitColor output = ObjectFactory.CreateColor(red, green, blue).Get24BitColor();
						return output;
					}

					#endregion

				}
				catch (Exception e)
				{
					Debug.AddErrorMessage(e, "Error converting setting from string.");
				}
				return defaultObject;
			}

			internal static bool FindAndUpdateSetting(string command, string parameters)
			{
				try
				{
					#region Split Command

					string[] commandSplit = command.Split('.');

					#endregion

					#region Find and Modify the Setting.

					object TargetClass = Settings;
					PropertyInfo TargetProperty = typeof(SettingsLibrary).GetProperty("Settings", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Static);
					for (int i = 0; i < commandSplit.Length; i++)
					{
						#region Found a Matching Sub-Class, Move into it.

						if (i < commandSplit.Length - 1)
						{
							try
							{
								TargetProperty = TargetProperty.PropertyType.GetProperty(commandSplit[i],
									BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
								TargetClass = TargetProperty.GetValue(TargetClass);
							}
							catch (Exception e)
							{
								Debug.AddErrorMessage(e, "Setting Not Found: \"" + command + "\".");
								return false;
							}
							continue;
						}

						#endregion

						#region Convert the Paramters to an Object

						PropertyInfo thisProperty = TargetProperty.PropertyType.GetProperty(commandSplit[i], BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
						object valueToSet = ConvertParameterStringToObject(thisProperty.PropertyType, parameters, thisProperty.GetValue(TargetClass));

						#endregion

						#region Set the Field to the Converted Value

						thisProperty.SetValue(TargetClass, valueToSet);
						Debug.AddDetailMessage("Successfully Read Setting: \"" + command + "\".");
						return true;

						#endregion
					}

					#endregion

					#region Couldn't Find the Correct Setting.

					return false;

					#endregion
				}
				catch (Exception e)
				{
					Debug.AddErrorMessage(e, "Error in FindAndUpdateSetting");
					return false;
				}
			}

			public static bool LoadAll()
			{
				#region Settings Not Found on Disk

				if (!System.IO.File.Exists(@"./Settings.Dat")) return false;

				#endregion

				#region Load Settings File Contents

				SettingsFile.Load();

				#endregion

				#region Iterate over Contents, Update Settings

				try
				{
					for (int i = 0; i < SettingsLibrary.SettingsFile.Contents.Count; i++)
					{
						if (SettingsLibrary.SettingsFile.Contents[i].Command == "") continue;
						ICommandFileLine thisLine = SettingsLibrary.SettingsFile.Contents[i];

						string command = thisLine.Command;
						List<string> parameters = new List<string>();
						for (int j = 0; j < thisLine.NumberOfParameters; j++)
							parameters.Add(thisLine.GetParameter(j));
						bool Failed = !FindAndUpdateSetting(command, string.Join(" ", parameters));
						if (Failed)
						{
							Debug.AddWarningMessage("Setting Not Recognised or Failed Conversion: \"" + command + "\".");
						}
					}
					return true;
				}
				catch (Exception)
				{
					return false;
				}

				#endregion
			}

			private static void FindContents(List<String> OutputStringList, PropertyInfo CurrentProperty, object CurrentObject, string CurrentName)
			{
				PropertyInfo[] ClassProperties = CurrentProperty.PropertyType.GetProperties();
				List<object> ClassObjects = new List<object>();
				foreach (PropertyInfo thisPropertyInfo in ClassProperties.Where(x => x.PropertyType.IsNestedPublic))
				{
					ClassObjects.Add(thisPropertyInfo.GetValue(CurrentObject));
					FindContents(OutputStringList, thisPropertyInfo, thisPropertyInfo.GetValue(CurrentObject), CurrentName + (CurrentName.Length > 0 ? "." : "") + thisPropertyInfo.Name);
				}
				foreach (PropertyInfo thisPropertyInfo in ClassProperties.Where(x => !x.PropertyType.IsNestedPublic))
				{
					OutputStringList.Add((CurrentName + "." + thisPropertyInfo.Name).ResizeOnRight(64, ' ') + "\t" + thisPropertyInfo.GetValue(CurrentObject).ToString());
				}
				return;
			}
			public static bool SaveAll()
			{
				List<String> OutputList = new List<string>();
				PropertyInfo SettingsProperties = typeof(SettingsLibrary).GetProperty("Settings", BindingFlags.Public | BindingFlags.Static);
				FindContents(OutputList, SettingsProperties, Settings, "");
				File.WriteAllLines(@"./Settings.DAT", OutputList);
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
					//		for (int i = 0; i < stream.Distance; i++)
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
}
