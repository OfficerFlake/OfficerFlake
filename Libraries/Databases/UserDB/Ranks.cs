using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.OfficerFlake.Libraries
{
	public static partial class Database
	{
		public class Rank
		{
			public string Name;
			public int Index;
			public Permissions Permissions;

			public Permission GetPermission(PermissionTypes permissionType)
			{
				Permission permission = null;
				switch (permissionType)
				{
					case PermissionTypes.Mute:
						permission = Permissions.Mute;
						break;
					case PermissionTypes.Freeze:
						permission = Permissions.Freeze;
						break;
					case PermissionTypes.Kick:
						permission = Permissions.Kick;
						break;
					case PermissionTypes.Ban:
						permission = Permissions.Ban;
						break;

					case PermissionTypes.AddToGroup:
						permission = Permissions.AddToGroup;
						break;
					case PermissionTypes.RemoveFromGroup:
						permission = Permissions.RemoveFromGroup;
						break;

					case PermissionTypes.Promote:
						permission = Permissions.Promote;
						break;
					case PermissionTypes.Demote:
						permission = Permissions.Demote;
						break;

					default:
						break;
				}
				return permission;
			}
		}

		public static class Ranks
		{
			#region ServerRanks
			public static Rank ServerRankOwner = new Rank()
			{
				Name = "Owner",
				Index = 4,
				Permissions = new Permissions()
				{
					Mute = new Permission(0, -1, false),
					Freeze = new Permission(0, -1, false),
					Kick = new Permission(0, -1, false),
					Ban = new Permission(0, -1, false),

					AddToGroup = new Permission(0, -1, false),
					RemoveFromGroup = new Permission(0, -1, true),

					Promote = new Permission(0, -1, true),
					Demote = new Permission(0, -1, true),
				},
			};
			public static Rank ServerRankAdmin = new Rank()
			{
				Name = "Admin",
				Index = 3,
				Permissions = new Permissions()
				{
					Mute = new Permission(0, -1, true),
					Freeze = new Permission(0, -1, true),
					Kick = new Permission(0, -1, true),
					Ban = new Permission(0, -1, true),

					AddToGroup = new Permission(0, -1, true),
					RemoveFromGroup = new Permission(0, -1, true),

					Promote = new Permission(0, -1, true),
					Demote = new Permission(0, -1, true),
				},
			};
			public static Rank ServerRankModerator = new Rank()
			{
				Name = "Moderator",
				Index = 2,
				Permissions = new Permissions()
				{
					Mute = new Permission(0, -1, true),
					Freeze = new Permission(0, -1, true),
					Kick = new Permission(0, -1, true),
					Ban = new Permission(-1, 0, true),

					AddToGroup = new Permission(0, -1, true),
					RemoveFromGroup = new Permission(0, -1, true),

					Promote = new Permission(0, -1, true),
					Demote = new Permission(0, -1, true),
				},
			};
			public static Rank ServerRankMember = new Rank()
			{
				Name = "Member",
				Index = 1,
				Permissions = new Permissions()
				{
					Mute = new Permission(-1, -1, true),
					Freeze = new Permission(-1, -1, true),
					Kick = new Permission(-1, -1, true),
					Ban = new Permission(-1, -1, true),

					AddToGroup = new Permission(-1, -1, true),
					RemoveFromGroup = new Permission(-1, -1, true),

					Promote = new Permission(-1, -1, true),
					Demote = new Permission(-1, -1, true),
				},
			};
			public static Rank ServerRankGuest = new Rank()
			{
				Name = "Guest",
				Index = 0,
				Permissions = new Permissions()
				{
					Mute = new Permission(-1, -1, true),
					Freeze = new Permission(-1, -1, true),
					Kick = new Permission(-1, -1, true),
					Ban = new Permission(-1, -1, true),

					AddToGroup = new Permission(-1, -1, true),
					RemoveFromGroup = new Permission(-1, -1, true),

					Promote = new Permission(-1, -1, true),
					Demote = new Permission(-1, -1, true),
				},
			};

			public static List<Rank> ServerRanks = new List<Rank>()
			{
				ServerRankOwner,
				ServerRankAdmin,
				ServerRankModerator,
				ServerRankMember,
				ServerRankGuest
			};
			#endregion
		}
	}
}
