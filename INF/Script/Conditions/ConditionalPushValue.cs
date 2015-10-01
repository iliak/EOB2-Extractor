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
	public class ConditionalPushValue : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalPushValue(byte value, Script script) : base(script)
		{
			Value = value;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Push value 0x{0:X2}, ", Value);
		}

		/// <summary>
		/// 
		/// </summary>
		byte Value;
	}
}
