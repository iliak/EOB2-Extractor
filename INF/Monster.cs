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
			return String.Format("({0}:{1} {2}|{3}) [delay:{4}\ttype:{5}\tpicture:{6}\tmovestate:{7}\tpause:{8}\tweapon:{9}\tpocket:{10}]",
			Position.X, Position.X, SubPosition, Direction,
			TimeDelay, Type, PictureIndex, MoveState, Pause, Weapon, PocketItem);
		}

		#region Properties
		public byte Index;
		public byte TimeDelay;
		public Point Position;
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
