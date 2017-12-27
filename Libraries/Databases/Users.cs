using Com.OfficerFlake.Libraries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.OfficerFlake.Libraries
{
	public static partial class Database
    {
	    public class User : IUser
	    {
		    public IRichTextString UserName { get; set; }
		    
			public User(IRichTextString _Username)
		    {
				Can = new PermissionsTesting_Can(this);
				Cannot = new PermissionsTesting_Cannot(this);

			    UserName = _Username;
		    }

		    public override string ToString()
		    {
			    return UserName.ToUnformattedSystemString();
		    }

			#region History
		    public IUserHistory History { get; set; }
			public class ExpiringAction : IExpiringAction
		    {
			    public IUser ActionedBy { get; set; }
			    public IDateTime Starts { get; set; }
				public IDateTime Ends { get; set; }
				public IRichTextString Reason { get; set; }

				public ExpiringAction(IUser actionedBy, IDateTime starts, IDateTime ends, IRichTextString reason)
			    {
				    ActionedBy = actionedBy;
				    Starts = starts;
				    Ends = ends;
				    Reason = reason;
			    }
			}
		    public class PermanentAction : IPermanentAction
		    {
			    public IUser ActionedBy { get; set; }
			    public IDateTime ActionedDateTime { get; set; }
				public IRichTextString Reason { get; set; }

				public PermanentAction(IUser actionedBy, IDateTime actioneDateTime, IRichTextString reason)
			    {
				    ActionedBy = actionedBy;
				    ActionedDateTime = actioneDateTime;
				    Reason = reason;
			    }
		    }

			#region Mute
			public IExpiringAction MuteHistory = new ExpiringAction(
				Users.Console,
				(OYSDateTime)DateTime.MinValue,
				(OYSDateTime)DateTime.MinValue,
				ObjectFactory.CreateRichTextString("Never Muted."));
		    public bool isMuted => ((OYSDateTime)DateTime.Now < (OYSDateTime)MuteHistory.Ends);
		    void Mute(User mutedBy, DateTime starts, DateTime ends, IRichTextString reason)
		    {
			    throw new NotImplementedException();
		    }
			#endregion
			#region Freeze
			public ExpiringAction FreezeHistory = new ExpiringAction(
				Users.Console,
				(OYSDateTime)DateTime.MinValue,
				(OYSDateTime)DateTime.MinValue,
				ObjectFactory.CreateRichTextString("Never Frozen."));
		    public bool isFrozen => ((OYSDateTime)DateTime.Now < (OYSDateTime)FreezeHistory.Ends);
			void Freeze(User frozenby, DateTime starts, DateTime ends, IRichTextString reason)
		    {
			    throw new NotImplementedException();
		    }
			#endregion
			#region Kick
			public PermanentAction KickHistory = new PermanentAction(
				Users.Console,
				(OYSDateTime)DateTime.MinValue,
				ObjectFactory.CreateRichTextString("Never Kicked."));
			void Kick(User kickedby, DateTime timestamp, IRichTextString reason)
		    {
				throw new NotImplementedException();
			}
			#endregion
			#region Ban
			public ExpiringAction BanHistory = new ExpiringAction(
				Users.Console, (OYSDateTime)DateTime.MinValue,
				(OYSDateTime)DateTime.MinValue,
				ObjectFactory.CreateRichTextString("Never Banned."));
		    public bool isBanned => ((OYSDateTime)DateTime.Now < (OYSDateTime)FreezeHistory.Ends);
			void Ban(User bannedby, DateTime starts, DateTime ends, IRichTextString reason)
		    {
				throw new NotImplementedException();
			}
			#endregion

		    #region GroupUpdates
		    public class GroupUpdate : IUserGroupUpdate
		    {
			    public IUser ActionedBy { get; set; }
			    public IDateTime ActionedDateTime { get; set; }
				public GroupUpdateType ActionType { get; set; }

			    public IGroup Group { get; set; }
			    public IRank Rank { get; set; }

			    public IRichTextString Reason { get; set; }
		    }
		    public List<IUserGroupUpdate> GroupUpdateHistory { get; set; } = new List<IUserGroupUpdate>();
			#region Add
			private void AddToGroup(IUser addedBy, IGroup groupToAddTo, IDateTime datetime, IRichTextString reason)
		    {
			    GroupUpdateHistory.Add(new GroupUpdate()
			    {
				    ActionedBy = addedBy,
					Group = groupToAddTo,
				    ActionedDateTime = datetime,
				    Reason = reason,
				});
		    }
			#endregion
			#region Remove
		    private void RemoveFromGroup(IUser removedby, IGroup groupToRemoveFrom, IDateTime datetime, IRichTextString reason)
		    {
				GroupUpdateHistory.Add(new GroupUpdate()
				{
					ActionedBy = removedby,
					Group = groupToRemoveFrom,
					ActionedDateTime = datetime,
					Reason = reason,
				});
			}
		    #endregion

			public IRank GetRankInGroupOrNull(IGroup target)
		    {
			    try
				{
					var groupReference = GroupUpdateHistory.Where(x => x.Group == target).OrderBy(y=>y.ActionedDateTime).Last();
					return groupReference.Rank;
				}
			    catch
			    {
				    return null;
			    }
		    }
		    public bool IsCurrentlyInGroup(IGroup group)
		    {
				//Not In the Group
			    if (GroupUpdateHistory.All(x => x.Group != group)) return false;
			    IEnumerable<IUserGroupUpdate> GroupReferences = GroupUpdateHistory.Where(x => x.Group == group).OrderBy(y => y.ActionedDateTime);

				//Was Never Added/Removed. Must be still a member by default.
			    if (GroupReferences.All(x => x.ActionType != GroupUpdateType.Added & x.ActionType != GroupUpdateType.Removed)
			    ) return true;

				//Get al updates that are additions or removals.
			    IUserGroupUpdate GroupReferenceAction = GroupReferences
				    .Where(x => x.ActionType == GroupUpdateType.Added | x.ActionType == GroupUpdateType.Removed)
				    .OrderBy(y => y.ActionedDateTime).Last();

				//if addition, true.
				if (GroupReferenceAction.ActionType == GroupUpdateType.Added) return true;
				//must be a removal.
			    else return false;
		    }
		    #endregion
			#endregion
			#region Perissmions
		    public ILocalPermissions LocalPermissions { get; set; }
				= ObjectFactory.CreateLocalPermissions();
			public ILocalPermissionsTester LocalPermissionsTester { get; set; }
				= ObjectFactory.CreateLocalPermissionsTester(Users.Unknown);

		    public IGlobalPermissions GlobalPermissions { get; set; }
				= ObjectFactory.CreateGlobalPermissions();
		    public IGlobalPermissionsTester GlobalPermissionsTester { get; set; }
				= ObjectFactory.CreateGlobalPermissionsTester(Users.Unknown);

			public class PermissionsTesting_Can
		    {
			    private IUser parent;

			    public PermissionsTesting_Can(IUser parent)
			    {
				    this.parent = parent;
			    }

				public bool Mute(User target)
			    {
				    return parent.GlobalPermissionsTester.Mute(target);
			    }
			    public bool Freeze(User target)
			    {
					return parent.GlobalPermissionsTester.Freeze(target);
				}
			    public bool Kick(User target)
			    {
					return parent.GlobalPermissionsTester.Kick(target);
				}
			    public bool Ban(User target)
			    {
					return parent.GlobalPermissionsTester.Ban(target);
				}

			    public bool AddToGroup(IGroup group, IUser target)
			    {
					return parent.GlobalPermissionsTester.AddToGroup(group, target);
				}
			    public bool RemoveFromGroup(Group group, User target)
			    {
					return parent.GlobalPermissionsTester.RemoveFromGroup(group, target);
				}

			    public bool Promote(Group group, User target)
			    {
					return parent.GlobalPermissionsTester.Promote(group, target);
				}
			    public bool Demote(Group group, User target)
			    {
					return parent.GlobalPermissionsTester.Demote(group, target);
				}
			}
		    public PermissionsTesting_Can Can;

		    public class PermissionsTesting_Cannot
		    {
				private IUser parent;

			    public PermissionsTesting_Cannot(IUser parent)
			    {
				    this.parent = parent;
			    }

			    public bool Mute(User target)
			    {
				    return !parent.GlobalPermissionsTester.Mute(target);
			    }
			    public bool Freeze(User target)
			    {
				    return !parent.GlobalPermissionsTester.Freeze(target);
			    }
			    public bool Kick(User target)
			    {
				    return !parent.GlobalPermissionsTester.Kick(target);
			    }
			    public bool Ban(User target)
			    {
				    return !parent.GlobalPermissionsTester.Ban(target);
			    }

			    public bool AddToGroup(User target, Group group)
			    {
				    return !parent.GlobalPermissionsTester.AddToGroup(group, target);
			    }
			    public bool RemoveFromGroup(User target, Group group)
			    {
				    return !parent.GlobalPermissionsTester.RemoveFromGroup(group, target);
				}

			    public bool Promote(User target, Group group)
			    {
				    return !parent.GlobalPermissionsTester.Promote(group, target);
				}
			    public bool Demote(User target, Group group)
			    {
				    return !parent.GlobalPermissionsTester.Demote(group, target);
				}
			}
		    public PermissionsTesting_Cannot Cannot;
			#endregion
			#region Actions
		    public void Mute(IUser mutedBy, ITimeSpan duration = null, IRichTextString reason = null)
		    {
				MuteHistory = new ExpiringAction(
					mutedBy,
					(OYSDateTime)DateTime.Now,
					(OYSDateTime)(DateTime.Now + (duration ?? (OYSTimeSpan)TimeSpan.MaxValue).ToTimeSpan()), 
					reason ?? ObjectFactory.CreateRichTextString("No Reason.")
					);
		    }
			public void Freeze(IUser frozenBy, ITimeSpan duration = null, IRichTextString reason = null)
			{
				FreezeHistory = new ExpiringAction(frozenBy,
					(OYSDateTime)DateTime.Now,
					(OYSDateTime)(DateTime.Now + (duration ?? (OYSTimeSpan)TimeSpan.MaxValue).ToTimeSpan()),
					reason ?? ObjectFactory.CreateRichTextString("No Reason.")
					);
			}
			public void Kick(IUser kickedBy, IRichTextString reason = null)
		    {
			    KickHistory = new PermanentAction(
					kickedBy,
					(OYSDateTime)DateTime.Now,
					reason ?? ObjectFactory.CreateRichTextString("No Reason.")
					);
		    }
		    public void Ban(IUser bannedBy, ITimeSpan duration = null, IRichTextString reason = null)
		    {
			    BanHistory = new ExpiringAction(
					bannedBy,
					(OYSDateTime)DateTime.Now,
					(OYSDateTime)(DateTime.Now + (duration ?? (OYSTimeSpan)TimeSpan.MaxValue).ToTimeSpan()),
					reason ?? ObjectFactory.CreateRichTextString("No Reason.")
					);
		    }

		    public void AddToGroup(IUser addedBy, IGroup group, IRichTextString reason = null)
		    {
			    if (IsCurrentlyInGroup(group)) return; //Currently a member, no need to add again.
			    GroupUpdateHistory.Add(
					new GroupUpdate()
					{
						Group = group,
						Rank = group.GetLowestRank(),

						ActionedBy = addedBy,
						ActionedDateTime = new OYSDateTime(DateTime.Now),

						Reason = reason ?? ObjectFactory.CreateRichTextString("No Reason.")
					}
					);
		    }
		    public void RemoveFromGroup(IUser addedBy, IGroup group, IRichTextString reason = null)
		    {
			    if (!IsCurrentlyInGroup(group)) return; //Not even in the group.
			    GroupUpdateHistory.Add(
				    new GroupUpdate()
				    {
					    Group = group,
						Rank = group.GetLowestRank(),

						ActionedBy = addedBy,
					    ActionedDateTime = (OYSDateTime)DateTime.Now,

					    Reason = reason ?? ObjectFactory.CreateRichTextString("No Reason.")
					}
			    );
		    }

		    public void Promote(IUser promotedBy, IGroup group, IRichTextString reason = null)
		    {
				if (!IsCurrentlyInGroup(group)) return; //Not in the group. Can't promote!
			    IRank currentRank = GetRankInGroupOrNull(group) ?? group.GetLowestRank();
			    IRank newRank = group.GetNextHigherRank(currentRank);

			    GroupUpdateHistory.Add(
				    new GroupUpdate()
				    {
					    Group = group,
						Rank = newRank,

					    ActionedBy = promotedBy,
					    ActionedDateTime = new OYSDateTime(DateTime.Now),

					    Reason = reason ?? ObjectFactory.CreateRichTextString("No Reason.")
					}
			    );
			}
		    public void Demote(IUser demotedBy, IGroup group, IRichTextString reason = null)
		    {
			    if (!IsCurrentlyInGroup(group)) return; //Not in the group. Can't demote!
			    IRank currentRank = GetRankInGroupOrNull(group) ?? group.GetLowestRank();
			    IRank newRank = group.GetNextLowerRank(currentRank);

			    GroupUpdateHistory.Add(
				    new GroupUpdate()
				    {
					    Group = group,
					    Rank = newRank,

					    ActionedBy = demotedBy,
					    ActionedDateTime = new OYSDateTime(DateTime.Now),

						Reason = reason ?? ObjectFactory.CreateRichTextString("No Reason.")
					}
			    );
		    }
			#endregion
		}

	    public static class Users
	    {
		    public static User Unknown = new User(ObjectFactory.CreateRichTextString("&o&4<UNKNOWN>"));
		    public static User Console = new User(ObjectFactory.CreateRichTextString("&o&3<OpenYS Console>"))
		    {
			    GroupUpdateHistory = new List<IUserGroupUpdate>()
			    {
				    new User.GroupUpdate()
				    {
					    Group = Groups.Server,
						Rank = Ranks.ServerRankAdmin
				    }
			    }
		    };
		    public static User TestUser = new User(ObjectFactory.CreateRichTextString("TestUser"));
	    }
    }
}
