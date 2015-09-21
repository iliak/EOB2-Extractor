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
	public class ConditionalGetPartyPosition : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalGetPartyPosition(Script script) : base(script)
		{
			Target = script.ReadPosition();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Party position {0} ", Target);
		}

		/// <summary>
		/// 
		/// </summary>
		Point Target;
	}
}
