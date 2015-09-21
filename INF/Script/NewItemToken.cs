using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class NewItemToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public NewItemToken(Script script) : base(script)
		{
			ItemID = script.ReadByte();
			Target = script.ReadPosition();
			SubPos = script.ReadByte();

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("New item 0x{0:X4} at {1}:{2}", ItemID, Target, SubPos);
		}


		#region Properties

		ushort ItemID;
		Point Target;
		byte SubPos;

		#endregion
	}
}
