using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
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
			switch (Type)
			{
				// Party
				case 0xe8:
				{
					Unknown0 = script.ReadShort();
					Destination = Location.FromScript(script);
				}
				break;

				//
				case 0xe1:
				{
					Destination = Location.FromScript(script);
				}
				break;

				// Monster
				case 0xf3:
				{
					script.ReadByte();
					script.ReadByte();
					script.ReadByte();
					script.ReadByte();
					//Source = Location.FromScript(script);
					//Destination = Location.FromScript(script);
				}
				break;

				// Item
				case 0xf5:
				{
					Source = Location.FromScript(script);
					Destination = Location.FromScript(script);
					script.ReadShort();
				}
				break;

				default:
				{
					Source = Location.FromScript(script);
					Destination = Location.FromScript(script);
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
				case 0xe8: return string.Format("Teleport team to {0}", Destination);
				case 0xf3: return string.Format("Teleport monster from {0} to {1}", Source, Destination);
				case 0xf5: return string.Format("Teleport item from {0} to {1}", Source, Destination);
				case 0xe1: return string.Format("Teleport unknown to {0}", Destination);
				default: return string.Format("Teleport unknow type 0x{0:X2} from {1} to {2}", Type, Source, Destination);
			}
		}


		#region Properties

		Location Destination;
		Location Source;
		byte Type;
		ushort Unknown0;

		#endregion
	}
}
