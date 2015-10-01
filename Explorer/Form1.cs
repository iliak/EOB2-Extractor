using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Explorer
{
	public partial class Form1 : Form
	{

		/// <summary>
		/// 
		/// </summary>
		public Form1()
		{
			InitializeComponent();

			Items = new List<Item>();
			ItemTypes = new List<ItemType>();

			WorkingDirectory = @"c:\eob2-uncps\";
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		void RebuildItemInterface(Item item)
		{
			ItemIdentifiedName.Text = item != null ? item.IdentifiedName : "";
			ItemUnidentifiedName.Text = item != null ? item.UnidentifiedName : "";
			ItemFlagBox.Text = item != null ? "0x" + ((byte)item.Flags).ToString("X2") : "";
			ItemCharges.Text = item != null ? item.Charges.ToString() : "";
			ItemPicture.Text = item != null ? "0x" + item.Picture.ToString("X2") : "";
			ItemTypeTxt.Text = item != null ? "0x" + item.ItemTypeID.ToString("X2") : "";
			ItemSubPos.Text = item != null ? "0x" + item.SubPos.ToString("X2") : "";
			ItemLocation.Text = item != null ? item.Location.ToString() : "";
			ItemLevel.Text = item != null ? item.Level.ToString() : "";
			ItemValue.Text = item != null ? item.Value.ToString() : "";
			ItemIndex.Text = item != null ? "0x" + item.Index.ToString("X4") : "";

			if (item != null)
				ItemTypesListbox.SelectedIndex = item.ItemTypeID;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		void RebuildItemTypeInterface(ItemType type)
		{
			ItemTypeInventoryBox.Text = type != null ? "0x" + ((ushort)type.Inventory).ToString("X4") : "";
			ItemTypeQuiver.Checked = type != null ? (type.Inventory & ItemTypeInventory.Quiver) == ItemTypeInventory.Quiver : false;
			ItemTypeArmour.Checked = type != null ? (type.Inventory & ItemTypeInventory.Armour) == ItemTypeInventory.Armour : false;
			ItemTypeBracers.Checked = type != null ? (type.Inventory & ItemTypeInventory.Bracers) == ItemTypeInventory.Bracers : false;
			ItemTypeBackpack.Checked = type != null ? (type.Inventory & ItemTypeInventory.Backpack) == ItemTypeInventory.Backpack : false;
			ItemTypeBoots.Checked = type != null ? (type.Inventory & ItemTypeInventory.Boots) == ItemTypeInventory.Boots : false;
			ItemTypeHelmet.Checked = type != null ? (type.Inventory & ItemTypeInventory.Helmet) == ItemTypeInventory.Helmet : false;
			ItemTypeNecklace.Checked = type != null ? (type.Inventory & ItemTypeInventory.Necklace) == ItemTypeInventory.Necklace : false;
			ItemTypeBelt.Checked = type != null ? (type.Inventory & ItemTypeInventory.Belt) == ItemTypeInventory.Belt : false;
			ItemTypeRing.Checked = type != null ? (type.Inventory & ItemTypeInventory.Ring) == ItemTypeInventory.Ring : false;


			ItemTypeHandsBox.Text = type != null ? "0x" + ((ushort)type.Flags).ToString("X4") : "";
			ItemTypeFlag_01.Checked = type != null ? (type.Flags & ItemFlag._01) == ItemFlag._01 : false;
			ItemTypeFlag_02.Checked = type != null ? (type.Flags & ItemFlag.ArmorBonus) == ItemFlag.ArmorBonus : false;
			ItemTypeFlag_04.Checked = type != null ? (type.Flags & ItemFlag._04) == ItemFlag._04 : false;
			ItemTypeDrainHP.Checked = type != null ? (type.Flags & ItemFlag.DrainHP) == ItemFlag.DrainHP : false;
			ItemTypeFlag_10.Checked = type != null ? (type.Flags & ItemFlag.SpeedBonus) == ItemFlag.SpeedBonus : false;
			ItemTypeCursed.Checked = type != null ? (type.Flags & ItemFlag.Cursed) == ItemFlag.Cursed : false;
			ItemTypeIdentified.Checked = type != null ? (type.Flags & ItemFlag.Identified) == ItemFlag.Identified : false;
			ItemTypeMagic.Checked = type != null ? (type.Flags & ItemFlag.Magic) == ItemFlag.Magic : false;
			ItemTypeFlag_100.Checked = type != null ? (type.Flags & ItemFlag.Ring) == ItemFlag.Ring : false;


			ItemTypeACBox.Text = type != null ? type.ACBonus.ToString() : "";

			ItemTypeClassBox.Text = type != null ? "0x" + ((byte)type.Classes).ToString("X2") : "";
			ItemTypeFighter.Checked = type != null ? (type.Classes & ItemTypeClass.Fighter) == ItemTypeClass.Fighter : false;
			ItemTypeMage.Checked = type != null ? (type.Classes & ItemTypeClass.Mage) == ItemTypeClass.Mage : false;
			ItemTypeCleric.Checked = type != null ? (type.Classes & ItemTypeClass.Cleric) == ItemTypeClass.Cleric : false;
			ItemTypePaladin.Checked = type != null ? (type.Classes & ItemTypeClass.Paladin) == ItemTypeClass.Paladin : false;
			ItemTypeThief.Checked = type != null ? (type.Classes & ItemTypeClass.Thief) == ItemTypeClass.Thief : false;
			ItemTypeRanger.Checked = type != null ? (type.Classes & ItemTypeClass.Ranger) == ItemTypeClass.Ranger : false;

			ItemTypeRestrictionBox.Text = type != null ? "0x" + ((byte)type.HandRestriction).ToString("X2") : "";
			ItemTypeNoRestriction.Checked = type != null ? type.HandRestriction == ItemHandRestiction.NoRestiction : false;
			ItemTypeOneHand.Checked = type != null ? type.HandRestriction == ItemHandRestiction.OneHand : false;
			ItemTypeTwoHands.Checked = type != null ? type.HandRestriction == ItemHandRestiction.TwoHands : false;


			ItemTypeDVSBox.Text = type != null ? type.DamageVSSmall.ToString() : "";
			ItemTypeDVBBox.Text = type != null ? type.DamageVsBig.ToString() : "";
			ItemTypeActionBox.Text = type != null ? "0x" + type.Action.ToString("X2") : "";

			ItemTypeUnknown0Box.Text = type != null ? "0x" + type.Unk0.ToString("X2") : "";
			ItemTypeUnknown1Box.Text = type != null ? "0x" + type.Unk1.ToString("X2") : "";
			ItemTypeActionDescription.Text = type.GetAction();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		void RebuildTextInterface(int id)
		{
			MessageIdBox.Text = TextData.Count > id ? id.ToString() : "";
			TextMsgBox.Text = TextData.Count > id ? TextData[id] : "";
		}


		/// <summary>
		/// 
		/// </summary>
		void ExportTextData()
		{
			using (TextWriter writer = File.CreateText(WorkingDirectory + "textdata.txt"))
			{
				for (int i = 0; i < TextData.Count; i++)
				{
					writer.WriteLine("0x{0:X2}:	'{1}'", i + 1, TextData[i]);
				}
			}
		}

		#region Events

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DecodeButton_Click(object sender, EventArgs e)
		{
			// Items
			Items = Item.Decode(WorkingDirectory);
			ItemListbox.Items.Clear();
			foreach (Item item in Items)
				ItemListbox.Items.Add(item);

			// Item types
			ItemTypes = ItemType.Decode(WorkingDirectory);
			ItemTypesListbox.Items.Clear();
			foreach (ItemType type in ItemTypes)
				ItemTypesListbox.Items.Add(type);

			// Text data
			TextData = Explorer.Text.Decode(WorkingDirectory);
			TextIDBox.Items.Clear();
			for (int i = 0; i < TextData.Count; i++)
				TextIDBox.Items.Add("0x" + i.ToString("X4"));
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemListbox_SelectedIndexChanged(object sender, EventArgs e)
		{
			RebuildItemInterface(ItemListbox.SelectedItem as Item);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemTypesListbox_SelectedIndexChanged(object sender, EventArgs e)
		{
			RebuildItemTypeInterface(ItemTypesListbox.SelectedItem as ItemType);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextIDBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			RebuildTextInterface(TextIDBox.SelectedIndex);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			ExportTextData();
		}

		#endregion


		#region Properties

		/// <summary>
		/// Base working directory
		/// </summary>
		string WorkingDirectory;



		/// <summary>
		/// 
		/// </summary>
		List<Item> Items;


		/// <summary>
		/// 
		/// </summary>
		List<ItemType> ItemTypes;


		/// <summary>
		/// 
		/// </summary>
		List<string> TextData;


		#endregion

	}

}
