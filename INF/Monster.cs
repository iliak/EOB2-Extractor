using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace INF
{
	public class Monster
	{

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override String ToString()
		{
			return String.Format("({0} {1}|{2}) [delay:{3}\ttype:{4}\tpicture:{5}\tmovestate:{6}\tpause:{7}\tweapon:0x{8:X4}\tpocket:0x{9:X4}]",
			Position, SubPosition, Direction,
			TimeDelay, Type, PictureIndex, MoveState, Pause, Weapon, PocketItem);
		}

		#region Properties
		public byte Index;
		public byte TimeDelay;
		public Location Position;
		public byte SubPosition;
		public byte Direction;
		public byte Type;
		public byte PictureIndex;
		public byte MoveState;
		public byte Pause;
		public ushort Weapon;
		public ushort PocketItem;
		#endregion
	}
}
