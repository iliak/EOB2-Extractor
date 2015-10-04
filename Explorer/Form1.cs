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

			WorkingDirectory = @"c:\eob2-uncps";
		}


		/// <summary>
		/// Log some text to the window
		/// </summary>
		/// <param name="msg"></param>
		public void Log(string msg)
		{
			LogBox.Text += msg + "\n";
		}


		/// <summary>
		/// 
		/// </summary>
		void LoadAssets()
		{
			// Items
			string iconsgfx = Path.Combine(WorkingDirectory, "ITEMICN.PNG");
			if (File.Exists(iconsgfx))
			{
				Image ItemsImage = Image.FromFile(iconsgfx);
				ItemsBitmap = new Bitmap(ItemsImage);
				ItemsImage.Dispose();
			}
			else
				Log(string.Format("Failed to find items image \"{0}\"", iconsgfx));

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
			{
				string filename = Path.Combine(WorkingDirectory, string.Format("LEVEL{0}", i));
				Mazes.Add(Maze.FromFile(filename));
			}
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

			if (ItemsBitmap!= null && item != null)
			{
				Rectangle rect = new Rectangle((item.Picture % 20) * 16, (item.Picture / 20) * 16, 16, 16);
				ItemPictureBox.Image =  ItemsBitmap.Clone(rect, ItemsBitmap.PixelFormat);
			}
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
		void RebuildMazeInterface()
		{
			Maze maze = GetCurrentMaze();
			if (maze == null)
				return;

			// Header
			RebuildMazeHeaderInterface();

			// Monster
			MonsterIdBox.Value = 0;
			MonsterIdBox.Maximum = Math.Max(maze.Monsters.Count - 1, 0);
			RebuildMonsterInterface();


			// Strings
			StringIdBox.Value = 0;
			StringIdBox.Maximum = Math.Max(maze.Messages.Count - 1, 0);

			// Triggers
			TriggerIdBox.Value = 0;
			TriggerIdBox.Maximum = Math.Max(maze.Triggers.Count - 1, 0);

			// Script
			ScriptTextBox.Text = maze.Script.Decompile();

			MazePictureBox.Refresh();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="header"></param>
		void RebuildMazeHeaderInterface()
		{

			MazeHeader header = GetCurrentMazeHeader();
			if (header == null)
			{
				MazeNameBox.Text = "";
				MazeVMPName.Text = "";
				MazePaletteName.Text = "";
				MazeSoundName.Text = "";

				MazeHeaderInformationTab.SelectedIndex = 0;
				MazeHeaderInformationTab.Enabled = false;
				return;
			}
			MazeHeaderInformationTab.Enabled = true;

			MazeNameBox.Text = header.MazeName;
			MazeVMPName.Text = header.VmpVcnName;
			MazePaletteName.Text = header.paletteName;
			MazeSoundName.Text = header.SoundName;

			RebuildDoorInfoInterface();
			RebuildMonsterGFXInterface();

			// Decorations
			DecorationInfoID.Value = 0;
			DecorationInfoID.Maximum = Math.Max(header.Decorations.Count - 1, 0);
			RebuildDecorationInterface();

		}


		/// <summary>
		/// 
		/// </summary>
		private void RebuildMonsterInterface()
		{
			Maze maze = GetCurrentMaze();
			if (maze == null)
				return;

			int id = (int)MonsterIdBox.Value;
			if (id >= maze.Monsters.Count)
			{
				MonsterMoveTime.Text = "";
				MonsterLocation.Text = "";
				MonsterDirection.Text = "";
				MonsterType.Text = "";
				MonsterPicture.Text = "";
				MonsterPhase.Text = "";
				MonsterPause.Text = "";
				MonsterPocket.Text = "";
				MonsterWeapon.Text = "";
				MonsterPocketItemTxt.Text = "";
				MonsterWeaponTxt.Text = "";
				return;
			}

			Monster m = maze.Monsters[id];

			MonsterMoveTime.Text = "0x" + m.TimeDelay.ToString("X2");
			MonsterLocation.Text = m.Location.ToString();
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


		/// <summary>
		/// 
		/// </summary>
		private void RebuildDoorInfoInterface()
		{
			MazeHeader header = GetCurrentMazeHeader();
			if (header == null)
			{
				ClearDoorInfoInterface();
				return;
			}

			DoorInfo info = header.Doors[(int)DoorInfoBox.Value];
			if (info == null)
			{
				ClearDoorInfoInterface();
				return;
			}

			DoorInfoIDBox.Text = info.Id.ToString();
			DoorInfoGfxBox.Text = info.GfxName;
			DoorInfoTypeBox.Text = info.Type.ToString();
			DoorInfoKnob.Checked = info.knob == 1;

			DoorInfoRect1.Text = string.Format("{0},{1} {2},{3}", info.DoorRectangle[0].X, info.DoorRectangle[0].Y, info.DoorRectangle[0].Width, info.DoorRectangle[0].Height);
			DoorInfoRect2.Text = string.Format("{0},{1} {2},{3}", info.DoorRectangle[1].X, info.DoorRectangle[1].Y, info.DoorRectangle[1].Width, info.DoorRectangle[1].Height);
			DoorInfoRect3.Text = string.Format("{0},{1} {2},{3}", info.DoorRectangle[2].X, info.DoorRectangle[2].Y, info.DoorRectangle[2].Width, info.DoorRectangle[2].Height);

			DoorInfoButton1.Text = string.Format("{0},{1}", info.ButtonPositions[0].X, info.ButtonPositions[0].Y);
			DoorInfoButton2.Text = string.Format("{0},{1}", info.ButtonPositions[1].X, info.ButtonPositions[1].Y);

			DoorInfoPos1.Text = string.Format("{0},{1} {2},{3}", info.ButtonRectangles[0].X, info.ButtonRectangles[0].Y, info.ButtonRectangles[0].Width, info.ButtonRectangles[0].Height);
			DoorInfoPos2.Text = string.Format("{0},{1} {2},{3}", info.ButtonRectangles[1].X, info.ButtonRectangles[1].Y, info.ButtonRectangles[1].Width, info.ButtonRectangles[1].Height);
		}

		/// <summary>
		/// 
		/// </summary>
		private void ClearDoorInfoInterface()
		{
			DoorInfoIDBox.Text = "";
			DoorInfoGfxBox.Text = "";
			DoorInfoTypeBox.Text = "";
			DoorInfoKnob.Checked = false;

			DoorInfoRect1.Text = "";
			DoorInfoRect2.Text = "";
			DoorInfoRect3.Text = "";

			DoorInfoButton1.Text = "";
			DoorInfoButton2.Text = "";

			DoorInfoPos1.Text = "";
			DoorInfoPos2.Text = "";
		}

		/// <summary>
		/// 
		/// </summary>
		private void RebuildMonsterGFXInterface()
		{
			MazeHeader header = GetCurrentMazeHeader();
			if (header == null)
			{
				ClearMonsterGFXInterface();
				return;
			}

			if (header.MonsterGFX[0] != null)
			{
				MonsterGFXProgramId1.Text = "0x" + header.MonsterGFX[0].LoadProg.ToString("X2");
				MonsterGFXFilename1.Text = header.MonsterGFX[0].Label;
				MonsterGFXUnknown1.Text = string.Format("0x{0:X2}, 0x{1:X2}", header.MonsterGFX[0].unk0, header.MonsterGFX[0].unk1);
				MonsterGFXUsed1.Checked = header.MonsterGFX[0].used;
			}
			else
			{
				MonsterGFXProgramId1.Text = "";
				MonsterGFXFilename1.Text = "";
				MonsterGFXUnknown1.Text = "";
				MonsterGFXUsed1.Checked = false;
			}
			if (header.MonsterGFX[1] != null)
			{
				MonsterGFXProgramId2.Text = "0x" + header.MonsterGFX[1].LoadProg.ToString("X2");
				MonsterGFXFilename2.Text = header.MonsterGFX[1].Label;
				MonsterGFXUnknown2.Text = string.Format("0x{0:X2}, 0x{1:X2}", header.MonsterGFX[1].unk0, header.MonsterGFX[1].unk1);
				MonsterGFXUsed2.Checked = header.MonsterGFX[1].used;
			}
			else
			{
				MonsterGFXProgramId2.Text = "";
				MonsterGFXFilename2.Text = "";
				MonsterGFXUnknown2.Text = "";
				MonsterGFXUsed2.Checked = false;
			}


		}

		/// <summary>
		/// 
		/// </summary>
		private void ClearMonsterGFXInterface()
		{
			MonsterGFXProgramId1.Text = "";
			MonsterGFXFilename1.Text = "";
			MonsterGFXUnknown1.Text = "";
			MonsterGFXUsed1.Checked = false;

			MonsterGFXProgramId2.Text = "";
			MonsterGFXFilename2.Text = "";
			MonsterGFXUnknown2.Text = "";
			MonsterGFXUsed2.Checked = false;

		}

		/// <summary>
		/// 
		/// </summary>
		private void RebuildDecorationInterface()
		{
			MazeHeader header = GetCurrentMazeHeader();
			if (header == null)
			{
				ClearDecorationInterface();
				return;
			}

			DecorationInfo di = header.Decorations[(int)DecorationInfoID.Value];
			if (di.Files != null)
			{
				DecorationInfoGFX.Text = di.Files.GFXName;
				DecorationInfoDEC.Text = di.Files.DECName;
			}
			else
			{
				DecorationInfoGFX.Text = "";
				DecorationInfoDEC.Text = "";
			}
			if (di.WallMappings != null)
			{
				DecorationInfoDecoID.Text = di.WallMappings.DecorationID.ToString();
				DecorationInfoWallType.Text = di.WallMappings.WallType.ToString();
				DecorationInfoEventMask.Text = di.WallMappings.EventMask.ToString();
				DecorationInfoFlags.Text = di.WallMappings.Flags.ToString();
			}
			else
			{
				DecorationInfoDecoID.Text = "";
				DecorationInfoWallType.Text = "";
				DecorationInfoEventMask.Text = "";
				DecorationInfoFlags.Text = "";
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void ClearDecorationInterface()
		{
			DecorationInfoGFX.Text = "";
			DecorationInfoDEC.Text = "";

			DecorationInfoDecoID.Text = "";
			DecorationInfoWallType.Text = "";
			DecorationInfoEventMask.Text = "";
			DecorationInfoFlags.Text = "";
		}

		/// <summary>
		/// Returns the selected maze
		/// </summary>
		Maze GetCurrentMaze()
		{
			if (Mazes.Count == 0)
				return null;

			return Mazes[MazeSelectBox.SelectedIndex];
		}


		/// <summary>
		/// Returns current Maze header
		/// </summary>
		/// <returns></returns>
		MazeHeader GetCurrentMazeHeader()
		{
			Maze maze = GetCurrentMaze();
			if (maze == null)
				return null;

			return maze.Headers[(int)MazeHeaderNumberBox.Value];
		}



		private void MazePictureBox_Paint(object sender, PaintEventArgs e)
		{
			Maze maze = GetCurrentMaze();
			if (maze == null)
				return;

			// Monsters 
			foreach (Monster monster in maze.Monsters)
			{
				if (monster.Location.IsInvalid)
					continue;

				e.Graphics.FillRectangle(Brushes.Red, new Rectangle(monster.Location.X * 16, monster.Location.Y * 16, 16, 16));
			}

			// Scripts
			foreach(Trigger trigger in maze.Triggers)
			{
				if (trigger.Location.IsInvalid)
					continue;

				e.Graphics.FillRectangle(Brushes.Green, new Rectangle(trigger.Location.X * 16, trigger.Location.Y * 16, 16, 16));
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
			RebuildMazeInterface();
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
			RebuildMonsterInterface();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChangeWorkingDirectoryBox_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fb = new FolderBrowserDialog();
			fb.SelectedPath = WorkingDirectoryBox.Text;
			fb.ShowDialog();

			WorkingDirectoryBox.Text = fb.SelectedPath;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WorkingDirectoryBox_TextChanged(object sender, EventArgs e)
		{
			WorkingDirectory = WorkingDirectoryBox.Text;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MazeHeaderNumberBox_ValueChanged(object sender, EventArgs e)
		{
			RebuildMazeHeaderInterface();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DoorInfoBox_ValueChanged(object sender, EventArgs e)
		{
			RebuildDoorInfoInterface();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DecorationInfoID_ValueChanged(object sender, EventArgs e)
		{
			RebuildDecorationInterface();
		}
		#endregion


		#region Properties


		/// <summary>
		/// 
		/// </summary>
		Bitmap ItemsBitmap;

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

		private void MazePictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			MazeMouseLocationBox.Text = string.Format("X = {0:D2}, Y = {1:D2}", e.Location.X / 16, e.Location.Y / 16);
		}
	}

}
