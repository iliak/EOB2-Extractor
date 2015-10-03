using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
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
			VersusSmall = script.ReadDice();
			VersusBig = script.ReadDice();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (Whom == 0xff)
				return string.Format("Damage Team with dice vsSmall: {1}, vsBig: {2}", Whom, VersusSmall, VersusBig);
			else
				return string.Format("Damage member {0} with dice vsSmall: {1}, vsBig: {2}", Whom, VersusSmall, VersusBig);
		}


		#region Properties

		/// <summary>
		/// 
		/// </summary>
		byte Whom;

		/// <summary>
		/// 
		/// </summary>
		Dice VersusSmall;

		/// <summary>
		/// 
		/// </summary>
		Dice VersusBig;

		#endregion
	}
}
