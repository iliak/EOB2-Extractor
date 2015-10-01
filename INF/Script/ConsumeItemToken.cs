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
			if (Type != 0xff)
				Target = Location.FromScript(script);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			switch (Type)
			{
				case 0xff: return string.Format("Consume item from mouse pointer");
				case 0xfe: return string.Format("Consume item at position {0}", Target);
				default: return string.Format("Consume item at position {0} of type {1}", Target, Type);
			}
		}

		#region Properties

		byte Type;
		Location Target;

		#endregion
	}
}
