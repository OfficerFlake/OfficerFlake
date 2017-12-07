using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Networking.Packets;

namespace Com.OfficerFlake.Libraries.Networking
{
	public class GenericPacket
	{
		public Int32 Size => Data.Length + 4;
		public Int32 Type = 0;
		public byte[] Data = new byte[0];

		public byte[] Serialise()
		{
			byte[] output = new byte[Size+4];
			byte[] sizeBytes = BitConverter.GetBytes(Size);
			byte[] typeBytes = BitConverter.GetBytes(Type);

			Array.Copy(sizeBytes, 0, output, 0, 4);
			Array.Copy(typeBytes, 0, output, 4, 4);
			Array.Copy(Data, 0, output, 8, Data.Length);

			return output;
		}

		public GenericPacket()
		{
		}

		public GenericPacket(int type)
		{
			Type = type;
		}
		public GenericPacket(int type, byte[] data)
		{
			Type = type;
			Data = data;
		}

		#region Data Manipulation
		public byte[] GetBytesFromStartToEnd(int start, int end)
		{
			int size = end - start;
			if (start > Data.Length) return new byte[size];
			if (end > Data.Length) return new byte[size];
			if (end <= start) return new byte[size];
			if (Data.Length < start+size) return new byte[size];
			byte[] output = new byte[size];
			try
			{
				Array.Copy(Data, start, output, 0, end - start);
			}
			catch
			{
			}
			return output;
		}
		public byte[] GetBytesFromStartToLength(int start, int length)
		{
			return GetBytesFromStartToEnd(start, start + length);
		}

		public void ResizeData(int newsize)
		{
			int oldsize = Data.Length;
			byte[] newData = new byte[newsize];
			Array.Copy(Data, 0, newData, 0, (oldsize >= newsize) ? newsize : oldsize);
			Data = newData;
		}
		public bool SetBytesFromStart(int start, byte[] bytesToCopy)
		{
			if (bytesToCopy == null) return false;
			if (start < 0) return false;
			if (start + bytesToCopy.Length > Data.Length) ResizeData(start + bytesToCopy.Length);
			byte[] dataBeforeInsertionPoint = new byte[start];
			try
			{
				Array.Copy(Data, 0, dataBeforeInsertionPoint, 0, dataBeforeInsertionPoint.Length);
			}
			catch
			{
			}
			byte[] dataAfterInsertionPoint = new byte[Data.Length - start - bytesToCopy.Length];
			try
			{
				Array.Copy(Data, start + bytesToCopy.Length, dataAfterInsertionPoint, 0, dataAfterInsertionPoint.Length);
			}
			catch
			{
			}
			byte[] combinedData = new byte[dataBeforeInsertionPoint.Length + bytesToCopy.Length + dataAfterInsertionPoint.Length];
			Array.Copy(dataBeforeInsertionPoint, 0, combinedData, 0, dataBeforeInsertionPoint.Length);
			Array.Copy(bytesToCopy, 0, combinedData, dataBeforeInsertionPoint.Length, bytesToCopy.Length);
			Array.Copy(dataAfterInsertionPoint, 0, combinedData, dataBeforeInsertionPoint.Length + bytesToCopy.Length, dataAfterInsertionPoint.Length);
			Data = combinedData;
			return true;
		}
		#endregion

		#region DataTypes
		#region Bool
		public bool GetBit(int start, int index)
		{
			byte releventByte = GetBytesFromStartToLength(start, 1)[0];
			return releventByte.GetBit(index);
		}
		public bool SetBit(int start, int index)
		{
			byte releventByte = (GetBytesFromStartToLength(start, 1) ?? new byte[]{ 0 })[0];
			releventByte = releventByte.SetBit(index);
			return SetBytesFromStart(start, new[]{ releventByte });
		}
		public bool UnsetBit(int start, int index)
		{
			byte releventByte = (GetBytesFromStartToLength(start, 1) ?? new byte[] { 0 })[0];
			releventByte = releventByte.UnsetBit(index);
			return SetBytesFromStart(start, new[] { releventByte });
		}

		public bool SetBit(int start, int index, bool value)
		{
			if (value) return SetBit(start, index);
			else return UnsetBit(start, index);
		}
		#endregion

		#region Byte
		public byte GetByte(int start)
		{
			return GetBytesFromStartToLength(start, 1)[0];
		}
		public bool SetByte(int start, byte input)
		{
			return SetBytesFromStart(start, new [] { input });
		}
		#endregion
		#region SByte
		public sbyte GetSByte(int start)
		{
			return (sbyte)GetBytesFromStartToLength(start, 1)[0];
		}
		public bool SetSByte(int start, sbyte input)
		{
			return SetBytesFromStart(start, new[] { (byte)input });
		}
		#endregion

		#region Uint16
		public UInt16 GetUInt16(int start)
		{
			return BitConverter.ToUInt16(GetBytesFromStartToLength(start, 2), 0);
		}
		public bool SetUInt16(int start, UInt16 input)
		{
			return SetBytesFromStart(start, BitConverter.GetBytes(input));
		}
		#endregion
		#region Int16
		public Int16 GetInt16(int start)
		{
			return BitConverter.ToInt16(GetBytesFromStartToLength(start, 2), 0);
		}
		public bool SetInt16(int start, Int16 input)
		{
			return SetBytesFromStart(start, BitConverter.GetBytes(input));
		}
		#endregion

		#region UInt32
		public UInt32 GetUInt32(int start)
		{
			return BitConverter.ToUInt32(GetBytesFromStartToLength(start, 4), 0);
		}
		public bool SetUInt32(int start, UInt32 input)
		{
			return SetBytesFromStart(start, BitConverter.GetBytes(input));
		}
		#endregion
		#region Int32
		public Int32 GetInt32(int start)
		{
			return BitConverter.ToInt32(GetBytesFromStartToLength(start, 4), 0);
		}
		public bool SetInt32(int start, Int32 input)
		{
			return SetBytesFromStart(start, BitConverter.GetBytes(input));
		}
		#endregion

		#region Single
		public Single GetSingle(int start)
		{
			return BitConverter.ToSingle(GetBytesFromStartToLength(start, 4), 0);
		}
		public bool SetSingle(int start, Single input)
		{
			return SetBytesFromStart(start, BitConverter.GetBytes(input));
		}
		#endregion

		#region String
		public string GetString(int start, int length)
		{
			return GetBytesFromStartToLength(start, length).ToSystemString().Split('\0')[0];
		}
		public bool SetString(int start, int length, string input)
		{
			string newString = input.ResizeOnRight(length);
			return SetBytesFromStart(start, newString.ToByteArray());
		}
		#endregion
		#endregion
	}

	public static class Packet
	{
		public static GenericPacket NoPacket => new GenericPacket(0);
	}
}
