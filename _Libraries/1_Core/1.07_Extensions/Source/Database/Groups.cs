using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class Groups
    {
	    public static IGroup None { get; }  = ObjectFactory.CreateGroup("None".AsRichTextString());
    }
}