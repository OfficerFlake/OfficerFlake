using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class Users
    {
	    public static IUser Console { get; } = ObjectFactory.CreateUser("&3&oConsole".AsRichTextString());
	    public static IUser None { get; } = ObjectFactory.CreateUser("None".AsRichTextString());
	}
}