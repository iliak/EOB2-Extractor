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
	public class ConditionalImmediateShort : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalImmediateShort(Script script) : base(script)
		{
			Value = script.ReadAddr();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("0x{0:X4} ", Value);
		}

		/// <summary>
		/// 
		/// </summary>
		ushort Value;
	}
}
