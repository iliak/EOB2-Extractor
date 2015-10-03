using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	/// <summary>
	/// 
	/// </summary>
	public class ConditionalContainRace : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalContainRace(Script script) : base(script)
		{
			Id = script.ReadByte();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Need race 0x{0:X2} ", Id);
		}

		/// <summary>
		/// 
		/// </summary>
		byte Id;
	}
}
