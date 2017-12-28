using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class Users
    {
	    public static IUser Console => ObjectFactory.GetUserConsole;
	    public static IUser None => ObjectFactory.GetUserNone;
	}
}