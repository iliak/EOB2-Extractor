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
	public class Trigger
	{

		/// <summary>
		/// 
		/// </summary>
		public Point Position;

		/// <summary>
		/// 
		/// </summary>
		public ushort Flags;

		/// <summary>
		/// 
		/// </summary>
		public ushort Offset;


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("{0} => 0x{1:X4}", Position, Offset);
		}
	}
}
