using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class GiveXPToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public GiveXPToken(Script script) : base(script)
		{
			Type = script.ReadByte();
			if (Type == 0x2e)
			{
				Amount = script.ReadShort();
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (Type == 0x2e)
				return string.Format("Give {0} XP to the team", Amount);
			else
				return string.Format("Give {0} XP to 0x{0:X2}", Amount, Type);
		}


		#region Properties

		byte Type;
		ushort Amount;

		#endregion
	}
}
