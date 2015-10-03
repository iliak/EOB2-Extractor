using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class EncounterToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public EncounterToken(Script script) : base(script)
		{
			Id = script.ReadByte();

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Encounter 0x{0:X2}", Id);
		}


		#region Properties

		byte Id;

		#endregion
	}
}
