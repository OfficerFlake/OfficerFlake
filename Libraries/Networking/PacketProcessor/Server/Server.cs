using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.OfficerFlake.Libraries.Networking
{
    public static partial class PacketProcessor
    {
	    public static partial class Server
	    {
		    public static void Process(Connection thisConnection, GenericPacket thisPacket)
		    {
			    switch (thisPacket.Type)
			    {
				    case 1:
					    Packets.Type_01_Login thisLogin = new Packets.Type_01_Login();
					    thisLogin.Data = thisPacket.Data;
					    Process_Type_01_Login(thisConnection, thisLogin);
					    break;
				    case 3:
					    //Type1;
					    break;
				    case 4:
					    //Type1;
					    break;
				    case 5:
					    //Type1;
					    break;
				    case 6:
					    //Type1;
					    break;
				    case 7:
					    //Type1;
					    break;
				    case 8:
					    //Type1;
					    break;
				    case 9:
					    //Type1;
					    break;
				    case 10:
					    //Type1;
					    break;
				    case 11:
					    //Type1;
					    break;
				    case 12:
					    //Type1;
					    break;
				    case 13:
					    //Type1;
					    break;
				    case 16:
					    //Type1;
					    break;
				    case 17:
					    //Type1;
					    break;
				    case 18:
					    //Type1;
					    break;
				    case 19:
					    //Type1;
					    break;
				    case 20:
					    //Type1;
					    break;
				    case 21:
					    //Type1;
					    break;
				    case 22:
					    //Type1;
					    break;
				    case 29:
					    //Type1;
					    break;
				    case 30:
					    //Type1;
					    break;
				    case 31:
					    //Type1;
					    break;
				    case 32:
					    //Type1;
					    break;
				    case 33:
					    //Type1;
					    break;
				    case 35:
					    //Type1;
					    break;
				    case 36:
					    //Type1;
					    break;
				    case 37:
					    //Type1;
					    break;
				    case 38:
					    //Type1;
					    break;
				    case 39:
					    //Type1;
					    break;
				    case 41:
					    //Type1;
					    break;
				    case 43:
					    //Type1;
					    break;
				    case 44:
					    //Type1;
					    break;
				    case 45:
					    //Type1;
					    break;
				    case 47:
					    //Type1;
					    break;
				    case 48:
					    //Type1;
					    break;
				    case 49:
					    //Type1;
					    break;
				    case 50:
					    //Type1;
					    break;
				    default:
					    //Type1;
					    break;
			    }
		    }
	    }
    }
}
