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
			ItemFlag.Text = item != null ? "0x" + item.Flags.ToString("X2") : "";
			ItemCharges.Text = item != null ? item.Charges.ToString() : "";
			ItemPicture.Text = item != null ? "0x" + item.Picture.ToString("X2") : "";
			ItemTypeTxt.Text = item != null ? "0x" + item.Type.ToString("X2") : "";
			ItemSubPos.Text = item != null ? "0x" + item.SubPos.ToString("X2") : "";
			ItemLocation.Text = item != null ? item.Location.ToString() : "";
			ItemLevel.Text = item != null ? item.Level.ToString() : "";
			ItemValue.Text = item != null ? item.Value.ToString() : "";
			ItemIndex.Text = item != null ? "0x" + item.Index.ToString("X2") : "";

			if (item != null)
				ItemTypesListbox.SelectedIndex = item.Type;
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


			ItemTypeHandsBox.Text = type != null ? "0x" + ((ushort)type.Hand).ToString("X4") : "";
			checkBox3.Checked = type != null ? (type.Hand & ItemTypeHandsFlag.A) == ItemTypeHandsFlag.A : false;
			ItemTypeIsMagic.Checked = type != null ? (type.Hand & ItemTypeHandsFlag.Magical) == ItemTypeHandsFlag.Magical : false;
			checkBox4.Checked = type != null ? (type.Hand & ItemTypeHandsFlag.C) == ItemTypeHandsFlag.C : false;
			checkBox1.Checked = type != null ? (type.Hand & ItemTypeHandsFlag.D) == ItemTypeHandsFlag.D : false;
			checkBox2.Checked = type != null ? (type.Hand & ItemTypeHandsFlag.E) == ItemTypeHandsFlag.E : false;
			checkBox5.Checked = type != null ? (type.Hand & ItemTypeHandsFlag.F) == ItemTypeHandsFlag.F : false;
			checkBox6.Checked = type != null ? (type.Hand & ItemTypeHandsFlag.G) == ItemTypeHandsFlag.G : false;
			ItemTypeKey.Checked = type != null ? (type.Hand & ItemTypeHandsFlag.Key) == ItemTypeHandsFlag.Key : false;
			checkBox8.Checked = type != null ? (type.Hand & ItemTypeHandsFlag.I) == ItemTypeHandsFlag.I : false;

			ItemTypeACBox.Text = type != null ? type.ACBonus.ToString() : "";

			ItemTypeClassBox.Text = type != null ? "0x" + ((byte)type.Classes).ToString("X2") : "";
			ItemTypeFighter.Checked = type != null ? (type.Classes & ItemTypeClass.Fighter) == ItemTypeClass.Fighter : false;
			ItemTypeMage.Checked = type != null ? (type.Classes & ItemTypeClass.Mage) == ItemTypeClass.Mage : false;
			ItemTypeCleric.Checked = type != null ? (type.Classes & ItemTypeClass.Cleric) == ItemTypeClass.Cleric : false;
			ItemTypePaladin.Checked = type != null ? (type.Classes & ItemTypeClass.Paladin) == ItemTypeClass.Paladin : false;
			ItemTypeThief.Checked = type != null ? (type.Classes & ItemTypeClass.Thief) == ItemTypeClass.Thief : false;
			ItemTypeRanger.Checked = type != null ? (type.Classes & ItemTypeClass.Ranger) == ItemTypeClass.Ranger : false;

			ItemTypeDoubleHandedBox.Text = type != null ? "0x" + type.DoubleHanded.ToString("X2") : "";
			ItemTypeDVSBox.Text = type != null ? type.DamageVSSmall.ToString() : "";
			ItemTypeDVBBox.Text = type != null ? type.DamageVsBig.ToString() : "";
			ItemTypeUnknown0Box.Text = type != null ? "0x" + type.Unk0.ToString("X2") : "";
			ItemTypeUnknown1Box.Text = type != null ? "0x" + type.Unk1.ToString("X2") : "";
			ItemTypeUnknown2Box.Text = type != null ? "0x" + type.Unk2.ToString("X2") : "";
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
		#endregion

	}

}
