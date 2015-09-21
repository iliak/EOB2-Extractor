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
	public class ConditionalOperator : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalOperator(Script script, byte value) : base(script)
		{
			Operator = value; 
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			switch(Operator)
			{
				case 0xff: return string.Format(" == "); 
				case 0xfe: return string.Format(" != "); 
				case 0xfd: return string.Format(" < ");
				case 0xfc: return string.Format(" <= "); 
				case 0xfb: return string.Format(" > ");
				case 0xfa: return string.Format(" >= ");
				case 0xf9: return string.Format(" AND "); 
				case 0xf8: return string.Format(" OR "); 
				default: return "Unknown operator";
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public byte Operator;
	}
}
