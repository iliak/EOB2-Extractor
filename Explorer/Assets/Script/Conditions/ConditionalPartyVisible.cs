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
	public class ConditionalPartyVisible : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalPartyVisible(Script script) : base(script)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "Party visibility";
		}

		#region Properties

		#endregion
	}
}
