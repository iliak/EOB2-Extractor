using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
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
			Flag = script.ReadByte();
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
					return string.Format("Clear flag 0x{0:X2} to level", Flag);
				}
				// Global
				case 0xf0:
				{
					return string.Format("Clear flag 0x{0:X2} to global", Flag);
				}
				// Monster
				case 0xf3:
				{
					return string.Format("Clear flag 0x{0:X2} to monster!", Flag);
				}

				default:
				{
					return string.Format("Clear flag unknow type 0x{0:X2}", Type);
				}
			}
		}


		#region Properties

		byte Type;
		byte Flag;

		#endregion
	}
}
