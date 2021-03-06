﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	public class Monster
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns></returns>
		static public Monster FromScript(Script script)
		{
			Monster m = new Monster();
			m.Index = script.ReadByte();
			m.TimerID = script.ReadByte();
			m.Location = Location.FromScript(script);
			m.SubPosition = (BlockSubPosition)script.ReadByte();
			m.Direction = (Compass)script.ReadByte();
			m.Type = script.ReadByte();
			m.PictureIndex = script.ReadByte();
			m.Phase = script.ReadByte();
			m.Pause = script.ReadByte();
			m.Weapon = script.ReadAddr();
			m.PocketItem = script.ReadAddr();

			return m;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override String ToString()
		{
			return String.Format("ID {0} @ {1}|{2} [ID: {3}, Timer:{4}, type:{5}, picture:{6}, movestate:{7}, pause:{8}, weapon:0x{9:X4}, pocket:0x{10:X4}]",
			Index, Location, SubPosition, Direction,
			TimerID, Type, PictureIndex, Phase, Pause, Weapon, PocketItem);
		}

		#region Properties
		public byte Index;
		public byte TimerID;
		public Location Location;
		public BlockSubPosition SubPosition;
		public Compass Direction;
		public byte Type;
		public byte PictureIndex;
		public byte Phase;
		public byte Pause;
		public ushort Weapon;
		public ushort PocketItem;
		#endregion
	}
}
