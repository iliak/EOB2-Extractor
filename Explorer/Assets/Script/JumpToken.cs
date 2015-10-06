using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class JumpToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public JumpToken(Script script) : base(script)
		{
			Target = script.ReadAddr();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Jump to 0x{0:X4}", Target);
		}

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		ushort Target;

		#endregion
	}
}
