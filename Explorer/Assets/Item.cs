using System;
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
			Flags = (byte)(b & 0xE0);
			Charges = (byte)(b & 0x1F);
			Picture = reader.ReadByte();
			Type = reader.ReadByte();
			SubPos = reader.ReadByte();
			Location = new Location(reader);
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

			string filename = basedir + "ITEM.DAT";
			using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
			{
				ushort itemscount = reader.ReadUInt16();
				for (ushort i = 0; i < itemscount; i++)
				{
					items.Add(new Item(i, reader));
				}

				ushort namescount = reader.ReadUInt16();
				for (ushort i = 0; i < namescount; i++)
				{
                    names.Add(new string(reader.ReadChars(35)).Replace("\0", ""));
				}

				foreach(Item item in items)
				{
					item.IdentifiedName = names[item.IdentifiedNameId];
					item.UnidentifiedName = names[item.UnidentifiedNameId];
				}

			}

			return items;
		}


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
		public byte Flags;
		public byte Charges;
		public byte Picture;
		public byte Type;
		public byte SubPos;
		public Location Location;
		public byte Level;
		public sbyte Value;
		public ushort Index;
		
		public ushort Unk0;
		public ushort Unk1;


		#endregion
	}
}
