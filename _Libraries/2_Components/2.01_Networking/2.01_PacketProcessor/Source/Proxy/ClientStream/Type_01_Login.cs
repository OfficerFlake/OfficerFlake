using System;
using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_01_Login(IConnection thisConnection, IPacket_01_Login packet)
			{
				#region Get Login(01)
				var username = packet.Username.Split('\0')[0];
				thisConnection.User = ObjectFactory.CreateUser(username.AsRichTextString());
				thisConnection.Version = packet.Version;
				thisConnection.LoginState = LoginStatus.LoggingIn;
				thisConnection.FlightStatus = FlightStatus.Idle;
				#endregion

				#region Get Complete UserName (Old Clients)
				if (thisConnection.Version <= 20120207 & thisConnection.User.UserName.ToUnformattedSystemString().Length >= 15)
				{
					thisConnection.SendToClientStream("You are using an old version of YSFlight");
					thisConnection.SendToClientStream("Please verify your username before continuing!");
					thisConnection.SendToClientStream("");
					thisConnection.SendToClientStream("Please type a blank string. (Press F12 and then press await enter)");
					thisConnection.SendToClientStream("IT IS IMPORTANT YOU DON'T TYPE ANYTHING, JUST A BLANK LINE!");
					while (true)
					{
						IPacketWaiter PacketWaiter_ConfirmUsername = thisConnection.CreatePacketWaiter(32);
						if (!PacketWaiter_ConfirmUsername.WaitUntilReceived(20000))
						{
							thisConnection.SendToClientStream("Still waiting on your to enter your username as a Chat Message. Please press F12 and then press enter within 10 seconds or you will be disconnected!");
						}
						if (!PacketWaiter_ConfirmUsername.WaitUntilReceived(10000))
						{
							thisConnection.SendToClientStream("Haven't heard back from you. Was expecting a chat message confirming your username. Now Disconnecting you. Please try again!");
							thisConnection.Disconnect("No Response to Username Confirmation Request.");
							return false;
						}
						IPacket_32_ServerMessage MessagePacket = ObjectFactory.CreatePacket32ServerMessage("");
						MessagePacket.Data = PacketWaiter_ConfirmUsername.RecievedPacket.Data;

						string EmptyStringResponse = "";
						EmptyStringResponse = MessagePacket.Message;
						if (!EmptyStringResponse.StartsWith("(") | !EmptyStringResponse.EndsWith(")"))
						{
							thisConnection.SendToClientStream("Sorry, that doesn't look quite right... YOU MUST USE A BLANK STRING. Try again!");
							continue;
						}

						thisConnection.User.UserName = ObjectFactory.CreateRichTextString(EmptyStringResponse.Substring(1, EmptyStringResponse.Length - 2));

						//Debug.WriteLine("Got Username from old client! (" + thisConnection.Username + ")");
						thisConnection.SendToClientStream("Thanks for that! Logging you in...");
						thisConnection.SendToClientStream("YSFlight Versions from 20120207 and forwards will avoid this log-in workaround as they do send the full username.");
						break;
					}
				}
				#endregion

				#region OpenYS Handshake  [DISABLED, TO BE HANDLED VIA UDP]
				//When the client sends the server a login packet, tell the client this server supports the OpenYS protocal!
				//if (Settings.Options.AllowOYSFramework)
				//{
				//	thisConnection.SendPacket(new Packets.Packet_64_29_OpenYS_Handshake(Settings.Loading.OYSNetcodeVersion).ToCustomPacket());
				//}
				#endregion

				thisConnection.SendToHostStream(packet);

				return true;
			}
		}
	}
}
