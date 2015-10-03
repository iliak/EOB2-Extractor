using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class ChangeLevelToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ChangeLevelToken(Script script) : base(script)
		{
			Type = script.ReadByte();
			switch (Type)
			{
				// Inter level
				case 0xe5:
				{
					Level = script.ReadByte();
					Target = script.ReadPosition();
					Direction = script.ReadByte();
					Unknown0 = script.ReadByte();
				}
				break;

				// Intra level
				case 0x00:
				{
					Target = script.ReadPosition();
					Direction = script.ReadByte();
				}
				break;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			switch (Type)
			{
				// Inter level
				case 0xe5:	return string.Format("Change level to {0} at {1} facing to {2} (unknown 0x{3:X4})", Level, Target, Direction, Unknown0);
				case 0x00:	return string.Format("Change level at {0} facing to {1} (unknown 0x{2:X4})", Target, Direction, Unknown0);
				default:	return string.Format("Change level (unknow id 0x{0:X2}) (unknown 0x{1:X4})", Type, Unknown0);
			}
		}

		#region Properties

		byte Type;
		byte Level;
		Point Target;
		byte Direction;
		byte Unknown0;

		#endregion
	}
}
