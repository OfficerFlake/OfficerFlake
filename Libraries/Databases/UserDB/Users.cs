using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Com.OfficerFlake.Libraries.RichText;

namespace Com.OfficerFlake.Libraries
{
	public static partial class Database
    {
	    public class User
	    {
			public YSFHQConnection YSFHQ = new YSFHQConnection();
		    public RichTextString Username;

		    public User(RichTextString _Username)
		    {
			    Username = _Username;
		    }

			#region History
			//Actions on User level.
			public class ExpiringAction
		    {
			    public User ActionedBy;
			    public DateTime Starts;
			    public DateTime Ends;
			    public RichTextString Reason;

			    public ExpiringAction(User actionedBy, DateTime starts, DateTime ends, RichTextString reason)
			    {
				    ActionedBy = actionedBy;
				    Starts = starts;
				    Ends = ends;
				    Reason = reason;
			    }
		    }
		    public class PermanentAction
		    {
			    public User ActionedBy;
			    public DateTime Timestamp;
			    public RichTextString Reason;

			    public PermanentAction(User actionedBy, DateTime timestamp, RichTextString reason)
			    {
				    ActionedBy = actionedBy;
				    Timestamp = timestamp;
				    Reason = reason;
			    }
		    }

			#region Mute
			public ExpiringAction MuteHistory = new ExpiringAction(Users.Console, DateTime.MinValue, DateTime.MinValue, "Never Muted.".AsRichTextString());
		    public bool isMuted => (DateTime.Now < MuteHistory.Ends);
		    void Mute(User mutedBy, DateTime starts, DateTime ends, RichTextString reason)
		    {
			    throw new NotImplementedException();
		    }
			#endregion
			#region Freeze
			public ExpiringAction FreezeHistory = new ExpiringAction(Users.Console, DateTime.MinValue, DateTime.MinValue, "Never Frozen.".AsRichTextString());
		    public bool isFrozen => (DateTime.Now < FreezeHistory.Ends);
			void Freeze(User frozenby, DateTime starts, DateTime ends, RichTextString reason)
		    {
			    throw new NotImplementedException();
		    }
			#endregion
			#region Kick
			public PermanentAction KickHistory = new PermanentAction(Users.Console, DateTime.MinValue,  "Never Kicked.".AsRichTextString());
			void Kick(User kickedby, DateTime timestamp, RichTextString reason)
		    {
				throw new NotImplementedException();
			}
			#endregion
			#region Ban
			public ExpiringAction BanHistory = new ExpiringAction(Users.Console, DateTime.MinValue, DateTime.MinValue, "Never Banned.".AsRichTextString());
		    public bool isBanned => (DateTime.Now < FreezeHistory.Ends);
			void Ban(User bannedby, DateTime starts, DateTime ends, RichTextString reason)
		    {
				throw new NotImplementedException();
			}
			#endregion

		    #region Groups
		    public class GroupReference
		    {
			    public Group Group;
			    public User ActionedBy;
			    public RichTextString Reason;

			    //Actions on Group level.
			    #region Add
			    void AddToGroup(User addedBy, Group groupToAddTo, DateTime timestamp, RichTextString reason)
			    {
				    throw new NotImplementedException();
			    }
			    #endregion
			    #region Remove
			    void RemoveFromGroup(User removedby, Group groupToRemoveFrom, DateTime timestamp, RichTextString reason)
			    {
				    throw new NotImplementedException();
			    }
			    #endregion

			    //Rank
			    #region Rank
			    public class _RankReference
			    {
				    public Rank Rank;
				    public User ActionedBy;
				    public RichTextString Reason;

				    //Actions on Rank level.
				    #region Promote

				    void Promote(User promotedBy, Rank rankToPromoteTo, DateTime timestamp, RichTextString reason)
				    {
					    throw new NotImplementedException();
				    }

				    #endregion
				    #region Demote

				    void Demote(User demotedBy, Rank rankToDemoteTo, DateTime timestamp, RichTextString reason)
				    {
					    throw new NotImplementedException();
				    }

				    #endregion
			    }
			    #endregion
			    public _RankReference RankReference = null;
		    }

		    public Rank GetRankInGroupOrNull(Group target)
		    {
			    try
			    {
				    GroupReference groupReference = Groups.Where(x => x.Group == target).First();
				    return groupReference.RankReference.Rank;
			    }
			    catch
			    {
				    return null;
			    }
		    }
		    #endregion
		    public List<GroupReference> Groups = new List<GroupReference>();
			#endregion
			#region Perissmions
			public bool Can(Permission action, User target, Group scope = null)
			{
				#region Permissions maximum rank is -1, and the "Must Outrank" rule is false. Will always have permission. RETURN TRUE.

				if (scope == null) scope = Database.Groups.Server;

				if (action.MaximumRank <= -1 && !action.MustOutrank) return true; //permission always enabled.
				#endregion

				#region Caller is not a member of the group. RETURN FALSE.
				Rank ActorsRank = GetRankInGroupOrNull(scope);
				if (ActorsRank == null) return false; //not a member of the group to begin with...
				#endregion
				#region Permissions minimum rank must be above -1 to be enabled. RETURN FALSE.
				if (action.MinimumRank <= -1) return false; //permission disabled.
				#endregion
				#region Caller doesn't outrank target. RETURN FALSE.
				#region Set TargetRank to Minimum if not in the group.
				Rank TargetRank = GetRankInGroupOrNull(scope);
				if (TargetRank == null) TargetRank = scope.Ranks.OrderBy(x=>x.Index).First(); //not a member of the group to begin with...
				#endregion

				int ActorRankNumber = 0;
				int TargetRankNumber = 0;

				ActorRankNumber = ActorsRank.Index;
				TargetRankNumber = TargetRank.Index;

				bool Outranks = (ActorRankNumber > TargetRankNumber);
				if (!Outranks) return false;
				#endregion
				#region Targets Rank is outside permissions scope. RETURN FALSE.
				if (TargetRankNumber < action.MinimumRank) return false; //Target rank is below minimum allowed.
				if (TargetRankNumber > action.MaximumRank) return false; //Target rank is above maximum allowed.
				#endregion

				#region Tested permissions and all is okay. RETURN TRUE.
				return true;
				#endregion
			}
		    public bool Cannot(Permission action, User target, Group scope = null)
		    {
			    return !Can(action, target, scope);
		    }
			#endregion
		}

	    public static class Users
	    {
		    public static User Unknown = new User("&o&4<UNKNOWN>".AsRichTextString());
		    public static User Console = new User("&o&3<OpenYS Console>".AsRichTextString())
		    {
			    Groups = new List<User.GroupReference>()
			    {
				    new User.GroupReference()
				    {
					    Group = Groups.Server,
						RankReference = new User.GroupReference._RankReference()
						{
							Rank = Ranks.ServerRankAdmin
						}
				    }
			    }
		    };
		    public static User TestUser = new User("TestUser".AsRichTextString())
		    {
			    Groups = new List<User.GroupReference>()
			    {
				    new User.GroupReference()
				    {
					    Group = Groups.Server,
					    RankReference = new User.GroupReference._RankReference()
					    {
						    Rank = Ranks.ServerRankGuest
						}
				    }
			    }
		    };
	    }
    }
}
