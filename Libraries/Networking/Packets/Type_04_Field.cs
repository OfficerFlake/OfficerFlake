using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Networking;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

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
			get => GetSingle(32).Meters();
			set => SetSingle(32, (Single)value.ConvertToBase().Meters().RawValue);
		}
		public IDistance PosY
		{
			get => GetSingle(36).Meters();
			set => SetSingle(36, (Single)value.ConvertToBase().Meters().RawValue);
		}
		public IDistance PosZ
		{
			get => GetSingle(40).Meters();
			set => SetSingle(40, (Single)value.ConvertToBase().Meters().RawValue);
		}

		public IAngle RotX
		{
			get => GetSingle(44).Radians();
			set => SetSingle(44, (Single)value.ConvertToBase().Radians().RawValue);
		}
		public IAngle RotY
		{
			get => GetSingle(48).Radians();
			set => SetSingle(48, (Single)value.ConvertToBase().Radians().RawValue);
		}
		public IAngle RotZ
		{
			get => GetSingle(52).Radians();
			set => SetSingle(52, (Single)value.ConvertToBase().Radians().RawValue);
		}

		public UInt32 Version
		{
			get => GetUInt32(56);
			set => SetUInt32(56, value);
		}
	}
}
