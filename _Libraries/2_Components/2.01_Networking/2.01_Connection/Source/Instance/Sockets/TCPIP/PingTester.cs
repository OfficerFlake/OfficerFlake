using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Loggers;

namespace Com.OfficerFlake.Libraries.Networking
{
	public partial class Connection : IConnection
	{
		#region Ping Tester

		public void StartPingTester()
		{
			_ = Task.Run(PingTesterLoop);
		}
		private async Task<bool> PingTesterLoop()
		{
			const int PingWaitInterval = 30000;
			const double PingMaxDeltaPercent = 0.40;
			const int PingAllowableMillisecondVariance = 20;

			if (Ping < 1) Ping = 1;

		    while (!IsLoggedIn & IsConnected)
		    {
		        await Task.Delay(PingWaitInterval);
		    }
			
			while (IsLoggedIn)
			{
				DateTime PingStartTime = DateTime.Now;

				#region Send PrepareSimulation(16)

				//Build Prepare Simulation (16)
				IPacket_16_PrepareSimulation PrepareSimulation = ObjectFactory.CreatePacket16PrepareSimulation();

				IPacketWaiter packetWaiter_AcknowledgePrepareSimulation = CreatePacketWaiter(6);
				packetWaiter_AcknowledgePrepareSimulation.Require(0, 7);
				packetWaiter_AcknowledgePrepareSimulation.StartListening();

				//Send Prepare Simulation (16)
				SendToClientStream(PrepareSimulation);
				LoginState = LoginStatus.LoggedIn;

				#endregion

				#region Get PrepareSimulation(06:07)
				if (!GetResponseOrResend(packetWaiter_AcknowledgePrepareSimulation, PrepareSimulation))
				{
					if (!IsConnected)
					{
						return false;
					}
					else
					{
						await Task.Delay(PingWaitInterval);
						Logger.AddDebugMessage("Ping Check for Connection " + ConnectionNumber + " Failed. Trying Again...");
					    continue;
					}
				}
				#endregion

				DateTime PingEndTime = DateTime.Now;
				double PingAdjustmentRatio = ((((PingEndTime - PingStartTime).TotalMilliseconds/2)-Ping) / Ping);
				if (PingAdjustmentRatio > PingMaxDeltaPercent) PingAdjustmentRatio = PingMaxDeltaPercent;
				if (PingAdjustmentRatio < -PingMaxDeltaPercent) PingAdjustmentRatio = -PingMaxDeltaPercent;
				PingAdjustmentRatio = Math.Abs(PingAdjustmentRatio);

				double OldPing = Ping;
				double NewPing = (PingEndTime - PingStartTime).TotalMilliseconds / 2;

				if (Math.Abs((NewPing - OldPing) / OldPing) > 5d && Math.Abs(OldPing - NewPing) > PingAllowableMillisecondVariance)
				{
					//SendToClientStream("Ping Overrun " + Math.Round(NewPing, 3) + "ms");
				}
				else
				{
					Ping = (OldPing) * (PingAdjustmentRatio) +
					       (NewPing) * (1 - PingAdjustmentRatio);
					if (Ping < 1) Ping = 1;
					//SendToClientStream("Your Ping is " + Math.Round(Ping, 3) + "ms");
				}

			    await Task.Delay(PingWaitInterval);
			}
			return false;
		}

		#endregion
	}
}
