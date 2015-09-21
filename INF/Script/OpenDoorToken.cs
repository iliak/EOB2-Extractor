using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class OpenDoorToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public OpenDoorToken(Script script) : base(script)
		{
			Target = script.ReadPosition();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Open door at {0}:{1}", Target.X, Target.Y);
		}


		#region Properties

		Point Target;

		#endregion
	}
}
