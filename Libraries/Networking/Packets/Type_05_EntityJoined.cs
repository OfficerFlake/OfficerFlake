using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_05_EntityJoined : GenericPacket, IPacket_05_AddVehicle
	{
		public Type_05_EntityJoined() : base(5)
		{
			ResizeData(140);
			Initialise();
		}

		private void Initialise()
		{
			ResizeData(108 + 16 + 48);
			SetString(108, 16, "" +
			    //No clue what this data is but seems to be required...
			    (char)03 + (char)00 + (char)00 + (char)00 + (char)00 + (char)00 + (char)20 + (char)41 +
			    (char)00 + (char)00 + (char)03 + (char)00 + (char)00 + (char)00 + (char)00 + (char)00);
		}

		public Packet_05VehicleType VehicleType
		{
			get
			{
				switch (GetUInt32(0))
				{
					case 0:
						return Packet_05VehicleType.Aircraft;
					default:
						return Packet_05VehicleType.Ground;
				}
			}
			set
			{
				switch (value)
				{
					case Packet_05VehicleType.Aircraft:
						SetUInt32(0, 0);
						return;
					default:
						SetUInt32(0, 65537);
						return;
				}
			}
		}
		public Boolean IsAircraft
		{
			get => (VehicleType == Packet_05VehicleType.Aircraft);
			set
			{
				if (value)
				{
					VehicleType = Packet_05VehicleType.Aircraft;
				}
				else
				{
					VehicleType = Packet_05VehicleType.Ground;
				}
			}
		}
		public Boolean IsGround
		{
			get => !IsAircraft;
			set => IsAircraft = !value;
		}

		public UInt32 ID
		{
			get => GetUInt32(4);
			set => SetUInt32(4, value);
		}
		public UInt32 IFF
		{
			get => GetUInt32(8);
			set => SetUInt32(8, value);
		}

		public IDistance PosX
		{
			get => ((double)GetSingle(12)).Meters();
			set => SetSingle(12, (Single)value.ToMeters().RawValue);
		}
		public IDistance PosY
		{
			get => ((double)GetSingle(16)).Meters();
			set => SetSingle(16, (Single)value.ToMeters().RawValue);
		}
		public IDistance PosZ
		{
			get => ((double)GetSingle(20)).Meters();
			set => SetSingle(20, (Single)value.ToMeters().RawValue);
		}
		public ICoordinate3 Position
		{
			get => ObjectFactory.CreateCoordinate3(PosX, PosY, PosZ);
			set
			{
				PosX = value.X;
				PosY = value.Y;
				PosZ = value.Z;
			}
		}

		public IAngle HdgH
		{
			get => ((double)GetSingle(24)).Radians();
			set => SetSingle(24, (Single)value.ToRadians().RawValue);
		}
		public IAngle HdgP
		{
			get => ((double)GetSingle(28)).Radians();
			set => SetSingle(28, (Single)value.ToRadians().RawValue);
		}
		public IAngle HdgB
		{
			get => ((double)GetSingle(32)).Radians();
			set => SetSingle(32, (Single)value.ToRadians().RawValue);
		}
		public IOrientation3 Attitude
		{
			get => ObjectFactory.CreateOrientation3(HdgH, HdgP, HdgB);
			set
			{
				HdgH = value.H;
				HdgP = value.P;
				HdgB = value.B;
			}
		}

		public String Identify
		{
			get => GetString(36, 32);
			set => SetString(36, 32, value);
		}

		//Skip 68 => 108 (???)

		public Packet_05OwnerType OwnerType
		{
			get
			{
				switch (GetUInt32(108))
				{
					case 3:
						return Packet_05OwnerType.Self;
					default:
						return Packet_05OwnerType.Other;
				}
			}
			set
			{
				switch (value)
				{
					case Packet_05OwnerType.Self:
						SetUInt32(108, 3);
						return;
					default:
						SetUInt32(0, 2);
						return;
				}
			}
		}
		public Boolean IsOwnedByThisClient
		{
			get => (OwnerType == Packet_05OwnerType.Self);
			set
			{
				if (value) OwnerType = Packet_05OwnerType.Self;
				else OwnerType = Packet_05OwnerType.Other;
			}
		}

		public String OwnerName
		{
			get => GetString(124, 16);
			set => SetString(124, 16, value);
		}
	}
}
