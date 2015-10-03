using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	class SpecialWindowToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public SpecialWindowToken(Script script) : base(script)
		{
			Unknown = script.ReadShort();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Special Window (0x{0:X4})...", Unknown);
		}

		#region Properties

		ushort Unknown;

		#endregion
	}
}
