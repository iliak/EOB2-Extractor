﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	public class Item
	{
		/// <summary>
		/// 
		/// </summary>
		public Item(ushort index)
		{
			Index = index;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="reader"></param>
		public Item(ushort index, BinaryReader reader)
		{
			byte b;
			UnidentifiedNameId = reader.ReadByte();
			IdentifiedNameId = reader.ReadByte();
			b = reader.ReadByte();
			Flags = (ItemFlag)(b & 0xE0);
			Charges = (byte)(b & 0x1F);
			Picture = reader.ReadByte();
			ItemTypeID = reader.ReadByte();
			SubPosition = reader.ReadByte();
			Location = Location.FromValue(reader.ReadUInt16());
			Unk0 = reader.ReadUInt16();
			Unk1 = reader.ReadUInt16();
			Level = reader.ReadByte();
			Value = reader.ReadSByte();
			Index = index;

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="basedir"></param>
		/// <returns></returns>
		public static List<Item> Decode(string basedir)
		{
			List<Item> items = new List<Item>();
			List<string> names = new List<string>();

			string filename = Path.Combine(basedir, "ITEM.DAT");
			using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
			{

				ushort itemscount = reader.ReadUInt16();

				// Items definitions
				for (ushort i = 0; i < itemscount; i++)
				{
					items.Add(new Item(i, reader));
				}

				// Item's name
				ushort namescount = reader.ReadUInt16();
				for (ushort i = 0; i < namescount; i++)
				{
					names.Add(new string(reader.ReadChars(35)).Replace("\0", ""));
				}

				// Associate each item its name
				foreach (Item item in items)
				{
					item.IdentifiedName = names[item.IdentifiedNameId];
					item.UnidentifiedName = names[item.UnidentifiedNameId];
				}

			}

			return items;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(UnidentifiedName + " ");

			if (!string.IsNullOrWhiteSpace(IdentifiedName))
				sb.Append(" *");

			return sb.ToString();
		}

		#region Properties

		public byte UnidentifiedNameId;
		public string UnidentifiedName;
		public byte IdentifiedNameId;
		public string IdentifiedName;
		public ItemFlag Flags;
		public byte Charges;
		public byte Picture;
		public byte ItemTypeID;
		public byte SubPosition;
		public Location Location;
		public byte Level;
		public sbyte Value;
		public ushort Index;

		public ushort Unk0;
		public ushort Unk1;


		#endregion
	}


	/// <summary>
	/// 
	/// </summary>
	[Flags]
	public enum ItemFlag
	{
		_01 = 0x01,				// Never used
		ArmorBonus = 0x02,				// 
		_04 = 0x04,				// Never used
		DrainHP = 0x08,         // Drains HP when weapon hits enemies
		SpeedBonus = 0x10,				// 
		Cursed = 0x20,			// Can't remove on hand
		Identified = 0x40,		// Identified
		Magic = 0x80,			// Magic
		Ring = 0x100,			// 
	}
}
