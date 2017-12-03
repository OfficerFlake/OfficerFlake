using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_04_Field : GenericPacket
	{
		public Type_04_Field() : base(4)
		{
		}
		public Type_04_Field(string fieldName) : base(4)
        {
			this.FieldName = fieldName;
		}
		public Type_04_Field(string fieldName, float posX, float posY, float posZ, float rotX, float rotY, float rotZ) : base(4)
        {
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
			get => GetString(0, 32);
			set => SetString(0, 32, value);
		}

		public Single PosX
		{
			get => GetSingle(32);
			set => SetSingle(32, value);
		}
		public Single PosY
		{
			get => GetSingle(36);
			set => SetSingle(36, value);
		}
		public Single PosZ
		{
			get => GetSingle(40);
			set => SetSingle(40, value);
		}

		public Single RotX
		{
			get => GetSingle(44);
			set => SetSingle(44, value);
		}
		public Single RotY
		{
			get => GetSingle(48);
			set => SetSingle(48, value);
		}
		public Single RotZ
		{
			get => GetSingle(52);
			set => SetSingle(52, value);
		}

		public Int32 Unknown
		{
			get => GetInt32(56);
			set => SetInt32(56, value);
		}
	}
}
