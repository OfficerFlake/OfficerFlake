using System.Collections.Generic;
using Com.OfficerFlake.Libraries.Interfaces;

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
				Name = ObjectFactory.CreateRichTextString("Owner"),
				Index = 4,
				LocalPermissions = ObjectFactory.CreateLocalPermissions(),
				GlobalPermissions = ObjectFactory.CreateGlobalPermissions()
			};
			public static IRank ServerRankAdmin = new Rank()
			{
				Name = ObjectFactory.CreateRichTextString("Admin"),
				Index = 3,
				LocalPermissions = ObjectFactory.CreateLocalPermissions(),
				GlobalPermissions = ObjectFactory.CreateGlobalPermissions()
			};
			public static IRank ServerRankModerator = new Rank()
			{
				Name = ObjectFactory.CreateRichTextString("Moderator"),
				Index = 2,
				LocalPermissions = ObjectFactory.CreateLocalPermissions(),
				GlobalPermissions = ObjectFactory.CreateGlobalPermissions()
			};
			public static IRank ServerRankMember = new Rank()
			{
				Name = ObjectFactory.CreateRichTextString("Member"),
				Index = 1,
				LocalPermissions = ObjectFactory.CreateLocalPermissions(),
				GlobalPermissions = ObjectFactory.CreateGlobalPermissions()
			};
			public static IRank ServerRankGuest = new Rank()
			{
				Name = ObjectFactory.CreateRichTextString("Guest"),
				Index = 0,
				LocalPermissions = ObjectFactory.CreateLocalPermissions(),
				GlobalPermissions = ObjectFactory.CreateGlobalPermissions()
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
}
