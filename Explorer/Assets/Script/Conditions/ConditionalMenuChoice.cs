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
	public class ConditionalMenuChoice : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalMenuChoice(Script script) : base(script)
		{
			Type = script.ReadByte();		// Always 0xd2
			Value = script.ReadAddr();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Push(Menu choice), Push(0x{0:X4})", Value);
		}

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public byte Type;

		/// <summary>
		/// 
		/// </summary>
		public ushort Value;

		#endregion
	}
}
