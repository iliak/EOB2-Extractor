using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	/// <summary>
	/// 
	/// </summary>
	public class ConditionalContainAlignment : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalContainAlignment(Script script) : base(script)
		{
			Type = script.ReadByte();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Party contains alignment 0x{0:X2}", Type);
		}

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public byte Type;

		#endregion
	}
}
