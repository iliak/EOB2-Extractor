using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class WaitToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public WaitToken(Script script) : base(script)
		{
			Ticks = script.ReadShort();

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Waiting {0}", Ticks);
		}


		#region Properties

		ushort Ticks;

		#endregion
	}
}
