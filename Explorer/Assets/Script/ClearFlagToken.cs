using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class ClearFlagToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ClearFlagToken(Script script) : base(script)
		{
			Type = script.ReadByte();
			switch(Type)
			{
				// Maze
				case 0xef:
				// Global
				case 0xf0:
				{
					Flag = script.ReadByte();
				}
				break;

				// Monster
				case 0xf3:
				{
					MonsterID = script.ReadByte();
					Flag = script.ReadByte();
				}
				break;

				// Event
				case 0xe4:
				{

				}
				break;

				// Party function ???
				case 0xd1:
				{

				}
				break;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			switch (Type)
			{
				// Level
				case 0xef:
				{
					return string.Format("Clear level flag 0x{0:X2}", Flag);
				}
				// Global
				case 0xf0:
				{
					return string.Format("Clear global flag 0x{0:X2}", Flag);
				}
				// Monster
				case 0xf3:
				{
					return string.Format("Clear monster {0:X2} flag 0x{1:X2}", MonsterID, Flag);
				}
				// Event
				case 0xe4:
				{
					return string.Format("Clear flag event");
				}
				// Party function
				case 0xd1:
				{
					return string.Format("Clear flag Party_Function(FUNC_SETVAL, PARTY_SAVEREST, 0)");
				}

				default:
				{
					return string.Format("Clear unknow flag 0x{0:X2}", Type);
				}
			}
		}


		#region Properties

		byte Type;
		byte Flag;
		byte MonsterID;

		#endregion
	}
}
