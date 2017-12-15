using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.IO;

using Com.OfficerFlake.Libraries.Color;

namespace Com.OfficerFlake.Libraries
{
	public static partial class Settings
	{
		public static class YSFlight
		{
			public static string Directory = "C:/Program Files/YSFLIGHT.COM/YSFLIGHT/";
		}

		public static class Login {
			#region Can Join Server?
			public static Boolean ConnectionLocked = false;
			#endregion

			#region Netcode Version
			public static UInt32 YSFNetcodeVersion = 20110207;
			public static UInt32 OYSNetcodeVersion = 20150207;
			#endregion
			#region AutoOPLocalIPs? [DEPRECATED]
			//public static Boolean AutoOPLocalIP = true;
			#endregion
			#region SendLoginWelcomeMessage
			public static Boolean SendWelcomeMessageOnJoinServer = true;
			#endregion
			#region Notify Users On Join
			public static Boolean NotifyServerWhenBotConnects = true;
			#endregion

			#region Send Map Name
			public static String FieldName = "HAWAII";
			#endregion
			#region Send Aircraft List
			public static UInt32 AircraftListPacketSize = 32;
			public static Boolean SendAircraftListLoadPercentNotification = true;
			#endregion
			#region Send Grounds List
			public static Boolean SendGroundObjectListLoadPercentNotification = true;
			#endregion

			#region Login Completed
			public static Boolean SendLoginCompleteNotification = true;
			public static Boolean SendWelcomeMessageOnLoginComplete = true;
			public static Boolean KickBotsOnLoginComplete = true;
			#endregion
		}

		public static class Server
		{
			#region Listening Ports
			public static UInt32 ListenPortTCP = 7915;
			public static UInt32 ListenPortUDP = 7964;
			#endregion
			#region Proxy Server
			public static UInt32 ProxyRedirectPort = 7915;
			public static IPAddress ProxyRedirectAddress = IPAddress.Parse("127.0.0.1");
			#endregion

			public static int RestartTimer = 120;
		}

		public static class Flight
		{
			#region Join Flight
			public static bool JoinLocked = false;
			public static bool JoinFlightNotification = true;
			public static bool SpawnChocks = true;
			#endregion

			#region Flight
			public static bool EnableSmoke = true;
			public static bool EnableMidAirRefueling = true;
			#endregion

			#region Leave Flight
			public static bool LeaveFlightNotification = true;
			#endregion
		}

		public static class Weather
		{
			#region Time
			public static int DayLength = 0;
			public static uint Time = 1200;
			#endregion

			#region Weather Packet
			public static float WindX = 0;
			public static float WindY = 0;
			public static float WindZ = 0;
			public static float Fog = 20000;
			#endregion

			public static class Updates
			{
				public static bool EnableVariableWeather = false;

				#region Colors
				public static bool OverrideSkyColor = false;
				public static XRGBColor SkyColor = new XRGBColor(180, 184, 186);

				public static bool OverrideFogColor = false;
				public static XRGBColor FogColor = new XRGBColor(120, 140, 160);

				public static bool OverrideGndColor = false;
				public static XRGBColor GndColor = new XRGBColor(94, 117, 109);
				#endregion

				public static class EnvironmentColors
				{
					public static XRGBColor NightSkyColor = new XRGBColor(48, 0, 96);
					public static XRGBColor NightHorizonColor = new XRGBColor(48, 0, 96);

					public static XRGBColor DawnSkyColor = new XRGBColor(200, 85, 200);
					public static XRGBColor DawnHorizonColor = new XRGBColor(240, 200, 90);

					public static XRGBColor DaySkyColor = new XRGBColor(23, 106, 189);
					public static XRGBColor DayHorizonColor = new XRGBColor(120, 140, 160);

					public static XRGBColor DuskSkyColor = new XRGBColor(128, 0, 32);
					public static XRGBColor DuskHorizonColor = new XRGBColor(255, 160, 0);

					public static XRGBColor MaxAltitudeSkyColor = new XRGBColor(48, 0, 96);
					public static XRGBColor MaxAltitudeHorizonColor = new XRGBColor(23, 106, 189);

					public static XRGBColor NoAtmosphereSkyColor = new XRGBColor(0, 0, 0);
					public static XRGBColor NoAtmosphereHorizonColor = new XRGBColor(0, 0, 5);

					public static XRGBColor WhiteFogColor = new XRGBColor(160, 160, 160);

					public static double OverallBlendFactor = 1.0;
					public static double NightColorFactor = 0.12;


				}

				public static class AtmosphericFading
				{
					public static double MinimumAltitudeInMeters = 12000;
					public static double MaximumAltitudeInMeters = 30000;
				}

				public static class ChangeLimitAbsolute
				{
					public static float WindX = 10;
					public static float WindY = 10;
					public static float WindZ = 10;
					public static float Fog = 400;
				}

				public static class AccelerationLimit
				{
					public static float WindX = 5;
					public static float WindY = 5;
					public static float WindZ = 5;
					public static float Fog = 1000;
				}

				public static int TurbulencePercent = 50;
			}
		}

		public static class Weapons
		{
			public static bool Missiles = true;
			public static bool Unguided = true;
		}

		public static class Options
		{
			public static bool NoExternalAirView = false;
			public static bool AllowOYSFramework = true;
			public static bool AllowGrounds = true;
			public static bool AllowOPs = true;
			public static bool AllowListUsers = true;
			public static uint RadarBaseAltitude = 0;
			public static string UsernameDistance = "TRUE";
			public static string ConsoleName = "OpenYS Console";
			public static string SchedulerName = "OpenYS Scheduler";
			public static string OwnerName = "???";
			public static string OwnerEmail = "???";
			public static string ServerName = "OpenYS Server";

			public static class Control
			{
				public static bool LandEverywhere = false;
				public static bool Collisions = false;
				public static bool BlackOut = false;
				public static bool Unknown = false;
			}

			public static class Enable
			{
				public static bool LandEverywhere = true;
				public static bool Collisions = false;
				public static bool BlackOut = false;
				public static bool Fog = true;
			}

		}

		public static class Novelties
		{
			public static bool LaunchBombsFromGuns = false;
		}

		public static class Administration
		{
			public static string AdminPassword = "";
		}

		public static class IRC
		{
			public static bool Enabled = false;
			public static string Name = "OpenYS";
			public static IPAddress HostIP = IPAddress.Parse("127.0.0.1");
			public static int HostPort = 6667;
			public static string Channels = "None";
			public static bool ForwardIRCToServer = true;
			public static bool ForwardsServerToIRC = true;
			public static bool ShowEvents = true;
			public static bool RegisteredNick = false;
			public static string RegistrationServiceName = "NickServ";
			public static string RegistrationAuthPass = "PASSWORD";
			public static string IRCMessagesColor = "&d";
			public static bool IRCToServerStripFormatting = false;
			public static bool ServerToIRCStripFormatting = false;
			public static int DelayTime = 1000;
			public static int BotCount = 1;
		}

		public static class YSFHQ
		{
			public static string Username = "";
			public static string EncryptedPassword = "";
		}
	}
}
