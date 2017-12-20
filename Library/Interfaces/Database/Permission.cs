using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	#region Permissions
	public interface IPermission
	{
		int MinimumRank { get; set; }
		int MaximumRank { get; set; }

		bool MustOutrank { get; set; }
	}
	#region Local Permissions
	public interface ILocalPermissions
	{
		#region Manage User
		IPermission Hide { get; set; }
		IPermission UnHide { get; set; }
		IPermission ChangeUsername { get; set; }
		#endregion

		#region Manage Group
		IPermission OpenGroup { get; set; }
		IPermission AddToGroup { get; set; }
		IPermission ChangeGroupsOwnership { get; set; }
		IPermission ChangeGroupsName { get; set; }
		IPermission RemoveFromGroup { get; set; }
		IPermission CloseGroup { get; set; }
		#endregion

		#region Manage Ranks
		IPermission AddRank { get; set; }
		IPermission Promote { get; set; }
		IPermission ChangeRanksName { get; set; }
		IPermission ChangeRanksIndex { get; set; }
		IPermission Demote { get; set; }
		IPermission DeleteRank { get; set; }
		#endregion

		#region Manage Permissions
		IPermission ChangePermissionsMininimumRank { get; set; }
		IPermission ChangePermissionsMaximumRank { get; set; }
		IPermission ChangePermissionsMustOutrank { get; set; }
		#endregion
	}
	#endregion
	#region Global Permissions
	public interface IGlobalPermissions
	{
		#region Manage User
		IPermission Mute { get; set; }
		IPermission Freeze { get; set; }
		IPermission Kick { get; set; }
		IPermission Ban { get; set; }
		#endregion

		#region Manage Groups
		IPermission AddGroups { get; set; }
		IPermission OpenGroups { get; set; }
		IPermission ChangeGroupNames { get; set; }
		IPermission ChangeGroupOwners { get; set; }
		IPermission CloseGroup { get; set; }
		IPermission DeleteGroups { get; set; }
		#endregion

		#region Manage Ranks
		IPermission AddRanksToGroups { get; set; }
		IPermission ChangeRankNames { get; set; }
		IPermission ChangeRankIndexes { get; set; }
		IPermission DeleteRanksFromGroups { get; set; }
		#endregion

		#region Manage Other Permissions
		IPermission ChangePermissionMininimumRanks { get; set; }
		IPermission ChangePermissionMaximumRanks { get; set; }
		IPermission ChangePermissionMustOutranks { get; set; }
		#endregion
	}
	#endregion
	#region Permissions Testing
	public interface IPermissionsTester
	{
		#region Manage User
		bool Mute(IUser user);
		bool Freeze(IUser user);
		bool Kick(IUser user);
		bool Ban(IUser user);
		#endregion

		#region Manage Group
		bool AddGroup(IRichTextString groupName);
		bool OpenGroup(IGroup group);
		bool AddToGroup(IGroup group, IUser user);
		bool ChangeGroupOwnership(IGroup group, IUser newOwner);
		bool ChangeGroupName(IGroup group, IRichTextString newName);
		bool RemoveFromGroup(IGroup group, IUser user);
		bool CloseGroup(IGroup group);
		bool DeleteGroup(IRichTextString groupName);
		#endregion

		#region Manage Ranks
		bool AddRank(IGroup group, IRichTextString rankName);
		bool Promote(IGroup group, IUser user);

		bool ChangeRanksName(IRank rank, IRichTextString newName);
		bool ChangeRanksIndex(IRank rank, int NewIndex);

		bool Demote(IGroup group, IUser user);
		bool DeleteRank(IGroup group, IRank rank);
		#endregion

		#region Manage Permissions
		bool ChangePermissionMininimumRank(IPermission permission, int minimumRankIndex);
		bool ChangePermissionMaximumRank(IPermission permission, int maximumRankIndex);
		bool ChangePermissionMustOutrank(IPermission permission, bool mustOutrank);
		#endregion
	}
	#endregion
	#endregion
}
