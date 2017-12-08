using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OfficerFlake.Libraries.Networking
{
    public static partial class PacketProcessor
    {
	    public static partial class Server
	    {
		    public static bool Process(Connection thisConnection, GenericPacket thisPacket)
		    {
			    switch (thisPacket.Type)
			    {
				    case 1:
					    Packets.Type_01_Login thisLogin = new Packets.Type_01_Login();
					    thisLogin.Data = thisPacket.Data;
					    return Process_Type_01_Login(thisConnection, thisLogin);
				    case 3:
					    break;
				    case 4:
					    break;
				    case 5:
					    break;
				    case 6:
					    break;
				    case 7:
					    break;
				    case 8:
					    break;
				    case 9:
					    break;
				    case 10:
					    break;
				    case 11:
					    break;
				    case 12:
					    break;
				    case 13:
					    break;
				    case 16:
					    break;
				    case 17:
					    break;
				    case 18:
					    break;
				    case 19:
					    break;
				    case 20:
					    break;
				    case 21:
					    break;
				    case 22:
					    break;
				    case 29:
					    break;
				    case 30:
					    break;
				    case 31:
					    break;
				    case 32:
						Packets.Type_32_ChatMessage thisChatMessage = new Packets.Type_32_ChatMessage();
					    thisChatMessage.SetUsername(thisConnection.Username);
					    thisChatMessage.Data = thisPacket.Data;
					    return Process_Type_32_ChatMessage(thisConnection, thisChatMessage);
				    case 33:
					    break;
				    case 35:
					    break;
				    case 36:
					    break;
				    case 37:
					    break;
				    case 38:
					    break;
				    case 39:
					    break;
				    case 41:
					    break;
				    case 43:
					    break;
				    case 44:
					    break;
				    case 45:
					    break;
				    case 47:
					    break;
				    case 48:
					    break;
				    case 49:
					    break;
				    case 50:
					    break;
				    default:
					    break;
			    }
			    return true;
		    }
	    }
    }
}
