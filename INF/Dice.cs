using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF
{
	public class Dice
	{
		/// <summary>
		/// 
		/// </summary>
		public Dice()
		{
			this.Rolls = 0;
			this.Sides = 0;
			this.Base = 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rolls"></param>
		/// <param name="sides"></param>
		/// <param name="@bases"></param>
		public Dice(byte rolls, byte sides, byte @base)
		{
			this.Rolls = rolls;
			this.Sides = sides;
			this.Base = @base;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("({0}d{1})+{2}", Rolls, Sides, Base);
		}


		/// <summary>
		/// 
		/// </summary>
		public byte Rolls;

		/// <summary>
		/// 
		/// </summary>
		public byte Sides;

		/// <summary>
		/// 
		/// </summary>
		public byte Base;
	}
}
