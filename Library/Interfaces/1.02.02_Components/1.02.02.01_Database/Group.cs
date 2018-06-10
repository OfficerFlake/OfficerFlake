using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	#region Groups
	public interface IGroup
	{
		#region Creation
		IUser CreatedBy { get; set; }

		IDateTime CreatedDateTime { get; set; }
		#endregion

		#region ChangeOfOwnership
		IUser CurrentOwner { get; set; }
		IUser PreviousOwner { get; set; }

		IUser OwnershipChangedBy { get; set; }
		IDateTime OwnerChangedDateTime { get; set; }
		bool ChangeOwner(IUser ChangedBy, IUser NewOwner);
		#endregion
		#region CurrentInfo
		IRichTextString Name { get; set; }

		List<IUser> Members { get; set; }
		List<IRank> Ranks { get; set; }

		bool IsClosed();
		bool IsOpen();
		#endregion
		#region Ranks
		IRank GetLowestRank();
		IRank GetNextLowerRank(IRank comparisonRank);
		IRank GetNextHigherRank(IRank comparisonRank);
		IRank GetHighestRank();
		#endregion

		#region Closed
		IUser ClosedBy { get; set; }

		IDateTime ClosedDateTime { get; set; }
		#endregion

		string ToString();
	}
	#endregion
}
