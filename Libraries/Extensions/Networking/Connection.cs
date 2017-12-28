using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
	public static class Connections
	{
		public static List<IConnection> AllConnections { get; } = new List<IConnection>();
		public static List<IConnection> LoggedIn => AllConnections.Where(x => x.IsLoggedIn).ToList();
		public static List<IConnection> NotLoggedIn => AllConnections.Where(x => !x.IsLoggedIn).ToList();
		public static List<IConnection> Flying => AllConnections.Where(x => x.IsFlying).ToList();
		public static List<IConnection> NotFlying => AllConnections.Where(x => !x.IsFlying).ToList();
	}

	public static class ConnectionExtensions
	{
		#region Include
		public static List<IConnection> Include(this List<IConnection> originalList, IConnection includeConnection)
		{
			var Output = new List<IConnection>();
			Output.AddRange(originalList);
			Output.RemoveAll(x => x == includeConnection);
			Output.Add(includeConnection);
			return Output;
		}
		public static List<IConnection> Include(this List<IConnection> originalList, List<IConnection> includeConnections)
		{
			var Output = new List<IConnection>();
			Output.AddRange(originalList);
			Output.RemoveAll(includeConnections.Contains);
			Output.AddRange(includeConnections);
			return Output;
		}
		#endregion
		#region Exclude
		public static List<IConnection> Exclude(this List<IConnection> originalList, IConnection excludeConnection)
		{
			var Output = new List<IConnection>();
			Output.AddRange(originalList);
			Output.RemoveAll(x => x == excludeConnection);
			return Output;
		}
		public static List<IConnection> Exclude(this List<IConnection> originalList, List<IConnection> excludeConnections)
		{
			var Output = new List<IConnection>();
			Output.AddRange(originalList);
			Output.RemoveAll(excludeConnections.Contains);
			return Output;
		}
		#endregion
		#region Send
		public static async Task<bool> SendAsync(this List<IConnection> connections, IPacket thisPacket)
		{
			List<Task<bool>> tasks = new List<Task<bool>>();
			foreach (IConnection thisConnection in connections)
			{
				tasks.Add(thisConnection.SendAsync(thisPacket));
			}
			bool AnyErrors = false;
			foreach (Task<bool> thisTask in tasks)
			{
				AnyErrors |= !(await thisTask);
			}
			return !AnyErrors;
		}
		public static async Task<bool> SendMessageAsync(this List<IConnection> connections, string message)
		{
			List<Task<bool>> tasks = new List<Task<bool>>();
			foreach (IConnection thisConnection in connections)
			{
				tasks.Add(thisConnection.SendMessageAsync(message));
			}
			bool AnyErrors = false;
			foreach (Task<bool> thisTask in tasks)
			{
				AnyErrors |= !(await thisTask);
			}
			return !AnyErrors;
		}
		#endregion
	}
}
