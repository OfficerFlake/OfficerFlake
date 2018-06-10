using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class RichTextExtensions
    {
	    public static IRichTextString AsRichTextString(this string input) => ObjectFactory.CreateRichTextString(input);

	    public static IConsoleUserMessage AsConsoleUserMessage(this string input, IUser user) => ObjectFactory.CreateConsoleUserMessage(user, input.AsRichTextString());
	    public static IConsoleInformationMessage AsConsoleInformationMessage(this string input) => ObjectFactory.CreateConsoleInformationMessage(input.AsRichTextString());

	    public static IDebugSummaryMessage AsDebugSummaryMessage(this string input) => ObjectFactory.CreateDebugSummaryMessage(input.AsRichTextString());
	    public static IDebugDetailMessage AsDebugDetailMessage(this string input) => ObjectFactory.CreateDebugDetailMessage(input.AsRichTextString());
	    public static IDebugWarningMessage AsDebugWarningMessage(this string input) => ObjectFactory.CreateDebugWarningMessage(input.AsRichTextString());
	    public static IDebugErrorMessage AsDebugErrorMessage(this string input, Exception e) => ObjectFactory.CreateDebugErrorMessage(e, input.AsRichTextString());
	    public static IDebugCrashMessage AsDebugCrashMessage(this string input, Exception e) => ObjectFactory.CreateDebugCrashMessage(e, input.AsRichTextString());
	}
}