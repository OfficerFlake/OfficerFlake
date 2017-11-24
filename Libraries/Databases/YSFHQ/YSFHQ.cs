using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.YSFHQ
{
    public static class YSFHQ
	{
		/// <summary>
		/// Tries to authorise the given Username and Password with YSFLight Headquarters.
		/// </summary>
		/// <param name="Username">YSFHQ Username</param>
		/// <param name="Password">YSFHQ Password</param>
		/// <returns>
		/// UserID : Positive Integer giving UserID if Authentication Success.
		/// -401 : API Key Invalid, Authentication Request rejected.
		/// -400 : Didn't use HTTPS or didn't supply a username/password.
		/// -403 : Username/Password invalid.
		/// -500 : Any other type of HTTP Error Code (Cloudflare error? API recalled? Who knows...)
		/// -503 : This Authentication program has an error.
		/// </returns>
		public static int TryAuthenticate(string Username, string Password)
		{
			try
			{
				//Please do not use this API Key for your own purposes! Contact the Website Engineers at YSFHQ to get your own.
				string APIKey = "X0kSNLfV78QE6sd618Mkc7I07Z87wDiIgpdvT15KgcVun2BjLjFtEyWDz1LtY5Zs";

				WebClient thisWebClient = new WebClient();

				NameValueCollection parameters = new NameValueCollection();

				parameters["username"] = Username;
				parameters["password"] = Password;

				byte[] response;

				try
				{
					//NEED HTTPS otherwise will return 400.
					response = thisWebClient.UploadValues(
						"https://forum.ysfhq.com/api-login.php?apikey=" + APIKey,
						"POST", parameters);
				}
				catch (WebException e)
				{
					HttpStatusCode status = (e.Response as HttpWebResponse)?.StatusCode ?? HttpStatusCode.InternalServerError;

					switch (status)
					{
						case HttpStatusCode.Unauthorized:
							return -401; //API Key Invalid.
						case HttpStatusCode.BadRequest:
							return -400; //Request username/password length 0 or not HTTPS.
						case HttpStatusCode.Forbidden:
							return -403; //Bad Username/Password.
						default:
							return -500; //Some kind of Error.
					}
				}

				string returnedUserID = Encoding.UTF8.GetString(response);

				int _userID = -1;

				Int32.TryParse(returnedUserID.CleanString(), out _userID);

				if (_userID > 0) return _userID;
			}
			catch
			{
			}
			return -503; //Authentication unavailable due to coding error.
		}
	}
}
