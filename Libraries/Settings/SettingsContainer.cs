using System;
using System.ComponentModel;
using System.Net;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	public static partial class SettingsLibrary
	{
		public partial class _Settings : INotifyPropertyChanged
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
				public Boolean AllowUnguided { get; set; } = true;

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

					public static UInt32 TCP = 7915;
					public static UInt32 UDP = 7964;
				}

				#endregion

				#region Proxy Server

				public class _ProxyServer : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public static UInt32 DestinationPort = 7915;
					public static IPAddress DestinationAddress = IPAddress.Parse("127.0.0.1");
				}

				#endregion

				public static IDuration RestartTimer = 120.Minutes();
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

				#endregion
			}

			public class _Colors : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public class _Time : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public class _Dawn : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public ITime Starts = new System.DateTime(0, 0, 0, 05, 0, 0).ToTime();
						public ITime Ends =   new System.DateTime(0, 0, 0, 07, 0, 0).ToTime();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
						}
					}
					public class _Day : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public ITime Starts = new System.DateTime(0, 0, 0, 06, 0, 0).ToTime();
						public ITime Ends =   new System.DateTime(0, 0, 0, 18, 0, 0).ToTime();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
						}
					}
					public class _Dusk : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public ITime Starts = new System.DateTime(0, 0, 0, 17, 0, 0).ToTime();
						public ITime Ends =   new System.DateTime(0, 0, 0, 19, 0, 0).ToTime();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
						}
					}
					public class _Night : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public ITime Starts = new System.DateTime(0, 0, 0, 18, 0, 0).ToTime();
						public ITime Ends =   new System.DateTime(0, 0, 0, 06, 0, 0).ToTime();

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
							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
						}
					}
				}
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

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
						}
					}
					public class _Ceiling : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public class _Range : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public IDistance Starts = 30000.Feet();
							public IDistance Ends = 100000.Feet();
						}

						public class _Colors : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
						}
					}
					public class _Space : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public class _Range : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public IDistance Starts = 50000.Feet();
							public IDistance Ends = 120000.Feet();
						}
						public class _Colors : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
							}
							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity = 0.0;
								public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
							}
							
						}
					}
				}
				public class _Defaults : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public class _Sky : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Double Opacity = 0.0;
						public IColor Color = ObjectFactory.CreateColor(180, 184, 186);
					}

					public class _Horizon : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public IColor Color = ObjectFactory.CreateColor(120, 140, 160);
					}

					public class _Ground : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Double Opacity = 0.0;
						public IColor Color = ObjectFactory.CreateColor(0, 0, 160);
					}

					public class _Fog : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public IColor Color = ObjectFactory.CreateColor(160, 160, 160);
					}
				}
			}

			public class _Day : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public ITime Duration = 24.Minutes().ToTime();
			}
			public class _Time : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public ITime Current = 12.Hours().ToTime();
				public ITime Default = 12.Hours().ToTime();
			}

			public class _Weather : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public class ForceObedience : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Boolean LandEverywhere = true;
					public Boolean Collisions = false;
					public Boolean BlackOut = false;
					public Boolean Fog = false;
				}
				public class Enable : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Boolean LandEverywhere = true;
					public Boolean Collisions = false;
					public Boolean BlackOut = false;
					public Boolean Fog = true;
				}

				public class _Wind : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public ISpeed WindX = 0.MetersPerSecond();
					public ISpeed WindY = 0.MetersPerSecond();
					public ISpeed WindZ = 0.MetersPerSecond();
				}
				public IDistance Visibility = 0.Meters();
			}

			public class OwnerInformation : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public String PreferredName = "???";
				public String ContactEmail = "???";
			}

			public class IRC : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				#region UseIRC?
				public static Boolean Enabled = false;
				#endregion
				#region IRC Server
				public class Server : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public static IPAddress Address = IPAddress.Parse("127.0.0.1");
					public static UInt32 Port = 6667;

					public static String Channel = "None";
				}
				#endregion
				#region OpenYS Nickname
				public static String Nickname = "OpenYS";

				public class _Authentication : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public static Boolean Enabled = false;
					public static String Service = "NickServ";
					public static String Password = "PASSWORD";
				}
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
					public class _OYStoIRC : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public static Boolean Enabled = true;
						public static Boolean StripFormatting = false;
						public static Boolean ShowEvents = true;
						public static String MessageColor = "&0";
					}
				}
				#endregion
			}

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
					public _ShowMessages ShowMessages = new _ShowMessages();

					public class _ShowDebug : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Boolean Summary { get; set; } = false;
						public Boolean Detail { get; set; } = false;
						public Boolean Warning { get; set; } = true;
						public Boolean Error { get; set; } = true;
						public Boolean Crash { get; set; } = true;
					}
					public _ShowDebug ShowDebug = new _ShowDebug();
				}
				public readonly _Console Console = new _Console();

			}
			public readonly _UserInterface UserInterface = new _UserInterface();
		}
		public static _Settings Settings { get; set; } = new _Settings();

		static SettingsLibrary()
		{
			Settings = new _Settings();
		}
	}
}
