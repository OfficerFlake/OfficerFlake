using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_33_Weather(IConnection thisConnection, IPacket_33_Weather packet)
			{
				if (packet.Data.Length == 0)
				{
					//TODO: [3] Send Weather Packet
					IPacket_33_Weather newWeather = ObjectFactory.CreatePacket33Weather();
					newWeather.Initialise();
					thisConnection.SendToClientStream(newWeather);
				}
				return true;
			}
		}
	}
}
