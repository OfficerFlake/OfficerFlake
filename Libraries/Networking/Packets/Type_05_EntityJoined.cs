using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_05_EntityJoined : GenericPacket
	{
		public Type_05_EntityJoined() : base(5)
		{
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

		public Int32 ObjectType
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}
		public Boolean IsAircraft
		{
			get => (ObjectType == 0);
			set
			{
				if (value)
				{
					ObjectType = 0;
				}
				else
				{
					ObjectType = 65537;
				}
			}
		}
		public Boolean IsGround
		{
			get => !IsAircraft;
			set => IsAircraft = !value;
		}

		public Int32 ID
		{
			get => GetInt32(4);
			set => SetInt32(4, value);
		}
		public Int32 IFF
		{
			get => GetInt32(8);
			set => SetInt32(8, value);
		}

		public Single PosX
		{
			get => GetSingle(12);
			set => SetSingle(12, value);
		}
		public Single PosY
		{
			get => GetSingle(16);
			set => SetSingle(16, value);
		}
		public Single PosZ
		{
			get => GetSingle(20);
			set => SetSingle(20, value);
		}

		public Single RotX
		{
			get => GetSingle(24);
			set => SetSingle(24, value);
		}
		public Single RotY
		{
			get => GetSingle(28);
			set => SetSingle(28, value);
		}
		public Single RotZ
		{
			get => GetSingle(32);
			set => SetSingle(32, value);
		}

		public String Identify
		{
			get => GetString(36, 32);
			set => SetString(36, 32, value);
		}

		//Skip 68 => 108 (???)

		public Byte OwnerType
		{
			get => GetByte(108);
			set => SetByte(108, value);
		}
		public Boolean IsOwnedByThisClient
		{
			get => (OwnerType == 3);
			set
			{
				if (value) OwnerType = 3;
				else OwnerType = 2;
			}
		}

		public String OwnerName
		{
			get => GetString(124, 16);
			set => SetString(124, 16, value);
		}
	}
}
