using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class EndToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public EndToken(Script script) : base(script)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("End");
		}


		#region Properties


		#endregion
	}
}
