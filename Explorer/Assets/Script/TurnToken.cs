using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class TurnToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public TurnToken(Script script) : base(script)
		{
			Type = script.ReadByte();
			Amount = script.ReadByte();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			switch (Type)
			{
				case 0xf1:	return string.Format("Turning party {0} time(s)", Amount);
				case 0xf5:	return string.Format("Turning item {0} time(s)", Amount);
				default:	return string.Format("Turning unknow type (0x{0:2}) {1} time(s)", Type, Amount);
			}
		}


		#region Properties

		byte Type;
		byte Amount;

		#endregion
	}
}
