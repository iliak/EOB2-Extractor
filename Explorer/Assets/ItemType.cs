using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	public class ItemType
	{
		/// <summary>
		/// 
		/// </summary>
		public ItemType(ushort id)
		{
			ID = id;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="reader"></param>
		public ItemType(ushort id, BinaryReader reader)
		{
			ID = id;

			Inventory = (ItemTypeInventory)reader.ReadUInt16();
			Hand = (ItemTypeHandsFlag)reader.ReadUInt16();
			ACBonus = reader.ReadSByte();
			Classes = (ItemTypeClass)reader.ReadByte();
			DoubleHanded = reader.ReadByte();
			DamageVSSmall = new Dice(reader);
			DamageVsBig = new Dice(reader);
			Unk0 = reader.ReadByte();
			Unk1 = reader.ReadByte();
			Unk2 = reader.ReadByte();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="basedir"></param>
		/// <returns></returns>
		public static List<ItemType> Decode(string basedir)
		{
			List<ItemType> types = new List<ItemType>();

			string filename = basedir + "ITEMTYPE.DAT";
			using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
			{
				ushort count = reader.ReadUInt16();
				for (ushort i = 0; i < count; i++)
				{
					types.Add(new ItemType(i, reader));
				}

			}

			return types;
		}


		public override string ToString()
		{
			return string.Format("0x{0:X2}", ID);
		}

		#region Properties

		public ushort ID;

		public ItemTypeInventory Inventory;
		public ItemTypeHandsFlag Hand;
		public sbyte ACBonus;
		public ItemTypeClass Classes;
		public byte DoubleHanded;
		public Dice DamageVSSmall;
		public Dice DamageVsBig;

		public byte Unk0;
		public byte Unk1;
		public byte Unk2;

		#endregion
	}



	/// <summary>
	/// 
	/// </summary>
	[Flags]
	public enum ItemTypeInventory
	{
		Quiver = 0x001,
		Armour = 0x002,
		Bracers = 0x004,
		Backpack = 0x008,
		Boots = 0x010,
		Helmet = 0x020,
		Necklace = 0x040,
		Belt = 0x080,
		Ring = 0x100,
	}

	/// <summary>
	/// 
	/// </summary>
	[Flags]
	public enum ItemTypeClass
	{
		Fighter = 0x1,
		Mage = 0x2,
		Cleric = 0x4,
		Thief = 0x8,
		Paladin = 0x10,
		Ranger = 0x20
	}

	public enum ItemTypeHandsFlag
	{
		A = 0x001,
		Magical = 0x002,
		C = 0x004,
		D = 0x008,
		E = 0x010,
		F = 0x020,
		G = 0x040,
		Key = 0x080,
		I = 0x100,
	}
}
