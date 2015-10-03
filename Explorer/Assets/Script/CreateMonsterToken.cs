using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class CreateMonsterToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public CreateMonsterToken(Script script) : base(script)
		{
			Monster = Monster.FromScript(script);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Create monster {0}", Monster);
		}


		#region Properties

		/// <summary>
		/// 
		/// </summary>
		Monster Monster;

		#endregion
	}
}
