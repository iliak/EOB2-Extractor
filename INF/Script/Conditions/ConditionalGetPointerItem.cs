using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	/// <summary>
	/// 
	/// </summary>
	public class ConditionalGetPointerItem : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalGetPointerItem(Script script) : base(script)
		{
			Type = script.ReadByte();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (Type == 0xf5)
				return string.Format("Pointer item unknown, ");
			else if (Type == 0xf6)
				return string.Format("Pointer item ID, ");
			else if (Type == 0xe1)
				return string.Format("Pointer item type ID, ");

			return "Get pointer item unknown !";
		}

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public byte Type;

		#endregion
	}
}
