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
					Target = Location.FromScript(script); // script.ReadPosition();
					To = script.ReadByte();
					From = script.ReadByte();
				}
				break;
				// One side
				case 0xe9:
				{
					Target = Location.FromScript(script); // script.ReadPosition();
					Side = script.ReadByte();
					To = script.ReadByte();
					From = script.ReadByte();
				}
				break;
				// Open door
				case 0xea:
				{
					Target = Location.FromScript(script); // script.ReadPosition();
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
					return string.Format("Change wall at {0} all sides from {1} to {2}", Target, From, To);
				}
				// One side
				case 0xe9:
				{
					return string.Format("Change wall at {0} side {1} from {2} to {3}", Target, Side, From, To);
				}
				// Open door
				case 0xea:
				{
					return string.Format("Change wall to open door at {0}", Target);
				}

				default:
				{
					return string.Format("Change wall unknow type 0x{0:X2}", Type);
				}
			}
		}


		#region Properties

		byte Type;
		Location Target;
		byte To;
		byte Side;
		byte From;


		#endregion
	}
}
