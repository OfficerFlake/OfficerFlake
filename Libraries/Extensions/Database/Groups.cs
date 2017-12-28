using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class Groups
    {
	    public static IGroup None => ObjectFactory.GetGroupNone;
	}
}