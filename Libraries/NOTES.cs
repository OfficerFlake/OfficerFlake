namespace Com.OfficerFlake.PlanningAndNotes
{
	public abstract class RoadMap
	{
		// TODO : ROADMAP
		//
		// Settings
		// Join/Leave Flight
		// PacketSniffer
		// All Packets Read
	}
	public abstract class OldNotes
	{
		//Database Save/Load
		//Server Implementation
		//	abstract Connection
		//		ConcurrentQueue<Packet> PacketsIn;
		//	GetPacket()
		//			Take packet from Queue.
		//			Action Packet();
		//	ActionPacket();
		//	TCP_Connection : Connection
		//		Socket TCP_Socket
		//		ReceivePacketEventLoop()
		//			ReceivePacketFromTCPConnection();
		//	Get Size.
		//	Get Data.
		//				-> Packet.
		//	Recall Event Loop.
		//				return Packet.
		//UDP_Connection : Connection

		//int UDP_ID

		//ReceivePacketLoop()
		//ReceivePacketFromUDPConnection();
		//	static UDP_Receiver
		//		GetUDPPacketEventLoop()
		//			GetUDPPacket
		//			ID
		//			Size
		//			Data
		//			-> Packet
		//			Connections where ID==
		//				PacketsIn.Enqueue(This);
		//			GetUDPPacketEventLoop();
		//	Packet
		//		TryGetBytesOrNull(Start, End);
		//		if null return default;

		//Link Database to Server

		//Settings
		//Settings Save/Load
		//Link Settings to Server




		//Database\
		//	Users\
		//		[Username]\
		//			Info.dat
		//				AutoID
		//			Mute.dat
		//			Freeze.dat
		//			Kick.dat
		//			Ban.dat
		//			YSFHQ.dat
		//			Groups\
		//				Active\
		//				Inactive\
		//					[Groupname].dat
		//						Rank
		//						RankedBy

		//	Groups\
		//		[Groupname]\
		//			Ranks\
		//				[Rankname]\
		//					Permissions.dat



		//Vehicle

		//	Data : File
		//	Model : File
		//	CollisionModel : File
		//	Cockpit : File
		//	Coarse : File

		//	User User { }; //So can create fake vehicles for offline users - vehicles get parked?

		//	File
		//	-> Variables encaspulated in property tree, variables updated onLoad, and written out onSave.

		//User
		//	YSFHQ
		//		Id
		//		Username
		//	OYSPortal
		//		FormattedString Nickname; //(implicit string without formating + like class operators)
		//		Group[] Groups;

		//	Ctor(Int ID); //Fetch data from OYSTables.
		//	Ctor(); //We will populate the data ourselves, return a blank user.
		//	Group
		//		Rank[] Ranks;

		//Rank
		//	string name;
		//	int index;

		//	class AutoPromoteTo; //When all these requirements are met, the user will be promoted to this rank!
		//	class ManualPromoteTo; //Notify all subscribers that the user meets promotion requirements.
		//	class AutoDemoteFrom;
		//	class ManualDemoteFrom;
		//	Requirement[] Requirements;
		//	Rank[] NotifyRanks;
		//	OYSRegisteredUser[] NotifyUsers;

		//	DATFile : File
		//	private class Line
		//		Command
		//		Parameters
		//	public class Property
		//		Parameters



		//private interface ICommand
		//	private string[] commands;

		//	private interface IArgument
		//	public object[] arguments

		//protected interface IProperty : ICommand, IArgument
		//	private string[] commands;
		//	public object[] arguments;

		//	public static class HasAfterburer : IProperty
		//	private string[] commands = new string[]("HASAFTBN");
		//	public string[] Commands { get { commands} };
		//	private object[] arguments => new object[] { Value }

		//	public bool Value => arguments[0];

		//	ctor(bool value)
		//	{
		//		Value = value;
		//	}

		//	HasAfterBurner.Value = true;
		//	CockpitPosition.X = 1.Meters();
	}
}

namespace Com.OfficerFlake.IdeaDevelopment
{
	//SETTINGS.DAT
}

