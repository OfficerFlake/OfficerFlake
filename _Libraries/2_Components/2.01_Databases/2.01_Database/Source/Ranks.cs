using System.Collections.Generic;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Database
{
	public class Rank : IRank, IPermissions
	{
		public IRichTextString Name { get; set; }
		public int Index { get; set; }

		public ILocalPermissions LocalPermissions { get; set; }
		public IGlobalPermissions GlobalPermissions { get; set; }
		public ILocalPermissionsTester LocalPermissionsTester { get; set; }
		public IGlobalPermissionsTester GlobalPermissionsTester { get; set; }

		public Rank(IRichTextString rankName)
		{
			Name = rankName;
		}

		public override string ToString()
		{
			return Name.ToUnformattedSystemString();
		}
	}

	public static class Ranks
	{
		#region ServerRanks
		public static IRank ServerRankOwner = new Rank("Owner".AsRichTextString())
		{
			Index = 4,
		};
		public static IRank ServerRankAdmin = new Rank("Admin".AsRichTextString())
		{
			Index = 3,
		};
		public static IRank ServerRankModerator = new Rank("Moderator".AsRichTextString())
		{
			Index = 2,
		};
		public static IRank ServerRankMember = new Rank("Member".AsRichTextString())
		{
			Index = 1,
		};
		public static IRank ServerRankGuest = new Rank("Guest".AsRichTextString())
		{
			Index = 0,
		};

		public static readonly List<IRank> ServerRanks = new List<IRank>()
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
