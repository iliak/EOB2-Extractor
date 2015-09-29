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
	public class ConditionalMenuChoice : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalMenuChoice(Script script) : base(script)
		{
			Type = script.ReadByte();
			Value = script.ReadByte();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Menu choice Type: 0x{0:X2}, Value 0x{1:X2}", Type, Value);
		}

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public byte Type;

		/// <summary>
		/// 
		/// </summary>
		public byte Value;

		#endregion
	}
}
