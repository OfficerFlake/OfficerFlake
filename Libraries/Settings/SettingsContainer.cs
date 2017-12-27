﻿using System;
using System.Net;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries
{
	public static partial class Settings
	{
		public static class YSFlight
		{
			public static String Directory = "C:/Program Files/YSFLIGHT.COM/YSFLIGHT/";
		}

		public static class Options
		{
			#region Can Join Server?
			public static Boolean ConnectionLocked = false;
			#endregion
			#region Netcode Version
			public static UInt32 YSFNetcodeVersion = 20110207;

			public static Boolean AllowOYSExtendedPackets = true;
			public static UInt32 OYSNetcodeVersion = 20150207;
			#endregion
			#region AutoOPLocalIPs? [DEPRECATED]
			//public static Boolean AllowOPs = true;
			//public static Boolean AutoOPLocalIP = true;
			#endregion
			#region SendLoginWelcomeMessage
			public static Boolean SendWelcomeMessageOnJoinServer = true;
			#endregion
			#region Notify Users On Join
			public static Boolean NotifyServerWhenBotConnects = true;
			#endregion

			#region Weapons
			public static Boolean AllowMissiles = true;
			public static Boolean AllowUnguided = true;
			#endregion
			#region Send Map Name
			public static String FieldName = "HAWAII";
			#endregion
			#region External Aircraft View
			public static Boolean AllowExternalAirView = false;
			#endregion
			#region Radar Altitude
			public static IDistance RadarBaseAltitude = 0.Meters();
			#endregion
			#region User List
			public static Boolean AllowListUsers = true;
			#endregion
			#region Send Aircraft List
			public static UInt32 AircraftListPacketSize = 32;
			public static Boolean SendAircraftListLoadPercentNotification = true;
			#endregion
			#region Send Grounds List
			public static Boolean LoadGrounds = true;
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

			public static Duration RestartTimer = 120.Minutes();
		}

		public static class Flight
		{
			#region Join Flight
			public static Boolean JoinLocked = false;
			public static Boolean JoinFlightNotification = true;
			public static Boolean SpawnChocks = true;
			#endregion

			#region Flight
			public static Boolean EnableSmoke = true;
			public static Boolean EnableMidAirRefueling = true;
			#endregion

			#region Leave Flight
			public static Boolean LeaveFlightNotification = true;
			#endregion
		}

		public static class Colors
		{
			public static class Basic
			{
				public static Boolean OverrideSkyColor = false;
				public static I24BitColor SkyColor = new XRGBColor(180, 184, 186);

				public static Boolean OverrideFogColor = false;
				public static I24BitColor FogColor = new XRGBColor(120, 140, 160);

				public static Boolean OverrideGndColor = false;
				public static I24BitColor GndColor = new XRGBColor(94, 117, 109);
			}

			public static class Atmosphere
			{
				public static I24BitColor MaxAltitudeSkyColor = new XRGBColor(48, 0, 96);
				public static I24BitColor MaxAltitudeHorizonColor = new XRGBColor(23, 106, 189);

				public static I24BitColor NoAtmosphereSkyColor = new XRGBColor(0, 0, 0);
				public static I24BitColor NoAtmosphereHorizonColor = new XRGBColor(0, 0, 5);

				public static I24BitColor WhiteFogColor = new XRGBColor(160, 160, 160);

				public static class Fading
				{
					public static Distance MinimumAltitude = 12000.Meters();
					public static Distance MaximumAltitude = 30000.Meters();
				}
			}

			public static class Time
			{
				public static I24BitColor DawnSkyColor = new XRGBColor(200, 85, 200);
				public static I24BitColor DawnHorizonColor = new XRGBColor(240, 200, 90);

				public static I24BitColor DaySkyColor = new XRGBColor(23, 106, 189);
				public static I24BitColor DayHorizonColor = new XRGBColor(120, 140, 160);

				public static I24BitColor DuskSkyColor = new XRGBColor(128, 0, 32);
				public static I24BitColor DuskHorizonColor = new XRGBColor(255, 160, 0);

				public static I24BitColor NightSkyColor = new XRGBColor(48, 0, 96);
				public static I24BitColor NightHorizonColor = new XRGBColor(48, 0, 96);

				//How much should the colors ber darkened by if the time is night?
				public static Double NightDarkeningFactor = 0.12;
			}

			//How much should these colors blend with the default field colors?
			public static Double OverallBlendFactor = 1.0;
		}

		public static class Time
		{
			public static ITime DayLength = new OYSTime(0.Hours(),24.Minutes(),0.Seconds());
			public static ITime CurrentTime = new OYSTime(12.Hours(), 0.Minutes(), 0.Seconds());
		}

		public static class Weather
		{
			#region Weather Packet
			public static class Control
			{
				public static Boolean LandEverywhere = true;
				public static Boolean Collisions = false;
				public static Boolean BlackOut = false;
				public static Boolean Fog = false;
			}
			public static class Enable
			{
				public static Boolean LandEverywhere = true;
				public static Boolean Collisions = false;
				public static Boolean BlackOut = false;
				public static Boolean Fog = true;
			}

			public static ISpeed WindX = 0.MetersPerSecond();
			public static ISpeed WindY = 0.MetersPerSecond();
			public static ISpeed WindZ = 0.MetersPerSecond();
			public static Distance Fog = 0.Meters();
			#endregion
		}

		public static class OwnerInformation
		{
			public static String PreferredName = "???";
			public static String ContactEmail = "???";
		}

		public static class IRC
		{
			#region UseIRC?
			public static Boolean Enabled = false;
			#endregion
			#region IRC Server
			public static IPAddress HostIPAddress = IPAddress.Parse("127.0.0.1");
			public static UInt32 HostPort = 6667;

			public static String Channel = "None";
			#endregion
			#region OpenYS Nickname
			public static String Nickname = "OpenYS";

			public static Boolean AuthenticateWithARegisteredNickNameService = false;
			public static String RegisteredNickNameServiceName = "NickServ";
			public static String RegistreredNickNameServicePass = "PASSWORD";
			#endregion
			#region Messaging Control
			public static Boolean ForwardIRCMessagesToOYS = true;
			public static Boolean IRCToOYSStripFormatting = false;
			public static Boolean ShowIRCEventsOnOYS = true;
			public static String IRCToOYSMessagesColor = "&d";
			
			public static Boolean ForwardOYSMessagesToIRC = true;
			public static Boolean OYSToIRCStripFormatting = false;
			public static Boolean ShowOYSEventsOnIRC = true;
			public static String OYSToIRCMessagesColor = "&0";

			public static Boolean ShowOYSEventsOInIRC = true;
			#endregion
		}
	}
}
