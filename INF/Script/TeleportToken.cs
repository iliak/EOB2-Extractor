using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class TeleportToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public TeleportToken(Script script) : base(script)
		{
			Type = script.ReadByte();
			Source = script.ReadPosition();
			Target = script.ReadPosition();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{

			switch (Type)
			{
				case 0xe8:	return string.Format("Teleport team to {0}", Target);
				case 0xf3:	return string.Format("Teleport monster at {0} to {1}", Source, Target);
				case 0xf5:	return string.Format("Teleport item at {0} to {1}", Source, Target);
				default:	return string.Format("Teleport unknow type 0x{0:X2}", Type);
			}
		}


		#region Properties

		Point Target;
		Point Source;

		byte Type;

		#endregion
	}
}
