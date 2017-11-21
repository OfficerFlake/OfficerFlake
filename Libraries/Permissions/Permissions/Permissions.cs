using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;

namespace Com.OfficerFlake.Libraries
{
    public class Permission
    {
		/// <summary>
		/// The minimum rank index in own group category that the user can action against.
		/// </summary>
		public int MinimumRank;

		/// <summary>
		/// the maximum rank index in own group category that the user can action against.
		/// </summary>
		public int MaximumRank;

		/// <summary>
		/// Safeguard: Should the user be prevented from acting on users of the same rank?
		/// </summary>
	    public bool MustOutrank;

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
    }

	public class Permissions
	{
		public Permission Mute;
		public Permission Freeze;
		public Permission Kick;
		public Permission Ban;

		public Permission AddToGroup;
		public Permission RemoveFromGroup;

		public Permission Promote;
		public Permission Demote;
	}
}
