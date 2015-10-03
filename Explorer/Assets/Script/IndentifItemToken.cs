using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class IdentifyItemToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public IdentifyItemToken(Script script) : base(script)
		{
			Target = script.ReadPosition();

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Identify item at {0}", Target);
		}


		#region Properties

		Point Target;

		#endregion
	}
}
