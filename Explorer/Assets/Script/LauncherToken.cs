using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class LauncherToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public LauncherToken(Script script) : base(script)
		{
			Type = script.ReadByte();
			ItemId = script.ReadShort();
			Target = script.ReadPosition();
			Direction = script.ReadByte();
			SubPos = script.ReadByte();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			switch (Type)
			{
				case 0xdf:	return string.Format("Launching spell 0x{0:X4} from {1} facing {2} at subpos {3}", ItemId, Target, Direction, SubPos);
				case 0xec:	return string.Format("Launching item 0x{0:X4} from {1} facing {2} at subpos {3}", ItemId, Target, Direction, SubPos);
				default:	return string.Format("Launching unknow (id: 0x{0:X4}) from {1} facing {2} at subpos {3}", ItemId, Target, Direction, SubPos);
			}
		}

		#region Properties

		byte Type;
		ushort ItemId;
		Point Target;
		byte Direction;
		byte SubPos;

		#endregion
	}

	//
	// Spells :
	// 0x0200 : Fireball (?)
	//
}
