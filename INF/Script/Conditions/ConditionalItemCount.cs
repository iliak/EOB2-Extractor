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
	public class ConditionalItemCount : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalItemCount(Script script) : base(script)
		{
			Type = script.ReadByte();
			Target = script.ReadPosition();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Count items of type 0x{0:X2} at {1}, ", Type, Target);
		}

		/// <summary>
		/// 
		/// </summary>
		Point Target;

		byte Type;
	}
}
