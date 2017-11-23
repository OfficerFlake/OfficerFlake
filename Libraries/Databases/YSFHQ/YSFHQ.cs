using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.YSFHQ
{
    public class YSFHQConnection
    {
	    public int ID = -1;
	    public IPAddress IpAddress = IPAddress.Loopback;
	    public string Username = "<UNKNOWN>";
	    public string Password = "???";

	    public bool TryAuthenticate()
	    {
		    WebClient thisWebClient = new WebClient();

		    NameValueCollection parameters = new NameValueCollection();

		    parameters["username"] = Username;
		    parameters["password"] = Password;

		    byte[] response;

		    try
		    {
			    //NEED HTTPS otherwise will return 400.
			    response = thisWebClient.UploadValues(
				    "https://forum.ysfhq.com/api-login.php?apikey=X0kSNLfV78QE6sd618Mkc7I07Z87wDiIgpdvT15KgcVun2BjLjFtEyWDz1LtY5Zs",
				    "POST", parameters);
		    }
		    catch
		    {
			    return false;
		    }

		    string returnedUserID = Encoding.ASCII.GetString(response);

		    int _userID = -1;

		    Int32.TryParse(returnedUserID.CleanString(), out _userID);

		    if (_userID > 0) ID = _userID;

		    return (_userID > 0);
	    }
	}
}
