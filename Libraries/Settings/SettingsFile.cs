using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Com.OfficerFlake.Libraries.IO;

namespace Com.OfficerFlake.Libraries
{
	public static partial class Settings
	{
		public class SettingFile : CommandFile
		{
			internal SettingFile(string filename) : base(filename)
			{

			}
		}
		public static SettingFile SettingsFile = new SettingFile(@"./Settings.Dat");
	}
}
