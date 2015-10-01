using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class SetWallToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public SetWallToken(Script script) : base(script)
		{
			Type = script.ReadByte();
			switch (Type)
			{
				// All sides
				case 0xf7:
				{
					Target = Location.FromScript(script);
					To = script.ReadByte();
				}
				break;
				// One side
				case 0xe9:
				{
					Target = Location.FromScript(script);
					Side = script.ReadByte();
					To = script.ReadByte();
				}
				break;
				// Change party direction
				case 0xed:
				{
					direction = script.ReadByte();
				}
				break;
				default:
				{

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
				case 0xf7:	return string.Format("Set wall at {0} all sides to {1}", Target, To);
				case 0xe9:	return string.Format("Set wall at {0} sides {1} to {2}", Target, Side, To); 
				case 0xed:	return string.Format("Set wall change party direction to {0}", direction); 
				default:	return string.Format("Set wall unknow type 0x{0:X2}", Type); 
			}
		}

		#region Properties

		Location Target;
		byte To;
		byte Side;
		byte direction;

		byte Type;

		#endregion
	}
}
