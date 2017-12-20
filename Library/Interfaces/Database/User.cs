using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	#region Users
	public interface IUser
	{
		IRichTextString UserName { get; set; }
		IUserHistory History { get; set; }

		string ToString();
	}
	#region History
	public interface IUserHistory
	{
		List<IPermanentAction> NameChangeHistory { get; set; }

		#region Administrative
		List<IExpiringAction> MuteHistory { get; set; }
		int TotalTimesMuted { get; }

		List<IExpiringAction> FreezeHistory { get; set; }
		int TotalTimesFrozen { get; }

		List<IPermanentAction> KickHistory { get; set; }
		int TotalTimesKicked { get; }

		List<IExpiringAction> BanHistory { get; set; }
		int TotalTimesBanned { get; }
		#endregion

		List<IUserGroupUpdate> GroupUpdateHistory { get; set; }

		IDateTime DateTimeFirstJoined { get; set; }
		IDateTime DateTimeLastSeen { get; set; }
		ITimeSpan TotalTimeOnline { get; set; }

		#region Messages
		int TotalChatMessagesTyped { get; set; }
		int TotalCommandsTyped { get; set; }
		#endregion

		#region Flights
		ITimeSpan TotalTimeFlight { get; set; }
		int TotalFlights { get; set; }
		int TotalLandings { get; set; }
		int TotalCrashes { get; set; }
		#endregion
	}
	#region Administrative
	public interface IExpiringAction
	{
		IUser ActionedBy { get; }
		IDateTime Starts { get; }
		IDateTime Ends { get; }
		IRichTextString Reason { get; }
	}
	public interface IPermanentAction
	{
		IUser ActionedBy { get; }
		IDateTime ActionedDateTime { get; }
		IRichTextString Reason { get; }
	}
	#endregion
	#region Group History
	public interface IUserGroupUpdate
	{
		IGroup Group { get; set; }
		IRank Rank { get; set; }
		
		IUser ActionedBy { get; set; }
		IDateTime ActionedDateTime { get; set; }
		GroupUpdateType ActionType { get; set; }
		IRichTextString Reason { get; set; }
	}
	public enum GroupUpdateType
	{
		Added,
		Promoted,
		Demoted,
		Removed,
	}
	#endregion
	#endregion
	#endregion
}
