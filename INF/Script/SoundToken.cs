using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class SoundToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public SoundToken(Script script) : base(script)
		{
			Id = script.ReadByte();
			Target = script.ReadPosition();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Play sound {0} at {1}", Id, Target);
		}


		#region Properties

		/// <summary>
		/// 
		/// </summary>
		Point Target;

		/// <summary>
		/// 
		/// </summary>
		byte Id;

		#endregion
	}
}
