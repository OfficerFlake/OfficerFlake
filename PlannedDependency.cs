//TODO : Refine Dependency (PRIORITY=5)
//LAYERS OF INHERITENCE

//8
//PacketIO : Connection, ConsoleIO, 
//Server : Connection, Packets;

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
//Settings : Color, Settings, DiskIO
//RichTextString : Color, Extensions;
//Equations : CoordinateSystems;

//3
//UnitsOfMeasurement : Extensions-
//Color : Extensions
//Permissions : Extensions
//YSFHQ : Extensions
//YSTypes : Extensions
//CoordinateSystems : Extensions
//Statistics : Extensions
//Packets : Extensions
//DiskIO : Extensions
//	CommandFile Save/Load

//2-
//*SystemExtensions : [1]
//AssemblyLoading : [1]
//	Load(string assemblyName);

//1-
//ExceptionHandling : [0]
//	Log(Exception e);

//0-
//DebugIO
//	AddMessage(string message);
//		If Event Subscribed, Call Event.
//		Else Write To VS Debugger.
//	LinkDebugOutput(delegate method(string));
//	UnlinkDebugOutput(delegate method(string));

//INTERFACES
