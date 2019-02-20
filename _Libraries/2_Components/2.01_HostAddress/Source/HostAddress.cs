﻿using System;
using System.Net;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Loggers;

namespace Com.OfficerFlake.Libraries.Networking
{
    public class HostAddress : IHostAddress
    {
	    public HostAddress(IPAddress IP)
	    {
		    IpAddress = IP;
		    ResolvedAddress = IP.ToString();
	    }
	    public HostAddress(string DomainName)
	    {
		    try
		    {
			    IpAddress = Dns.GetHostAddresses(DomainName)[0];
		    }
		    catch (Exception e)
		    {
			    Debug.AddWarningMessage("Couldn't resolve domain name: \"" + DomainName + "\".");
			    IpAddress = IPAddress.None;
		    }
		    ResolvedAddress = DomainName;
	    }

		public IPAddress IpAddress { get; set; }
		private String ResolvedAddress { get; set; }

	    public override string ToString()
	    {
		    return ResolvedAddress;
	    }
	}
}
