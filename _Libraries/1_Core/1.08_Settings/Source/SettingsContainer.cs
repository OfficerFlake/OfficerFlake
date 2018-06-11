using System;
using System.ComponentModel;
using System.Net;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	public static partial class SettingsLibrary
	{
		public class _Settings : INotifyPropertyChanged
		{
			public event PropertyChangedEventHandler PropertyChanged;

			public class _YSFlight : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public String Directory { get; set; } = "C:/Games/YSFLIGHT20120701/";
			}
			public readonly _YSFlight YSFlight = new _YSFlight();

			public class _Options : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				#region Can Join Server?

				public Boolean ConnectionLocked { get; set; } = false;

				#endregion

				#region Netcode Version

				public UInt32 YSFNetcodeVersion { get; set; } = 20110207;

				public Boolean AllowOYSExtendedPackets { get; set; } = true;
				public UInt32 OYSNetcodeVersion { get; set; } = 20150207;

				#endregion

				#region AutoOPLocalIPs? [DEPRECATED]

				//public Boolean AllowOPs { get; set; } = true;
				//public Boolean AutoOPLocalIP { get; set; } = true;

				#endregion

				#region SendLoginWelcomeMessage

				public Boolean SendWelcomeMessageOnJoinServer { get; set; } = true;

				#endregion

				#region Notify Users On Join

				public Boolean NotifyServerWhenBotConnects { get; set; } = true;

				#endregion

				#region Weapons

				public Boolean AllowMissiles { get; set; } = true;
				public Boolean AllowUnguidedWeapons { get; set; } = true;

				#endregion

				#region Send Map Name

				public String FieldName { get; set; } = "HAWAII";

				#endregion

				#region External Aircraft View

				public Boolean AllowExternalAirView { get; set; } = false;

				#endregion

				#region Radar Altitude

				public IDistance RadarBaseAltitude { get; set; } = 0.Meters();

				#endregion

				#region User List

				public Boolean AllowListUsers { get; set; } = true;

				#endregion

				#region Send Aircraft List

				public UInt32 AircraftListPacketSize { get; set; } = 32;
				public Boolean SendAircraftListLoadPercentNotification { get; set; } = true;

				#endregion

				#region Send Grounds List

				public Boolean LoadGrounds { get; set; } = true;
				public Boolean SendGroundObjectListLoadPercentNotification { get; set; } = true;

				#endregion

				#region Login Completed

				public Boolean SendLoginCompleteNotification { get; set; } = true;
				public Boolean SendWelcomeMessageOnLoginComplete { get; set; } = true;
				public Boolean KickBotsOnLoginComplete { get; set; } = true;

				#endregion
			}
			public readonly _Options Options = new _Options();

			public class _Server : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				#region Listening Ports

				public class _ListeningPorts : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public UInt32 TCP = 7915;
					public UInt32 UDP = 7964;
				}
				public readonly _ListeningPorts ListeningPorts = new _ListeningPorts();

				#endregion

				#region Proxy Server

				public class _ProxyServer : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public UInt32 DestinationPort = 7914;
					public IPAddress DestinationAddress = IPAddress.Parse("127.0.0.1");
				}
				public readonly _ProxyServer ProxyServer = new _ProxyServer();

				#endregion

				public IDuration RestartTimer = 120.Minutes();
			}
			public readonly _Server Server = new _Server();

			public class _Flight : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				#region Join Flight

				public class _Join : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Boolean Lock = false;
					public Boolean Notification = true;
					public Boolean UseWheelChocks = true;
				}
				public readonly _Join Join = new _Join();

				#endregion

				#region Flight
				public Boolean Smoke = true;
				public Boolean MidAirRefueling = true;

				#endregion

				#region Leave Flight

				public class _Leave : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Boolean Notification = true;
				}
				public readonly _Leave Leave = new _Leave();

				#endregion
			}
			public readonly _Flight Flight = new _Flight();

			public class _Colors : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public class _Time : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public class _Dawn : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public ITime Starts = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 05, 0, 0).ToTime();
						public ITime Ends =   new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 07, 0, 0).ToTime();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}
							public readonly _Sky Sky = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
							public readonly _Horizon Horizon = new _Horizon();
						}
						public readonly _Color Color = new _Color();
					}
					public readonly _Dawn Dawn = new _Dawn();

					public class _Day : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public ITime Starts = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 06, 0, 0).ToTime();
						public ITime Ends =   new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0).ToTime();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}
							public readonly _Sky Sky = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
							public readonly _Horizon Horizon = new _Horizon();
						}
						public readonly _Color Color = new _Color();
					}
					public readonly _Day Day = new _Day();

					public class _Dusk : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public ITime Starts = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0).ToTime();
						public ITime Ends =   new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 0, 0).ToTime();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}
							public readonly _Sky Sky = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
							public readonly _Horizon Horizon = new _Horizon();
						}
						public readonly _Color Color = new _Color();
					}
					public readonly _Dusk Dusk = new _Dusk();

					public class _Night : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public ITime Starts = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0).ToTime();
						public ITime Ends =   new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 06, 0, 0).ToTime();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public Double NightDarkeningFactor = 0.12;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}
							public readonly _Sky Sky = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
							public readonly _Horizon Horizon = new _Horizon();
						}
						public readonly _Color Color = new _Color();
					}
					public readonly _Night Night = new _Night();
				}
				public readonly _Time Time = new _Time();

				public class _Altitude : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Double Opacity = 1.0;

					public class _Floor : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public class _Range : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public IDistance Starts = 0.Feet();
							public IDistance Ends = 50000.Feet();
						}
						public readonly _Range Range = new _Range();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}
							public readonly _Sky Sky = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
							public readonly _Horizon Horizon = new _Horizon();
						}
						public readonly _Color Color = new _Color();
					}
					public readonly _Day Day = new _Day();

					public class _Ceiling : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public class _Range : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public IDistance Starts = 30000.Feet();
							public IDistance Ends = 100000.Feet();
						}
						public readonly _Range Range = new _Range();

						public class _Colors : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}
							public readonly _Sky Sky = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
							public readonly _Horizon Horizon = new _Horizon();
						}
						public readonly _Colors Colors = new _Colors();
					}
					public readonly _Ceiling Ceiling = new _Ceiling();

					public class _Space : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public class _Range : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public IDistance Starts = 50000.Feet();
							public IDistance Ends = 120000.Feet();
						}
						public readonly _Range Range = new _Range();

						public class _Colors : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}
							public readonly _Sky Sky = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
							public readonly _Horizon Horizon = new _Horizon();

						}
						public readonly _Colors Colors = new _Colors();
					}
					public readonly _Space Space = new _Space();
				}
				public readonly _Altitude Altitude = new _Altitude();

				public class _Defaults : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public class _Sky : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Double Opacity = 0.0;
						public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
					}
					public readonly _Sky Sky = new _Sky();

					public class _Horizon : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
					}
					public readonly _Horizon Horizon = new _Horizon();

					public class _Ground : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Double Opacity = 0.0;
						public IColor Color = ObjectFactory.CreateColor(0, 0, 160);
					}
					public readonly _Ground Ground = new _Ground();

					public class _Fog : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public IColor Color = ObjectFactory.CreateColor(160, 160, 160);
					}
					public readonly _Fog Fog = new _Fog();
				}
				public readonly _Defaults Defaults = new _Defaults();
			}
			public readonly _Colors Colors = new _Colors();

			public class _Day : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public ITime Duration = 24.Minutes().ToTime();
			}
			public readonly _Day Day = new _Day();

			public class _Time : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public ITime Current = 12.Hours().ToTime();
				public ITime Default = 12.Hours().ToTime();
			}
			public readonly _Time Time = new _Time();

			public class _Weather : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public class _ForceObedience : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Boolean LandEverywhere = true;
					public Boolean Collisions = false;
					public Boolean BlackOut = false;
					public Boolean Fog = false;
				}
				public readonly _ForceObedience ForceObedience = new _ForceObedience();

				public class _Enable : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Boolean LandEverywhere = true;
					public Boolean Collisions = false;
					public Boolean BlackOut = false;
					public Boolean Fog = true;
				}
				public readonly _Enable Enable = new _Enable();

				public class _Wind : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public ISpeed WindX = 0.MetersPerSecond();
					public ISpeed WindY = 0.MetersPerSecond();
					public ISpeed WindZ = 0.MetersPerSecond();
				}
				public readonly _Wind Wind = new _Wind();

				public IDistance Visibility = 0.Meters();
			}
			public readonly _Weather Weather = new _Weather();

			public class _OwnerInformation : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public String PreferredName = "???";
				public String ContactEmail = "???";
			}
			public readonly _OwnerInformation OwnerInformation = new _OwnerInformation();

			public class _IRC : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				#region UseIRC?
				public Boolean Enabled = false;
				#endregion
				#region IRC Server
				public class _Server : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public IPAddress Address = IPAddress.Parse("127.0.0.1");
					public UInt32 Port = 6667;

					public String Channel = "None";
				}
				public readonly _Server Server = new _Server();
				#endregion
				#region OpenYS Nickname
				public String Nickname = "OpenYS";

				public class _Authentication : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Boolean Enabled = false;
					public String Service = "NickServ";
					public String Password = "PASSWORD";
				}
				public readonly _Authentication Authentication = new _Authentication();
				#endregion
				#region Messaging Control
				public class _Messages : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public class _IRCtoOYS : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Boolean Enabled = true;
						public Boolean StripFormatting = false;
						public Boolean ShowEvents = true;
						public String MessageColor = "&d";
					}
					public readonly _IRCtoOYS IRCtoOYS = new _IRCtoOYS();

					public class _OYStoIRC : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Boolean Enabled = true;
						public Boolean StripFormatting = false;
						public Boolean ShowEvents = true;
						public String MessageColor = "&0";
					}
					public readonly _OYStoIRC OYStoIRC = new _OYStoIRC();
				}
				public readonly _Messages Messages = new _Messages();
				#endregion
			}
			public readonly _IRC IRC = new _IRC();

			public class _UserInterface : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public class _Console : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public class _ShowMessages : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Boolean Console { get; set; } = true;
						public Boolean User { get; set; } = true;
					}
					public readonly _ShowMessages ShowMessages = new _ShowMessages();

					public class _ShowDebug : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Boolean Summary { get; set; } = true;
						public Boolean Detail { get; set; } = false;
						public Boolean Warning { get; set; } = true;
						public Boolean Error { get; set; } = true;
						public Boolean Crash { get; set; } = true;
					}
					public readonly _ShowDebug ShowDebug = new _ShowDebug();
				}
				public readonly _Console Console = new _Console();

			}
			public readonly _UserInterface UserInterface = new _UserInterface();
		}
		public static _Settings Settings { get; }

		static SettingsLibrary()
		{
			Settings = new _Settings();
		}
	}
}
