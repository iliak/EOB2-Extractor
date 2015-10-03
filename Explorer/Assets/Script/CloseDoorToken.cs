using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class CloseDoorToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public CloseDoorToken(Script script) : base(script)
		{
			Target = Location.FromScript(script);

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Close door at {0}", Target);
		}


		#region Properties

		Location Target;

		#endregion
	}
}
