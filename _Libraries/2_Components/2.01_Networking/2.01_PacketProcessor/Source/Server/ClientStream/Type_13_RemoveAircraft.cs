using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_13_RemoveAircraft(IConnection thisConnection, IPacket_13_RemoveAircraft packet)
			{
				IPacket_06_Acknowledgement removeAcknowledgement = ObjectFactory.CreatePacket06Acknowledgement(2, packet.ID);
				thisConnection.SendToClientStream(removeAcknowledgement);
				return true;
			}
		}
	}
}
