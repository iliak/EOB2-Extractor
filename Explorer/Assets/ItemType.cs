using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

// http://eab.abime.net/showpost.php?p=931250&postcount=449
namespace Explorer
{
	/// <summary>
	/// 
	/// </summary>
	public class ItemType
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public ItemType(ushort id)
		{
			ID = id;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="reader"></param>
		public ItemType(ushort id, BinaryReader reader)
		{
			ID = id;

			Inventory = (ItemTypeInventory)reader.ReadUInt16();
			Flags = (ItemFlag)reader.ReadUInt16();
			ACBonus = reader.ReadSByte();
			Classes = (ItemTypeClass)reader.ReadByte();
			HandRestriction = (ItemHandRestiction)reader.ReadByte();
			DamageVSSmall = new Dice(reader);
			DamageVsBig = new Dice(reader);
			Unk0 = reader.ReadByte();
			Action = reader.ReadByte();
			Unk1 = reader.ReadByte();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="basedir"></param>
		/// <returns></returns>
		public static List<ItemType> Decode(string basedir)
		{
			List<ItemType> types = new List<ItemType>();

			string filename = Path.Combine(basedir , "ITEMTYPE.DAT");
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



		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetAction()
		{
			Dictionary<int, string> tab = new Dictionary<int, string>();
			tab[0x00] = "Nothing";
			tab[0x01] = "0x01";
			tab[0x02] = "Ammunition";
			tab[0x03] = "Use ammunition";
			tab[0x04] = "Amulet | Coin | Eye of Talon...";
			tab[0x05] = "Mage spell window";
			tab[0x06] = "Cleric spell window";
			tab[0x07] = "Food";
			tab[0x08] = "Bones";
			tab[0x09] = "Glass sphere | Magic dust | Scroll";
			tab[0x0A] = "Scroll";
			tab[0x0B] = "Parchment (something to read)";
			tab[0x0C] = "Stone item (Cross, Dagger, Gem...)";
			tab[0x0D] = "Key";
			tab[0x0E] = "Potion";
			tab[0x0F] = "Gem";
			tab[0x12] = "0x12";
			tab[0x13] = "Blow horn (N/S/W/E wind...)";
			tab[0x14] = "Amulet of Life or Death";
			tab[0x80] = "Range Party member";
			tab[0x81] = "Range Close";
			tab[0x82] = "Range Medium";
			tab[0x83] = "Range Long";
			tab[0x84] = "Lock picks";
			tab[0x8A] = "Amulet";
			tab[0x90] = "Crimson ring";
			tab[0x92] = "Wand";

			if (tab.ContainsKey(Action))
				return tab[Action];

			return "";
		}


		/// <summary>
		/// 
		/// </summary>
		public override string ToString()
		{
			return string.Format("0x{0:X2}", ID);
		}

		#region Properties


		/// <summary>
		/// 
		/// </summary>
		public ushort ID;

		/// <summary>
		/// At which position in inventory it is allowed to be put.
		/// </summary>
		public ItemTypeInventory Inventory;

		/// <summary>
		/// 
		/// </summary>
		public ItemFlag Flags;

		/// <summary>
		/// 
		/// </summary>
		public sbyte ACBonus;

		/// <summary>
		/// 
		/// </summary>
		public ItemTypeClass Classes;

		/// <summary>
		/// 
		/// </summary>
		public ItemHandRestiction HandRestriction;
		
		/// <summary>
		/// 
		/// </summary>
		public Dice DamageVSSmall;

		/// <summary>
		/// 
		/// </summary>
		public Dice DamageVsBig;

		/// <summary>
		/// 
		/// </summary>
		public byte Action;



		public byte Unk0;		// Never used
		public byte Unk1;		// Never used

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


	/// <summary>
	/// 
	/// </summary>
	public enum ItemHandRestiction
	{
		NoRestiction = 0,
		OneHand = 1,
		TwoHands = 2
	}


	/// <summary>
	/// 
	/// </summary>
	public enum ItemTypeAction
	{
		Food = 0x07,
		Key = 0x0d,
		Potion = 0x0e,

		RangeClose = 0x81,
		RangeMedium = 0x82,
	}
}
