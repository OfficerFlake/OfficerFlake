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

				public String Directory { get; set; } = "C:/Program Files/YSFLIGHT.COM/YSFlight/";
			}
			public _YSFlight YSFlight { get; } = new _YSFlight();

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
			public _Options Options { get; } = new _Options();

			public class _Server : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				#region Listening Ports

				public class _ListeningPorts : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public UInt32 TCP { get; set; } = 7915;
					public UInt32 UDP { get; set; } = 7964;
				}
				public  _ListeningPorts ListeningPorts { get; } = new _ListeningPorts();

				#endregion

				#region Proxy Server

				public class _ProxyServer : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public UInt32 DestinationPort { get; set; } = 7914;
					public IHostAddress DestinationAddress { get; set; } = ObjectFactory.CreateHostAddress(IPAddress.None);
				}
				public _ProxyServer ProxyServer { get; } = new _ProxyServer();

				#endregion

				public IDuration RestartTimer { get; set; } = 120.Minutes();
			}
			public _Server Server { get; } = new _Server();

			public class _Flight : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				#region Join Flight

				public class _Join : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Boolean Lock { get; set; } = false;
					public Boolean Notification { get; set; } = true;
					public Boolean UseWheelChocks { get; set; } = true;
				}
				public _Join Join { get; } = new _Join();

				#endregion

				#region Flight
				public Boolean Smoke { get; set; } = true;
				public Boolean MidAirRefueling { get; set; } = true;

				#endregion

				#region Leave Flight

				public class _Leave : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Boolean Notification { get; set; } = true;
				}
				public _Leave Leave { get; } = new _Leave();

				#endregion
			}
			public _Flight Flight { get; } = new _Flight();

			public class _Color : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public class _Time : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Double Opacity { get; set; } = 1.0;

					public class _Dawn : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public ITime Starts { get; set; } = ObjectFactory.CreateTime("05:00:00");
						public ITime Ends { get; set; } = ObjectFactory.CreateTime("08:00:00");

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(180, 184, 186).Get24BitColor();
							}
							public _Sky Sky { get; } = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(120, 140, 160).Get24BitColor();
							}
							public _Horizon Horizon { get; } = new _Horizon();
						}
						public _Color Color { get; } = new _Color();
					}
					public _Dawn Dawn { get; } = new _Dawn();

					public class _Day : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public ITime Starts { get; set; } = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 06, 0, 0).ToTime();
						public ITime Ends { get; set; } = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0).ToTime();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(180, 184, 186).Get24BitColor();
							}
							public _Sky Sky { get; } = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(120, 140, 160).Get24BitColor();
							}
							public _Horizon Horizon { get; } = new _Horizon();
						}
						public _Color Color { get; } = new _Color();
					}
					public _Day Day { get; } = new _Day();

					public class _Dusk : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public ITime Starts { get; set; } = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0).ToTime();
						public ITime Ends { get; set; } = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 0, 0).ToTime();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(180, 184, 186).Get24BitColor();
							}
							public _Sky Sky { get; } = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(120, 140, 160).Get24BitColor();
							}
							public _Horizon Horizon { get; } = new _Horizon();
						}
						public _Color Color { get; } = new _Color();
					}
					public _Dusk Dusk { get; } = new _Dusk();

					public class _Night : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public ITime Starts { get; set; } = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0).ToTime();
						public ITime Ends { get; set; } = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 06, 0, 0).ToTime();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public Double NightDarkeningFactor { get; set; } = 0.12;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(180, 184, 186).Get24BitColor();
							}
							public _Sky Sky { get; } = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(120, 140, 160).Get24BitColor();
							}
							public _Horizon Horizon { get; } = new _Horizon();
						}
						public _Color Color { get; } = new _Color();
					}
					public _Night Night { get; } = new _Night();
				}
				public _Time Time { get; } = new _Time();

				public class _Altitude : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Double Opacity { get; set; } = 1.0;

					public class _Floor : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public class _Range : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public IDistance Ends { get; set; } = 50000.Feet();
						}
						public _Range Range { get; } = new _Range();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(180, 184, 186).Get24BitColor();
							}
							public _Sky Sky { get; } = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(120, 140, 160).Get24BitColor();
							}
							public _Horizon Horizon { get; } = new _Horizon();
						}
						public _Color Color { get; } = new _Color();
					}
					public _Floor Floor { get; } = new _Floor();

					public class _Ceiling : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public class _Range : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public IDistance Starts { get; set; } = 30000.Feet();
							public IDistance Ends { get; set; } = 100000.Feet();
						}
						public _Range Range { get; } = new _Range();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(180, 184, 186).Get24BitColor();
							}
							public _Sky Sky { get; } = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(120, 140, 160).Get24BitColor();
							}
							public _Horizon Horizon { get; } = new _Horizon();
						}
						public _Color Color { get; } = new _Color();
					}
					public _Ceiling Ceiling { get; } = new _Ceiling();

					public class _Space : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public class _Range : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public IDistance Starts { get; set; } = 50000.Feet();
						}
						public _Range Range { get; } = new _Range();

						public class _Color : INotifyPropertyChanged
						{
							public event PropertyChangedEventHandler PropertyChanged;

							public class _Sky : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(180, 184, 186).Get24BitColor();
							}
							public _Sky Sky { get; } = new _Sky();

							public class _Horizon : INotifyPropertyChanged
							{
								public event PropertyChangedEventHandler PropertyChanged;

								public Double Opacity { get; set; } = 0.0;
								public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(120, 140, 160).Get24BitColor();
							}
							public _Horizon Horizon { get; } = new _Horizon();

						}
						public _Color Color { get; } = new _Color();
					}
					public _Space Space { get; } = new _Space();
				}
				public _Altitude Altitude { get; } = new _Altitude();

				public class _Defaults : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public class _Sky : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Double Opacity { get; set; } = 0.0;
						public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(180, 184, 186).Get24BitColor();
					}
					public _Sky Sky { get; } = new _Sky();

					public class _Horizon : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Double Opacity { get; set; } = 0.0;
						public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(120, 140, 160).Get24BitColor();
					}
					public _Horizon Horizon { get; } = new _Horizon();

					public class _Ground : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Double Opacity { get; set; } = 0.0;
						public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(0, 0, 160).Get24BitColor();
					}
					public _Ground Ground { get; } = new _Ground();

					public class _Fog : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Double Opacity { get; set; } = 0.0;
						public I24BitColor Color { get; set; } = ObjectFactory.CreateColor(160, 160, 160).Get24BitColor();
					}
					public _Fog Fog { get; } = new _Fog();
				}
				public  _Defaults Defaults { get; } = new _Defaults();
			}
			public _Color Color { get; } = new _Color();

			public class _Day : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public ITime Duration { get; set; } = 24.Minutes().ToTime();
			}
			public _Day Day { get; } = new _Day();

			public class _Time : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public ITime Current { get; set; } = 12.Hours().ToTime();
				public ITime Default { get; set; } = 12.Hours().ToTime();
			}
			public _Time Time { get; } = new _Time();

			public class _Weather : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public class _ForceObedience : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Boolean LandEverywhere { get; set; } = true;
					public Boolean Collisions { get; set; } = false;
					public Boolean BlackOut { get; set; } = false;
					public Boolean Fog { get; set; } = false;
				}
				public _ForceObedience ForceObedience { get; } = new _ForceObedience();

				public class _Enable : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Boolean LandEverywhere { get; set; } = true;
					public Boolean Collisions { get; set; } = false;
					public Boolean BlackOut { get; set; } = false;
					public Boolean Fog { get; set; } = true;
				}
				public _Enable Enable { get; } = new _Enable();

				public class _Wind : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public ISpeed WindX { get; set; } = 0.MetersPerSecond();
					public ISpeed WindY { get; set; } = 0.MetersPerSecond();
					public ISpeed WindZ { get; set; } = 0.MetersPerSecond();
				}
				public _Wind Wind { get; } = new _Wind();

				public IDistance Visibility { get; set; } = 0.Meters();
			}
			public _Weather Weather { get; } = new _Weather();

			public class _OwnerInformation : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				public String PreferredName { get; set; } = "???";
				public String ContactEmail { get; set; } = "???";
			}
			public _OwnerInformation OwnerInformation { get; } = new _OwnerInformation();

			public class _IRC : INotifyPropertyChanged
			{
				public event PropertyChangedEventHandler PropertyChanged;

				#region UseIRC?
				public Boolean Enabled { get; set; } = false;
				#endregion
				#region IRC Server
				public class _Server : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public IHostAddress Address { get; set; } = ObjectFactory.CreateHostAddress(IPAddress.None);
					public UInt32 Port { get; set; } = 6667;

					public String Channel { get; set; } = "None";
				}
				public _Server Server { get; } = new _Server();
				#endregion
				#region OpenYS Nickname
				public String Nickname { get; set; } = "OpenYS";

				public class _Authentication : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public Boolean Enabled { get; set; } = false;
					public String ServiceName { get; set; } = "NickServ";
					public String Password { get; set; } = "PASSWORD";
				}
				public _Authentication Authentication { get; } = new _Authentication();
				#endregion
				#region Messaging Control
				public class _Messages : INotifyPropertyChanged
				{
					public event PropertyChangedEventHandler PropertyChanged;

					public class _IRCtoOYS : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Boolean Enabled { get; set; } = true;
						public Boolean StripFormatting { get; set; } = false;
						public Boolean ShowEvents { get; set; } = true;
						public I24BitColor MessageColor { get; set; } = SimpleColors.White.Color.Get24BitColor();
					}
					public  _IRCtoOYS IRCtoOYS { get; } = new _IRCtoOYS();

					public class _OYStoIRC : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Boolean Enabled { get; set; } = true;
						public Boolean StripFormatting { get; set; } = false;
						public Boolean ShowEvents { get; set; } = true;
						public I24BitColor MessageColor { get; set; } = SimpleColors.Black.Color.Get24BitColor();
					}
					public _OYStoIRC OYStoIRC { get; } = new _OYStoIRC();
				}
				public _Messages Messages { get; } = new _Messages();
				#endregion
			}
			public _IRC IRC { get; } = new _IRC();

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
					public _ShowMessages ShowMessages { get; } = new _ShowMessages();

					public class _ShowDebug : INotifyPropertyChanged
					{
						public event PropertyChangedEventHandler PropertyChanged;

						public Boolean Summary { get; set; } = true;
						public Boolean Detail { get; set; } = false;
						public Boolean Warning { get; set; } = true;
						public Boolean Error { get; set; } = true;
						public Boolean Crash { get; set; } = true;
					}
					public _ShowDebug ShowDebug { get; } = new _ShowDebug();
				}
				public _Console Console { get; } = new _Console();

			}
			public _UserInterface UserInterface { get; } = new _UserInterface();
		}
		public static _Settings Settings { get; }		

		static SettingsLibrary()
		{
			Settings = new _Settings();
		}
	}
}
