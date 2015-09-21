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
	public class ConditionalInvalid : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalInvalid(byte value, Script script) : base(script)
		{
			Value = value;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Invalid condition opcode 0x{0:X2}, ", Value);
		}

		/// <summary>
		/// 
		/// </summary>
		byte Value;
	}
}
