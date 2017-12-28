using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class RichTextExtensions
    {
	    public static IRichTextString AsRichTextString(this string input)
	    {
		    return ObjectFactory.CreateRichTextString(input);
	    }
	}
}