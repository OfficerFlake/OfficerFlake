using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Com.OfficerFlake.Libraries.Networking.Packets;
using Com.OfficerFlake.Libraries.YSFlight;
using static Com.OfficerFlake.Libraries.Networking.Connection;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class Server
		{
			private static bool Process_Type_01_Login(Connection thisConnection, Packets.Type_01_Login LoginPacket)
			{
				thisConnection.SendMessage("TESTING...");

				#region Get Login(01)
				thisConnection.Username = LoginPacket.Username.Split('\0')[0];
				thisConnection.Version = LoginPacket.Version;
				thisConnection.SetLoggingIn();
				thisConnection.SetIsFlightIdle();
				#endregion

				#region Make OP [DISABLED]
				//if (Settings.Loading.AutoOPs)
				//{
				//	//The below checks if the user is from a local ip endpoint (From Wikipedias definitions...)
				//	//If so, the user is made an OP.
				//	if ((thisConnection.YSFClient.Socket.RemoteEndPoint as IPEndPoint).AddressFamily == AddressFamily.InterNetwork && thisConnection.Username != "PHP bot")
				//	{
				//		int byte0 = Int32.Parse((thisConnection.YSFClient.Socket.RemoteEndPoint as IPEndPoint).Address.ToString().Split('.')[0]);
				//		int byte1 = Int32.Parse((thisConnection.YSFClient.Socket.RemoteEndPoint as IPEndPoint).Address.ToString().Split('.')[1]);
				//		int byte2 = Int32.Parse((thisConnection.YSFClient.Socket.RemoteEndPoint as IPEndPoint).Address.ToString().Split('.')[2]);
				//		int byte3 = Int32.Parse((thisConnection.YSFClient.Socket.RemoteEndPoint as IPEndPoint).Address.ToString().Split('.')[3]);

				//		//10.*.*.*
				//		if (byte0 == 10) goto MakeOP;

				//		//127.0.0.1
				//		if (byte0 == 127 &
				//			byte1 == 0 &
				//			byte2 == 0 &
				//			byte3 == 1) goto MakeOP;

				//		//192.168.*.*
				//		if (byte0 == 192 &
				//			byte1 == 168) goto MakeOP;

				//		//172.16.*.* - 172.31.*.*
				//		if (byte0 == 172 &
				//			byte1 >= 16 &
				//			byte1 <= 31) goto MakeOP;

				//		//NOT a local ip, so not an OP.
				//		goto NotOP;


				//		MakeOP:
				//		if (Settings.Options.AllowOPs)
				//		{
				//			//Console.WriteLine(ConsoleColor.Red, "Connecting Client is from a local ip address (" + (thisConnection.YSFClient.Socket.RemoteEndPoint as IPEndPoint).Address.ToString() + ").\nMade them an OP.");
				//			thisConnection.OP();
				//		}

				//		NotOP:
				//		//Do Nothing.
				//		;
				//	}
				//}
				#endregion

				#region Get Complete UserName (Old Clients)
				if (thisConnection.Version <= 20120207 & thisConnection.Username.Length >= 15)
				{
					thisConnection.SendMessage("You are using an old version of YSFlight");
					thisConnection.SendMessage("Please verify your username before continuing!");
					thisConnection.SendMessage("");
					thisConnection.SendMessage("Please type a blank string. (Press F12 and then press await enter)");
					thisConnection.SendMessage("IT IS IMPORTANT YOU DON'T TYPE ANYTHING, JUST A BLANK LINE!");
					while (true)
					{
						PacketWaiter PacketWaiter_ConfirmUsername = new Connection.PacketWaiter(32);
						if (!PacketWaiter_ConfirmUsername.WaitUntilRecived(20000))
						{
							thisConnection.SendMessage("Still waiting on your to enter your username as a Chat Message. Please press F12 and then press enter within 10 seconds or you will be disconnected!");
						}
						if (!PacketWaiter_ConfirmUsername.WaitUntilRecived(10000))
						{
							thisConnection.SendMessage("Haven't heard back from you. Was expecting a chat message confirming your username. Now Disconnecting you. Please try again!");
							thisConnection.Disconnect();
							return false;
						}
						Packets.Type_32_ChatMessage MessagePacket = new Packets.Type_32_ChatMessage();
						MessagePacket.Data = PacketWaiter_ConfirmUsername.RecievedPacket.Data;

						string EmptyStringResponse = "";
						EmptyStringResponse = MessagePacket.FullMessage;
						if (!EmptyStringResponse.StartsWith("(") | !EmptyStringResponse.EndsWith(")"))
						{
							thisConnection.SendMessage("Sorry, that doesn't look quite right... YOU MUST USE A BLANK STRING. Try again!");
							continue;
						}

						thisConnection.Username = EmptyStringResponse.Substring(1, EmptyStringResponse.Length - 2);

						//Debug.WriteLine("Got Username from old client! (" + thisConnection.Username + ")");
						thisConnection.SendMessage("Thanks for that! Logging you in...");
						thisConnection.SendMessage("YSFlight Versions from 20120207 and forwards will avoid this log-in workaround as they do send the full username.");
						break;
					}
				}
				#endregion

				#region Send Join Message [DISABLED]
				//finally, send the jointext.
				//if (File.Exists("AutoMessages/_1_StartLogIn.txt") & Settings.Loading.SendConnectedWelcomeMessage)
				//{
				//	string[] msg = Files.FileReadAllLines("AutoMessages/_1_StartLogIn.txt");
				//	string output = "";
				//	foreach (string ThisLine in msg)
				//	{
				//		if (output.Length > 0) output += "\n";
				//		output += ThisLine;
				//	}
				//	//Send the join info packet.
				//	thisConnection.SendMessage(output);
				//}
				#endregion

				#region Bot Handling [DISABLED]
				//if (Clients.BotNames.Contains(thisConnection.Username)) thisConnection.SetBot();

				//if (!thisConnection.IsBot())
				//{

				//	if (thisConnection.IsOP()) Console.WriteLine(ConsoleColor.Yellow, thisConnection.Username + "&e Logging in... " + (thisConnection.YSFClient.Socket.RemoteEndPoint as IPEndPoint).Address.ToString());
				//	else Console.WriteLine(ConsoleColor.Yellow, thisConnection.Username + " Logging in... &7" + (thisConnection.YSFClient.Socket.RemoteEndPoint as IPEndPoint).Address.ToString());
				//}
				#endregion

				#region OpenYS Handshake  [DISABLED, TO BE HANDLED VIA UDP]
				//When the client sends the server a login packet, tell the client this server supports the OpenYS protocal!
				//if (Settings.Options.AllowOYSFramework)
				//{
				//	thisConnection.SendPacket(new Packets.Packet_64_29_OpenYS_Handshake(Settings.Loading.OYSNetcodeVersion).ToCustomPacket());
				//}
				#endregion

				#region Inform Players
				AllConnections.Exclude(thisConnection).SendMessageAsync(thisConnection.Username + " joined the server.").ConfigureAwait(false);
				#endregion

				#region Send Version(29)
				//Build Version (29)
				//if (Settings.Loading.YSFNetcodeVersion != 0)
				//{
				//	//If the netcode version is set to 0, use the clients version (Silences the "You are using a different version..." error.)
				//	NetcodeVersion = Settings.Loading.YSFNetcodeVersion;
				//}
				//Packets.Type_06_Acknowledgement AcknowledgeVersionPacket = new Packets.Type_06_Acknowledgement(9, 0);
				Type_29_NetcodeVersion VersionPacket = new Type_29_NetcodeVersion();
				VersionPacket.Version = 20110207;

				PacketWaiter PacketWaiter_AcknowledgeVersionPacket = new PacketWaiter(6);
				PacketWaiter_AcknowledgeVersionPacket.Require(0, (Int32)9);
				PacketWaiter_AcknowledgeVersionPacket.StartListening();

				thisConnection.Send(VersionPacket);

				#endregion

				#region Send MissilesOption (31)
				Packets.Type_31_MissilesEnabled MissilesOption = new Packets.Type_31_MissilesEnabled();
				MissilesOption.Enabled = true;

				Connection.PacketWaiter PacketWaiter_AcknowledgeMissileOption = new Connection.PacketWaiter(6);
				PacketWaiter_AcknowledgeMissileOption.Require(0, (Int32)10);
				PacketWaiter_AcknowledgeMissileOption.StartListening();

				thisConnection.Send(MissilesOption);
				#endregion

				#region Send WeaponsOption (39)
				Packets.Type_39_WeaponsEnabled WeaponsOption = new Packets.Type_39_WeaponsEnabled();
				WeaponsOption.Enabled = true;

				Connection.PacketWaiter PacketWaiter_AcknowledgeWeaponsOption = new Connection.PacketWaiter(6);
				PacketWaiter_AcknowledgeWeaponsOption.Require(0, (Int32)11);
				PacketWaiter_AcknowledgeWeaponsOption.StartListening();

				thisConnection.Send(WeaponsOption);
				#endregion

				#region Get Version(06:09)
				if (!thisConnection.GetResponseOrResend(PacketWaiter_AcknowledgeVersionPacket, VersionPacket))
				{
					thisConnection.SendMessage("Expected a Version Packet reply and didn't get an answer. Disconnecting...");
					thisConnection.Disconnect();
					return false;
				}
				#endregion

				#region Send UsernameDistance(41)
				Type_41_UsernameDistance UsernameDistance = new Type_41_UsernameDistance();
				UsernameDistance.SetAlwaysVisible();

				PacketWaiter packetWaiter_AcknowledgeUsernameDistance = new PacketWaiter(41);
				packetWaiter_AcknowledgeUsernameDistance.Require(0, UsernameDistance.Data);
				packetWaiter_AcknowledgeUsernameDistance.StartListening();

				thisConnection.Send(UsernameDistance);
				#endregion

				#region Send RadarAltitude(43)
				Type_43_MiscCommand RadarAltitude = new Type_43_MiscCommand();
				RadarAltitude.Command = "RADARALTI";
				RadarAltitude.Argument = "0.00M";

				PacketWaiter packetWaiter_AcknowledgeRadarAltitude = new PacketWaiter(43);
				packetWaiter_AcknowledgeRadarAltitude.Require(0, UsernameDistance.Data);
				packetWaiter_AcknowledgeRadarAltitude.StartListening();

				thisConnection.Send(RadarAltitude);
				#endregion

				#region Send No External View(43)
				Type_43_MiscCommand NoExAirView = new Type_43_MiscCommand();
				NoExAirView.Command = "NOEXAIRVIEW";
				NoExAirView.Argument = "TRUE";

				PacketWaiter packetWaiter_AcknowledgeNoExAirView = new PacketWaiter(43);
				packetWaiter_AcknowledgeNoExAirView.Require(0, NoExAirView.Data);
				packetWaiter_AcknowledgeNoExAirView.StartListening();

				thisConnection.Send(NoExAirView);

				//Send RadarAltitude (43)
				if (NoExAirView.Argument == "TRUE") thisConnection.Send(NoExAirView);
				#endregion

				#region Send Field(04)
				Type_04_Field Field = new Type_04_Field();
				Field.FieldName = "HAWAII";

				PacketWaiter packetWaiter_AcknowledgeField = new PacketWaiter(4);
				packetWaiter_AcknowledgeField.Require(0, Field.FieldName);
				packetWaiter_AcknowledgeField.StartListening();

				thisConnection.Send(Field);
				#endregion

				#region Get Field(04)
				if (!thisConnection.GetResponseOrResend(packetWaiter_AcknowledgeField, Field))
				{
					thisConnection.SendMessage("Expected a Field Reply and didn't get an answer. Disconnecting...");
					//thisConnection.Disconnect();
					//return false;
				}
				#endregion

				#region Get MissilesOption(06:10)
				if (!thisConnection.GetResponseOrResend(PacketWaiter_AcknowledgeMissileOption, MissilesOption))
				{
					thisConnection.SendMessage("Expected a Missle Option Acknowledge and didn't get an answer. Disconnecting...");
					//thisConnection.Disconnect();
					//return false;
				}
				#endregion

				#region Get WeaponsOption(06:11)
				if (!thisConnection.GetResponseOrResend(PacketWaiter_AcknowledgeWeaponsOption, WeaponsOption))
				{
					thisConnection.SendMessage("Expected a Weapons Option Acknowledge and didn't get an answer. Disconnecting...");
					//thisConnection.Disconnect();
					//return false;
				}
				#endregion

				#region Send AircraftList(44)
				//Process the Aircraft List.
				List<Metadata.Aircraft> MetaAircraftList = new List<Metadata.Aircraft>();
				int Percentage = 0;
				for (int i = 0; i < Metadata.Aircraft.List.Count; i++)
				{
					#region Tell YSClient the Percentage
					bool UpdatedPercentage = false;
					decimal CurrentPercent = (((decimal)i + 1) / (decimal)(Metadata.Aircraft.List.Count)) * 100;
					while (CurrentPercent >= Percentage+10)
					{
						Percentage += 10;
						UpdatedPercentage = true;
					}
					if (UpdatedPercentage)
					{
						if (Percentage == 100) thisConnection.SendMessage("Sending Aircraft List: " + Percentage + "% Complete!");
						else thisConnection.SendMessage("Sending Aircraft List: " + Percentage + "% Complete...");
					}
					#endregion

					MetaAircraftList.Add(Metadata.Aircraft.List[i]);
					if (MetaAircraftList.Count >= 32)
					{
						#region Prepare Aircraft List
						//Build AircraftList (44)
						Type_44_AircraftList ThisAircraftListPacket = new Type_44_AircraftList();
						ThisAircraftListPacket.Version = 1;
						ThisAircraftListPacket.Count = (byte) MetaAircraftList.Count();
						ThisAircraftListPacket.List = MetaAircraftList.Select(y => y.Identify.Split('\0')[0]).ToArray();
						MetaAircraftList.Clear();
						#endregion

						#region Send AircraftList(44)
						PacketWaiter packetWaiter_ThisAircraftList = new PacketWaiter(44);
						packetWaiter_ThisAircraftList.Require(0, ThisAircraftListPacket.Data);
						packetWaiter_ThisAircraftList.StartListening();

						thisConnection.Send(ThisAircraftListPacket);
						#endregion
					}
				}
				#endregion

				#region Disconnect Bots
				//if (Settings.Loading.KickBots)
				//{
				//	if (thisConnection.IsBot())
				//	{
				//		thisConnection.SendMessage("Domo arigato for checking this OpenYS server, anonymous robot-sama. Sayonara! ^_^");
				//		thisConnection.Disconnect("Bot kicked after logging in.");
				//		return true;
				//	}
				//}
				#endregion

				#region Update FogColor
				//if (Settings.Weather.Advanced.EnableFogColor & thisConnection.Version > 20110207)
				//{
				//	Packets.Type_48_FogColor FogColor = new Packets.Type_48_FogColor(OpenYS.AdvancedWeatherOptions.FogColor.Red, OpenYS.AdvancedWeatherOptions.FogColor.Green, OpenYS.AdvancedWeatherOptions.FogColor.Blue);
				//	thisConnection.SendPacket(FogColor);
				//}
				#endregion
				#region Update SkyColor
				//if (Settings.Weather.Advanced.EnableSkyColor & thisConnection.Version > 20110207)
				//{
				//	Packets.Type_49_SkyColor SkyColor = new Packets.Type_49_SkyColor(OpenYS.AdvancedWeatherOptions.SkyColor.Red, OpenYS.AdvancedWeatherOptions.SkyColor.Green, OpenYS.AdvancedWeatherOptions.SkyColor.Blue);
				//	thisConnection.SendPacket(SkyColor);
				//}
				#endregion
				#region Update GndColor
				//if (Settings.Weather.Advanced.EnableGndColor & thisConnection.Version > 20110207)
				//{
				//	Packets.Type_50_GroundColor GndColor = new Packets.Type_50_GroundColor(OpenYS.AdvancedWeatherOptions.GndColor.Red, OpenYS.AdvancedWeatherOptions.GndColor.Green, OpenYS.AdvancedWeatherOptions.GndColor.Blue);
				//	thisConnection.SendPacket(GndColor);
				//}
				#endregion

				#region Send Entities(05)
				//Create all the other players aircraft.
				//foreach (Client OtherClient in Clients.AllClients.Where(x => x.Vehicle != null).Where(y => y.Vehicle != Vehicles.NoVehicle).ToArray())
				//{
				//    //Client.Connection.PacketWaiter ThisListener = //thisConnection.YSFClient.ExpectAcknowledgement(0, OtherClient.Vehicle.ID);
				//    Packets.Type_06_Acknowledgement AcknowledgeJoin = new Packets.Type_06_Acknowledgement(0, OtherClient.Vehicle.ID);
				//    thisConnection.SendPacketGetPacket(OtherClient.Vehicle.GetJoinPacket(false), AcknowledgeJoin);
				//}

				#region Online Vehicles
				/*
				foreach (Vehicle ThisVehicle in Vehicles.List.ToArray())
				{
					Packets.Type_06_Acknowledgement AcknowledgeJoin = new Packets.Type_06_Acknowledgement(0, ThisVehicle.ID);
					//thisConnection.SendPacketGetPacket(ThisVehicle.GetJoinPacket(false), AcknowledgeJoin);
					thisConnection.SendPacket(ThisVehicle.GetJoinPacket(false));

					Packets.Type_36_WeaponsConfig Loading = ThisVehicle.WeaponsLoading;
					thisConnection.SendPacket(Loading);

					if (ThisVehicle.VirtualCarrierObject_ID != 0)
					{
						MetaData.Ground VirtualCarrierObject = ThisVehicle.VirtualCarrierObject_MetaData;
						ThisVehicle.VirtualCarrierObject_MetaData = VirtualCarrierObject;

						if (VirtualCarrierObject != MetaData._Ground.None)
						{
							Packets.Type_05_EntityJoined VCOJoined;
							VCOJoined = new Packets.Type_05_EntityJoined();
							VCOJoined.IsGround = true;
							VCOJoined.ID = ThisVehicle.VirtualCarrierObject_ID;
							VCOJoined.IFF = ThisVehicle.IFF;
							VCOJoined.PosX = ThisVehicle.PosX;
							VCOJoined.PosY = ThisVehicle.PosY;
							VCOJoined.PosZ = ThisVehicle.PosZ;
							VCOJoined.RotX = (float)(ThisVehicle.HdgX / 32767d * Math.PI);
							VCOJoined.RotY = (float)(ThisVehicle.HdgY / 32767d * Math.PI);
							VCOJoined.RotZ = (float)(ThisVehicle.HdgZ / 32767d * Math.PI);
							VCOJoined.Identify = VirtualCarrierObject.Identify;
							VCOJoined.OwnerName = ThisVehicle.OwnerName;
							VCOJoined.IsOwnedByThisPlayer = false;

							thisConnection.SendPacket(VCOJoined);
						}
					}
				}
				*/
				#endregion

				//Create all the ground objects.
				Percentage = 0;
				for (int i = 0; i < World.Objects.GroundList.Count; i++)
				{
					#region Tell YSClient the Percentage
					bool UpdatedPercentage = false;
					decimal CurrentPercent = (((decimal)i + 1) / (decimal)(World.Objects.GroundList.Count)) * 100;
					while (CurrentPercent >= Percentage + 10)
					{
						Percentage += 10;
						UpdatedPercentage = true;
					}
					if (UpdatedPercentage)
					{
						if (Percentage == 100) thisConnection.SendMessage("Sending Ground Objects List: " + Percentage + "% Complete!");
						else thisConnection.SendMessage("Sending Ground Objects List: " + Percentage + "% Complete...");
					}
					#endregion

					World.Objects.Ground ThisGround = World.Objects.GroundList[i];
					Packets.Type_05_EntityJoined GroundJoin = new Packets.Type_05_EntityJoined();
					GroundJoin.IsGround = true;
					GroundJoin.ID = (Int32)ThisGround.ID;
					GroundJoin.Identify = ThisGround.Identify;
					GroundJoin.OwnerName = ThisGround.Tag;
					GroundJoin.IFF = (Int32)ThisGround.IFF;
					GroundJoin.PosX = ThisGround.Position.X;
					GroundJoin.PosY = ThisGround.Position.Y;
					GroundJoin.PosZ = ThisGround.Position.Z;
					GroundJoin.RotX = (float)(ThisGround.Attitude.X / 180 * System.Math.PI);
					GroundJoin.RotY = (float)(ThisGround.Attitude.Y / 180 * System.Math.PI);
					GroundJoin.RotZ = (float)(ThisGround.Attitude.Z / 180 * System.Math.PI);

					thisConnection.Send(GroundJoin);
				}

				#endregion

				#region Send PrepareSimulation(16)
				//Build Prepare Simulation (16)
				Type_16_PrepareSimulation PrepareSimulation = new Type_16_PrepareSimulation();

				PacketWaiter packetWaiter_AcknowledgePrepareSimulation = new PacketWaiter(16);
				packetWaiter_AcknowledgePrepareSimulation.Require(0, (Int32)7);
				packetWaiter_AcknowledgePrepareSimulation.StartListening();

				//Send Prepare Simulation (16)
				thisConnection.Send(PrepareSimulation);
				thisConnection.SetLoggedIn();
				#endregion

				#region Get PrepareSimulation(06:07)
				if (!thisConnection.GetResponseOrResend(packetWaiter_AcknowledgePrepareSimulation, PrepareSimulation))
				{
					thisConnection.SendMessage("Expected a Prepare Simulation Acknowledge and didn't get an answer. Disconnecting...");
					thisConnection.Disconnect();
					return false;
				}
				#endregion

				#region Complete Login!
				thisConnection.SendMessage("*** Login Complete! ***");
				#endregion

				#region Send WelcomeText
				//finally, send the loggedin.
				//if (Files.FileExists("AutoMessages/_1_EndLogIn.txt") && Settings.Loading.SendLogInCompleteWelcomeMessage)
				//{
				//	string[] msg = Files.FileReadAllLines("AutoMessages/_1_EndLogIn.txt");
				//	string output = "";
				//	foreach (string ThisLine in msg)
				//	{
				//		if (output.Length > 0) output += "\n";
				//		output += ThisLine;
				//	}
				//	//Send the join info packet.
				//	thisConnection.SendMessage(output);
				//}
				#endregion

				#region DEBUG TESTING
				/*
#if DEBUG
				Packets.Type_05_EntityJoined GroundJoin2 = new Packets.Type_05_EntityJoined();
				GroundJoin2.IsGround = true;
				GroundJoin2.ID = 99999;
				GroundJoin2.Identify = "[OPENYS]CVX-15V_DEBUG";
				GroundJoin2.OwnerName = "DEBUG TEST";
				GroundJoin2.IFF = 0;
				GroundJoin2.PosX = 0;
				GroundJoin2.PosY = 0;
				GroundJoin2.PosZ = 100;
				GroundJoin2.RotX = 0;
				GroundJoin2.RotY = 0;
				GroundJoin2.RotZ = 0;

				thisConnection.Send(GroundJoin2);

				Packets.Type_21_GroundData GroundData2 = new Type_21_GroundData();
				GroundData2.AnimFlags = 0;
				GroundData2._CPU_Flags = 0;
				GroundData2.HdgX = 0;
				GroundData2.HdgY = 0;
				GroundData2.HdgZ = 0;
				GroundData2.ID = 99999;
				GroundData2.PosX = 0;
				GroundData2.PosY = 0;
				GroundData2.PosZ = 100;
				GroundData2.Strength = 10;
				GroundData2.TimeStamp = 0;
				GroundData2.V_PosX = 0;
				GroundData2.V_PosY = 0;
				GroundData2.V_PosZ = 10; //this is being ignored! Works for "TRUCK" ground object...
				GroundData2.V_Rotation = 0;

				thisConnection.Send(GroundData2);
#endif
				*/
				#endregion

				thisConnection.SendMessage("DONE");

				return true;
			}
		}
	}
}
