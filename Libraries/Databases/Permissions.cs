using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Database
{
    public class Permission : IPermission
    {
		/// <summary>
		/// The minimum rank index in own group category that the user can action against.
		/// </summary>
		public int MinimumRank { get; set; }

		/// <summary>
		/// the maximum rank index in own group category that the user can action against.
		/// </summary>
		public int MaximumRank { get; set; }

		/// <summary>
		/// Safeguard: Should the user be prevented from acting on users of the same rank?
		/// </summary>
		public bool MustOutrank { get; set; }

		/// <summary>
		/// Create a new Permission Definition.
		/// </summary>
		/// <param name="minimumRank">Minimum rank the permission can act on. Set to -1 to disable permission entirely.</param>
		/// <param name="maximumRank">Maximum rank the permission can act on. Set to -1 to allow to act on all ranks, limited if mustOutrank = true.</param>
		/// <param name="mustOutrank">If true, the user asking for permission must outrank the target.</param>
		public Permission(int minimumRank, int maximumRank, bool mustOutrank = true)
	    {
		    MinimumRank = minimumRank;
		    MaximumRank = maximumRank;
		    MustOutrank = mustOutrank;
	    }

	    public Permission()
	    {
		    MinimumRank = -1;
		    MaximumRank = -1;
		    MustOutrank = true;
	    }
    }

	public class LocalPermissions : ILocalPermissions
	{
		public IPermissions Owner { get; set; }

		#region Users
		public IPermission Hide { get; set; } = new Permission(0,0,true);
		public IPermission UnHide { get; set; } = new Permission(0, 0, true);
		public IPermission ChangeUsername { get; set; } = new Permission(0, 0, true);
		#endregion
		#region Groups
		public IPermission OpenGroup { get; set; } = new Permission(0, 0, true);
		public IPermission AddToGroup { get; set; } = new Permission(0, 0, true);
		public IPermission ChangeGroupsOwnership { get; set; } = new Permission(0, 0, true);
		public IPermission ChangeGroupsName { get; set; } = new Permission(0, 0, true);
		public IPermission RemoveFromGroup { get; set; } = new Permission(0, 0, true);
		public IPermission CloseGroup { get; set; } = new Permission(0, 0, true);
		#endregion
		#region Ranks
		public IPermission AddRank { get; set; } = new Permission(0, 0, true);
		public IPermission Promote { get; set; } = new Permission(0, 0, true);
		public IPermission ChangeRanksName { get; set; } = new Permission(0, 0, true);
		public IPermission ChangeRanksIndex { get; set; } = new Permission(0, 0, true);
		public IPermission Demote { get; set; } = new Permission(0, 0, true);
		public IPermission DeleteRank { get; set; } = new Permission(0, 0, true);
		#endregion
		#region Permissions
		public IPermission ChangePermissionsMininimumRank { get; set; } = new Permission(0, 0, true);
		public IPermission ChangePermissionsMaximumRank { get; set; } = new Permission(0, 0, true);
		public IPermission ChangePermissionsMustOutrank { get; set; } = new Permission(0, 0, true);
		#endregion
	}
	public class GlobalPermissions : IGlobalPermissions
	{
		public IPermissions Owner { get; set; }

		#region Users
		public IPermission Mute { get; set; } = new Permission(0, 0, true);
		public IPermission Freeze { get; set; } = new Permission(0, 0, true);
		public IPermission Kick { get; set; } = new Permission(0, 0, true);
		public IPermission Ban { get; set; } = new Permission(0, 0, true);
		#endregion
		#region Groups
		public IPermission AddGroups { get; set; } = new Permission(0, 0, true);
		public IPermission OpenGroups { get; set; } = new Permission(0, 0, true);
		public IPermission ChangeGroupNames { get; set; } = new Permission(0, 0, true);
		public IPermission ChangeGroupOwners { get; set; } = new Permission(0, 0, true);
		public IPermission CloseGroup { get; set; } = new Permission(0, 0, true);
		public IPermission DeleteGroups { get; set; } = new Permission(0, 0, true);
		#endregion
		#region Ranks
		public IPermission AddRanksToGroups { get; set; } = new Permission(0, 0, true);
		public IPermission ChangeRankNames { get; set; } = new Permission(0, 0, true);
		public IPermission ChangeRankIndexes { get; set; } = new Permission(0, 0, true);
		public IPermission DeleteRanksFromGroups { get; set; } = new Permission(0, 0, true);
		#endregion
		#region Permissions
		public IPermission ChangePermissionMininimumRanks { get; set; } = new Permission(0, 0, true);
		public IPermission ChangePermissionMaximumRanks { get; set; } = new Permission(0, 0, true);
		public IPermission ChangePermissionMustOutranks { get; set; } = new Permission(0, 0, true);
		#endregion

		public GlobalPermissions()
		{
			Mute = new Permission();
		}
	}
	public class LocalPermissionsTester : ILocalPermissionsTester
	{
		public IPermissions Owner { get; set; }

		#region Manage User
		public bool Hide(IUser user) { throw new NotImplementedException(); }
		public bool UnHide(IUser user) { throw new NotImplementedException(); }
		public bool ChangeUsername(IUser user) { throw new NotImplementedException(); }
		#endregion
		#region Manage Group
		public bool OpenGroup(IGroup group) { throw new NotImplementedException(); }
		public bool AddToGroup(IGroup group, IUser user) { throw new NotImplementedException(); }
		public bool ChangeGroupsOwnership(IGroup group, IUser user) { throw new NotImplementedException(); }
		public bool ChangeGroupsName(IGroup group) { throw new NotImplementedException(); }
		public bool RemoveFromGroup(IGroup group, IUser user) { throw new NotImplementedException(); }
		public bool CloseGroup(IGroup group) { throw new NotImplementedException(); }
		#endregion
		#region Manage Ranks
		public bool AddRank(IGroup group) { throw new NotImplementedException(); }
		public bool Promote(IGroup group, IUser user) { throw new NotImplementedException(); }
		public bool ChangeRanksName(IRank rank) { throw new NotImplementedException(); }
		public bool ChangeRanksIndex(IRank rank) { throw new NotImplementedException(); }
		public bool Demote(IGroup group, IUser user) { throw new NotImplementedException(); }
		public bool DeleteRank(IRank rank) { throw new NotImplementedException(); }
		#endregion
		#region Manage Permissions
		public bool ChangePermissionsMininimumRank(IPermission permission) { throw new NotImplementedException(); }
		public bool ChangePermissionsMaximumRank(IPermission permission) { throw new NotImplementedException(); }
		public bool ChangePermissionsMustOutrank(IPermission permission) { throw new NotImplementedException(); }
		#endregion

		public LocalPermissionsTester(IPermissions owner)
		{
			Owner = owner;
		}
	}
	public class GlobalPermissionsTester : IGlobalPermissionsTester
	{
		public IPermissions Owner { get; set; }

		#region Manage User
		public bool Mute(IUser user) { throw new NotImplementedException(); }
		public bool Freeze(IUser user) { throw new NotImplementedException(); }
		public bool Kick(IUser user) { throw new NotImplementedException(); }
		public bool Ban(IUser user) { throw new NotImplementedException(); }
		#endregion
		#region Manage Group
		public bool AddGroup(IRichTextString groupName) { throw new NotImplementedException(); }
		public bool OpenGroup(IGroup group) { throw new NotImplementedException(); }
		public bool AddToGroup(IGroup group, IUser user) { throw new NotImplementedException(); }
		public bool ChangeGroupOwnership(IGroup group, IUser newOwner) { throw new NotImplementedException(); }
		public bool ChangeGroupName(IGroup group, IRichTextString newName) { throw new NotImplementedException(); }
		public bool RemoveFromGroup(IGroup group, IUser user) { throw new NotImplementedException(); }
		public bool CloseGroup(IGroup group) { throw new NotImplementedException(); }
		public bool DeleteGroup(IRichTextString groupName) { throw new NotImplementedException(); }
		#endregion
		#region Manage Ranks
		public bool AddRank(IGroup group, IRichTextString rankName) { throw new NotImplementedException(); }
		public bool Promote(IGroup group, IUser user) { throw new NotImplementedException(); }

		public bool ChangeRanksName(IRank rank, IRichTextString newName) { throw new NotImplementedException(); }
		public bool ChangeRanksIndex(IRank rank, int NewIndex) { throw new NotImplementedException(); }

		public bool Demote(IGroup group, IUser user) { throw new NotImplementedException(); }
		public bool DeleteRank(IGroup group, IRank rank) { throw new NotImplementedException(); }
		#endregion
		#region Manage Permissions
		public bool ChangePermissionMininimumRank(IPermission permission, int minimumRankIndex) { throw new NotImplementedException(); }
		public bool ChangePermissionMaximumRank(IPermission permission, int maximumRankIndex) { throw new NotImplementedException(); }
		public bool ChangePermissionMustOutrank(IPermission permission, bool mustOutrank) { throw new NotImplementedException(); }
		#endregion

		public GlobalPermissionsTester(IPermissions owner)
		{
			Owner = owner;
		}
	}

	public class Permissions : IPermissions
	{
		public ILocalPermissions LocalPermissions { get; set; }
		public IGlobalPermissions GlobalPermissions { get; set; }
		public ILocalPermissionsTester LocalPermissionsTester { get; set; }
		public IGlobalPermissionsTester GlobalPermissionsTester { get; set; }

		public Permissions()
		{
			LocalPermissions = new LocalPermissions();
			GlobalPermissions = new GlobalPermissions();
			LocalPermissionsTester = new LocalPermissionsTester(this);
			GlobalPermissionsTester = new GlobalPermissionsTester(this);
		}
	}
}
