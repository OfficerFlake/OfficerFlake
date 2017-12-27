using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
    public static partial class PacketProcessor
    {
	    public static partial class Server
	    {
		    public static bool Process(IConnection thisConnection, IPacket thisPacket)
		    {
			    switch (thisPacket.Type)
			    {
				    case 1:
					    IPacket_01_Login thisLogin = ObjectFactory.CreatePacket01Login();
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
					    IPacket_32_ChatMessage thisChatMessage = ObjectFactory.CreatePacket32ChatMessage(thisConnection.User, "");
					    thisChatMessage.User = thisConnection.User;
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
