using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.RichText;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries
{
	public static partial class Database
	{
	    public class Group : IGroup
	    {
			#region Creation
			public IUser CreatedBy { get; set; } = Users.Unknown;
		    public IDateTime CreatedDateTime { get; set; } = new OYSDateTime(DateTime.Now);
			#endregion
			#region Last Owner Info
			public IUser CurrentOwner { get; set; }
			public IUser PreviousOwner { get; set; }
			public IUser OwnershipChangedBy { get; set; }
			public IDateTime OwnerChangedDateTime { get; set; }
		    #endregion
			#region Current Info
			public IRichTextString Name { get; set; }
		    public List<IUser> Members { get; set; }
		    public List<IRank> Ranks { get; set; }
		    #endregion
			#region Close
			public IUser ClosedBy { get; set; }
			public IDateTime ClosedDateTime { get; set; }
			#endregion

			public override string ToString()
		    {
			    return Name.ToUnformattedSystemString();
		    }

			public IRank GetLowestRank()
		    {
			    if (Ranks.Count <= 0) return null;
			    return Ranks.OrderBy(x => x.Index).First();
		    }
		    public IRank GetNextLowerRank(IRank currentRank)
		    {
			    int currentIndex = currentRank.Index;
			    if (!Ranks.Any(x => x.Index < currentIndex)) return currentRank;
			    return (Ranks.Where(x => x.Index < currentIndex).OrderByDescending(y => y.Index).First());
			}
			public IRank GetNextHigherRank(IRank currentRank)
		    {
			    int currentIndex = currentRank.Index;
			    if (!Ranks.Any(x => x.Index > currentIndex)) return currentRank;
			    return (Ranks.Where(x => x.Index > currentIndex).OrderBy(y => y.Index).First());
		    }
		    public IRank GetHighestRank()
		    {
			    if (Ranks.Count <= 0) return null;
			    return Ranks.OrderByDescending(x => x.Index).First();
		    }

			public bool ChangeOwner(IUser ChangedBy, IUser NewOwner)
			{
				throw new NotImplementedException();
			}

			public bool IsClosed()
			{
				throw new NotImplementedException();
			}
			public bool IsOpen()
			{
				throw new NotImplementedException();
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
