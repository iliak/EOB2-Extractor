using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class ChangeWallToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ChangeWallToken(Script script) : base(script)
		{
			Type = script.ReadByte();
			switch (Type)
			{
				// All sides
				case 0xf7:
				{
					Target = script.ReadPosition();
					To = script.ReadByte();
					From = script.ReadByte();
				}
				break;
				// One side
				case 0xe9:
				{
					Target = script.ReadPosition();
					Side = script.ReadByte();
					To = script.ReadByte();
					From = script.ReadByte();
				}
				break;
				// Open door
				case 0xed:
				{
					Target = script.ReadPosition();
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
				// All sides
				case 0xf7:
				{
					return string.Format("Change wall at {0} all sides to {1} from {2}", Target, To, From);
				}
				// One side
				case 0xe9:
				{
					return string.Format("Change wall at {0} side {1} to {2} from {3}", Target, Side, To, From);
				}
				// Open door
				case 0xed:
				{
					return string.Format("Change wall open door at {0}", Target);
				}

				default:
				{
					return string.Format("Change wall unknow type 0x{0:X2}", Type);
				}
			}
		}


		#region Properties

		byte Type;
		Point Target;
		byte To;
		byte Side;
		byte From;


		#endregion
	}
}
