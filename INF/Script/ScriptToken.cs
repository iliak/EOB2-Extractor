using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF
{
	/// <summary>
	/// 
	/// </summary>
	public class ScriptToken
	{
		public ScriptToken(Script script)
		{
			Address = script.Cursor;
		}
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public ushort Address;

		#endregion
	}
}
