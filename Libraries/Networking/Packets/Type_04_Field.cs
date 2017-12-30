using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_04_Field : GenericPacket, IPacket_04_Field
	{
		public Type_04_Field() : base(4)
		{
			ResizeData(60);
		}
		public Type_04_Field(string fieldName) : base(4)
        {
	        ResizeData(60);
			this.FieldName = fieldName;
		}
		public Type_04_Field(string fieldName, IDistance posX, IDistance posY, IDistance posZ, IAngle rotX, IAngle rotY, IAngle rotZ) : base(4)
        {
	        ResizeData(60);
			FieldName = fieldName;
			PosX = posX;
			PosY = posY;
			PosZ = posZ;
			RotX = rotX;
			RotY = rotY;
			RotZ = rotZ;
		}

		public String FieldName
		{
			get => GetString(0, 32).Split('\0')[0];
			set => SetString(0, 32, value);
		}

		public IDistance PosX
		{
			get => ((double)GetSingle(32)).Meters();
			set => SetSingle(32, (Single)value.ToMeters().RawValue);
		}
		public IDistance PosY
		{
			get => ((double)GetSingle(36)).Meters();
			set => SetSingle(36, (Single)value.ToMeters().RawValue);
		}
		public IDistance PosZ
		{
			get => ((double)GetSingle(40)).Meters();
			set => SetSingle(40, (Single)value.ToMeters().RawValue);
		}

		public IAngle RotX
		{
			get => ((double)GetSingle(44)).Radians();
			set => SetSingle(44, (Single)value.ToRadians().RawValue);
		}
		public IAngle RotY
		{
			get => ((double)GetSingle(48)).Radians();
			set => SetSingle(48, (Single)value.ToRadians().RawValue);
		}
		public IAngle RotZ
		{
			get => ((double)GetSingle(52)).Radians();
			set => SetSingle(52, (Single)value.ToRadians().RawValue);
		}

		public UInt32 Version
		{
			get => GetUInt32(56);
			set => SetUInt32(56, value);
		}
	}
}
