using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class ScreenMenuToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ScreenMenuToken(Script script) : base(script)
		{
			Id = script.ReadByte();

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Screen menu 0x{0:X2}", Id);
		}


		#region Properties

		byte Id;

		#endregion
	}
}
