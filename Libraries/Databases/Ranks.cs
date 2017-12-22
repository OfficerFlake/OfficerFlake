using System.Collections.Generic;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.RichText;

namespace Com.OfficerFlake.Libraries
{
	public static partial class Database
	{
		public class Rank : IRank, IHasPermissions
		{
			public IRichTextString Name { get; set; }
			public int Index { get; set; }

			public ILocalPermissions LocalPermissions { get; set; }
			public IGlobalPermissions GlobalPermissions { get; set; }

			public override string ToString()
			{
				return Name.ToUnformattedSystemString();
			}
		}

		public static class Ranks
		{
			#region ServerRanks
			public static IRank ServerRankOwner = new Rank()
			{
				Name = "Owner".AsRichTextString(),
				Index = 4,
				LocalPermissions = new LocalPermissions(),
				GlobalPermissions = new GlobalPermissions(),
			};
			public static IRank ServerRankAdmin = new Rank()
			{
				Name = "Admin".AsRichTextString(),
				Index = 3,
				LocalPermissions = new LocalPermissions(),
				GlobalPermissions = new GlobalPermissions(),
			};
			public static IRank ServerRankModerator = new Rank()
			{
				Name = "Moderator".AsRichTextString(),
				Index = 2,
				LocalPermissions = new LocalPermissions(),
				GlobalPermissions = new GlobalPermissions(),
			};
			public static IRank ServerRankMember = new Rank()
			{
				Name = "Member".AsRichTextString(),
				Index = 1,
				LocalPermissions = new LocalPermissions(),
				GlobalPermissions = new GlobalPermissions(),
			};
			public static IRank ServerRankGuest = new Rank()
			{
				Name = "Guest".AsRichTextString(),
				Index = 0,
				LocalPermissions = new LocalPermissions(),
				GlobalPermissions = new GlobalPermissions(),
			};

			public static List<IRank> ServerRanks = new List<IRank>()
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
