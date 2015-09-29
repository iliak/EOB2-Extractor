using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class UnknownToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public UnknownToken(Script script) : base(script)
		{
			OpCode = script.ReadByte();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("################### Unknown opcode 0x{0:X2}", OpCode);
		}


		#region Properties

		byte OpCode;

		#endregion
	}
}
