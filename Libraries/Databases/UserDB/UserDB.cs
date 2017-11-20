using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.RichText;
using static Com.OfficerFlake.Libraries.Extensions.Byte;

namespace Com.OfficerFlake.Libraries.Databases
{
    public class UserDB
    {
	    public class UserObject
	    {
		    public class YSFHQConnectionModule
		    {
			    public int ID = -1;
			    public IPAddress IpAddress = IPAddress.Loopback;
			    public string Username = "<UNKNOWN>";
			    public string Password = "???";

			    public bool TryAuthenticate()
			    {
				    WebClient thisWebClient = new WebClient();

				    NameValueCollection parameters = new NameValueCollection();

				    string hashedPassword = "";

				    #region HashPassword
				    using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
				    {
					    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Password);
					    byte[] hashBytes = md5.ComputeHash(inputBytes);

					    // Convert the byte array to hexadecimal string
					    StringBuilder sb = new StringBuilder();
					    for (int i = 0; i < hashBytes.Length; i++)
					    {
						    sb.Append(hashBytes[i].ToString("X2"));
					    }
					    hashedPassword = sb.ToString();
				    }
				    #endregion

				    parameters["username"] = Username;
				    parameters["password"] = Password;
				    //parameters["password"] = hashedPassword;


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
			public YSFHQConnectionModule YSFHQ = new YSFHQConnectionModule();

		    public RichTextString Username;

		    public UserObject(RichTextString _Username)
		    {
			    Username = _Username;
		    }
	    }

	    public static UserObject Unknown = new UserObject("&o&4<UNKNOWN>".AsRichTextString());
	    public static UserObject Console = new UserObject("&o&3<OpenYS Console>".AsRichTextString());
	    public static UserObject TestUser = new UserObject("TestUser".AsRichTextString());
	}
}
