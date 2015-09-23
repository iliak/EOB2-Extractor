using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
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
		/// <param name="@base"></param>
		public Dice(byte rolls, byte sides, byte @base)
		{
			Rolls = rolls;
			Sides = sides;
			Base = @base;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="reader"></param>
		public Dice(BinaryReader reader)
		{
			Rolls = reader.ReadByte();
			Sides = reader.ReadByte();
			Base = reader.ReadByte();
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
