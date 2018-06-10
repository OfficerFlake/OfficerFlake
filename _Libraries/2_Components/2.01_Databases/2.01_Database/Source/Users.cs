using Com.OfficerFlake.Libraries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.Database
{
	public class User : IUser
	{
		public IRichTextString UserName { get; set; }

		public IConnection Connection { get; set; }

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
			Users.None,
			DateTime.MinValue.ToDateTime(),
			DateTime.MinValue.ToDateTime(),
			"Never Muted.".AsRichTextString());
		public bool isMuted => (DateTime.Now.ToDateTime().ToSystemDateTime() < MuteHistory.Ends.ToSystemDateTime());
		void Mute(User mutedBy, DateTime starts, DateTime ends, IRichTextString reason)
		{
			throw new NotImplementedException();
		}
		#endregion
		#region Freeze
		public ExpiringAction FreezeHistory = new ExpiringAction(
			Users.None,
			DateTime.MinValue.ToDateTime(),
			DateTime.MinValue.ToDateTime(),
			"Never Frozen.".AsRichTextString());
		public bool isFrozen => (DateTime.Now.ToDateTime().ToSystemDateTime() < FreezeHistory.Ends.ToSystemDateTime());
		void Freeze(User frozenby, DateTime starts, DateTime ends, IRichTextString reason)
		{
			throw new NotImplementedException();
		}
		#endregion
		#region Kick
		public PermanentAction KickHistory = new PermanentAction(
			Users.None,
			DateTime.MinValue.ToDateTime(),
			"Never Kicked.".AsRichTextString());
		void Kick(User kickedby, DateTime timestamp, IRichTextString reason)
		{
			throw new NotImplementedException();
		}
		#endregion
		#region Ban
		public ExpiringAction BanHistory = new ExpiringAction(
			Users.Console,
			DateTime.MinValue.ToDateTime(),
			DateTime.MinValue.ToDateTime(),
			"Never Banned.".AsRichTextString());
		public bool isBanned => (DateTime.Now.ToDateTime().ToSystemDateTime() < BanHistory.Ends.ToSystemDateTime());
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
				var groupReference = GroupUpdateHistory.Where(x => x.Group == target).OrderBy(y => y.ActionedDateTime).Last();
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
		public IPermissions Permissions { get; set; }

		public class PermissionsTesting_Can
		{
			private IUser parent;

			public PermissionsTesting_Can(IUser parent)
			{
				this.parent = parent;
			}

			public bool Mute(User target)
			{
				return parent.Permissions.GlobalPermissionsTester.Mute(target);
			}
			public bool Freeze(User target)
			{
				return parent.Permissions.GlobalPermissionsTester.Freeze(target);
			}
			public bool Kick(User target)
			{
				return parent.Permissions.GlobalPermissionsTester.Kick(target);
			}
			public bool Ban(User target)
			{
				return parent.Permissions.GlobalPermissionsTester.Ban(target);
			}

			public bool AddToGroup(IGroup group, IUser target)
			{
				return parent.Permissions.GlobalPermissionsTester.AddToGroup(group, target);
			}
			public bool RemoveFromGroup(Group group, User target)
			{
				return parent.Permissions.GlobalPermissionsTester.RemoveFromGroup(group, target);
			}

			public bool Promote(Group group, User target)
			{
				return parent.Permissions.GlobalPermissionsTester.Promote(group, target);
			}
			public bool Demote(Group group, User target)
			{
				return parent.Permissions.GlobalPermissionsTester.Demote(group, target);
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
				return !parent.Permissions.GlobalPermissionsTester.Mute(target);
			}
			public bool Freeze(User target)
			{
				return !parent.Permissions.GlobalPermissionsTester.Freeze(target);
			}
			public bool Kick(User target)
			{
				return !parent.Permissions.GlobalPermissionsTester.Kick(target);
			}
			public bool Ban(User target)
			{
				return !parent.Permissions.GlobalPermissionsTester.Ban(target);
			}

			public bool AddToGroup(User target, Group group)
			{
				return !parent.Permissions.GlobalPermissionsTester.AddToGroup(group, target);
			}
			public bool RemoveFromGroup(User target, Group group)
			{
				return !parent.Permissions.GlobalPermissionsTester.RemoveFromGroup(group, target);
			}

			public bool Promote(User target, Group group)
			{
				return !parent.Permissions.GlobalPermissionsTester.Promote(group, target);
			}
			public bool Demote(User target, Group group)
			{
				return !parent.Permissions.GlobalPermissionsTester.Demote(group, target);
			}
		}
		public PermissionsTesting_Cannot Cannot;
		#endregion

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


		#region Actions
		public void Mute(IUser mutedBy, ITimeSpan duration = null, IRichTextString reason = null)
		{
			MuteHistory = new ExpiringAction(
				mutedBy,
				DateTime.Now.ToDateTime(),
				(DateTime.Now + (duration ?? TimeSpan.MaxValue.ToTimeSpan()).ToSystemTimeSpan()).ToDateTime(), 
				reason ?? "No Reason.".AsRichTextString()
				);
		}
		public void Freeze(IUser frozenBy, ITimeSpan duration = null, IRichTextString reason = null)
		{
			FreezeHistory = new ExpiringAction(
				frozenBy,
				DateTime.Now.ToDateTime(),
				(DateTime.Now + (duration ?? TimeSpan.MaxValue.ToTimeSpan()).ToSystemTimeSpan()).ToDateTime(),
				reason ?? "No Reason.".AsRichTextString()
				);
		}
		public void Kick(IUser kickedBy, IRichTextString reason = null)
		{
			KickHistory = new PermanentAction(
				kickedBy,
				DateTime.Now.ToDateTime(),
				reason ?? "No Reason.".AsRichTextString()
				);
		}
		public void Ban(IUser bannedBy, ITimeSpan duration = null, IRichTextString reason = null)
		{
			BanHistory = new ExpiringAction(
				bannedBy,
				DateTime.Now.ToDateTime(),
				(DateTime.Now + (duration ?? TimeSpan.MaxValue.ToTimeSpan()).ToSystemTimeSpan()).ToDateTime(),
				reason ?? "No Reason.".AsRichTextString()
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
					ActionedDateTime = DateTime.Now.ToDateTime(),

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
					ActionedDateTime = DateTime.Now.ToDateTime(),

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
					ActionedDateTime = DateTime.Now.ToDateTime(),

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
					ActionedDateTime = DateTime.Now.ToDateTime(),

					Reason = reason ?? ObjectFactory.CreateRichTextString("No Reason.")
				}
			);
		}
		#endregion
	}
}
