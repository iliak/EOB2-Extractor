using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	/// <summary>
	/// 
	/// </summary>
	public class ConditionalDice : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalDice(Script script) : base(script)
		{
			Dice = script.ReadDice();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Roll dice {0} ", Dice);
		}

		/// <summary>
		/// 
		/// </summary>
		Dice Dice;
	}
}
