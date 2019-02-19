using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.Networking
{
	public partial class Connection : IConnection
	{
        // 4) Process that Data accordingly
		#region Processing
		#region Pass In A Packet
		public void GivePacket(IPacket thisPacket) => GivePacketToConnection(this, thisPacket);
	    private static void GivePacketToConnection(Connection thisConncetion, IPacket thisPacket)
	    {
		    if (thisPacket == null)
		    {
			    return;
		    }

		    //Action Packet.
		    _ = thisConncetion.ProcessPacketClientStream(thisPacket);
	    }
		#endregion
		#region Wait For A Packet
		public class PacketWaiter : IPacketWaiter
		{
			public PacketWaiter(UInt32 type)
			{
				RequireType = type;

			}

			public UInt32 RequireType { get; }
			public class PacketWaiterSegmentDescriptor : IPacketWaiterSegmentDescriptor
			{
				public int Start { get; set; } = 0;
				public int End { get; set; } = 0;
				public byte[] DataExpected { get; set; } = new byte[0];

				public PacketWaiterSegmentDescriptor(int start, byte[] dataExpected)
				{
					Start = start;
					End = Start + dataExpected.Length;
					DataExpected = dataExpected;
				}
			}
			public IPacket RecievedPacket { get; set; } = null;

			#region Require
			private List<PacketWaiterSegmentDescriptor> Required = new List<PacketWaiterSegmentDescriptor>();
			public void Require(int start, byte[] description)
			{
				PacketWaiterSegmentDescriptor thisDescriptor = new PacketWaiterSegmentDescriptor(start, description);
				Required.Add(thisDescriptor);
			}
			public void Require(int start, Byte description)
			{
				Require(start, new byte[] { description });
			}
			public void Require(int start, SByte description)
			{
				Require(start, new byte[] { (byte)description });
			}
			public void Require(int start, Int16 description)
			{
				Require(start, BitConverter.GetBytes(description));
			}
			public void Require(int start, Int32 description)
			{
				Require(start, BitConverter.GetBytes(description));
			}
			public void Require(int start, Int64 description)
			{
				Require(start, BitConverter.GetBytes(description));
			}
			public void Require(int start, UInt16 description)
			{
				Require(start, BitConverter.GetBytes(description));
			}
			public void Require(int start, UInt32 description)
			{
				Require(start, BitConverter.GetBytes(description));
			}
			public void Require(int start, UInt64 description)
			{
				Require(start, BitConverter.GetBytes(description));
			}
			public void Require(int start, Single description)
			{
				Require(start, BitConverter.GetBytes(description));
			}
			public void Require(int start, Double description)
			{
				Require(start, BitConverter.GetBytes(description));
			}
			public void Require(int start, string description)
			{
				byte[] bytes = description.ToByteArray();
				Require(start, bytes);
			}
			#endregion
			#region Desire
			private List<PacketWaiterSegmentDescriptor> Desired = new List<PacketWaiterSegmentDescriptor>();
			public void Desire(int start, byte[] description)
			{
				PacketWaiterSegmentDescriptor thisDescriptor = new PacketWaiterSegmentDescriptor(start, description);
				Desired.Add(thisDescriptor);
			}
			public void Desire(int start, Byte description)
			{
				Desire(start, new byte[] { description });
			}
			public void Desire(int start, SByte description)
			{
				Desire(start, new byte[] { (byte)description });
			}
			public void Desire(int start, Int16 description)
			{
				Desire(start, BitConverter.GetBytes(description));
			}
			public void Desire(int start, Int32 description)
			{
				Desire(start, BitConverter.GetBytes(description));
			}
			public void Desire(int start, Int64 description)
			{
				Desire(start, BitConverter.GetBytes(description));
			}
			public void Desire(int start, UInt16 description)
			{
				Desire(start, BitConverter.GetBytes(description));
			}
			public void Desire(int start, UInt32 description)
			{
				Desire(start, BitConverter.GetBytes(description));
			}
			public void Desire(int start, UInt64 description)
			{
				Desire(start, BitConverter.GetBytes(description));
			}
			public void Desire(int start, Single description)
			{
				Desire(start, BitConverter.GetBytes(description));
			}
			public void Desire(int start, Double description)
			{
				Desire(start, BitConverter.GetBytes(description));
			}
			public void Desire(int start, string description)
			{
				byte[] bytes = description.ToByteArray();
				Desire(start, bytes);
			}
			#endregion
			#region Receiving
			private ManualResetEvent Received { get; set; }= new ManualResetEvent(false);
			public bool IsReceived => Received.WaitOne(0);
			public bool StartListening()
			{
				if (RecievedPacket != null) return false;
				if (!PacketWaiters.Contains(this)) PacketWaiters.Add(this);
				return true;
			}
			private void MarkReceived()
			{
				Received.Set();
				PacketWaiters.RemoveAll(x => x == this);
			}
			internal void CheckIfReceived(IPacket thisPacket)
			{				
				bool GetDesired = (false | Desired.Count <= 0);
				foreach (var desiredPacketSegment in Desired)
				{
					if (thisPacket.Data.Length < desiredPacketSegment.End)
					{
						continue;
					}
					byte[] desiredBytes = desiredPacketSegment.DataExpected;
					byte[] thisPacketBytes = thisPacket.Data.Skip(desiredPacketSegment.Start)
						.Take(desiredPacketSegment.End - desiredPacketSegment.Start).ToArray();
					if (desiredBytes.SequenceEqual(thisPacketBytes))
					{
						GetDesired = true;
						break;
					}
				}

				bool GetAllRequired = true;
				foreach (var requiredPacketSegment in Required)
				{
					if (thisPacket.Data.Length < requiredPacketSegment.End)
					{
						GetAllRequired = false;
						continue;
					}
					byte[] requiredBytes = requiredPacketSegment.DataExpected;
					byte[] thisPacketBytes = thisPacket.Data.Skip(requiredPacketSegment.Start)
						.Take(requiredPacketSegment.End - requiredPacketSegment.Start).ToArray();
					if (requiredBytes.SequenceEqual(thisPacketBytes))
					{
						GetAllRequired &= true;
						continue;
					}
					else
					{
						GetAllRequired = false;
					}
				}

				if (GetDesired & GetAllRequired)
				{
					RecievedPacket = thisPacket;
					MarkReceived();
				}
			}
			#endregion

			public bool WaitUntilReceived(int microseconds)
			{
				if (Received.WaitOne(0)) return true;
				StartListening();
				return Received.WaitOne(microseconds);
			}
		}
		private static List<PacketWaiter> PacketWaiters = new List<PacketWaiter>();

	    public IPacketWaiter CreatePacketWaiter(int type)
	    {
		    return new PacketWaiter((uint)type);
	    }
		public bool GetResponseOrResend(IPacketWaiter response, IPacket resend)
		{
			int resends = 0;
			while (!response.WaitUntilReceived(3000))
			{
				if (resends >= 3) return false;

				_ = SendToClientStreamAsync(resend);
				resends++;
			}
			return true;
		}
		#endregion
		#region Set Up Packet Processor
		#region Dummy Processor
		public delegate bool DelegatePacketProcessor(Connection thisConnection, IPacket thisPacket);
	    private static bool DummyPacketProcessor(Connection thisConnection, IPacket thisPacket)
	    {
		    throw new NotImplementedException();
	    }
		#endregion
		#region ClientStream
		private static DelegatePacketProcessor PacketProcessorClientStream = DummyPacketProcessor;
	    public static bool SetPacketProcessorClientStream(DelegatePacketProcessor thisPacketProcessor)
	    {
		    PacketProcessorClientStream = thisPacketProcessor;
		    return true;
	    }
		#endregion
		#region HostStream
		private static DelegatePacketProcessor PacketProcessorHostStream = DummyPacketProcessor;
		public static bool SetPacketProcessorHostStream(DelegatePacketProcessor thisPacketProcessor)
	    {
		    PacketProcessorHostStream = thisPacketProcessor;
		    return true;
	    }
		#endregion
		#endregion
		#region Process Packet
		private async Task ProcessPacketClientStream(IPacket thisPacket)
		{
			if (thisPacket == null)
			{
				return;
			}

			for (int i = 0; i < PacketWaiters.Count; i++)
			{
				PacketWaiter thisWaiter = PacketWaiters[i];
				if (thisPacket.Type == thisWaiter.RequireType)
				{
					thisWaiter.CheckIfReceived(thisPacket);
				}
			}

			try
			{
				await Task.Run(() => PacketProcessorClientStream(this, thisPacket));
			}
			catch (NotImplementedException e)
			{
				Debug.AddErrorMessage(e, "Packet Processing for type " + thisPacket.Type + " is not yet implemented.");
				//this.SendMessageAsync("Sorry, that feature or packet is not implemented yet! Please try something else...");
			}
			catch (Exception e)
			{
				Debug.AddErrorMessage(e, "Packet Processing for type " + thisPacket.Type + " encountered an error.");
				_ = this.SendToClientStreamAsync("There was an error processing on of your packets. You haven't been disconnected, but you might have problems on the server from here!");
			}
		}
	    private async Task ProcessPacketHostStream(IPacket thisPacket)
	    {
		    if (thisPacket == null)
		    {
			    return;
		    }

		    try
		    {
			    await Task.Run(() => PacketProcessorHostStream(this, thisPacket));
		    }
		    catch (NotImplementedException e)
		    {
			    Debug.AddErrorMessage(e, "Packet Processing for type " + thisPacket.Type + " is not yet implemented.");
			    //this.SendMessageAsync("Sorry, that feature or packet is not implemented yet! Please try something else...");
		    }
		    catch (Exception e)
		    {
			    Debug.AddErrorMessage(e, "Packet Processing for type " + thisPacket.Type + " encountered an error.");
			    _ = this.SendToHostStreamAsync("There was an error processing on of your packets. You haven't been disconnected, but you might have problems on the server from here!");
		    }
	    }
		#endregion
		#endregion
	}
}
