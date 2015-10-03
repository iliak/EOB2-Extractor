using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class GiveXPToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public GiveXPToken(Script script) : base(script)
		{
			Amount = script.ReadAddr();
			Unknown0 = script.ReadShort();
			Unknown1 = script.ReadShort();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Give {0} XP to the team (0x{1:X4}, 0x{2:X4})", Amount, Unknown0, Unknown1);
		}


		#region Properties

		ushort Amount;

		ushort Unknown0;
		ushort Unknown1;

		#endregion
	}
}
