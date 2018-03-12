using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_21_GroundData : GenericPacket, IPacket_21_GroundData
	{
		public Type_21_GroundData() : base(21)
		{
			Version = 1;
		}

		public ITimeSpan Timestamp
		{
			get => GetSingle(0).Seconds().ToTimeSpan();
			set => SetSingle(0, (Single)(value.ToSystemTimeSpan().TotalSeconds));
		}

		public UInt32 ID
		{
			get => GetUInt32(4);
			set => SetUInt32(4, value);
		}

		public UInt16 Strength
		{
			get => GetUInt16(8);
			set => SetUInt16(8, value);
		}

		public UInt16 Version
		{
			get => GetUInt16(10);
			set => SetUInt16(10, value);
		}

		public IDistance PosX
		{
			get => GetSingle(12).Meters();
			set => SetSingle(12, (Single)(value.ToMeters().RawValue));
		}
		public IDistance PosY
		{
			get => GetSingle(16).Meters();
			set => SetSingle(16, (Single)(value.ToMeters().RawValue));
		}
		public IDistance PosZ
		{
			get => GetSingle(20).Meters();
			set => SetSingle(20, (Single)(value.ToMeters().RawValue));
		}

		public IAngle HdgX
		{
			get => (GetInt16(24) / 32767f).Radians();
			set => SetInt16(24, (Int16) (value.ToRadians().RawValue * 32767));
		}
		public IAngle HdgY
		{
			get => (GetInt16(26) / 32767f).Radians();
			set => SetInt16(26, (Int16)(value.ToRadians().RawValue * 32767));
		}
		public IAngle HdgZ
		{
			get => (GetInt16(28)/32767f).Radians();
			set => SetInt16(28, (Int16)(value.ToRadians().RawValue * 32767));
		}

		public Byte AnimFlags
		{
			get => GetByte(30);
			set => SetByte(30, value);
		}
		public Boolean AnimGuns
		{
			get => ((AnimFlags & (1 << 0)) == (1<<0));
			set
			{
				if (value) AnimFlags |= 1 << 0;
				else AnimFlags &= (255 - (1 << 0));
			}
		}

		public Byte CPUFlags
		{
			get => GetByte(31);
			set => SetByte(31, value);
		}

		public ISpeed V_PosX
		{
			get => GetInt16(32).MetersPerSecond();
			set => SetInt16(32, (Int16)(value.ToMetersPerSecond().RawValue));
		}
		public ISpeed V_PosY
		{
			get => GetInt16(34).MetersPerSecond();
			set => SetInt16(34, (Int16)(value.ToMetersPerSecond().RawValue));
		}
		public ISpeed V_PosZ
		{
			get => GetInt16(36).MetersPerSecond();
			set => SetInt16(36, (Int16)(value.ToMetersPerSecond().RawValue));
		}

		public IAngle V_Rotation
		{
			get => (GetInt16(38)/32767).Radians();
			set => SetInt16(38, (Int16)(value.ToRadians().RawValue*32767));
		}
	}
}
