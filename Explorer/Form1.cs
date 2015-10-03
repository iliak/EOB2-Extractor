using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// http://www.gamewinners.com/walkthrough/eye_of_the_beholder_2/
// http://gigi.nullneuron.net/comp/eob2.php
// http://www.gamefaqs.com/pc/564792-eye-of-the-beholder-ii-the-legend-of-darkmoon/faqs/8566
//
//
namespace Explorer
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Form1 : Form
	{

		/// <summary>
		/// 
		/// </summary>
		public Form1()
		{
			InitializeComponent();

			WorkingDirectory = @"c:\eob2-uncps\";
		}



		/// <summary>
		/// 
		/// </summary>
		void LoadAssets()
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
			SelectTextIDBox.Items.Clear();
			for (int i = 0; i < TextData.Count; i++)
				SelectTextIDBox.Items.Add("0x" + i.ToString("X2"));

			// Mazes
			for (byte i = 1; i <= 16; i++)
				Mazes.Add(Maze.FromFile(string.Format("{0}LEVEL{1}.INF_uncps", WorkingDirectory, i)));
			MazeSelectBox.SelectedIndex = 0;
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
			TextIdBox.Text = TextData.Count > id ? "0x" + id.ToString("X2") : "";
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


		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		void RebuildMazeInterface(int id)
		{
			if (Mazes.Count == 0)
				return;

			Maze maze = Mazes[id];
			MonsterIdBox.Value = 0;
			MonsterIdBox.Maximum = maze.Monsters.Count - 1;
			StringIdBox.Value = 0;
			StringIdBox.Maximum = maze.Messages.Count - 1;
			TriggerIdBox.Value = 0;
			TriggerIdBox.Maximum = maze.Triggers.Count - 1;


			ScriptTextBox.Text = maze.Script.Decompile();
		}


		#region Events

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DecodeButton_Click(object sender, EventArgs e)
		{
			LoadAssets();
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
			RebuildTextInterface(SelectTextIDBox.SelectedIndex);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExportTextButton_Click(object sender, EventArgs e)
		{
			ExportTextData();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SortItemListboxCheck_CheckedChanged(object sender, EventArgs e)
		{
			ItemListbox.Sorted = checkBox1.Checked;
		}




		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MazeSelectBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			RebuildMazeInterface(MazeSelectBox.SelectedIndex);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StringIdBox_ValueChanged(object sender, EventArgs e)
		{
			if (Mazes.Count == 0)
				return;

			Maze maze = Mazes[MazeSelectBox.SelectedIndex];
			StringMessageLabel.Text = maze.Messages[(int)StringIdBox.Value];
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TriggerIdBox_ValueChanged(object sender, EventArgs e)
		{
			if (Mazes.Count == 0)
				return;

			Maze maze = Mazes[MazeSelectBox.SelectedIndex];
			Trigger trigger = maze.Triggers[(int)TriggerIdBox.Value];
			TriggerCoordinateBox.Text = trigger.Location.ToString();
			TriggerOffsetBox.Text = "0x" + trigger.Offset.ToString("X4");
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MonsterIdBox_ValueChanged(object sender, EventArgs e)
		{
			if (Mazes.Count == 0)
				return;

			Maze maze = Mazes[MazeSelectBox.SelectedIndex];
			Monster m = maze.Monsters[(int)MonsterIdBox.Value];

			MonsterMoveTime.Text = "0x" + m.TimeDelay.ToString("X2");
			MonsterLocation.Text = m.Position.ToString();
			MonsterDirection.Text = "0x" + m.Direction.ToString("X2");
			MonsterType.Text = "0x" + m.Type.ToString("X2");
			MonsterPicture.Text = "0x" + m.PictureIndex.ToString("X2");
			MonsterPhase.Text = "0x" + m.Phase.ToString("X2");
			MonsterPause.Text = "0x" + m.Pause.ToString("X2");
			MonsterPocket.Text = "0x" + m.PocketItem.ToString("X4");
			MonsterWeapon.Text = "0x" + m.Weapon.ToString("X4");


			MonsterPocketItemTxt.Text = m.PocketItem != 0 ? Items[m.PocketItem].UnidentifiedName : "";
			MonsterWeaponTxt.Text = m.Weapon != 0 ? Items[m.Weapon].UnidentifiedName : "";
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
		List<Maze> Mazes = new List<Maze>();


		/// <summary>
		/// 
		/// </summary>
		List<Item> Items = new List<Item>();


		/// <summary>
		/// 
		/// </summary>
		List<ItemType> ItemTypes = new List<ItemType>();


		/// <summary>
		/// 
		/// </summary>
		List<string> TextData = new List<string>();


		#endregion

	}

}
