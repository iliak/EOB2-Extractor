using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class ConsumeItemToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConsumeItemToken(Script script) : base(script)
		{
			Type = script.ReadByte();
			switch (Type)
			{
				// Mouse pointer
				case 0xff:
				{
					Location = Type;
				}
				break;
				// at position
				case 0xfe:
				{
					Location = Type;
					Target = script.ReadPosition();
				}
				break;
				// At position by type
				case 0x0:
				{
					Location = 0;
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
				case 0xff:	return string.Format("Consume item from mouse pointer");
				case 0xfe:	return string.Format("Consume item at position {0}", Target);
				case 0x0:	return string.Format("Consume item at position {0} of type {1}", Target, Type);
				default:	return string.Format("Consume item unknown type 0x{0:X2}", Type);
			}
		}

		#region Properties

		byte Type;
		byte Location;
		Point Target;

		#endregion
	}
}
