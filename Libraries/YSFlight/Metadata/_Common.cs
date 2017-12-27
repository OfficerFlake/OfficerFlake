using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.YSFlight
{
    public static partial class Metadata
    {
	    public const string YSFlightDirectory = "C:/Games/YSFLIGHT20120701/";
	    public static List<RichTextMessage> DebugInformation = new List<RichTextMessage>();

		public static bool LoadAll()
		{
			DebugInformation.Clear();

		    bool aircraftErrors = !Aircraft.LoadAll();
			if (aircraftErrors) DebugInformation.AddRange(Aircraft.DebugInformation);

		    bool groundErrors = !Ground.LoadAll();
		    if (groundErrors) DebugInformation.AddRange(Aircraft.DebugInformation);

			bool sceneryErrors = !Scenery.LoadAll();
		    if (sceneryErrors) DebugInformation.AddRange(Aircraft.DebugInformation);

		    bool anyErrors = aircraftErrors | groundErrors | sceneryErrors;
			return anyErrors;
	    }
	}
}
