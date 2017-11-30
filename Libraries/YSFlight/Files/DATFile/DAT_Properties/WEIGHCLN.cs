﻿using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class WEIGHCLN : DAT_Mass
    {
        public WEIGHCLN(Mass value) : base("WEIGHCLN", value)
        {
        }
    }
}