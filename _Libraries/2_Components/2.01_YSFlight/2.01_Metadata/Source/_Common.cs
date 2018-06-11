using System.Collections.Generic;

using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight
{
    public static partial class Metadata
    {
		public static bool LoadAll()
		{
		    bool aircraftErrors = !Aircraft.LoadAll();
		    bool groundErrors = !Ground.LoadAll();
			bool sceneryErrors = !Scenery.LoadAll();

		    bool anyErrors = aircraftErrors | groundErrors | sceneryErrors;
			return anyErrors;
	    }
	}
}
