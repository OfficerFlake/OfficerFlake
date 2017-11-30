﻿using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class HTRADIUS : DAT_Length
    {
        public HTRADIUS(Length value) : base("HTRADIUS", value)
        {
        }
    }
}