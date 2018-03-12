using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class Server
		{
			private static bool Process_Type_33_Weather(IConnection thisConnection, IPacket_33_Weather weatherPacket)
			{
				if (weatherPacket.Data.Length == 0)
				{
					//TODO: Send Weather Packet
					IPacket_33_Weather newWeather = ObjectFactory.CreatePacket33Weather();
					newWeather.Initialise();
					thisConnection.SendAsync(newWeather);
				}
				return true;
			}
		}
	}
}
