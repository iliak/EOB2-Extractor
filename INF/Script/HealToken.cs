using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class HealToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public HealToken(Script script) : base(script)
		{
			//Type = script.ReadByte();
			//if (Type == 0x2e)
			//{
				//Amount = script.ReadShort();
			//}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Heal");
		}


		#region Properties

		//byte Type;
		//ushort Amount;
		//byte Target;

		#endregion
	}
}
