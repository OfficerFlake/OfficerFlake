using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.RichText;

namespace Com.OfficerFlake.Libraries
{
	public static partial class Database
	{
	    public class Group
	    {
		    public RichTextString Name = "???".AsRichTextString();

		    public User CreatedBy = Users.Unknown;
		    public DateTime TimestampGroupCreated = DateTime.Now;

		    public User CurrentOwner = Users.Unknown;
		    public DateTime TimestampLastOwnershipChange = DateTime.Now;

		    public User ClosedBy = Users.Unknown;
		    public DateTime TimestampGroupClosed = DateTime.MinValue;

		    public List<Rank> Ranks = new List<Rank>();
		    public List<User> Members = new List<User>();

		    public Rank GetLowestRank()
		    {
			    if (Ranks.Count <= 0) return null;
			    return Ranks.OrderBy(x => x.Index).First();
		    }
	    }

		public static class Groups
		{
			public static Group Server = new Group()
			{
				Name = "Server".AsRichTextString(),

				CreatedBy = Users.Console,
				CurrentOwner = Users.Console,

				Ranks = Ranks.ServerRanks
			};
		}
    }
}
