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
			switch (Type)
			{
				// Party
				case 0xe8:
				{
					Unknown0 = script.ReadShort();
					Destination = Location.FromScript(script);
				}
				break;

				// Monster
				case 0xf3:
				{
					Source = Location.FromScript(script); 
					Destination = Location.FromScript(script);
				}
				break;

				// Item
				case 0xf5:
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
				default: return string.Format("Teleport unknow type 0x{0:X2}", Type);
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
