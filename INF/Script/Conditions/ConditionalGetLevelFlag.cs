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
	public class ConditionalGetLevelFlag : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalGetLevelFlag(Script script) : base(script)
		{
			Flag = script.ReadByte();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Level flag 0x{0:X2}, ", Flag);
		}

		/// <summary>
		/// 
		/// </summary>
		byte Flag;
	}
}
