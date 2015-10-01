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

			Member = script.ReadByte();
			Target = script.ReadPosition();
			SubPos = script.ReadByte();

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Steal small item to member {0} and drop to {1}:{2}", Member, Target, SubPos);
		}


		#region Properties

		/// <summary>
		/// 
		/// </summary>
		byte Member;

		/// <summary>
		/// 
		/// </summary>
		Point Target;

		/// <summary>
		/// 
		/// </summary>
		byte SubPos;

		#endregion
	}
}
