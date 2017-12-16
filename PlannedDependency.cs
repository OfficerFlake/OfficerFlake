//TODO : Refine Dependency (PRIORITY=5)
//LAYERS OF INHERITENCE

//8
//PacketIO : Connection(?)
//Server

//7
//MetaData : ConsoleIO
//World : ConsoleIO
//DATFile : DiskIO, YSTypes
//LSTFile : DiskIO, YSTypes
//Connection : ConsoleIO, Packets
//ConsoleUI : ConsoleIO, RichTextMessage
//DebugUI : DebugIO. RichTextMessage

//6
//ConsoleIO : RichTextMessage
//	AddMessage(RichTextMessage message);

//6
//RichTextMessage : Database
//	ref User

//5
//Database : RichTextString, Permissions

//4
//Settings : UnitsOfMeasurement, Color
//RichTextString : Color;
//Equations : CoordinateSystems

//3
//UnitsOfMeasurement
//Color
//Permissions
//YSFHQ
//YSTypes
//CoordinateSystems
//Statistics
//Packets
//DiskIO
//	CommandFile Save/Load

//2
//*SystemExtensions : ExceptionHandling(1);
//AssemblyLoading : ExceptionHandling(1)
//	Load(string assemblyName);

//1
//ExceptionHandling : DebugIO(0);
//	Log(Exception e);

//0
//DebugIO
//	AddMessage(string message);
//		If Event Subscribed, Call Event.
//		Else Write To VS Debugger.
//	LinkDebugOutput(delegate method(string));
//	UnlinkDebugOutput(delegate method(string));
