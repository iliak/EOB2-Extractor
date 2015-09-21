using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class DamageToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public DamageToken(Script script) : base(script)
		{
			Whom = script.ReadByte();
			Dice = script.ReadDice();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Damage {0} with dice {1}", Whom, Dice);
		}


		#region Properties

		byte Whom;
		Dice Dice;

		#endregion
	}
}
