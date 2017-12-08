using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.RichText;

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
