using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class StealSmallItemToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public StealSmallItemToken(Script script) : base(script)
		{
			Target = script.ReadPosition();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Steal small item at {0}", Target);
		}


		#region Properties

		Point Target;

		#endregion
	}
}
